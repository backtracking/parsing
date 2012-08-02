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
 * This <code>JSOM</code> type represents an annotation initializer.
 * <p>
 * An instance of this type corresponds to a key/value pair stated with an 
 * annotation.
 * 
 * @author Dieter Habelitz
 */
public class AST2AnnotationInitializer : AST2JSOM, AnnotationInitializer {
    
    private AnnotationElementValue mValue;
    
    private bool mIsDefaultInitializer = true;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an annotation identifier. This
     *               may be a root node of type <code>IDENT</code> for named
     *               initializers or any start/root node that matches an
     *               annotation element value.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2AnnotationInitializer(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ANNOTATION_INITIALIZER, pTokenRewriteStream)
    {
        
        int type = pTree.Type;
        if (type == JavaTreeParser.IDENT) {
            mIsDefaultInitializer = false;
        } else if (   type != JavaTreeParser.ANNOTATION_INIT_ARRAY_ELEMENT
                   && type != JavaTreeParser.AT
                   && type != JavaTreeParser.EXPR) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Returns the <i>character in line</i> position where the annotation 
     * initializer starts.
     * 
     * @return  The <i>character in line</i> position where the annotation 
     *          initializer starts.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the initializer's identifier.
     * 
     * @return  The initializer's identifier or <code>null</code> if <code>this
     *          </code> represents the default initializer, i.e. if the 
     *          annotation element key <code>value</code> hasn't been stated 
     *          explicitly within the Java source.
     */
    public String getIdentifier() {
        
        if (mIsDefaultInitializer) {
            return null; // 'this' represents the default initializer 'value'.
        }
        
        return getTreeNode().Text;
    }
    
    /**
     * Returns the line number of the annotation initializer.
     * 
     * @return  The line number of the annotation initializer.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the initialization value.
     * 
     * @return  The initialization value.
     */
    public AnnotationElementValue getValue() {
        
        if (mValue == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            if (!mIsDefaultInitializer) {
                tree = (AST2JSOMTree)tree.GetChild(0);
            }
            mValue = 
                new AST2AnnotationElementValue(tree, getTokenRewriteStream());
        }
        
        return mValue;
    }
    
    /**
     * Tells if an initializer identifier hasn't been stated, i.e. if <code>this
     * </code> represents the default annotation initializer <code>value</code>.
     * 
     * @return  <code>true</code> if <code>this</code> represents the default 
     *          annotation initializer <code>value</code>.
     */
    public bool isDefaultInitializer() {
        
        return mIsDefaultInitializer;
    }

    /**
     * Replaces the identifier of <code>this</code>.
     * <p>
     * If <code>this</code> represents the default initializer, i.e. if the 
     * annotation element key <code>value</code> hasn't been stated explicitly,
     * this method does nothing but return <code>null</code>.
     * 
     * @param pNewIdentifier  The new initializer identifier.
     * 
     * @return  The old identifier or <code>null</code> if <code>this</code>
     *          represents the default initializer.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        AST2JSOMTree root = (AST2JSOMTree) getTreeNode();
        if (root.Type == JavaTreeParser.IDENT) {
            String oldId = root.Text;
            root.Token.Text = pNewIdentifier;
            return oldId;
        }
        
        return null;
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
            getValue().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}