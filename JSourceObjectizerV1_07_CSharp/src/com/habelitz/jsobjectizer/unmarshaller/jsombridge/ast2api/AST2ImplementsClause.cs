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
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{

    /**
     * This <code>JSOM</code> represents an <code>,</code> clause.
     * 
     * @author Dieter Habelitz
     */
    public class AST2ImplementsClause : AST2JSOM, ImplementsClause
    {

        // The types of the ',' clause.
        private List<com.habelitz.jsobjectizer.jsom.api.Type> mTypes;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing an <code>,</code> 
         *               clause for class declarations.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2ImplementsClause(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.IMPLEMENTS_CLAUSE, pTokenRewriteStream)
        {
            if (pTree.Type != JavaTreeParser.IMPLEMENTS_CLAUSE)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the <code>,
         * </code> clause starts.
         * 
         * @return  The <i>character in line</i> position where the <code>,
         *          </code> clause starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the <code>,</code> clause.
         * 
         * @return  The line number of the <code>,</code> clause.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns a list of the types stated by the <code>,</code> clause.
         * <p>
         * Calling this method equals an <code>getTypes(null)</code> call.
         * 
         * @see #getTypes(List)
         *  
         * @return  A list of the types stated by of the <code>,</code> 
         *          clause.
         */
        public List<Type> getTypes()
        {

            return getTypes(null);
        }

        /**
         * Returns a list of the types stated by the <code>,</code> clause.
         * 
         * @param  pList  If this argument isn't <code>null</code> the types will be
         *                added to this list and this list object will be returned. 
         *                Otherwise a new list will be created for the result.
         *  
         * @return  A list of the types stated by of the <code>,</code> 
         *          clause.
         */
        public List<Type> getTypes(List<Type> pList)
        {

            if (mTypes == null)
            {
                resolveTypes();
            }

            List<Type> result = pList;
            if (result == null)
            {
                result = new List<Type>(mTypes.Count);
            }
            result.AddRange(mTypes);

            return result;
        }

        /**
         * Resolves the types stated by the <code>,</code> clause.
         */
        private void resolveTypes()
        {

            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            int size = tree.ChildCount;
            mTypes = new List<Type>(size);
            for (int offset = 0; offset < size; offset++)
            {
                mTypes.Add(new AST2Type((AST2JSOMTree)
                                tree.GetChild(offset), getTokenRewriteStream()));
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
            // Traverse the types.
            if (mTypes == null) {
                resolveTypes();
            }
            foreach (Type type in mTypes) {
                type.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
    }
}