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
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;
using SwitchLabel = com.habelitz.jsobjectizer.jsom.api.statement.SwitchLabel;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using CommonJSOMMessages = com.habelitz.jsobjectizer.resource.resbundle.CommonJSOMMessages;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;
using AST2StatementBlockElementContainerImpl = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.abstracttype.AST2StatementBlockElementContainerImpl;
using TreeNodeValidator = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.utils.TreeNodeValidator;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {
/**
 * This <code>Statement</code> type represents a <code>switch</code> statement.
 * <p>
 * This class also defines an inner class <code>SwitchLabel</code> representing 
 * <code>case</code> and <code>default</code> clauses.
 * <p>
 * <b>Problem:</b> <code>SwitchLabel</code> : an implementation of <code>
 * StatementBlockElementContainer</code> and therefore each <code>SwitchLabel
 * </code> knows about the statements and local class and variable declarations
 * that have been stated following this <code>SwitchLabel</code> up to the next
 * one or up to the end of the <code>switch</code> statement for the last <code>
 * SwitchLabel</code>. However, this doesn't actually match the visibility of 
 * the content in the real Java world because <code>SwitchLabel</code>s haven't
 * their own local scopes - there's only one local scope bound to the <code>
 * switch</code> statement.    
 * <b>Solution:</b> This class , <code>
 * StatementBlockElementContainer</code> that hasn't any content because it just
 * operates on the statement block element content of the <code>SwitchLabel
 * </code>s instead.  
 *  
 * @author Dieter Habelitz
 */
public class AST2SwitchStatement : AST2Statement , SwitchStatement {

    // The 'switch' expression.
    private Expression mExpression;
    // The switch block labels.
    private List<SwitchLabel> mLabels;
    
    private bool mHasSwitchLabels = true;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a <code>switch</code> statement.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2SwitchStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ElementType.SWITCH_STATEMENT, pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.SWITCH) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (pTree.GetChild(1).ChildCount == 0) {
            mHasSwitchLabels = false;
        }
    }
    
    /**
     * Returns the <code>switch</code> expression.
     * 
     * @return  The <code>switch</code> expression.
     */
    public Expression getExpression() {
        
        if (mExpression == null) {
            mExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(0).GetChild(0),
                    getTokenRewriteStream());
        }
        
        return mExpression;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclaration(java.lang.String)
     */
    public LocalClassDeclaration getLocalClassDeclaration(String pClassName) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        foreach (SwitchLabel label in mLabels) {
            LocalClassDeclaration classDecl =
                label.getLocalClassDeclaration(pClassName);
            if (classDecl != null) {
                return classDecl;
            }
        }
        
        return null;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclarations()
     */
    public List<LocalClassDeclaration> getLocalClassDeclarations() {
        
        return getLocalClassDeclarations(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclarations(java.util.List)
     */
    public List<LocalClassDeclaration> getLocalClassDeclarations(
            List<LocalClassDeclaration> pList) {
                                                    
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<LocalClassDeclaration> result = pList;
        if (result == null) {
            result = new List<LocalClassDeclaration>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getLocalClassDeclarations(result);
        }
        
        return result.Count > oldSize ? result : null;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalVariableDeclarations()
     */
    public List<LocalVariableDeclaration> getLocalVariableDeclarations() {
        
        return getLocalVariableDeclarations(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalVariableDeclarations(java.util.List)
     */
    public List<LocalVariableDeclaration> getLocalVariableDeclarations(
            List<LocalVariableDeclaration> pList) {
                                            
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<LocalVariableDeclaration> result = pList;
        if (result == null) {
            result = new List<LocalVariableDeclaration>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getLocalVariableDeclarations(result);
        }
        
        return result.Count > oldSize ? result : null;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType) {
        
        return getSelectedStatementBlockElements(
                pStatementBlockElementType, null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType, java.util.List)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType, 
            List<StatementBlockElement> pList) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<StatementBlockElement> result = pList;
        if (result == null) {
            result = new List<StatementBlockElement>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getSelectedStatementBlockElements(
                    pStatementBlockElementType, result);
        }
        
        return result.Count > oldSize ? result : null;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType[])
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes) {
        
        return getSelectedStatementBlockElements(
                pStatementBlockElementTypes, null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType[], java.util.List)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes,
            List<StatementBlockElement> pList) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<StatementBlockElement> result = pList;
        if (result == null) {
            result = new List<StatementBlockElement>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getSelectedStatementBlockElements(
                    pStatementBlockElementTypes, result);
        }
        
        return result.Count > oldSize ? result : null;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatementBlockElements()
     */
    public List<StatementBlockElement> getStatementBlockElements() {
        
        return getStatementBlockElements(null);
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatementBlockElements(java.util.List)
     */
    public List<StatementBlockElement> getStatementBlockElements(
            List<StatementBlockElement> pList) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<StatementBlockElement> result = pList;
        if (result == null) {
            result = new List<StatementBlockElement>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getStatementBlockElements(result);
        }
        
        return result.Count > oldSize ? result : null;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatements()
     */
    public List<Statement> getStatements() {
        
        return getStatements(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatements(java.util.List)
     */
    public List<Statement> getStatements(List<Statement> pList) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<Statement> result = pList;
        if (result == null) {
            result = new List<Statement>();
        }
        int oldSize = result.Count;
        foreach (SwitchLabel label in mLabels) {
            label.getStatements(result);
        }
        
        return result.Count > oldSize ? result : null;
    }
    

    /**
     * Returns a list of the <code>case</code> and <code>default</code> clauses.
     * <p>
     * Calling this method equals an <code>getSwitchLabels(null)</code>
     * call.
     * 
     * @see #getSwitchLabels(List)
     *  
     * @return  A list of <code>case</code> and/or <code>default</code> clauses. 
     *          If there are no <code>case</code> and <code>default</code> 
     *          clauses <code>null</code> will be returned.
     */
    public List<SwitchLabel> getSwitchLabels() {
        
        return getSwitchLabels(null);
    }
    
    /**
     * Returns a list of the <code>case</code> and <code>default</code> clauses.
     * 
     * @param  pList  If this argument isn't <code>null</code> the <code>case
     *                </code> and <code>default</code> clauses will be added to 
     *                this list and this list object will be returned. Otherwise 
     *                a new list will be created for the result.  
     * 
     * @return  A list of <code>case</code> and/or <code>default</code> clauses. 
     *          If there are no <code>case</code> and <code>default </code> 
     *          clauses <code>null</code> will be returned, even if the argument
     *          <code>pList</code> isn't <code>null</code>.
     */
    public List<SwitchLabel> getSwitchLabels(List<SwitchLabel> pList) {
        
        if (!mHasSwitchLabels) {
            return null; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        List<SwitchLabel> result = pList;
        if (result == null) {
            result = new List<SwitchLabel>(mLabels.Count);
        }
        result.AddRange(mLabels);
        
        return result;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement()
     */
    public bool hasStatementBlockElement() {

        if (!mHasSwitchLabels) {
            return false; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        foreach (SwitchLabel label in mLabels) {
            if (label.hasStatementBlockElement()) {
                return true;
            }
        }
        
        return false;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement)
     */
    public bool hasStatementBlockElement(
            StatementBlockElement pStatementBlockElement) {
        
        if (!mHasSwitchLabels) {
            return false; // No switch labels available.
        }
        if (mLabels == null) {
            resolveSwitchLabels();
        }
        foreach (SwitchLabel label in mLabels) {
            if (label.hasStatementBlockElement(pStatementBlockElement)) {
                return true;
            }
        }
        
        return false;
    }

    /**
     * Tells if the <code>switch</code> statement has at least one <code>case
     * </code> or <code>default</code> clause.
     * 
     * @return  <code>true</code> if the <code>switch</code> statement has at 
     *          least one <code>case</code> or <code>default</code> clause.
     */
    public bool hasSwitchLabel() {
        
        return mHasSwitchLabels;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#removeStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement)
     *
     * __TEST__
     */
    public void removeStatementBlockElement(
            StatementBlockElement pStatementBlockElement) 
         {
        
        removeStatementBlockElement(pStatementBlockElement, false);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#removeStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement, bool)
     *
     * __TEST__
     */
    public void removeStatementBlockElement(
            StatementBlockElement pStatementBlockElement,
            bool pRemovingOfSurroundingHiddenTokensEnabled) 
         {
        
        bool elementRemoved = false;
        if (mHasSwitchLabels) {
            if (mLabels == null) {
                resolveSwitchLabels();
            }
            foreach (SwitchLabel label in mLabels) {
                if (label.hasStatementBlockElement(pStatementBlockElement)) {
                    label.removeStatementBlockElement(
                            pStatementBlockElement, 
                            pRemovingOfSurroundingHiddenTokensEnabled);
                    elementRemoved = true;
                    break;
                }
            }
        }
        if (!elementRemoved) {
            // The stated statement block element doesn't belong to 'this'.
            throw new JSourceObjectizerException(
                    CommonJSOMMessages
                        .getStatementBlockElementDoesNotExistMessage(
                            pStatementBlockElement.getJSOMType().ToString() + 
                            " (" + pStatementBlockElement.getLineNumber() + 
                            ':' + 
                            pStatementBlockElement.getCharPositionInLine() + 
                            ")", 
                            getLineNumber() + ":" + getCharPositionInLine()));
        }
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#replaceStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement, java.lang.String)
     *
     * __TEST__
     */
    public void replaceStatementBlockElement(
            StatementBlockElement pOldElement, String pNewElement)
         {
        
        bool elementReplaced = false;
        if (mHasSwitchLabels) {
            if (mLabels == null) {
                resolveSwitchLabels();
            }
            foreach (SwitchLabel label in mLabels) {
                if (label.hasStatementBlockElement(pOldElement)) {
                    label.replaceStatementBlockElement(
                            pOldElement, pNewElement);
                    elementReplaced = true;
                    break;
                }
            }
        }
        if (!elementReplaced) {
            // The stated statement block element doesn't belong to 'this'.
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "The old statement block element '" + 
                    pOldElement.getMarshaller().ToString() + 
                    "' passed as argument doesn't belong to the statement " +
                    "block scope.");
        }
    }

    /**
     * Resolves the <code>switch</code> labels.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * <code>switch</code> label.
     */
    private void resolveSwitchLabels() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(1);
        int size = tree.ChildCount;
        mLabels = new List<SwitchLabel>(size);
        for (int offset = 0; offset < size; offset++) {
            mLabels.Add(new AST2SwitchLabel((AST2JSOMTree)
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
            getExpression().traverseAll(pAction);
            if (mHasSwitchLabels) {
                if (mLabels == null) {
                    resolveSwitchLabels();
                }
                foreach (SwitchLabel switchLabel in mLabels) {
                    switchLabel.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }

    internal class SwitchLabelTreeNodeValidator : TreeNodeValidator
    {
        private AST2SwitchLabel mSwitchLabel;

        public SwitchLabelTreeNodeValidator(AST2SwitchLabel switchLabel)
        { 
            mSwitchLabel = switchLabel;
        }

        public bool isValidTreeNode(ITree pTree) 
        {
        
                ITree labelRoot = mSwitchLabel.getTreeNode();
                if (pTree.Parent != labelRoot) {
                    // TODO  Internationalize the message.
                    throw new ArgumentException(
                            "The passed tree (position " +
                            pTree.Line + ':' + 
                            pTree.CharPositionInLine + ") isn't a child " +
                            "of the switch label root node (position " +
                            labelRoot.Line + ':' +
                            labelRoot.CharPositionInLine + ").");
                }
                // The tree node isn't valid if it's the first child of a case
                // label root node.
                if (!mSwitchLabel.isDefaultClause() && 
                    labelRoot.GetChild(0) == pTree) {
                    return false;
                }
                
                return true;
            }
    }

    /**
     * Represents <code>case</code> and <code>default</code> clauses.
     * <p>
     * The difference between the two clauses is that a <code>case</code> clause
     * always has a constant expression whereas a <code>default</code> clause
     * never has one, of course. However, there's also the method <code>
     * isDefaultClause()</code> to find out if a certain clause is a <code>
     * default</code> clause or a <code>case</code> clause. 
     * 
     * @author Dieter Habelitz
     */
    public class AST2SwitchLabel : AST2StatementBlockElementContainerImpl, SwitchLabel {

        // The expression of a 'case' label.
        private Expression mCaseExpression;
        private bool mIsDefaultClause = true;
        private TreeNodeValidator mChildValidator;

        //private TreeNodeValidator mChildValidator = new TreeNodeValidator() {
        
        //    /**
        //     * Checks if the given tree node belongs to the statement list
        //     * instead of representing a case label's expression.
        //     * 
        //     * @param pTree  The tree node that should be checked.
        //     * 
        //     * @return  <code>true</code> if the given tree node belongs to a 
        //     *          default label or to the statement list of a case label.
        //     *          
        //     * @throws ArgumentException  if the passed tree isn't a
        //     *                                   child of <code>
        //     *                                   SwitchLabelImpl.this.getTreeNode()</code>.
        //     */
        //    public bool isValidTreeNode(ITree pTree) 
        //    {
                
                
        //        ITree labelRoot = AST2SwitchLabel.this.getTreeNode();
        //        if (pTree.Parent != labelRoot) {
        //            // TODO  Internationalize the message.
        //            throw new ArgumentException(
        //                    "The passed tree (position " +
        //                    pTree.Line + ':' + 
        //                    pTree.CharPositionInLine + ") isn't a child " +
        //                    "of the switch label root node (position " +
        //                    labelRoot.Line + ':' +
        //                    labelRoot.CharPositionInLine + ").");
        //        }
        //        // The tree node isn't valid if it's the first child of a case
        //        // label root node.
        //        if (   !AST2SwitchLabel.this.isDefaultClause()
        //            && labelRoot.GetChild(0) == pTree) {
        //            return false;
        //        }
                
        //        return true;
        //    }
        //};
        
        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a <code>case</code> or 
         *               <code>default<code> switch label.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2SwitchLabel(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
            : base(pTree, JSOMType.STATEMENT_BLOCK_ELEMENT_HELPER, pTokenRewriteStream)
        {
            mChildValidator = new SwitchLabelTreeNodeValidator(this);
            setChildTreeNodeValidator(mChildValidator);
            if (pTree.Type == JavaTreeParser.CASE) {
                mIsDefaultClause = false;
            } else if (pTree.Type != JavaTreeParser.DEFAULT) {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + 
                                pTree.Type, "pTree"));
            }
        }
        
        /**
         * Tells if <code>this</code> is a <code>default</code> clause.
         * 
         * @return  <code>true</code> if <code>this</code> is a <code>default
         *          </code> clause.
         */
        public bool isDefaultClause() {
            
            return mIsDefaultClause;
        }

        /**
         * Returns the expression of the <code>case<code> clause.
         * 
         * @return  The expression of the <code>case<code> clause or <code>null
         *          </code> if <code>this</code> is actually a <code>default
         *          </code> clause.
         */
        public Expression getExpression() {
            
            if (mIsDefaultClause) {
                return null;
            }
            if (mCaseExpression == null) {
                mCaseExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            }
            
            return mCaseExpression;
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
        public override void traverseAll(TraverseAction pAction) {
            
            pAction.performAction(this);
            if (pAction.isMemberTraversingEnabled()) {
                // Traverse the members.
                Expression expression = getExpression();
                if (expression != null) {
                    expression.traverseAll(pAction);
                }
                base.traverseAll(pAction);
            }
            pAction.actionPerformed(this);
        }
    }
}
}