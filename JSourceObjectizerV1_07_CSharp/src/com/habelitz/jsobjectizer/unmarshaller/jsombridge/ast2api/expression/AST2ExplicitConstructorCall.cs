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
using com.habelitz.jsobjectizer.jsom.api.expression;
using LiteralType = com.habelitz.jsobjectizer.jsom.api.expression.LiteralType;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression
{
    /**
     * This <code>PrimaryExpression</code> type represents an explicit <code>this
     * </code> or </code>super</code> constructor call.
     * 
     * @author Dieter Habelitz
     */
    public class AST2ExplicitConstructorCall
        : AST2PrimaryExpression, ExplicitConstructorCall
    {

        // The optional generic type arguments.
        private List<AST2GenericTypeArgument> mGenericTypeArguments;
        // A list of argument expressions
        private List<Expression> mArguments;
        // A primary expression that may qualify a super constructor call.
        private PrimaryExpression mSuperTypeExpr;
        // 'true' if 'this' is a super constructor call.
        private bool mIsSuperConstructorCall = false;

        // The children from an explicit super/this constructor call. 
        private AST2JSOMTree mPrimaryExprTree;
        private AST2JSOMTree mGenericTypeArgumentListTree;
        private AST2JSOMTree mArgumentListTree;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a type.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2ExplicitConstructorCall(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ExpressionType.EXPLICIT_CONSTRUCTOR_CALL,pTokenRewriteStream)
        {

            if (pTree.Type == JavaTreeParser.SUPER_CONSTRUCTOR_CALL)
            {
                mIsSuperConstructorCall = true;
            }
            else if (pTree.Type != JavaTreeParser.THIS_CONSTRUCTOR_CALL)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            int offset = 0;
            AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(offset);
            // 'super' constructor calls may be preceded by a primary expression
            // stating the constructor's owner.
            if (mIsSuperConstructorCall
                && child.Type != JavaTreeParser.GENERIC_TYPE_ARG_LIST
                && child.Type != JavaTreeParser.ARGUMENT_LIST)
            {
                // There must be a primary expression tree.
                mPrimaryExprTree = child;
                offset++;
                child = (AST2JSOMTree)pTree.GetChild(offset);
            }
            // Check if there is a generic type argument list.
            if (child.Type == JavaTreeParser.GENERIC_TYPE_ARG_LIST)
            {
                mGenericTypeArgumentListTree = child;
                offset++;
                child = (AST2JSOMTree)pTree.GetChild(offset);
            }
            // Get the optional arguments.
            if (child.ChildCount > 0)
            {
                mArgumentListTree = child;
            }
        }

        /**
         * Returns a list of the explicit constructor call's arguments.
         * <p>
         * Calling this method equals an <code>getMethodDeclarations(null)</code>
         * call.
         * 
         * @see #getArguments(List)
         *  
         * @return  A list of the explicit constructor call's arguments. If there 
         *          are no arguments <code>null</code> will be returned. 
         */
        public List<Expression> getArguments()
        {

            return getArguments(null);
        }

        /**
         * Returns a list of the explicit constructor call's arguments.
         * 
         * @param  pList  If this argument isn't <code>null</code> the arguments 
         *                will be added to this list and this list object will be
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of the explicit constructor call's arguments. If there 
         *          are no arguments <code>null</code> will be returned, even if
         *          the argument <code>pList</code> isn't <code>null</code>. 
         */
        public List<Expression> getArguments(List<Expression> pList)
        {

            if (mArgumentListTree == null)
            {
                return null; // There're no arguments.
            }
            if (mArguments == null)
            {
                resolveArguments();
            }
            List<Expression> result = pList;
            if (result == null)
            {
                result = new List<Expression>(mArguments.Count);
            }
            result.AddRange(mArguments);

            return result;
        }

        /**
         * Returns the <i>character in line</i> position where the <code>this</code>
         * or <code>super</code> keyword starts.
         * 
         * @return  The <i>character in line</i> position where the <code>this
         *          </code> or <code>super</code> keyword clause starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns a list of the generic type arguments that may have been stated 
         * with the <code>this</code> or </code>super</code> constructor invocation.
         * <p>
         * Calling this method equals an <code>getMethodDeclarations(null)</code>
         * call.
         * 
         * @see #getGenericTypeArguments(List)
         *  
         * @return  A list of the generic type arguments that may have been stated 
         *          with the <code>this</code> or </code>super</code> constructor 
         *          invocation. If there are no generic type arguments <code>null
         *          </code> will be returned. 
         */
        public List<GenericTypeArgument> getGenericTypeArguments()
        {

            return getGenericTypeArguments(null);
        }

        /**
         * Returns a list of the generic type arguments that may have been stated 
         * with the <code>this</code> or </code>super</code> constructor invocation.
         * 
         * @param  pList  If this argument isn't <code>null</code> the generic type
         *                arguments will be added to this list and this list object
         *                will be returned. Otherwise a new list will be created for
         *                the result.
         *  
         * @return  A list of the generic type arguments that may have been stated 
         *          with the <code>this</code> or </code>super</code> constructor 
         *          invocation. If there are no generic type arguments <code>null
         *          </code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>. 
         */
        public List<GenericTypeArgument> getGenericTypeArguments(
                List<GenericTypeArgument> pList)
        {

            if (mGenericTypeArgumentListTree == null)
            {
                return null; // There're no generic type arguments.
            }
            if (mGenericTypeArguments == null)
            {
                mGenericTypeArguments =
                    AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                            mGenericTypeArgumentListTree, getTokenRewriteStream());
            }
            List<GenericTypeArgument> result = pList;
            if (result == null)
            {
                result = new List<GenericTypeArgument>(
                        mGenericTypeArguments.Count);
            }
            result.AddRange(mGenericTypeArguments);

            return result;
        }

        /**
         * Returns the line number of the <code>this</code> or <code>super</code> 
         * keyword.
         * 
         * @return  The line number of the <code>this</code> or <code>super</code> 
         *          keyword.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns the expression that may precede the <code>super</code>
         * keyword of an explicit <code>super</code> constructor call.
         * <p>
         * A returned expression states the type a called <code>super</code>
         * constructor belongs to. For most cases this is something like <code>
         * ACertainType.this.base(...)</code>
         * 
         * @return  The expression that precedes the <code>super</code>
         *          keyword or <code>null</code> if there is no such expression. If
         *          <code>this</code> represents an explicit <code>this</code> 
         *          constructor call this method always returns<code>null</code>.
         */
        public PrimaryExpression getSuperType()
        {

            if (mPrimaryExprTree == null)
            {
                return null;
            }
            if (mSuperTypeExpr == null)
            {
                mSuperTypeExpr = AST2Expression.resolvePrimaryExpression(
                        mPrimaryExprTree, getTokenRewriteStream());
            }

            return mSuperTypeExpr;
        }

        /**
         * This method equals to a {@link #getSuperType()} call.
         * 
         * @deprecated  Replaced by {@link #getSuperType()}.
         * 
         * @return  Same as {@link #getSuperType()}
         */
        [Obsolete]
        public PrimaryExpression getPrimaryExpression()
        {

            return getSuperType();
        }

        /**
         * Tells if the explicit constructor call has at least one argument.
         * 
         * @return  <code>true</code> if the explicit constructor call has at least
         *          one argument.
         *          
         * TEST          
         */
        public bool hasArgument()
        {

            return mArgumentListTree != null;
        }

        /**
         * Tells if <code>this</code> has at least one generic type argument.
         * 
         * @return  <code>true</code> if <code>this</code> has at least one generic
         *          type argument.
         */
        public bool hasGenericTypeArgument()
        {

            return mGenericTypeArgumentListTree != null;
        }

        /**
         * @deprecated  Replaced by {@link #hasGenericTypeArgument()}
         * 
         * @return  Same as {@link #hasGenericTypeArgument()}
         */
        [Obsolete]
        public bool hasGenericTypeParameter()
        {

            return mGenericTypeArgumentListTree != null;
        }

        /**
         * @deprecated  Replaced by {@link #hasSuperTypeExpression()}
         * 
         * @return  Same as {@link #hasSuperTypeExpression()}
         */
        [Obsolete]
        public bool hasPrimaryExpression()
        {

            return mPrimaryExprTree != null;
        }

        /**
         * Tells if an explicit <code>super</code> constructor call is preceded by
         * an expression stating the super type explicitly.
         * 
         * @return  <code>true</code> if an explicit <code>super</code> constructor
         *          call is preceded by an expression stating the super type. If 
         *          <code>this</code> represents an explicit <code>this</code>
         *          constructor call this method always returns <code>false</code>.
         */
        public bool hasSuperTypeExpression()
        {

            return mPrimaryExprTree != null;
        }

        /**
         * Tells if <code>this</code> represents an explicit <code>this</code> or 
         * </code>super</code> constructor call.
         * 
         * @return  <code>true</code> for explicit <code>super</code> constructor
         *          calls and <code>false</code> for explicit <code>this</code>
         *          constructor calls.
         */
        public bool isSuperConstructorCall()
        {

            return mIsSuperConstructorCall;
        }

        /**
         * Resolves the arguments.
         * <p>
         * Note that it's up to the caller to ensure that there's at least one
         * argument.
         */
        private void resolveArguments()
        {

            int numberOfArgs = mArgumentListTree.ChildCount;
            mArguments = new List<Expression>(numberOfArgs);
            for (int offset = 0; offset < numberOfArgs; offset++)
            {
                mArguments.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                        mArgumentListTree.GetChild(offset),
                        getTokenRewriteStream()));
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
            PrimaryExpression expression = getSuperType();
            if (expression != null) {
                expression.traverseAll(pAction);
            }
            if (mGenericTypeArgumentListTree != null) {
                if (mGenericTypeArguments == null) {
                    mGenericTypeArguments = 
                        AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                                mGenericTypeArgumentListTree,
                                getTokenRewriteStream());
                }
                foreach (GenericTypeArgument arg in mGenericTypeArguments) {
                    arg.traverseAll(pAction);
                }
            }
            // Traverse the members.
            if (mArgumentListTree != null) {
                if (mArguments == null) {
                    resolveArguments();
                }
                foreach (Expression arg in mArguments) {
                    arg.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
    }
}
