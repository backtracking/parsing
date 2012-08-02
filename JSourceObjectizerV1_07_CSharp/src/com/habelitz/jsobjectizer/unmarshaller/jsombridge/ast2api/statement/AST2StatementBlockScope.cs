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
using com.habelitz.jsobjectizer.jsom.api.statement;
using Owner = com.habelitz.jsobjectizer.jsom.api.statement.Owner;
using OwnerType = com.habelitz.jsobjectizer.jsom.api.OwnerType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using AST2StatementBlockElementContainerImpl = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.abstracttype.AST2StatementBlockElementContainerImpl;



namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {
/**
 * This <code>Statement</code> type represents a statement block scope, i.e. a 
 * method body, a compound statement and so on.
 * 
 * @author Dieter Habelitz
 */
public class AST2StatementBlockScope : AST2Statement, StatementBlockScope {

    // Because Java doesn't like multiple inheritance delegation must be used
    // here.
    private AST2StatementBlockElementContainerImpl mElementContainer;
    private readonly Owner mOwner;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a statement block scope.
     * @param pOwner  The appropriate constant of the owner of the new instance.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2StatementBlockScope(
            AST2JSOMTree pTree, Owner pOwner, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ElementType.STATEMENT_BLOCK_SCOPE, pTokenRewriteStream)
    {
        
        
        if (pTree.Type != JavaTreeParser.BLOCK_SCOPE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mElementContainer = new AST2StatementBlockElementContainerImpl(
                pTree, null, pTokenRewriteStream);
        mOwner = pOwner;
    }
    
    /**
     * Returns the statement block element container with the content of the 
     * statement block scope represented by <code>this</code>.
     * 
     * @return  The statement block element container with the content of the
     *          statement block scope represented by <code>this</code>.
     */
    public AST2StatementBlockElementContainerImpl getElementContainer() {
        
        return mElementContainer;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclaration(java.lang.String)
     */
    public LocalClassDeclaration getLocalClassDeclaration(String pClassName) {
        
        return mElementContainer.getLocalClassDeclaration(pClassName);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclarations()
     */
    public List<LocalClassDeclaration> getLocalClassDeclarations() {
        
        return mElementContainer.getLocalClassDeclarations(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclarations(java.util.List)
     */
    public List<LocalClassDeclaration> getLocalClassDeclarations(
            List<LocalClassDeclaration> pList) {
                                                    
        return mElementContainer.getLocalClassDeclarations(pList);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalVariableDeclarations()
     */
    public List<LocalVariableDeclaration> getLocalVariableDeclarations() {
        
        return mElementContainer.getLocalVariableDeclarations(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalVariableDeclarations(java.util.List)
     */
    public List<LocalVariableDeclaration> getLocalVariableDeclarations(
            List<LocalVariableDeclaration> pList) {
                                            
        return mElementContainer.getLocalVariableDeclarations(pList);
    }
    
    /**
     * Returns the appropriate constant for the owner <code>this</code> belongs 
     * to.
     * 
     * @return One of the <code>Owner</code> constants.
     */
    public Owner getOwner() {
        
        return mOwner;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType) {
        
        return mElementContainer.getSelectedStatementBlockElements(
                pStatementBlockElementType, null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType, java.util.List)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType, 
            List<StatementBlockElement> pList) {
        
        return mElementContainer.getSelectedStatementBlockElements(
                pStatementBlockElementType, pList);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType[])
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes) {
        
        return mElementContainer.getSelectedStatementBlockElements(
                pStatementBlockElementTypes, null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType[], java.util.List)
     */
    public List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes,
            List<StatementBlockElement> pList) {
        
        return mElementContainer.getSelectedStatementBlockElements(
                pStatementBlockElementTypes, pList);
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatementBlockElements()
     */
    public List<StatementBlockElement> getStatementBlockElements() {
        
        return mElementContainer.getStatementBlockElements(null);
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatementBlockElements(java.util.List)
     */
    public List<StatementBlockElement> getStatementBlockElements(
            List<StatementBlockElement> pList) {
        
        return mElementContainer.getStatementBlockElements(pList);
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatements()
     */
    public List<Statement> getStatements() {
        
        return mElementContainer.getStatements(null);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getStatements(java.util.List)
     */
    public List<Statement> getStatements(List<Statement> pList) {
        
        return mElementContainer.getStatements(pList);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement()
     */
    public bool hasStatementBlockElement() {

        return mElementContainer.hasStatementBlockElement();
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement)
     */
    public bool hasStatementBlockElement(
            StatementBlockElement pStatementBlockElement) {
        
        return mElementContainer.hasStatementBlockElement(
                pStatementBlockElement);
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#removeStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement)
     *
     * __TEST__
     */
    public void removeStatementBlockElement(
                                StatementBlockElement pStatementBlockElement) 
         {
        
        mElementContainer.removeStatementBlockElement(
                pStatementBlockElement, false);
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
        
        mElementContainer.removeStatementBlockElement(
                pStatementBlockElement, 
                pRemovingOfSurroundingHiddenTokensEnabled);
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#replaceStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement, java.lang.String)
     *
     * __TEST__
     */
    public void replaceStatementBlockElement(
            StatementBlockElement pOldElement, String pNewElement)
         {
        
        mElementContainer.replaceStatementBlockElement(
                pOldElement, pNewElement);
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
            mElementContainer.traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}