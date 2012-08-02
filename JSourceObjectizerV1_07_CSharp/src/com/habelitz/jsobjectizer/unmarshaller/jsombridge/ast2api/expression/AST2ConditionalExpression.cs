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
using com.habelitz.jsobjectizer.jsom.api.expression;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression
{
    /**
     * This <code>Expression</code> type represents a conditional expression, i.e.
     * something like
     *  <pre>
     *      conditionExpression ? ifTrueExpression : ifFalseExpression
     *  </pre>
     * 
     * @author Dieter Habelitz
     */
    public class AST2ConditionalExpression
        : AST2Expression, ConditionalExpression
    {

        /*
         * The condition expression. 
         */
        private Expression mCondition;
        /*
         * The expression for the case where the condition is <code>true</code>.
         */
        private Expression mIfTrueExpression;
        /*
         * The expression for the case where the condition is <code>false</code>.
         */
        private Expression mIfFalseExpression;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing the literal.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2ConditionalExpression(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ExpressionType.CONDITIONAL_EXPRESSION, pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.QUESTION)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position of the <code>'?'</code>
         * character.
         * 
         * @return  The <i>character in line</i> position of the <code>'?'</code>
         *          character.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the condition expression.
         * 
         * @return  The condition expression.
         */
        public Expression getCondition()
        {

            if (mCondition == null)
            {
                mCondition = AST2Expression.resolveExpression((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            }

            return mCondition;
        }

        /**
         * Returns the expression for the case where the condition is <code>true
         * </code>.
         * 
         * @return  The expression for the case where the condition is <code>true
         *          </code>.
         */
        public Expression getIfTrueExpression()
        {

            if (mIfTrueExpression == null)
            {
                mIfTrueExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                        getTreeNode().GetChild(1), getTokenRewriteStream());
            }

            return mIfTrueExpression;
        }

        /**
         * Returns the expression for the case where the condition is <code>
         * false</code>.
         * 
         * @return  The expression for the case where the condition is <code>
         *          false</code>.
         */
        public Expression getIfFalseExpression()
        {

            if (mIfFalseExpression == null)
            {
                mIfFalseExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                        getTreeNode().GetChild(2), getTokenRewriteStream());
            }

            return mIfFalseExpression;
        }

        /**
         * Returns the line number of the <code>'?'</code> character.
         * 
         * @return  The line number of the <code>'?'</code> character.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
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
                getIfTrueExpression().traverseAll(pAction);
                getIfFalseExpression().traverseAll(pAction);
            }
            pAction.actionPerformed(this);
        }
    }
}