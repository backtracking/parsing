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
using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {

/**
 * This <code>JSOM</code> type represents an enumeration constant declaration.
 * 
 * @author Dieter Habelitz
 */
public class AST2EnumConstant : AST2JSOM , EnumConstant {

    // The enum constant's optional annotations.
    private List<Annotation> mAnnotations;
    // The enum constant's optional arguments.
    private List<Expression> mArguments;
    // An optional class scope.
    private AST2ClassTopLevelScope mClassScope;
    
    private bool mHasAnnotations = false;

    // The children from the enum constant's root tree.
    private AST2JSOMTree mArgumentsTree;
    private AST2JSOMTree mClassScopeTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2EnumConstant(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ENUM_CONSTANT, pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.IDENT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(0);
        if (child.ChildCount > 0) {
            mHasAnnotations = true;
        }
        if (pTree.ChildCount > 1) {
            // The next child may be an argument list or a class scope.
            child = (AST2JSOMTree)pTree.GetChild(1);
            if (child.Type == JavaTreeParser.ARGUMENT_LIST) {
                if (child.ChildCount > 0) {
                    mArgumentsTree = child;
                }
                if (pTree.ChildCount == 3) {
                    // Switch forward to the class scope.
                    child = (AST2JSOMTree)pTree.GetChild(2);
                } else {
                    child = null;
                }
            }
            if (child != null) {
                mClassScopeTree = child;
            }
        }
    }
    
    /**
     * Returns a list of the annotations that belong to the enumeration constant
     * declaration.
     * <p>
     * Calling this method equals an <code>getAnnotations(null)</code> call.
     * 
     * @see #getAnnotations(List)
     *
     * @return  A list of the annotations that belong to the enumeration 
     *          constant declaration. If no annotation has been stated <code>
     *          null</code> will be returned.
     */
    public List<Annotation> getAnnotations() {
        
        return getAnnotations(null);
    }

    /**
     * Returns a list of the annotations that belong to the enumeration constant
     * declaration.
     * 
     * @param  pList  If this argument isn't <code>null</code> the annotations
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *
     * @return  A list of the annotations that belong to the enumeration 
     *          constant declaration. If no annotation has been stated <code>
     *          null</code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    public List<Annotation> getAnnotations(List<Annotation> pList) {
        
        if (!mHasAnnotations) {
            return null; // There're no annotations.
        }
        if (mAnnotations == null) {
            resolveAnnotations();
        }
        List<Annotation> result = pList;
        if (result == null) {
            result = new List<Annotation>(mAnnotations.Count);
        }
        result.AddRange(mAnnotations);
        
        return result;
    }

    /**
     * Returns a list of the enumeration constant declaration's arguments.
     * <p>
     * Calling this method equals an <code>getArguments(null)</code> call.
     * 
     * @see #getArguments(List)
     *  
     * @return  An list of the enumeration constant declaration's arguments. If
     *          no argument has been stated <code>null</code> will be returned.
     */
    public List<Expression> getArguments() {
        
        return getArguments(null);
    }
    
    /**
     * Returns a list of the enumeration constant declaration's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  An list of the enumeration constant declaration's arguments. If 
     *          no argument has been stated <code>null</code> will be returned, 
     *          even if the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<Expression> getArguments(List<Expression> pList) {
        
        if (mArgumentsTree == null) {
            return null; // There're no arguments.
        }
        if (mArguments == null) {
            resolveArguments();
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mArguments.Count);
        }
        result.AddRange(mArguments);
        
        return result;
    }
    
    /**
     * Returns the <i>character in line</i> position where the enumeration 
     * constant identifier starts.
     * 
     * @return  The <i>character in line</i> position where the enumeration 
     *          constant identifier starts.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the identifier of the enumeration constant.
     * 
     * @return  The identifier of the enumeration constant.
     */
    public String getIdentifier() {
        
        return getTreeNode().Text;
    }
    
    /**
     * Returns the line number of the enumeration constant identifier.
     * 
     * @return  The line number of the enumeration constant identifier.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * An enumeration constant can be followed by it's own class body that 
     * corresponds to a class bodies of an anonymous class declaration. However,
     * to keep things simple this method returns a fully featured <code>
     * ClassTopLevelScope</code> object.
     * 
     * @return  The class top level scope following the enumeration constant or
     *          <code>null</code> if no appropriate class body has been stated.
     */
    public ClassTopLevelScope getClassTopLevelScope() {
        
        if (mClassScopeTree == null) {
            return null; // There're no class scope.
        }
        if (mClassScope == null) {
            mClassScope = new AST2ClassTopLevelScope(
                    mClassScopeTree, this, getTokenRewriteStream());
        }
        
        return mClassScope;
    }

    
    /**
     * Tells if the enumeration constant has at least one annotation.
     * 
     * @return  <code>true</code> if the enumeration constant has at least one 
     *          annotation.
     */
    public bool hasAnnotation() {
        
        return mHasAnnotations; 
    }
    
    /**
     * Tells if the enumeration constant has at least one argument.
     * 
     * @return  <code>true</code> if the enumeration constant has at least one 
     *          argument.
     */
    public bool hasArgument() {
        
        return mArgumentsTree != null;
    }
    
    /**
     * Tells if the enumeration constant is followed by a class declaration 
     * body.
     * 
     * @see #getClassTopLevelScope()
     * 
     * @return  <code>true</code> if the enumeration constant is followed by a 
     *          class declaration body.
     */
    public bool hasClassTopLevelScope() {
        
        return mClassScopeTree != null;
    }

    /**
     * Resolves the optional annotations.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * annotation.
     */
    private void resolveAnnotations() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(0);
        int size = tree.ChildCount;
        mAnnotations = new List<Annotation>(size);
        for (int offset = 0; offset < size; offset++) {
            mAnnotations.Add(new AST2Annotation((AST2JSOMTree)
                            tree.GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Resolves the optional arguments.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * argument.
     */
    private void resolveArguments() {
        
        int size = mArgumentsTree.ChildCount;
        mArguments = new List<Expression>(size);
        for (int offset = 0; offset < size; offset++) {
            mArguments.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                    mArgumentsTree.GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new constant identifier.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {

        AST2JSOMTree root = (AST2JSOMTree)getTreeNode();
        String oldId = root.Text;
        root.Token.Text = pNewIdentifier;
        
        return oldId;
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
            if (mHasAnnotations) {
                if (mAnnotations == null) {
                    resolveAnnotations();
                }
                foreach (Annotation annotation in mAnnotations) {
                    annotation.traverseAll(pAction);
                }
            }
            if (mArgumentsTree != null) {
                if (mArguments == null) {
                    resolveArguments();
                }
                foreach (Expression expression in mArguments) {
                    expression.traverseAll(pAction);
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