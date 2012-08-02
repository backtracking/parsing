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
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using FormalParameterDeclaration = com.habelitz.jsobjectizer.jsom.api.FormalParameterDeclaration;
using com.habelitz.jsobjectizer.jsom.api.statement;
using Catch = com.habelitz.jsobjectizer.jsom.api.statement.Catch;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement
{


    /**
     * This <code>Statement</code> type represents a <code>try</code> statement.
     * <p>
     * This class also defines an inner class <code>Catch</code> representing <code>
     * catch</code> clauses.
     *  
     * @author Dieter Habelitz
     */
    public class AST2TryStatement : AST2Statement, TryStatement
    {

        // The 'try' expression's block scope.
        private StatementBlockScope mTryBlockScope;
        // The optional catch clauses.
        private List<Catch> mCatchClauses;
        // The optional 'finally' clause's block scope.
        private StatementBlockScope mFinallyBlockScope;

        // The 'try' statement tree's children.
        private AST2JSOMTree mCatchClauseListTree;
        private AST2JSOMTree mFinallyBlockScopeTree;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a <code>switch</code> statement.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2TryStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, ElementType.TRY_STATEMENT,pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.TRY)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            if (pTree.ChildCount > 1)
            {
                // The next child may be an 'catch' clause list or a 'finally'
                // clause.
                AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(1);
                if (child.Type == JavaTreeParser.CATCH_CLAUSE_LIST)
                {
                    if (child.ChildCount > 0)
                    {
                        mCatchClauseListTree = child;
                    }
                    if (pTree.ChildCount == 3)
                    {
                        // Switch forward to the 'finally' clause.
                        child = (AST2JSOMTree)pTree.GetChild(2);
                    }
                    else
                    {
                        child = null;
                    }
                }
                if (child != null)
                {
                    mFinallyBlockScopeTree = child;
                }
            }
        }

        /**
         * Returns a list of the <code>catch</code> clauses.
         * <p>
         * Calling this method equals an <code>getCatchClauses(null)</code>
         * call.
         * 
         * @see #getCatchClauses(List)
         *  
         * @return  A list of the <code>catch</code> clauses. If the <code>try
         *          </code> statement has no <code>catch</code> clause <code>null
         *          </code> will be returned.
         */
        public List<Catch> getCatchClauses()
        {

            return getCatchClauses(null);
        }

        /**
         * Returns a list of the <code>catch</code> clauses.
         * 
         * @param  pList  If this argument isn't <code>null</code> the <code>catch
         *                </code> clauses will be added to this list and this list
         *                object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of the <code>catch</code> clauses. If the <code>try
         *          </code> statement has no <code>catch</code> clause <code>null
         *          </code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>.
         */
        public List<Catch> getCatchClauses(List<Catch> pList)
        {

            if (mCatchClauseListTree == null)
            {
                return null; // No 'catch' clauses available.
            }
            if (mCatchClauses == null)
            {
                resolveCatchClauses();
            }

            List<Catch> result = pList;
            if (result == null)
            {
                result = new List<Catch>(mCatchClauses.Count);
            }
            result.AddRange(mCatchClauses);

            return result;
        }

        /**
         * Returns the <code>finally</code> clause's statement block scope, i.e. the 
         * content of the <code>finally</code> block.
         * 
         * @return  The <code>finally</code> clause's statement block scope or 
         *          <code>null</code> if the <code>try</code> statement has no 
         *          <code>finally</code> clause.
         */
        public StatementBlockScope getFinallyStatementBlockScope()
        {

            if (mFinallyBlockScopeTree == null)
            {
                return null; // There's no 'finally' clause.
            }
            if (mFinallyBlockScope == null)
            {
                mFinallyBlockScope = new AST2StatementBlockScope(
                        mFinallyBlockScopeTree,
                        Owner.FINALLY_CLAUSE,
                        getTokenRewriteStream());
            }

            return mFinallyBlockScope;
        }

        /**
         * Returns the <code>try</code> statement's statement block scope, i.e. the 
         * content of the <code>try</code> block.
         * 
         * @return  The <code>try</code> statement's statement block scope.
         */
        public StatementBlockScope getStatementBlockScope()
        {

            if (mTryBlockScope == null)
            {
                mTryBlockScope = new AST2StatementBlockScope((AST2JSOMTree)
                        getTreeNode().GetChild(0),
                        Owner.TRY_STATEMENT,
                        getTokenRewriteStream());
            }

            return mTryBlockScope;
        }

        /**
         * Tells if the <code>try</code> statement has at least one catch clause.
         * 
         * @return  <code>true</code> if the <code>try</code> statement has at least 
         *          one <code>catch</code> clause.
         */
        public bool hasCatchClause()
        {

            return mCatchClauseListTree != null;
        }

        /**
         * Tells if the <code>try</code> statement has a finally clause.
         * 
         * @return  <code>true</code> if the <code>try</code> statement has a 
         *          <code>finally</code> clause.
         */
        public bool hasFinallyClause()
        {

            return mFinallyBlockScopeTree != null;
        }

        /**
         * Resolves the <code>catch</code> clauses.
         * <p>
         * Note that it's up to the caller to ensure that there's at least one
         * <code>catch</code> clause.
         */
        private void resolveCatchClauses()
        {

            int size = mCatchClauseListTree.ChildCount;
            mCatchClauses = new List<Catch>(size);
            TokenRewriteStream stream = getTokenRewriteStream();
            for (int offset = 0; offset < size; offset++)
            {
                mCatchClauses.Add(new AST2Catch((AST2JSOMTree)
                        mCatchClauseListTree.GetChild(offset), stream));
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
            getStatementBlockScope().traverseAll(pAction);
            if (mCatchClauseListTree != null) {
                if (mCatchClauses == null) {
                    resolveCatchClauses();
                }
                foreach (Catch catchClause in mCatchClauses) {
                    catchClause.traverseAll(pAction);
                }
            }
            StatementBlockScope scope = getFinallyStatementBlockScope();
            if (scope != null) {
                scope.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }

        /**
         * Represents <code>catch</code> clauses.
         * <p>
         * The JSOM abstraction of <i>catch</i> clauses looks like
         * <pre>
         *     catch(localModifierList type variableDeclaratorIdentifier)
         * </pre>
         * 
         * @author Dieter Habelitz
         */
        public class AST2Catch : AST2JSOM, Catch
        {

            // The 'catch' clause's parameter declaration.
            private FormalParameterDeclaration mParameter = null;
            // The 'catch' clause's statement block scope.
            private StatementBlockScope mBlockScope = null;

            /**
             * Constructor.
             * 
             * @param pTree  The tree node representing a <code>synchronized</code> 
             *               statement.
             * @param pTokenRewriteStream  The token stream the token of the stated
             *                             tree node belongs to.            
             */
            public AST2Catch(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
                : base(pTree, JSOMType.STATEMENT_BLOCK_ELEMENT_HELPER,pTokenRewriteStream)
            {

                if (pTree.Type != JavaTreeParser.CATCH)
                {
                    throw new ArgumentException(
                            CommonErrorMessages.getInvalidArgumentValueMessage(
                                    "pTree.Type == " + pTree.Type,
                                    "pTree"));
                }
            }

            /**
             * Returns the <i>character in line</i> position of the <code>catch
             * </code> clause.
             * 
             * @return  The <i>character in line</i> position of the <code>catch
             *          </code> clause.
             */
            public int getCharPositionInLine()
            {

                return getTreeNode().CharPositionInLine;
            }

            /**
             * Returns the formal parameter of the <code>catch</code> clause.
             * 
             * @return  The formal parameter of the <code>catch</code> clause.
             */
            public FormalParameterDeclaration getFormalParameter()
            {

                if (mParameter == null)
                {
                    mParameter = new AST2FormalParameterDeclaration((AST2JSOMTree)
                            getTreeNode().GetChild(0), getTokenRewriteStream());
                }

                return mParameter;
            }

            /**
             * Returns the line number of the <code>catch</code> clause.
             * 
             * @return  The line number of the <code>catch</code> clause.
             */
            public int getLineNumber()
            {

                return getTreeNode().Line;
            }

            /**
             * Returns the <code>catch</code> clause's statement block scope, i.e. 
             * the content of the <code>catch</code> block.
             * 
             * @return  The <code>catch</code> clause's statement block scope.
             */
            public StatementBlockScope getStatementBlockScope()
            {

                if (mBlockScope == null)
                {
                    mBlockScope = new AST2StatementBlockScope((AST2JSOMTree)
                            getTreeNode().GetChild(1),
                            Owner.CATCH_CLAUSE,
                            getTokenRewriteStream());
                }

                return mBlockScope;
            }

            /**
             * Calls the methods <code>pAction.performAction(...)</code> and <code>
             * pAction.actionPerformed(...)</code> with <code>this</code> as 
             * argument.
             * <P>
             * Furthermore, if <code>pAction.isMemberTraversionEnabled() == true
             * </code> all <code>JSOM</code> members that belong to <code>this
             * </code> will be traversed by calling the <code>traverseAll(...)
             * </code> method on these members with <code>pAction</code> as 
             * argument. This will be done after the <code>
             * pAction.performAction(...)</code> call but before the <code>
             * pAction.actionPerformed(...)</code> call.
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
                    getFormalParameter().traverseAll(pAction);
                    getStatementBlockScope().traverseAll(pAction);
                }
                pAction.actionPerformed(this);
            }
        }
    }
}