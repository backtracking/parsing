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
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement
{
    /**
     * This <code>Statement</code> type represents an <code>if</code> statement.
     * 
     * @author Dieter Habelitz
     */
    public class AST2IfStatement : AST2Statement, IfStatement
    {

        // The 'if' condition.
        private Expression mCondition;
        // The statement that should be executed if the condition is 'true'
        private Statement mIfStatement;
        // An optional 'else' statement.
        private Statement mElseStatement;

        private bool mHasElseStatement = false;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing an <code>if</code> statement.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2IfStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ElementType.IF_STATEMENT,pTokenRewriteStream)
        {

            
            if (pTree.Type != JavaTreeParser.IF)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            if (pTree.ChildCount == 3)
            {
                mHasElseStatement = true;
            }
        }

        /**
         * Returns the <code>if</code> statement's condition expression.
         * 
         * @return  The <code>if</code> statement's condition expression.
         */
        public Expression getCondition()
        {

            if (mCondition == null)
            {
                mCondition = AST2Expression.resolveExpression((AST2JSOMTree)
                        getTreeNode().GetChild(0).GetChild(0),
                        getTokenRewriteStream());
            }

            return mCondition;
        }

        /**
         * Returns the statement that belongs to the optional <code>else</code> 
         * clause that belongs to <code>this</code>, i.e. this is the statement
         * that should be executed if the <code>if</code> statement's condition 
         * expression is <code>false</code>.
         * 
         * @return  The statement that belongs an <code>else</code> clause or <code>
         *          null</code> if no <code>else</code> clause has been stated.
         */
        public Statement getElseStatement()
        {

            if (!mHasElseStatement)
            {
                return null; // There's no 'else' that belongs to this 'if'.
            }
            if (mElseStatement == null)
            {
                mElseStatement =
                    AST2Statement.resolveStatement((AST2JSOMTree)
                            getTreeNode().GetChild(2), getTokenRewriteStream());
            }

            return mElseStatement;
        }

        /**
         * Returns the statement that should be executed if the <code>if</code> 
         * statement condition is <code>true</code>.
         * 
         * @return  The statement that should be executed if the <code>if</code> 
         *          statement condition is <code>true</code>.
         */
        public Statement getStatement()
        {

            if (mIfStatement == null)
            {
                mIfStatement =
                        AST2Statement.resolveStatement((AST2JSOMTree)
                                getTreeNode().GetChild(1), getTokenRewriteStream());
            }

            return mIfStatement;
        }

        /**
         * Tells if the <code>if</code> statement has an <code>else</code> branch.
         * 
         * @return  <code>true</code> if the <code>if</code> statement has an <code>
         *          else</code> branch.
         */
        public bool hasElseClause()
        {

            return mHasElseStatement;
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
                getCondition().traverseAll(pAction);
                getStatement().traverseAll(pAction);
                Statement statement = getElseStatement();
                if (statement != null)
                {
                    pAction.performActionForElseClause(this);
                    statement.traverseAll(pAction);
                    pAction.actionPerformedForElseClause(this);
                }
            }
            pAction.actionPerformed(this);
        }
    }
}