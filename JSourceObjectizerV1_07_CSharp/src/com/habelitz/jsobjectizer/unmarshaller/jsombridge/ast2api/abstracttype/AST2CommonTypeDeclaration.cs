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

using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using CommonTypeDeclaration = com.habelitz.jsobjectizer.jsom.api.abstracttype.CommonTypeDeclaration;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using AST2ModifierList = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ModifierList;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype
{
/**
 * This <code>JSOM</code> type is the base type for all kinds of type 
 * declarations, i.e. for classes, interfaces and so on.
 * 
 * This implementation handles the declaration type, the types identifier and
 * optional modifiers stated for the declaration. Everything else must be 
 * handled by derived classes.
 * 
 * @author Dieter Habelitz
 */
public class AST2CommonTypeDeclaration 
    : AST2JSOM , CommonTypeDeclaration {

    // The modifiers stated for the type.
    private ModifierList mModifierList;
    
    // Some of the type declaration's children.
    private AST2JSOMTree mIdentifierTree;
    private bool mHasModifier = true;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing any type declaration, i.e. a
     *               a class declaration, for example. Note that it's up to 
     *               derived classes to check that the given tree node is of a
     *               valid type.
     * @param pJSOMType  One of the <code>JSOMType.???</code> constants defined
     *                   by the interface <code>JSOM</code>.              
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2CommonTypeDeclaration(
        AST2JSOMTree pTree, JSOMType pJSOMType,
        TokenRewriteStream pTokenRewriteStream) : 
        base(pTree, pJSOMType, pTokenRewriteStream)
    {
        if (pTree.GetChild(0).ChildCount == 0) {
            mHasModifier = false;
        }
        mIdentifierTree = (AST2JSOMTree)getTreeNode().GetChild(1);
    }
    
    /**
     * Returns the <i>character in line</i> position where the type identifier 
     * starts.
     * 
     * @return  The <i>character in line</i> position where the type identifier
     *          starts.
     */
    public override int getCharPositionInLine() {
        
        return mIdentifierTree.CharPositionInLine;
    }
    
    /**
     * Returns the type declaration's identifier.
     * 
     * @return  The type declaration's identifier.
     */
    public String getIdentifier() {
        
        return mIdentifierTree.Text;
    }

    /**
     * Returns the line number of the type identifier.
     * 
     * @return  The line number of the type identifier.
     */
    public int getLineNumber() {
        
        return mIdentifierTree.Line;
    }

    /**
     * Returns the type modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the type
     *          declaration has no modifiers.
     * 
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    public ModifierList getModifiers() {
        
        if (!mHasModifier) {
            return null;
        }
        
        return getModifierList();
    }
    
    /**
     * Returns the type modifiers including annotations.
     * 
     * @return  A list of type modifiers which is empty if the type declaration 
     *          has no modifiers.
     */
    public ModifierList getModifierList() {
 
        if (mModifierList == null) {
            mModifierList = new AST2ModifierList((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mModifierList;
    }
    
    /**
     * Tells if <code>this</code> has at least one modifier or annotation.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          modifier or annotation.
     */
    public bool hasModifier() {
        
        return mHasModifier;
    }

    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new type declaration identifier.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        String oldId = mIdentifierTree.Text;
        mIdentifierTree.Token.Text = pNewIdentifier;
        
        return oldId;
    }

    /**
     * If <code>pAction.isMemberTraversionEnabled() == true</code> this method
     * traverses all <code>JSOM</code> members that belong to <code>this</code> 
     * by calling the <code>traverseAll(...)</code> method on these members with
     * <code>pAction</code> as argument.
     * <p>
     * Calling the methods <code>pAction.performAction(this)</code> and <code>
     * pAction.actionPerformed(this)</code> is up to classes that implement all 
     * the abstract methods not implemented by this class.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public virtual void traverseAll(TraverseAction pAction) {
        
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            getModifierList().traverseAll(pAction);
        }
    }
}
}