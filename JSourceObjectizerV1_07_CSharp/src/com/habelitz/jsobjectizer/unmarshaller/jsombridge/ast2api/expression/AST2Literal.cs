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
using LiteralType = com.habelitz.jsobjectizer.jsom.api.expression.LiteralType;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression
{
    /**
     * This <code>PrimaryExpression</code> represents a literal.
     * 
     * @author Dieter Habelitz
     */
    public class AST2Literal : AST2PrimaryExpression, Literal
    {

        /*
         * One of the 'LITERAL_???' constants defined by the interface 'Literal'.
         */
        private LiteralType mLiteralType;

        /**
         * Constructor.
         * <p>
         * Creates a new instance for a certain literal type.
         * 
         * @param pTree  The tree node representing the literal.
         * @param pLiteralType  One of the 'LITERAL_???' constants defined by the 
         *                      interface 'Literal'. Note that it's up to the caller
         *                      to ensure that the literal type matches the token
         *                      type.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2Literal(AST2JSOMTree pTree, LiteralType pLiteralType,
                    TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ExpressionType.LITERAL, pTokenRewriteStream)
        {

            mLiteralType = pLiteralType;
        }

        /**
         * Returns the <i>character in line</i> position where the literal starts.
         * 
         * @return  The <i>character in line</i> position where the literal starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the literal.
         * 
         * @return  The line number of the literal.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns the literal.
         * <p>
         * For the number, character or string literals the appropriate literal
         * string will be returned. For the literal types <code>LITERAL_TRUE</code>, 
         * <code>LITERAL_FALSE</code> and <code>LITERAL_NULL</code> this method 
         * returns always <code>"true"</code>, <code>"false"</code> and <code>"null"
         * </code>, respectively.
         * 
         * @return  The literal.
         */
        public String getLiteral()
        {

            return getTreeNode().Text;
        }

        /**
         * Returns one of the <code>LiteralType.???</code> constants.
         * 
         * @return  One of the <code>LiteralType.???</code> constants.
         */
        public LiteralType getType()
        {

            return mLiteralType;
        }

        /**
         * Changes <code>this</code> to become a <code>Literal</code> object
         * representing a literal stated as string.
         * <p>
         * Literals like numbers, bool values, the <code>null</code> literal,
         * characters and so on can be stated as expected, i.e. like
         * <ul>
         *  <li>
         *      <i>"123"</i> (an integer)
         *  </li>
         *  <li>
         *      <i>"true"</i> (a bool literal)
         *  </li>
         *  <li>
         *      <i>"null"</i> (the <code>null</code> literal)
         *  </li>
         *  <li>
         *      <i>"'a'"</i> (the character literal <code>a</code>)
         *  </li>
         *  <li>
         *      <i>"'\''"</i> (the character literal <code>'</code>)
         *  </li>
         * </ul> 
         * For string literals it must be considered that they must be stated
         * including the quotation marks that belong to the string literal. Examples
         * are
         * <ul>
         *  <li>
         *      <i>"\"\""</i> (the empty string)
         *  </li>
         *  <li>
         *      <i>"\"anyString\""</i> (a simple non-empty string)
         *  </li>
         *  <li>
         *      <i>"\"with \\\" character\""</i> (a string containing one escaped 
         *      <code>'"'</code> character)
         *  </li>
         * </ul>
         * 
         * @param pLiteral  The new literal stated as string.
         * 
         * @return  The old literal.
         *
         * @  if the given literal isn't a valid
         *                                     literal; note that the passed literal
         *                                     string must be parsable by the
         *                                     unmarshaller.
         * 
         * @see #setLiteralChecked(String)
         */
        public String setLiteral(String pLiteral)
        {

            if (pLiteral == null)
            {
                throw new JSourceObjectizerException(
                        CommonErrorMessages.getArgumentIsNullMessage("pLiteral"));
            }
            // Remember the old literal string.
            AST2JSOMTree thisRootNode = (AST2JSOMTree)getTreeNode();
            String oldLiteral = thisRootNode.Text;
            // Create a temporary literal object for the new literal.
            List<String> messages = new List<String>();
            AST2Literal tempLiteral = null;
            try
            {
                tempLiteral =
                    (AST2Literal)getUnmarshaller().unmarshalAST2Expression(
                        pLiteral, messages);
            }
            catch (Exception pException)
            {
                // Catch any kind of exception.
                throw new JSourceObjectizerException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pLiteral", pLiteral),
                                pException);
            }
            if (tempLiteral == null || messages.Count > 0)
            {
                throw new JSourceObjectizerException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pLiteral", pLiteral));
            }
            // Get the data from the temporary literal.
            AST2JSOMTree tempRootNode = (AST2JSOMTree)tempLiteral.getTreeNode();
            mLiteralType = tempLiteral.mLiteralType;
            IToken token = thisRootNode.Token;
            token.Type = tempRootNode.Type;
            token.Text = tempRootNode.Text;

            return oldLiteral;
        }

        /**
         * Changes <code>this</code> to become a <code>Literal</code> object
         * representing a literal stated as string.
         * <p>
         * Calling this method equals to a {@link #setLiteral(String)} call with
         * the exception that this method doesn't throw an exception if the given
         * literal is invalid, i.e. not parsable. In such cases this method just
         * returns <code>null</code>.
         * <p>
         * Literals like numbers, bool values, the <code>null</code> literal,
         * characters and so on can be stated as expected, i.e. like
         * <ul>
         *  <li>
         *      <i>"123"</i> (an integer)
         *  </li>
         *  <li>
         *      <i>"true"</i> (a bool literal)
         *  </li>
         *  <li>
         *      <i>"null"</i> (the <code>null</code> literal)
         *  </li>
         *  <li>
         *      <i>"'a'"</i> (the character literal <code>a</code>)
         *  </li>
         *  <li>
         *      <i>"'\''"</i> (the character literal <code>'</code>)
         *  </li>
         * </ul> 
         * For string literals it must be considered that they must be stated
         * including the quotation marks that belong to the string literal. Examples
         * are
         * <ul>
         *  <li>
         *      <i>"\"\""</i> (the empty string)
         *  </li>
         *  <li>
         *      <i>"\"anyString\""</i> (a simple non-empty string)
         *  </li>
         *  <li>
         *      <i>"\"with \\\" character\""</i> (a string containing one escaped 
         *      <code>'"'</code> character)
         *  </li>
         * </ul>
         * 
         * @param pLiteral  The new literal stated as string.
         * 
         * @return  The old literal or <code>null</code> if the passed literal is
         *          invalid, i.e. not parsable.
         *
         * @see #setLiteral(String)
         */
        public String setLiteralChecked(String pLiteral)
        {

            try
            {
                return setLiteral(pLiteral);
            }
            catch (JSourceObjectizerException e)
            {
                return null;
            }
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