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
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api.statement;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement
{

    /** 
     * This <code>StatementBlockElement</code> type represents all kinds of 
     * statements.
     * 
     * @author Dieter Habelitz
     */
    public abstract class AST2Statement : AST2JSOM, Statement, AST2StatementBlockElement
    {

        // The statement block element type represented by 'this'.
        private ElementType mStatementBlockElementType;

        /**
         * Constructor.
         * 
         * @param pTree  The root or start node of the statement.
         * @param pStatementBlockElemType  One of the constants defined by <code>
         *                                 StatementBlockElement</code>.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2Statement(
            AST2JSOMTree pTree, ElementType pStatementBlockElemType,
            TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.STATEMENT_BLOCK_ELEMENT, pTokenRewriteStream)
        {

            mStatementBlockElementType = pStatementBlockElemType;

        }

        /**
         * Returns the <i>character in line</i> position of the statement's <i>root
         * </i> which represents a statement keyword for most cases.
         * 
         * If a subclass of this class represents a statement type where the
         * behavior of this implementation is not okay it must override this method
         * appropriately, of course.
         * 
         * @return  The <i>character in line</i> position of the statement's <i>root
         *          </i> which represents a statement keyword for most cases.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the statement's <i>root</i> which represents a 
         * statement keyword for most cases..
         * 
         * If a subclass of this class represents a statement type where the
         * behavior of this implementation is not okay it must override this method
         * appropriately, of course.
         * 
         * @return  The line number of the statement's <i>root</i> which represents 
         *          a statement keyword for most cases..
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns the <code>ElementType</code> represented by <code>this</code>.
         * 
         * @return  The <code>ElementType</code> represented by <code>this</code>.
         */
        public ElementType getStatementBlockElementType()
        {

            return mStatementBlockElementType;
        }

        /**
         * Always returns <code>true</code>.
         * 
         * @return  <code>true</code>
         */
        public bool isStatement()
        {

            return true;
        }

        /**
         * Returns <code>true</code> if <code>pType</code> equals to <code>
         * StatementBlockElement.ElementType.LOCAL_VARIABLE_DECLARATION</code>.
         * 
         * @return  <code>true</code> if <code>pType</code> equals to <code>
         *          StatementBlockElement.ElementType.LOCAL_VARIABLE_DECLARATION</code>.
         */

        public override bool isStatementBlockElementType(ElementType pType)
        {

            return pType == mStatementBlockElementType;
        }

        /**
         * Resolves all kinds of <code>Statement</code> types.
         * 
         * @param pTree  The statement's root or start node.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         * 
         * @return  The resolved statement.
         * 
         * @throws ArgumentException  if the stated tree doesn't represent a
         *                                   statement.
         */
        public static AST2Statement resolveStatement(
                AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        {

            switch (pTree.Type)
            {
                case JavaTreeParser.BLOCK_SCOPE:
                    return new AST2StatementBlockScope(
                            pTree, Owner.COMPOUND_STATEMENT,
                            pTokenRewriteStream);
                case JavaTreeParser.ASSERT:
                    return new AST2AssertStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.IF:
                    return new AST2IfStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.FOR:
                    return new AST2ForStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.FOR_EACH:
                    return new AST2ForEachStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.WHILE:
                case JavaTreeParser.DO:
                    return new AST2WhileAndDoStatements(pTree, pTokenRewriteStream);
                case JavaTreeParser.TRY:
                    return new AST2TryStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.SWITCH:
                    return new AST2SwitchStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.SYNCHRONIZED:
                    return new AST2SynchronizedStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.RETURN:
                    return new AST2ReturnStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.THROW:
                    return new AST2ThrowStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.BREAK:
                    return new AST2BreakStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.CONTINUE:
                    return new AST2ContinueStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.LABELED_STATEMENT:
                    return new AST2LabeledStatement(pTree, pTokenRewriteStream);
                case JavaTreeParser.EXPR:
                case JavaTreeParser.SEMI:
                    return new AST2ExpressionStatement(pTree, pTokenRewriteStream);
                default:
                    throw new ArgumentException(
                            CommonErrorMessages.getInvalidArgumentValueMessage(
                                    "pTree.Type == " + pTree.Type, "pTree"));
            }
        }
    }
}