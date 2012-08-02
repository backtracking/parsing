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
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSourceObjectizerInternalException = com.habelitz.jsobjectizer.JSourceObjectizerInternalException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api.statement;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using CommonJSOMMessages = com.habelitz.jsobjectizer.resource.resbundle.CommonJSOMMessages;
using JSourceUnmarshallerException = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshallerException;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using JavaTreeParser = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated.JavaTreeParser;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using AST2LocalClassDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2LocalClassDeclaration;
using AST2LocalVariableDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2LocalVariableDeclaration;
using AST2Statement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2Statement;
using AST2StatementBlockElement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2StatementBlockElement;
using TreeNodeValidator = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.utils.TreeNodeValidator;
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;
using StatementBlockElementContainer = com.habelitz.jsobjectizer.jsom.api.statement.abstracttype.StatementBlockElementContainer;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.abstracttype {
/**
 * Contains and deals with all those <code>JSOM</code> elements that represent
 * statement block elements and that belong to a certain local statement scope.
 * <p>
 * This class bundles the functionality for all the content a statement block 
 * scope can have, i.e. statements and local variable/type declarations, but
 * that may also occur within local scopes that behave like statement block
 * scopes but aren't such scopes from a grammatical point of view (think about 
 * the statement scope of <code>case/default</code> labels of a <code>switch
 * </code> statement.
 * 
 * @author Dieter Habelitz
 */
public class AST2StatementBlockElementContainerImpl : AST2JSOM, StatementBlockElementContainer {

    // The statement block elements.
    private List<AST2StatementBlockElement> mElements;
    private TreeNodeValidator mTreeNodeValidator;

    /**
     * Constructor.
     * <p>
     * A new object assumes that all children of the stated tree node represent
     * statement block elements. If this is not the case for a certain tree node
     * an appropriate filter must be added to this via 
     * {@link #setChildTreeNodeValidator(TreeNodeValidator)} or the constructor.
     *  Alternatively the constructor
     * {@link #AST2StatementBlockElementContainerImpl(AST2JSOMTree, TreeNodeValidator, com.habelitz.jsobjectizer.jsom.JSOM.JSOMType, TokenRewriteStream)}
     * could be used, of course.
     * 
     * @see #AST2StatementBlockElementContainerImpl(AST2JSOMTree, TreeNodeValidator, com.habelitz.jsobjectizer.jsom.JSOM.JSOMType, TokenRewriteStream)
     * @see #setChildTreeNodeValidator(TreeNodeValidator)
     * 
     * @param pTree  The root node of the statement block elements.
     * @param pJSOMType  If a class : this class the JSOM type of the
     *                   extending class should be passed for this argument
     *                   which will be passed forward to the super type of this
     *                   class. Otherwise this argument should be <code>null
     *                   </code> - in this case the constant 
     *                   <code>JSOM.JSOMType.XTRA</code> will be passed to the
     *                   super type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2StatementBlockElementContainerImpl(
            AST2JSOMTree pTree, JSOMType? pJSOMType,
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, pJSOMType != null ? pJSOMType : JSOMType.XTRA, pTokenRewriteStream)
    {
        
        
    }

    /**
     * Constructor.
     * <p>
     * A new object assumes that all children of the stated tree node represent
     * statement block elements. This constructor calls the method
     * {@link #setChildTreeNodeValidator(TreeNodeValidator)} automatically with
     * the passed validator as parameter.
     * 
     * @param pTree  The root node of the statement block elements.
     * @param pTreeNodeValidator  The validator the method
     *                            {@link #setChildTreeNodeValidator(TreeNodeValidator)}
     *                            should be called with.
     * @param pJSOMType  If a class : this class the JSOM type of the
     *                   extending class should be passed for this argument
     *                   which will be passed forward to the implementation of
     *                   the type <code>JSOM</code>. Otherwise this argument
     *                   should be <code>null</code> - in this case the constant
     *                   <code>JSOM.JSOMType.XTRA</code> will be passed to the 
     *                   <code>JSOM</code> super type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2StatementBlockElementContainerImpl(
            AST2JSOMTree pTree, TreeNodeValidator pTreeNodeValidator, 
            JSOMType pJSOMType, TokenRewriteStream pTokenRewriteStream) 
        : this(pTree, pJSOMType, pTokenRewriteStream)
    {
        
        setChildTreeNodeValidator(pTreeNodeValidator);
    }
    
    /**
     * Returns the <i>character in line</i> position of the <i>root</i> the 
     * statement elements belong to.
     * 
     * @return  The <i>character in line</i> position of the <i>root</i> the 
     *          statement elements belong to.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }

    /**
     * Returns the line number of the <i>root</i> the statement elements belong 
     * to.
     * 
     * @return  The line number of the <i>root</i> the statement elements 
     *          belong to.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#getLocalClassDeclaration(java.lang.String)
     */
    public LocalClassDeclaration getLocalClassDeclaration(String pClassName) {
        
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        foreach (StatementBlockElement elem in mElements) {
            if (elem.isStatementBlockElementType(
                                        ElementType.LOCAL_CLASS_DECLARATION)) {
                LocalClassDeclaration decl = (LocalClassDeclaration) elem;
                if (decl.getIdentifier().Equals(pClassName)) {
                    return decl;
                }
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
        
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<LocalClassDeclaration> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<LocalClassDeclaration>();
        } else {
            oldSize = result.Count;
        }
        foreach (StatementBlockElement elem in mElements) {
            if (elem.isStatementBlockElementType(
                    ElementType.LOCAL_CLASS_DECLARATION)) {
                result.Add((LocalClassDeclaration) elem);
            }
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
                
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<LocalVariableDeclaration> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<LocalVariableDeclaration>();
        } else {
            oldSize = result.Count;
        }
        foreach (StatementBlockElement elem in mElements) {
            if (elem.isStatementBlockElementType(
                    ElementType.LOCAL_VARIABLE_DECLARATION)) {
                result.Add((LocalVariableDeclaration) elem);
            }
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
        
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<StatementBlockElement> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<StatementBlockElement>();
        } else {
            oldSize = result.Count;
        }
        foreach (StatementBlockElement elem in mElements) {
            if (elem.isStatementBlockElementType(pStatementBlockElementType)) {
                result.Add(elem);
            }
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
        
        if (pStatementBlockElementTypes == null) {
            return null;
        }
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<StatementBlockElement> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<StatementBlockElement>();
        } else {
            oldSize = result.Count;
        }
        foreach (StatementBlockElement elem in mElements) {
            foreach (ElementType elemType in pStatementBlockElementTypes) {
                if (elemType == null) {
                    continue;
                }
                if (elem.isStatementBlockElementType(elemType)) {
                    result.Add(elem);
                    break; // Continue with the outer loop.
                }
            }
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

        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<StatementBlockElement> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<StatementBlockElement>();
        } else {
            oldSize = result.Count;
        }
        result.AddRange(mElements);
        
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
        
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        List<Statement> result = pList;
        int oldSize = 0;
        if (result == null) {
            result = new List<Statement>();
        } else {
            oldSize = result.Count;
        }
        foreach (StatementBlockElement elem in mElements) {
            if (elem.isStatement()) {
                result.Add((Statement) elem) ;
            }
        }
        
        return result.Count > oldSize ? result : null;
    }
    
    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement()
     */
    public bool hasStatementBlockElement() {

        if (mElements == null) {
            resolveStatementBlockElements();
        }

        return mElements.Count > 0;
    }

    /**
     * @see com.habelitz.jsobjectizer.jsom.api.statement.base.StatementBlockElementContainer#hasStatementBlockElement(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement)
     */
    public bool hasStatementBlockElement(
            StatementBlockElement pStatementBlockElement) {

        if (mElements == null) {
            resolveStatementBlockElements();
        }
        foreach (StatementBlockElement element in mElements) {
            if (element == pStatementBlockElement) {
                return true;
            }
        }
        
        return false;
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
        
        AST2StatementBlockElement removedElement = null;
        // If the elements haven't been resolve the passed statement block
        // element can't belong to this.
        if (mElements != null) {
            int offset = mElements.IndexOf((AST2StatementBlockElement)pStatementBlockElement);
            if (offset != -1) {
                removedElement = mElements[offset];
                mElements.RemoveAt(offset);
            }
        }
        if (removedElement == null) {
            // The stated statement block element doesn't belong to 'this'.
            throw new JSourceObjectizerException(
                CommonJSOMMessages.getStatementBlockElementDoesNotExistMessage(
                        pStatementBlockElement.getJSOMType().ToString() + " (" + 
                        pStatementBlockElement.getLineNumber() + ':' + 
                        pStatementBlockElement.getCharPositionInLine() + ")", 
                        getLineNumber() + ":" + getCharPositionInLine()));
            
        }
        // If still here a matching statement block element has been found.
        if (pRemovingOfSurroundingHiddenTokensEnabled) {
            removeTreeNode(
                    removedElement, 
                    ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING, 
                    ChangeTokenBorder.NEXT_NEWLINE_INCLUDING);

        } else {
            removeTreeNode(removedElement);
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
        
        List<String> errorMessages = new List<String>();
        AST2StatementBlockElement newElement = null;
        try {
            newElement =
                getUnmarshaller().unmarshalAST2StatementBlockElement(
                        pNewElement, errorMessages);
        } catch (JSourceUnmarshallerException jsue) {
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "Parsing the statement block element '" + pNewElement + 
                    "' failed.", jsue);
        }
        if (pNewElement != null) {
            if (mElements == null) {
                resolveStatementBlockElements();
            }
            int offset = mElements.IndexOf((AST2StatementBlockElement)pOldElement);
            if (offset >= 0) {
                AST2StatementBlockElement oldParamDecl = mElements[offset];
                mElements[offset] = newElement;
                // Note that the offset of the statement block element within
                // the list of 'StatementBlockElement' object may not match the
                // offset of the root tree's child list.
                ITree root = getTreeNode();
                ITree oldChild = oldParamDecl.getTreeNode();
                int childCount = root.ChildCount;
                bool childFound = false;
                for (offset = 0; offset < childCount; offset++) {
                    if (oldChild == root.GetChild(offset)) {
                        root.SetChild(offset, newElement.getTreeNode());
                        getTokenRewriteStream().Replace(
                                oldChild.TokenStartIndex, 
                                oldChild.TokenStopIndex, pNewElement);
                        childFound = true;
                        break;
                    }
                }
                if (!childFound) {
                    // TODO  Internationalize the message.
                    throw new JSourceObjectizerInternalException(
                            "No tree node found for the statement block " +
                            "element '" + 
                            pOldElement.getMarshaller().ToString() + "' at " +
                            pOldElement.getLineNumber() + ':' +
                            pOldElement.getCharPositionInLine() + '.');
                }
            } else {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Replace message by an internationalized message.
                throw new JSourceObjectizerException(
                        "The old statement block element '" + 
                        pOldElement.getMarshaller().ToString() + 
                        "' passed as argument doesn't belong to the " +
                        "statement block scope.");
            }
        } else {
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "Unmarshalling the new statement block element '" + 
                    pNewElement + "' failed.");
        }
    }

    /**
     * Resolves the statement block elements that belong to <code>this</code>.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * statement block element.
     */
    private void resolveStatementBlockElements() {

        AST2JSOMTree tree = (AST2JSOMTree) getTreeNode();
        int childCount = tree.ChildCount;
        mElements = new List<AST2StatementBlockElement>(childCount);
        for (int offset = 0; offset < childCount; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)tree.GetChild(offset);
            if (   mTreeNodeValidator != null
                && !mTreeNodeValidator.isValidTreeNode(child)) {
                continue;
            }
            if (child.Type == JavaTreeParser.VAR_DECLARATION) {
                mElements.Add(new AST2LocalVariableDeclaration(
                                            child, getTokenRewriteStream()));
            } else if (child.Type == JavaTreeParser.CLASS) {
                mElements.Add(new AST2LocalClassDeclaration(
                                            child, getTokenRewriteStream()));
            } else {
                // Everything else is a statement.
                mElements.Add(AST2Statement.resolveStatement(
                                            child, getTokenRewriteStream()));
            }
        }
    }
    
    /**
     * Add a new statement block element validator to <code>this</code>.
     * 
     * If not all children of the root tree node represented by <code>this
     * </code> are statement block elements the <i>invalid</i> children must be
     * filtered, otherwise resolving the statement block elements from the
     * children will fail.
     * <p>
     * Note that the validator (i.e. the filter) must be set before the
     * statement block elements get resolved. To ensure this it's best practice
     * to set the validator immediately after <code>this</code> has been 
     * created. Alternatively the constructor
     * {@link #AST2StatementBlockElementContainerImpl(AST2JSOMTree, TreeNodeValidator, com.habelitz.jsobjectizer.jsom.JSOM.JSOMType, TokenRewriteStream)}
     * could be used, of course.
     * 
     * @see #AST2StatementBlockElementContainerImpl(AST2JSOMTree, TreeNodeValidator, com.habelitz.jsobjectizer.jsom.JSOM.JSOMType, TokenRewriteStream)
     * 
     * @param pTreeNodeValidator  The validator that should be used the filter
     *                            the child nodes or <code>null</code> to
     *                            remove/deactivate a set validator.
     */
    public void setChildTreeNodeValidator(
            TreeNodeValidator pTreeNodeValidator) {
        
        mTreeNodeValidator = pTreeNodeValidator;
    }

    /**
     * Traverses all statement block elements that belong to <code>this</code>.
     * <p>
     * Note that there's no <code>pAction.performAction(...)</code> or <code>
     * pAction.actionPerformed(...)</code> method for this class. Furthermore
     * it's up to the caller to check if the statement block elements should be
     * traversed or not, i.e. if member traversing is enabled, for instance.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public virtual void traverseAll(TraverseAction pAction) {
        
        // Traverse the statement block elements.
        if (mElements == null) {
            resolveStatementBlockElements();
        }
        foreach (StatementBlockElement elem in mElements) {
            elem.traverseAll(pAction);
        }
    }
}
}