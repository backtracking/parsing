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
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{

/**
 * This <code>JSOM</code> type represents the top level scope of an annotation
 * declaration.
 * 
 * @author Dieter Habelitz
 */
public class AST2AnnotationTopLevelScope : AST2CommonTypeTopLevelScope, AnnotationTopLevelScope {

    // The method declarations from this scope.
    private List<AST2AnnotationMethodDeclaration> mMethodDecls;
    
    /*
     * Must be set to 'false' by the method declaration resolving code if there
     * are no method declarations.
     */
    private bool mHasMethodDeclarations = true;

    // The owner of 'this'.
    private AST2AnnotationDeclaration mOwner;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pOwner  The annotation declaration the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2AnnotationTopLevelScope(
            AST2JSOMTree pTree, AST2AnnotationDeclaration pOwner, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ANNOTATION_TOP_LEVEL_SCOPE, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.ANNOTATION_TOP_LEVEL_SCOPE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mOwner = pOwner;
    }
    
    /**
     * Returns a certain annotation method declaration.
     * 
     * @param pMethodIdentifier  The identifier of the annotation method.
     *  
     * @return  An annotation method declaration or <code>null</code> if no 
     *          method declaration exists for the stated identifier.
     */
    public AnnotationMethodDeclaration getMethodDeclaration(
            String pMethodIdentifier) {
        
        if (!mHasMethodDeclarations) {
            return null; // No method declarations available.
        }
        if (mMethodDecls == null) {
            // Just enforce resolving the method declarations and call this
            // method again.
            getMethodDeclarations();
            if (!mHasMethodDeclarations) {
                return null; // No method declarations available.
            }
        }
        foreach (AST2AnnotationMethodDeclaration methodDecl in mMethodDecls) {
            if (methodDecl.getIdentifier().Equals(pMethodIdentifier)) {
                return methodDecl;
            }
        }
        
        return null;
    }

    /**
     * Returns a list of this annotation scope's annotation method declarations.
     * <p>
     * Calling this method equals an <code>getMethodDeclarations(null)</code>
     * call.
     * 
     * @see #getMethodDeclarations(List)
     *  
     * @return  A list of this annotation scope's annotation method 
     *          declarations. If there are no annotation method declarations
     *          <code>null</code> will be returned.
     */
    public List<AnnotationMethodDeclaration> getMethodDeclarations() {
        
        return getMethodDeclarations(null);
    }
    
    /**
     * Returns a list of this annotation scope's annotation method declarations.
     * 
     * @param  pList  If this argument isn't <code>null</code> the annotation
     *                method declarations will be added to this list and this 
     *                list object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of this annotation scope's annotation method 
     *          declarations. If there are no annotation method declarations
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    public List<AnnotationMethodDeclaration> getMethodDeclarations(
            List<AnnotationMethodDeclaration> pList) {
        
        if (!mHasMethodDeclarations) {
            return null; // No method declarations available.
        }
        if (mMethodDecls == null) {
            resolveMethodDeclarations();
            if (!mHasMethodDeclarations) {
                return null; // No method declarations available.
            }
        }
        
        List<AnnotationMethodDeclaration> result = pList;
        if (result == null) {
            result = new List<AnnotationMethodDeclaration>(
                    mMethodDecls.Count);
        }
        result.AddRange(mMethodDecls);
        
        return result;
    }
    
    /**
     * Returns the annotation declaration this top level scope belongs to.
     * 
     * @return  The annotation declaration this top level scope belongs to.
     */
    public AnnotationDeclaration getOwner() {
        
        return mOwner;
    }

    /**
     * Tells if <code>this</code> has a certain annotation method declaration.
     * 
     * @param pMethodIdentifier  A method identifier.
     * 
     * @return  <code>true</code> if an annotation method declaration exists for
     *          the stated identifier.
     */
    public bool hasMethodDeclaration(String pMethodIdentifier) {
        
        return getMethodDeclaration(pMethodIdentifier) != null;
    }
    
    /**
     * Tells if <code>this</code> has at least one annotation method
     * declaration.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one 
     *          annotation method declaration.
     */
    public bool hasMethodDeclaration() {
        
        if (mMethodDecls == null && mHasMethodDeclarations) {
            resolveMethodDeclarations();
        }
        
        return mHasMethodDeclarations;
    }

    /**
     * Resolves the annotation method declarations belong to <code>this</code>.
     * <p>
     * If there is no annotation method declaration <code>mHasMethodDeclarations
     * </code> will be set to <code>false</code>.
     */
    private void resolveMethodDeclarations() {

        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int numberOfMethodDecls = rootNode.ChildCount;
        if (numberOfMethodDecls == 0) {
            mHasMethodDeclarations = false;
            return;
        }
        int size = 0;
        for (int offset = 0; offset < numberOfMethodDecls; offset++) {
            if (   rootNode.GetChild(offset).Type 
                == JavaTreeParser.ANNOTATION_METHOD_DECL) {
                size++;
            }
        }
        if (size == 0) {
            mHasMethodDeclarations = false;
            return;
        }
        mMethodDecls = new List<AST2AnnotationMethodDeclaration>(size);
        for (int offset = 0; offset < numberOfMethodDecls; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            if (child.Type == JavaTreeParser.ANNOTATION_METHOD_DECL) {
                mMethodDecls.Add(
                        new AST2AnnotationMethodDeclaration(
                                child, getTokenRewriteStream()));
            }
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
    public override void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            if (hasMethodDeclaration()) {
                foreach (AnnotationMethodDeclaration declaration in mMethodDecls) {
                    declaration.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}