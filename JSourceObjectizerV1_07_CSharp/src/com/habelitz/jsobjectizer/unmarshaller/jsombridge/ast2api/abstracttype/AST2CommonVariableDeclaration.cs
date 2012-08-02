/*
 * BSD license
 * 
 * Copyright (c) 2007-2011 by HABELITZ Software Developments
 *
 * All rights reserved.
 * 
 * http://www.habelitz.com
 *
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 *
 *  1. Redistributions of source code must retain the above copyright
 *     notice, this list of conditions and the following disclaimer.
 *  2. Redistributions in binary form must reproduce the above copyright
 *     notice, this list of conditions and the following disclaimer in the
 *     documentation and/or other materials provided with the distribution.
 *  3. The name of the author may not be used to endorse or promote products
 *     derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY HABELITZ SOFTWARE DEVELOPMENTS ('HSD') ``AS IS'' 
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
 * ARE DISCLAIMED. IN NO EVENT SHALL 'HSD' BE LIABLE FOR ANY DIRECT, INDIRECT, 
 * INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT 
 * LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
 * OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
 * LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
 * NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
 * EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */


using System;
using System.Collections.Generic;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using CommonVariableDeclaration = com.habelitz.jsobjectizer.jsom.api.abstracttype.CommonVariableDeclaration;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using CommonJSOMMessages = com.habelitz.jsobjectizer.resource.resbundle.CommonJSOMMessages;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype {

/**
 * This <code>JSOM</code> type represents a variable declaration.
 * 
 * @author Dieter Habelitz
 */
public class AST2CommonVariableDeclaration : 
    AST2JSOM,CommonVariableDeclaration {

    /*
     * The variable's optional modifier list. 
     */
    private ModifierList mModifierList;
    /*
     * The variable's type. 
     */
    private com.habelitz.jsobjectizer.jsom.api.Type mType;
    /*
     * The variable's type declarators.
     */
    private List<AST2VariableDeclarator> mVariableDeclarators;
    
    // The variable declaration's children.
    private bool mHasModifier = true;
    
    /**
     * Constructor.
     * <p>
     * If classes derived from this class should be recognized by another JSOM
     * type than <code>JSOMType.VARIABLE_DECLARATION</code> they must call
     * this constructor via the explicit super constructor call.
     * 
     * @param pTree  The tree node representing a variable declaration.
     * @param pJSOMType  The JSOM type of the new instance.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2CommonVariableDeclaration(
            AST2JSOMTree pTree, JSOMType pJSOMType, 
            TokenRewriteStream pTokenRewriteStream) : base(pTree, pJSOMType, pTokenRewriteStream) {
        
        if (pTree.Type != JavaTreeParser.VAR_DECLARATION) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (pTree.GetChild(0).ChildCount == 0) {
            mHasModifier = false;
        }
    }
    
    /**
     * Returns the <i>character in line</i> position where the first variable
     * identifier starts.
     * 
     * @return  The <i>character in line</i> position where the first variable
     * identifier starts.
     */
    public int getCharPositionInLine() {
        
        if (mVariableDeclarators == null) {
            // Force resolving the variable declarators.
            resolveVariableDeclarators();
        }
        return mVariableDeclarators[0].getCharPositionInLine();
    }
    
    /**
     * Returns the line number of the first variable identifier.
     * 
     * @return  The line number of the first variable identifier.
     */
    public int getLineNumber() {
        
        if (mVariableDeclarators == null) {
            // Force resolving the variable declarators.
            resolveVariableDeclarators();
        }
        return mVariableDeclarators[0].getLineNumber();
    }

    /**
     * Returns the variable's modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the variable
     *          declaration has no modifiers.
     *          
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    public ModifierList getModifiers() {
        
        if (!mHasModifier) {
            return null;
        }
        
        return getModifierList();
    }

    /**
     * Returns the variable's modifiers including annotations.
     * 
     * @return  A list of type modifiers which is empty if the variable 
     *          declaration has no modifiers.
     */
    public ModifierList getModifierList() {
 
        if (mModifierList == null) {
            mModifierList = new AST2ModifierList((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mModifierList;
    }
    
    /**
     * Returns the variable's type.
     * 
     * @return  The variable's type.
     */
    public Type getType() {
        
        if (mType == null) {
            mType = new AST2Type((AST2JSOMTree)
                    getTreeNode().GetChild(1), getTokenRewriteStream());
        }
        
        return mType;
    }
    
    /**
     * Returns a list of variable declarators (i.e. the identifier(s) including 
     * optional initializer(s).
     * 
     * Calling this method equals an <code>getVariableDeclarators(null)</code>
     * call.
     * 
     * @see #getVariableDeclarators(List)
     * 
     * @return  A list of variable declarators.
     */
    public List<VariableDeclarator> getVariableDeclarators() {
        
        return getVariableDeclarators(null);
    }

    /**
     * Returns a list of variable declarators (i.e. the identifier(s) including 
     * optional initializer(s).
     * 
     * @param  pList  If this argument isn't <code>null</code> the variable 
     *                declarators will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of variable declarators.
     */
    public List<VariableDeclarator> getVariableDeclarators(List<VariableDeclarator> pList) {
        
        if (mVariableDeclarators == null) {
            resolveVariableDeclarators();
        }
        List<VariableDeclarator> result = pList;
        if (result == null) {
            result = new List<VariableDeclarator>(mVariableDeclarators.Count);
        }
        result.AddRange(mVariableDeclarators);
        
        return result;
    }

    /**
     * Tells if the variable declaration has at least one modifier or 
     * annotation.
     * 
     * @return  <code>true</code> if the variable declaration has at least one
     *          modifier or annotation.
     */
    public bool hasModifier() {
        
        return mHasModifier;
    }

    /**
     * Resolves the variable declarators that belong to <code>this</code>.
     * <p>
     * If the variable declarators have already been resolved this method does
     * nothing.
     */
    private void resolveVariableDeclarators() {

        if (mVariableDeclarators == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(2);
            int size = tree.ChildCount;
            mVariableDeclarators = new List<AST2VariableDeclarator>(size);
            for (int offset = 0; offset < size; offset++) {
                mVariableDeclarators.Add(new AST2VariableDeclarator((AST2JSOMTree)
                        tree.GetChild(offset), getTokenRewriteStream()));
            }
        }
    }
    
    /**
     * Removes a certain variable declarator from <code>this</code>.
     * 
     * @param pVariableDeclarator  The variable declarator that should be
     *                             removed. The object passed to this method 
     *                             remains unchanged.
     * 
     * @  if the variable declarator passed to 
     *                                     this method doesn't belong to <code>
     *                                     this</code>.
     * 
     * __TEST__                                         
     */
    public void removeVariableDeclarator(VariableDeclarator pVariableDeclarator) {
        
        // If the stated argument belongs to >this< 'mBlockElements' can't be 
        // null, i.e. it must have been already resolved.
        
        int offset = -1;
        if (mVariableDeclarators != null) {
            offset = mVariableDeclarators.IndexOf((AST2VariableDeclarator)pVariableDeclarator);
        }
        if (offset == -1) {
            // The stated variable declarator doesn't belong to 'this'.
            throw new JSourceObjectizerException(
                    CommonJSOMMessages.getVariableDeclaratorDoesNotExistMessage(
                            pVariableDeclarator.getIdentifier().getIdentifier()
                            + " (" + pVariableDeclarator.getLineNumber() + ':'
                            + pVariableDeclarator.getCharPositionInLine() + ")", 
                            getLineNumber() + ":" + getCharPositionInLine()));
        }
        // If still here a matching variable declarator has been found.
        int numberOfdeclarators = mVariableDeclarators.Count;
        AST2VariableDeclarator declaratorToRemove = mVariableDeclarators[offset];
        if (offset + 1 < numberOfdeclarators) {
            // There's another declarator at right.
            removeTreeNode((AST2JSOMBase)declaratorToRemove, null, (AST2JSOMBase)mVariableDeclarators[offset + 1]);
        } else if (numberOfdeclarators > 1) {
            // The current declarator is the last but not the only
            // one, i.e. there's a declarator on the left side.
            removeTreeNode((AST2JSOMBase)declaratorToRemove, (AST2JSOMBase)mVariableDeclarators[offset - 1], null);
        } else {
            // The current declarator is the only one.
            removeTreeNode((AST2JSOMBase)declaratorToRemove);
        }
        if (numberOfdeclarators > 1) {
            mVariableDeclarators.RemoveAt(offset);
        } else {
            // There're no more variable declarators now.
            mVariableDeclarators = null;
        }
    }

    /**
     * If <code>pAction.isMemberTraversionEnabled() == true</code> this method
     * traverses all <code>JSOM</code> members that belong to <code>this</code> 
     * by calling the <code>traverseAll(...)</code> method on these members with
     * <code>pAction</code> as argument.
     * <p>
     * Calling the methods <code>pAction.performAction(this)</code> and <code>
     * pAction.actionPerformed(this)</code> is up to classes that implement all 
     * the abstract methods not implemented by this class.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public virtual void traverseAll(TraverseAction pAction) {
        
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            getModifierList().traverseAll(pAction);
            getType().traverseAll(pAction);
            if (mVariableDeclarators == null) {
                resolveVariableDeclarators();
            }
            foreach (VariableDeclarator declarator in mVariableDeclarators) {
                declarator.traverseAll(pAction);
            }
        }
    }
}
}