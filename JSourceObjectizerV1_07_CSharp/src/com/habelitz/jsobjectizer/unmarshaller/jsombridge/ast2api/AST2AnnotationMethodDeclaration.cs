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
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {
/**
 * This <code>JSOM</code> type represents an annotation method declarations.
 * 
 * @author Dieter Habelitz
 */
public class AST2AnnotationMethodDeclaration : AST2JSOM, AnnotationMethodDeclaration {

    // The optional modifier list.
    private ModifierList mModifierList;
    // The method's type (if it's not a void method).
    private Type mType;
    // The default value.
    private AnnotationElementValue mDefaultValue;
    
    // Some child trees fetched from the tree passed to the constructor.
    private AST2JSOMTree mModifierListTree;
    private AST2JSOMTree mIdentifierTree;
    private bool mHasDefaultValue = false;

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a method declaration.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2AnnotationMethodDeclaration(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ANNOTATION_METHOD_DECLARATION, pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.ANNOTATION_METHOD_DECL) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mModifierListTree = (AST2JSOMTree)pTree.GetChild(0);
        mIdentifierTree = (AST2JSOMTree)pTree.GetChild(2);
        if (pTree.ChildCount == 4) {
            mHasDefaultValue = true;
        }
    }
    
    /**
     * Returns the <i>character in line</i> position where the annotation method
     * identifier starts
     * 
     * @return  The <i>character in line</i> position where the annotation
     *          method identifier starts.
     */
    public int getCharPositionInLine() {
        
        return mIdentifierTree.CharPositionInLine;
    }
    
    /**
     * Returns the annotation method declaration's default value.
     * 
     * @return  The annotation method declaration's default value or <code>null
     *          </code> if no default value has been stated.
     */
    public AnnotationElementValue getDefaultValue() {
        
        if (!mHasDefaultValue) {
            return null; // There's no default value.
        }
        if (mDefaultValue == null) {
            mDefaultValue = new AST2AnnotationElementValue(
                    (AST2JSOMTree)getTreeNode().GetChild(3).GetChild(0), 
                    getTokenRewriteStream());
        }
        
        return mDefaultValue;
    }
    
    /**
     * Returns the annotation method's identifier.
     * 
     * @return  The annotation method's identifier.
     */
    public String getIdentifier() {

        return mIdentifierTree.Text;
    }

    /**
     * Returns the line number of the annotation method's identifier.
     * 
     * @return  The line number of the annotation method's identifier.
     */
    public int getLineNumber() {
        
        return mIdentifierTree.Line;
    }

    /**
     * Returns the method's modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the method
     *          declaration has no modifiers.
     * 
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    public ModifierList getModifiers() {
        
        if (mModifierListTree.ChildCount == 0) {
            return null;
        }
        
        return getModifierList();
    }
 
    /**
     * Returns the method's modifiers including annotations.
     * 
     * @see  #getModifiers()
     * 
     * @return  A list of type modifiers which is empty if the method 
     *          declaration has no modifiers.
     */
    public ModifierList getModifierList() {
 
        if (mModifierList == null) {
            mModifierList = new AST2ModifierList(
                    mModifierListTree, getTokenRewriteStream());
        }
        
        return mModifierList;
    }
    
    /**
     * Returns the annotation method's type.
     * 
     * @return  The annotation method's type.
     */
    public Type getType() {
        
        if (mType == null) {
            mType =
                new AST2Type((AST2JSOMTree)getTreeNode().GetChild(1), getTokenRewriteStream());
        }
        
        return mType;
    }
    
    /**
     * Tells if a default value has been stated for the annotation method
     * declaration.
     * 
     * @return  <code>true</code> if a default value has been stated for the 
     *          annotation method declaration.
     */
    public bool hasDefaultValue() {
        
        return mHasDefaultValue;
    }
    
    /**
     * Tells if <code>this</code> has at least one modifier or annotation.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          modifier or annotation.
     */
    public bool hasModifier() {
        
        return mModifierListTree.ChildCount > 0;
    }

    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new initializer identifier.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        String oldId = mIdentifierTree.Text;
        mIdentifierTree.Token.Text = pNewIdentifier;
        
        return oldId;
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
            getModifierList().traverseAll(pAction);
            getType().traverseAll(pAction);
            AnnotationElementValue defaultValue = getDefaultValue();
            if (defaultValue != null) {
                defaultValue.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}