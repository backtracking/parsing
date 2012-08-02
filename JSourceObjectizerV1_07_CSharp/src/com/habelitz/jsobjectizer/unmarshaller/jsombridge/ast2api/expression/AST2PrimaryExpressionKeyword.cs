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
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using Keyword = com.habelitz.jsobjectizer.jsom.api.expression.Keyword;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression
{
    /**
     * This <code>PrimaryExpression</code> type represents the most trivial kinds of
     * primary expressions which are the keywords <code>class</code>, <code>this
     * </code>, <code>super</code> or <code>void</code>.
     * 
     * @author Dieter Habelitz
     */
    public class AST2PrimaryExpressionKeyword : AST2PrimaryExpression, PrimaryExpressionKeyword
    {

        /*
         * One of the 'PrimaryExpressionKeyword.Keyword.???' constants.  
         */
        private Keyword mKeywort;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing the primary expression keyword.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2PrimaryExpressionKeyword(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ExpressionType.KEYWORD, pTokenRewriteStream)
        {


            switch (pTree.Type)
            {
                case JavaTreeParser.CLASS:
                    mKeywort = Keyword.CLASS;
                    break;
                case JavaTreeParser.THIS:
                    mKeywort = Keyword.THIS;
                    break;
                case JavaTreeParser.SUPER:
                    mKeywort = Keyword.SUPER;
                    break;
                case JavaTreeParser.VOID:
                    mKeywort = Keyword.VOID;
                    break;
                default:
                    throw new ArgumentException(
                            CommonErrorMessages.getInvalidArgumentValueMessage(
                                    "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the primary 
         * expression keyword starts.
         * 
         * @return  The <i>character in line</i> position where the primary 
         *          expression keyword starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * One of the <code>PrimaryExpressionKeyword.Keyword.???</code> constants.
         * 
         * @return  One of the <code>PrimaryExpressionKeyword.Keyword.???</code> 
         *          constants.
         */
        public Keyword getKeywordType()
        {

            return mKeywort;
        }

        /**
         * Returns the line number of the primary expression keyword.
         * 
         * @return  The line number of the primary expression keyword.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Calls the methods <code>pAction.performAction(...)</code> and <code>
         * pAction.actionPerformed(...)</code> with <code>this</code> as argument.
         * <p>
         * Note that this <code>JSOM</code> type has no <code>JSOM</code> members to
         * traverse.
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
            // Nothing to traverse.
            pAction.actionPerformed(this);
        }
    }
}