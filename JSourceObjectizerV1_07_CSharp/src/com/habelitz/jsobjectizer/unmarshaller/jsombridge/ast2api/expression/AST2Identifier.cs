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
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression
{
    /**
     * This <code>PrimaryExpression</code> type represents a simple identifier 
     * expression, i.e. such an expression is nothing else than a not qualified 
     * identifier.
     * 
     * @author Dieter Habelitz
     */
    public class AST2Identifier : AST2PrimaryExpression, Identifier
    {

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing the literal.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2Identifier(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ExpressionType.IDENTIFIER, pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.IDENT)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the identifier
         * starts.
         * 
         * @return  The <i>character in line</i> position where the identifier
         *          starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the identifier.
         * 
         * @return  The identifier.
         */
        public String getIdentifier()
        {

            return getTreeNode().Text;
        }

        /**
         * Returns the line number of the identifier.
         * 
         * @return  The line number of the identifier.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Replaces the identifier of <code>this</code>.
         * 
         * @param pNewIdentifier  The new identifier.
         * 
         * @return  The old identifier.
         */
        public String setIdentifier(String pNewIdentifier)
        {

            AST2JSOMTree treeNode = (AST2JSOMTree)getTreeNode();
            String oldId = treeNode.Text;
            treeNode.Token.Text = pNewIdentifier;

            return oldId;
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