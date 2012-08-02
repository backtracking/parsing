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
using JSourceObjectizerInternalException = com.habelitz.jsobjectizer.JSourceObjectizerInternalException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using UnmarshallerMessages = com.habelitz.jsobjectizer.resource.resbundle.UnmarshallerMessages;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>PrimaryExpression</code> type represents a method invocation.
 * 
 * @author Dieter Habelitz
 */
public class AST2MethodCall : AST2PrimaryExpression , MethodCall {

    // A primary expression stating the method invocation.
    private AST2PrimaryExpression mMethodInvocation;
    // The optional generic type arguments.
    private List<AST2GenericTypeArgument> mGenericTypeArguments;
    // A list of argument expressions
    private List<Expression> mArguments;
    private AST2JSOMTree mArgumentListTree;
    // The identifier of the called method (resolved on demand).
    private AST2JSOMTree mIdentifierTree;
    // The children from an explicit super/this constructor call. 
    private bool mHasGenericTypeArgumentList = false;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2MethodCall(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.METHOD_CALL, pTokenRewriteStream)
    {
        
        
        if (pTree.Type != JavaTreeParser.METHOD_CALL) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        // Check if there is a generic type argument list.
        ITree child = pTree.GetChild(1);
        if (child.Type == JavaTreeParser.GENERIC_TYPE_ARG_LIST) {
            if (child.ChildCount > 0) {
                mHasGenericTypeArgumentList = true;
            }
        }
    }

    /**
     * Returns a list of the method call's arguments.
     * <p>
     * Calling this method equals an <code>getArguments(null)</code> call.
     * 
     * @see #getArguments(List)
     *  
     * @return  A list of the method call's arguments. If there are no arguments
     *          <code>null</code> will be returned. 
     */
    public List<Expression> getArguments() {
        
        return getArguments(null);
    }

    /**
     * Returns a list of the method call's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the method call's arguments. If there are no
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    public List<Expression> getArguments(List<Expression> pList) {
        
        if (mArgumentListTree == null) {
            // 'mArguments' may remain 'null' for an empty argument list but
            // the tree node will be set.
            resolveArguments();
        }
        if (mArguments == null) {
            return null; // There're no arguments.
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mArguments.Count);
        }
        result.AddRange(mArguments);
        
        return result;
    }

    /**
     * Returns the <i>character in line</i> position where the method's 
     * identifier starts.
     * 
     * @return  The <i>character in line</i> position where the method's
     *          identifier starts.
     */
    public int getCharPositionInLine() {
        
        if (mIdentifierTree == null) {
            // Force resolving the method's identifier.
            resolveIdentifier();
        }
        
        return mIdentifierTree.CharPositionInLine;
    }

    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the method invocation.
     * <p>
     * Example: for a method call like <code>
     * '&lt;T&gt; anyMethodCall(anyArgs)'</code> this method would return a list 
     * that contains just one generic type parameter that represents the type 
     * <code>T</code> stated by <code>&lt;T&gt;</code>.
     * 
     * @see #getGenericTypeArguments(List)
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned. 
     */
    public List<GenericTypeArgument> getGenericTypeArguments() {
        
        return getGenericTypeArguments(null);
    }
    
    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the method invocation.
     * <p>
     * Example: for a method call like <code>
     * '&lt;T&gt; anyMethodCall(anyArgs)'</code> this method would return a list 
     * that contains just one generic type parameter that represents the type 
     * <code>T</code> stated by <code>&lt;T&gt;</code>.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    public List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList) {
        
        if (!mHasGenericTypeArgumentList) {
            return null; // There're no generic type arguments.
        }
        if (mGenericTypeArguments == null) {
            mGenericTypeArguments =
                AST2GenericTypeArgument.resolveGenericTypeArgumentList((AST2JSOMTree)
                        getTreeNode().GetChild(1), getTokenRewriteStream());
        }
        List<GenericTypeArgument> result = pList;
        if (result == null) {
            result = new List<GenericTypeArgument>(
                    mGenericTypeArguments.Count);
        }
        result.AddRange(mGenericTypeArguments);
        
        return result;
    }
    
    /**
     * Returns the method's identifier.
     * 
     * @see #getMethodInvocation()
     * 
     * @return  The method's identifier.  
     */
    public String getIdentifier() {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }
        
        return mIdentifierTree.Text;
    }
    
    /**
     * Returns the line number of the method identifier.
     * 
     * @return  The line number of the method identifier.
     */
    public int getLineNumber() {
        
        if (mIdentifierTree == null) {
            // Force resolving the method's identifier.
            resolveIdentifier();
        }
        
        return mIdentifierTree.Line;
    }

    /**
     * Returns the method invocation.
     * <p>
     * Such an invocation is a more or less complicated primary expression 
     * ending with the methods identifier. A formal example could look like: 
     * <pre>
     *     anyPrimaryExpression.anyMethodCall(...).anotherMethodCall(...)
     * </pre>. 
     * Calling this method for the example above the primary expression
     * representing <code>
     * 'anyPrimaryExpression.anyMethodCall(...).anotherMethodCall'</code> would 
     * be returned.
     * <p>
     * The most trivial primary expression would be the method's identifier, of
     * course.
     * 
     * @see #getIdentifier()
     * 
     * @return  The method invocation.
     */
    public PrimaryExpression getMethodInvocation() {
        
        if (mMethodInvocation == null) {
            mMethodInvocation = AST2Expression.resolvePrimaryExpression((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mMethodInvocation;
    }

    /**
     * Tells if the method call has at least one argument.
     * 
     * @return  <code>true</code> if the method call has at least one argument.
     */
    public bool hasArgument() {
        
        if (mArgumentListTree == null) {
            // 'mArguments' may remain 'null' for an empty argument list but
            // the tree node will be set.
            resolveArguments();
        }
        
        return mArguments != null;
    }
    
    /**
     * Tells if <code>this</code> has at least one generic type argument.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type argument.
     */
    public bool hasGenericTypeArgument() {
        
        return mHasGenericTypeArgumentList;
    }

    /**
     * Removes all arguments.
     * <p>
     * If there're no arguments passed to the method call an implementation of
     * this method is expected to do nothing than return <code>null</code>.
     * 
     * @return  The removed arguments or <code>null</code> if there're no
     *          arguments.
     */
    public List<Expression> removeArguments() {
        
        if (mArgumentListTree == null) {
            // 'mArguments' may remain 'null' for an empty argument list but
            // the tree node will be set.
            resolveArguments();
        }
        if (mArguments == null) {
            return null;
        }
        List<Expression> arguments = mArguments;
        mArguments = null;
        // Update the token stream.
        // For that remove all tokens between the opening and closing brackets
        // but excluding the brackets, of course.
        TokenRewriteStream stream = getTokenRewriteStream();
        stream.Delete(mArgumentListTree.TokenStartIndex + 1, 
                mArgumentListTree.TokenStopIndex - 1);
        
        return arguments;
    }
    
    /**
     * Resolves the arguments.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * argument.
     */
    private void resolveArguments() {

        mArgumentListTree = (AST2JSOMTree)getTreeNode().GetChild(1);
        if (mHasGenericTypeArgumentList) {
            mArgumentListTree = (AST2JSOMTree)getTreeNode().GetChild(2);
        }
        int numberOfArgs = mArgumentListTree.ChildCount;
        if (numberOfArgs > 0) {
            mArguments = new List<Expression>(numberOfArgs);
            for (int offset = 0; offset < numberOfArgs; offset++) {
                mArguments.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                        mArgumentListTree.GetChild(offset), 
                        getTokenRewriteStream()));
            }
        }
    }
    
    /**
     * Resolves the identifier of the called method.
     */
    private void resolveIdentifier() {
        
        if (mIdentifierTree == null) {
            if (mMethodInvocation == null) {
                // Force resolving the method invocation.
                getMethodInvocation();
            }
            if (mMethodInvocation.isExpressionType(ExpressionType.IDENTIFIER)) {
                mIdentifierTree = (AST2JSOMTree)mMethodInvocation.getTreeNode();
                return;
            } else if (mMethodInvocation.isExpressionType(
                    ExpressionType.DOT_EXPRESSION)) {
                AST2PrimaryExpression rightExpression = (AST2PrimaryExpression)
                    ((AST2DotExpression) mMethodInvocation).getRightExpression();
                if (rightExpression.isExpressionType(ExpressionType.IDENTIFIER)) {
                    mIdentifierTree = (AST2JSOMTree)rightExpression.getTreeNode();
                    return;
                }
            }
            // If still here something is wrong or at least not supported.
            throw new JSourceObjectizerInternalException(
                    UnmarshallerMessages.getUnsupportedExpressionTypeMessage(
                            mMethodInvocation.getExpressionType()));
        }
    }
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new identifier of the method call.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }
        String oldId = mIdentifierTree.Text;
        mIdentifierTree.Token.Text = pNewIdentifier;
        
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
            getMethodInvocation().traverseAll(pAction);
            if (mHasGenericTypeArgumentList) {
                if (mGenericTypeArguments == null) {
                    mGenericTypeArguments =
                        AST2GenericTypeArgument.resolveGenericTypeArgumentList((AST2JSOMTree)
                                getTreeNode().GetChild(1), 
                                getTokenRewriteStream());
                }
                foreach (GenericTypeArgument arg in mGenericTypeArguments) {
                    arg.traverseAll(pAction);
                }
            }
            if (hasArgument()) {
                foreach (Expression expression in mArguments) {
                    expression.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}