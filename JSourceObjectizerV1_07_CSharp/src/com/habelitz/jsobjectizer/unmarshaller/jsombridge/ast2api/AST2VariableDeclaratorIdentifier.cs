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
using System.Reflection;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
    /**
     * This <code>JSOM</code> type represents a variable declarator identifier.
     * <p>
     * A variable declarator identifier is an identifier followed by 0 or more array
     * declarators.
     * 
     * @author Dieter Habelitz
     */
    public class AST2VariableDeclaratorIdentifier : AST2JSOM, VariableDeclaratorIdentifier
    {

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a variable declarator 
         *               identifier.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2VariableDeclaratorIdentifier(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.VARIABLE_DECLARATOR_IDENTIFIER,pTokenRewriteStream)
        {
            if (pTree.Type != JavaTreeParser.IDENT)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the variable
         * declarator identifier starts.
         * 
         * @return  The <i>character in line</i> position where the variable
         *          declarator identifier starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the variable declarator identifier starts.
         * 
         * @return  The line number of the variable declarator identifier starts.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns the variable's identifier.
         * 
         * @return  The variable's identifier.
         */
        public String getIdentifier()
        {

            return getTreeNode().Text;
        }

        /**
         * Returns the number of array declarators, i.e. the number of <code>[]
         * </code> character sequences following the identifier.
         * <p>
         * Note that array declarators may also follow the variable's type 
         * identifier; those array declarators will not be counted here.
         *
         * @return  The number of array declarators.
         */
        public int getNumberOfArrayDeclarators()
        {

            ITree tree = getTreeNode();
            if (tree.ChildCount == 1)
            {
                return tree.GetChild(0).ChildCount;
            }

            return 0;
        }

        /**
         * Replaces the variable declarator's identifier.
         * 
         * @param pNewIdentifier  The new identifier.
         * 
         * @return  The previous identifier.
         * 
         * @deprecated  Use the method {@link #setIdentifier(String)} instead.
         */
        [Obsolete]
        public String replaceIdentifier(String pNewIdentifier)
        {

            return setIdentifier(pNewIdentifier);
        }

        /**
         * Replaces the variable declarator's identifier.
         * 
         * @param pNewIdentifier  The new identifier.
         * 
         * @return  The previous identifier.
         */
        public String setIdentifier(String pNewIdentifier)
        {

            AST2JSOMTree root = (AST2JSOMTree)getTreeNode();
            String oldIdentifier = root.Text;
            root.Token.Text = pNewIdentifier;

            return oldIdentifier;
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