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

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{

/** 
 * This <code>JSOM</code> type represents an annotation, i.e. something like
 * <pre>
 *     &#0064;AnnotationTypeId(anyAnnotationInitializers)
 * </pre>
 * were the annotation initializers are optional, of course.
 * 
 * @author Dieter Habelitz
 */
public class AST2Annotation : AST2JSOM, Annotation {
    
    /*
     * The annotation's identifier.
     */
    private QualifiedIdentifier mIdentifier;
    /*
     * The optional initializers.
     */
    private List<AnnotationInitializer> mInitializers;
    
    private bool mHasInitializers = false;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an annotation.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2Annotation(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        : base(pTree, JSOMType.ANNOTATION, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.AT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (   pTree.ChildCount == 2 
            && pTree.GetChild(1).ChildCount == 1) {
            mHasInitializers = true;
        }
    }
    
    /**
     * Returns the <i>character in line</i> position of the <code>'@'</code>
     * character.
     * 
     * @return  The <i>character in line</i> position of the <code>'@'</code> 
     *          character.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the annotation's identifier.
     * 
     * @return  The annotation's identifier.
     */
    public QualifiedIdentifier getIdentifier() {
        
        if (mIdentifier == null) {
            mIdentifier = new AST2QualifiedIdentifier((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mIdentifier;
    }
    
    /**
     * Returns a list of the annotation's initializers.
     * <p>
     * Calling this method equals an <code>getInitializers(null)</code>
     * call.
     * 
     * @see #getInitializers(List)
     *  
     * @return  A list of the annotation's initializers. If the annotation has 
     *          no initializer <code>null</code> will be returned.
     */
    public List<AnnotationInitializer> getInitializers() {
        
        return getInitializers(null);
    }
    
    /**
     * Returns a list of the annotation's initializers.
     * 
     * @param  pList  If this argument isn't <code>null</code> the initializers
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the annotation's initializers. If the annotation has 
     *          no initializer <code>null</code> will be returned, even if the
     *          argument <code>pList</code> isn't <code>null</code>.
     */
    public List<AnnotationInitializer> getInitializers(
            List<AnnotationInitializer> pList) {
        
        if (!mHasInitializers) {
            return null; // No initializer available.
        }
        if (mInitializers == null) {
            resolveInitializers();
        }
        List<AnnotationInitializer> result = pList;
        if (result == null) {
            result = new List<AnnotationInitializer>(mInitializers.Count);
        }
        result.AddRange(mInitializers);
        
        return result;
    }
    
    /**
     * Returns the line number of the <code>'@'</code> character.
     * 
     * @return  The line number of the <code>'@'</code> character.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }
    
    /**
     * Tells if the annotation has any initializers.
     * 
     * @return  <code>true</code> if the annotations has at least one
     *          initializer.
     */
    public bool hasInitializer() {
        
        return mHasInitializers;
    }

    /**
     * Resolves the optional initializers.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * initializer.
     */
    private void resolveInitializers() {
        
        AST2JSOMTree initRoot = (AST2JSOMTree)getTreeNode().GetChild(1).GetChild(0);
        if (initRoot.Type == JavaTreeParser.ANNOTATION_INIT_KEY_LIST) {
            int size = initRoot.ChildCount;
            mInitializers = new List<AnnotationInitializer>(size);
            for (int offset = 0; offset < size; offset++) {
                mInitializers.Add(new AST2AnnotationInitializer((AST2JSOMTree)
                        initRoot.GetChild(offset), getTokenRewriteStream()));
            }
        } else {
            // It's an annotation element value.
            mInitializers = new List<AnnotationInitializer>(1);
            mInitializers.Add(new AST2AnnotationInitializer((AST2JSOMTree)
                    initRoot.GetChild(0), getTokenRewriteStream()));
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
            getIdentifier().traverseAll(pAction);
            if (mHasInitializers) {
                if (mInitializers == null) {
                    resolveInitializers();
                }
                foreach (AnnotationInitializer initializer in mInitializers) {
                    initializer.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}