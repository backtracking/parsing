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
using System.IO;
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
     * This <code>JSOM</code> type represents a <code>throws</code> clause.
     * 
     * @author Dieter Habelitz
     */
    public class AST2ThrowsClause : AST2JSOM, ThrowsClause
    {

        // A list of qualified identifiers.
        private List<QualifiedIdentifier> mIdentifiers;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing an <code>throws</code> clause.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.
         */
        public AST2ThrowsClause(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.THROWS_CLAUSE, pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.THROWS_CLAUSE)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the <code>throws
         * </code> clause starts.
         * 
         * @return  The <i>character in line</i> position where the <code>throws
         *          </code> clause starts.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the <code>throws</code> clause.
         * 
         * @return  The line number of the <code>throws</code> clause.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Returns a list of the qualified identifiers, i.e. of the stated throwable 
         * types.
         * <p>
         * Calling this method equals an <code>getQualifiedIdentifiers(null)</code>
         * call.
         * 
         * @see #getQualifiedIdentifiers(List)
         *  
         * @return  A list of the qualified identifiers.
         */
        public List<QualifiedIdentifier> getQualifiedIdentifiers()
        {

            return getQualifiedIdentifiers(null);
        }

        /**
         * Returns a list of the qualified identifiers, i.e. of the stated throwable 
         * types.
         * 
         * @param  pList  If this argument isn't <code>null</code> the qualified
         *                identifiers will be added to this list and this list
         *                object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of the qualified identifiers.
         */
        public List<QualifiedIdentifier> getQualifiedIdentifiers(
                List<QualifiedIdentifier> pList)
        {

            if (mIdentifiers == null)
            {
                resolveQualifiedIdentifiers();
            }

            List<QualifiedIdentifier> result = pList;
            if (result == null)
            {
                result = new List<QualifiedIdentifier>(mIdentifiers.Count);
            }
            result.AddRange(mIdentifiers);

            return result;
        }

        /**
         * Resolves the qualified identifiers.
         */
        private void resolveQualifiedIdentifiers()
        {

            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            int size = tree.ChildCount;
            mIdentifiers = new List<QualifiedIdentifier>(size);
            for (int offset = 0; offset < size; offset++)
            {
                mIdentifiers.Add(new AST2QualifiedIdentifier((AST2JSOMTree)
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
            // Traverse the members.
            if (mIdentifiers == null) {
                resolveQualifiedIdentifiers();
            }
            foreach (QualifiedIdentifier id in mIdentifiers) {
                id.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
    }
}