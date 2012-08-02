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
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {

/**
 * This <code>JSOM</code> type represents the top level scope of an enumeration 
 * declaration.
 * 
 * @author Dieter Habelitz
 */
public class AST2EnumTopLevelScope : AST2JSOM , EnumTopLevelScope {

    // The enumeration constants from this scope.
    private List<AST2EnumConstant> mEnumConstants;
    // An optional class scope.
    private AST2ClassTopLevelScope mClassScope;

    private bool mHasEnumConstants = true;
    private bool mHasClassScope = false;

    // The owner of 'this'.
    private AST2EnumDeclaration mOwner;

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an enumeration top level scope.
     * @param pOwner  The enumeration declaration the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2EnumTopLevelScope(
            AST2JSOMTree pTree, AST2EnumDeclaration pOwner, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ENUM_TOP_LEVEL_SCOPE, pTokenRewriteStream)
    {
        
        mOwner = pOwner;
        if (pTree.Type != JavaTreeParser.ENUM_TOP_LEVEL_SCOPE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        int numberOfConsts = pTree.ChildCount;
        // Check if the last child is a class top level scope.
        if (   numberOfConsts > 0
            &&    pTree.GetChild(numberOfConsts - 1).Type
               == JavaTreeParser.CLASS_TOP_LEVEL_SCOPE) {
            mHasClassScope = true;
            numberOfConsts--;
        }
        if (numberOfConsts == 0) {
            mHasEnumConstants = false;
        }
    }

    /**
     * Returns the <i>character in line</i> position of the opening curly 
     * bracket.
     * 
     * @return  The <i>character in line</i> position of the opening curly 
     *          bracket.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }

    /**
     * The enumeration constant declaration part can be followed by the contents
     * of a class body.
     * 
     * @return  The class top level scope following the enumeration constant 
     *          declaration part or <code>null</code> of no appropriate class 
     *          body like content has been stated.
     */
    public ClassTopLevelScope getClassTopLevelScope() {
        
        if (!mHasClassScope) {
            return null; // There're no class scope.
        }
        if (mClassScope == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            mClassScope = new AST2ClassTopLevelScope((AST2JSOMTree)
                    tree.GetChild(tree.ChildCount - 1), this,
                    getTokenRewriteStream());
        }
        
        return mClassScope;
    }
    
    /**
     * Returns a list of the enumeration constants.
     * <p>
     * Calling this method equals an <code>getEnumConstants(null)</code> call.
     * 
     * @see #getEnumConstants(List)
     *  
     * @return  A list of the enumeration constants. If no enumeration constant
     *          has been declared <code>null</code> will be returned.
     */
    public List<EnumConstant> getEnumConstants() {
        
        return getEnumConstants(null);
    }
    
    /**
     * Returns a list of the enumeration constants.
     * 
     * @param  pList  If this argument isn't <code>null</code> the enumeration
     *                constants will be added to this list and this list object
     *                will be returned. Otherwise a new list will be created for 
     *                the result.
     *  
     * @return  A list of the enumeration constants. If no enumeration constant
     *          has been declared <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<EnumConstant> getEnumConstants(List<EnumConstant> pList) {
        
        if (!mHasEnumConstants) {
            return null;
        }
        if (mEnumConstants == null) {
            resolveEnumConstants();
        }
        List<EnumConstant> result = pList;
        if (result == null) {
            result = new List<EnumConstant>(mEnumConstants.Count);
        }
        result.AddRange(mEnumConstants);
        
        return result;
    }

    /**
     * Returns the line number of the opening curly bracket.
     * 
     * @return  The line number of the opening curly bracket.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the enumeration declaration this top level scope belongs to.
     * 
     * @return  The enumeration declaration this top level scope belongs to.
     */
    public EnumDeclaration getOwner() {
        
        return mOwner;
    }
    
    /**
     * Tells if the enumeration constant declaration part is followed by any
     * class top level scope content.
     * <p>
     * Note that there's also a class top level scope if there aren't any class
     * top level scope content but if a semicolon has been stated within the
     * enumeration declaration's top level scope (behind the last constant or
     * at the start of the top level scope if it doesn't contain a constant).
     * 
     * @see #getClassTopLevelScope()
     * 
     * @return  <code>true</code> if the enumeration constant declaration part
     *          is followed by any class top level scope content.
     */
    public bool hasClassTopLevelScope() {
        
        return mHasClassScope;
    }
    
    /**
     * Tells if <code>this</code> has at least one enumeration constant 
     * declaration.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one 
     *          enumeration constant declaration.
     */
    public bool hasEnumConstant() {
        
        return mHasEnumConstants;
    }

    /**
     * Resolves the enum constants.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one enum
     * constant.
     */
    private void resolveEnumConstants() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
        int size = tree.ChildCount;
        if (mHasClassScope) {
            size--;
        }
        mEnumConstants = new List<AST2EnumConstant>(size);
        for (int offset = 0; offset < size; offset++) {
            mEnumConstants.Add(new AST2EnumConstant((AST2JSOMTree)
                    tree.GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Calls the methods <code>pAction.performAction(...)</code> and <code>
     * pAction.actionPerformed(...)</code> with <code>this</code> as argument.
     * <P>
     * Furthermore, if <code>pAction.isMemberTraversionEnabled() == true</code>
     * all <code>JSOM</code> members that belong to <code>this
     * </code> will be traversed by calling the <code>traverseAll(...)</code> 
     * method on these members with <code>pAction</code> as argument. This will
     * be done after the <code>pAction.performAction(...)</code> call but before
     * the <code>pAction.actionPerformed(...)</code> call.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            if (mHasEnumConstants) {
                if (mEnumConstants == null) {
                    resolveEnumConstants();
                }
                foreach (EnumConstant constant in mEnumConstants) {
                    constant.traverseAll(pAction);
                }
            }
            ClassTopLevelScope scope = getClassTopLevelScope();
            if (scope != null) {
                scope.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}