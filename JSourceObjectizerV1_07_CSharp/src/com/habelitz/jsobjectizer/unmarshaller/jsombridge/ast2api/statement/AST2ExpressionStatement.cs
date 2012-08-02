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
using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement
{
    /**
     * This <code>Statement</code> type represents an expression on statement level.
     * 
     * Examples for such expressions are assignment expressions or method calls that 
     * are not part of a statement but represents a statement itself.
     * <p>
     * Note that empty statements will also be represented by this statement type.
     * 
     * @author Dieter Habelitz
     */
    public class AST2ExpressionStatement : AST2Statement, ExpressionStatement
    {

        // The expression itself.
        private Expression mExpression;
        // 'true' if 'this' represents an empty statement.
        private bool mIsEmptyStatement = false;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing an expression or an empty
         *               expression (i.e. a <code>SEMI</code>).
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2ExpressionStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ElementType.EXPRESSION_STATEMENT, pTokenRewriteStream)
        {


            if (pTree.Type == JavaTreeParser.SEMI)
            {
                mIsEmptyStatement = true;
            }
            else if (pTree.Type != JavaTreeParser.EXPR)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the statement expression.
         * 
         * @return  The statement expression or <code>null</code> if <code>this
         *          </code> represents an empty statement.
         */
        public Expression getExpression()
        {

            if (mIsEmptyStatement)
            {
                return null;
            }
            if (mExpression == null)
            {
                mExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                                            getTreeNode(), getTokenRewriteStream());
            }

            return mExpression;
        }

        /**
         * Tells if <code>this</code> is an empty statement or not.
         * 
         * @return  <code>true</code> if <code>this</code> is an empty statement.
         */
        public bool isEmptyStatement()
        {

            return mIsEmptyStatement;
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
        public void traverseAll(TraverseAction pAction)
        {

            pAction.performAction(this);
            if (pAction.isMemberTraversingEnabled())
            {
                // Traverse the members.
                Expression expression = getExpression();
                if (expression != null)
                {
                    expression.traverseAll(pAction);
                }
            }
            pAction.actionPerformed(this);
        }
    }
}