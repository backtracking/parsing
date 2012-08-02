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
using PrimitiveType = com.habelitz.jsobjectizer.jsom.api.PrimitiveType;
using TypeKeyword = com.habelitz.jsobjectizer.jsom.api.TypeKeyword;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
    /**
     * This <code>JSOM</code> represents a primitive type.
     * 
     * @author Dieter Habelitz
     */
    public class AST2PrimitiveType : AST2JSOM, PrimitiveType
    {

        /**
         * The type represented by 'this'.
         */
        private TypeKeyword mTypeKeyword;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing the literal.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2PrimitiveType(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.PRIMITIVE_TYPE, pTokenRewriteStream)
        {
            switch (pTree.Type)
            {
                case JavaTreeParser.BOOLEAN:
                    mTypeKeyword = TypeKeyword.BOOLEAN;
                    break;
                case JavaTreeParser.CHAR:
                    mTypeKeyword = TypeKeyword.CHAR;
                    break;
                case JavaTreeParser.BYTE:
                    mTypeKeyword = TypeKeyword.BYTE;
                    break;
                case JavaTreeParser.SHORT:
                    mTypeKeyword = TypeKeyword.SHORT;
                    break;
                case JavaTreeParser.INT:
                    mTypeKeyword = TypeKeyword.INT;
                    break;
                case JavaTreeParser.LONG:
                    mTypeKeyword = TypeKeyword.LONG;
                    break;
                case JavaTreeParser.FLOAT:
                    mTypeKeyword = TypeKeyword.FLOAT;
                    break;
                case JavaTreeParser.DOUBLE:
                    mTypeKeyword = TypeKeyword.DOUBLE;
                    break;
                default:
                    throw new ArgumentException(
                            CommonErrorMessages.getInvalidArgumentValueMessage(
                                    "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the primitive type
         * keyword starts.
         * 
         * @return  The <i>character in line</i> position where the primitive type
         * keyword starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the primitive type keyword.
         * 
         * @return  The line number of the primitive type keyword.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns the type constant for the type represented by <code>this</code>.
         * 
         * @return  One of the <code>PrimitiveType.TypeKeyword</code> constants.
         */
        public TypeKeyword getTypeKeyword()
        {

            return mTypeKeyword;
        }

        /**
         * Returns the type constant for the type represented by <code>this</code>.
         * 
         * @return  One of the <code>PrimitiveType.TypeKeyword</code> constants.
         */
        [Obsolete]
        public TypeKeyword getTypeKeywort()
        {

            return getTypeKeyword();
        }

        /**
         * Tells if the given tree represents a primitive type.
         * 
         * @param pTree  The tree of interest.
         * 
         * @return  <code>true</code> if the given tree represents a primitive type.
         */
        public static bool isPrimitiveType(ITree pTree)
        {

            switch (pTree.Type)
            {
                case JavaTreeParser.BOOLEAN:
                case JavaTreeParser.CHAR:
                case JavaTreeParser.BYTE:
                case JavaTreeParser.SHORT:
                case JavaTreeParser.INT:
                case JavaTreeParser.LONG:
                case JavaTreeParser.FLOAT:
                case JavaTreeParser.DOUBLE:
                    return true;
            }

            return false;
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
            // No members to traverse.
            pAction.actionPerformed(this);
        }
    }
}