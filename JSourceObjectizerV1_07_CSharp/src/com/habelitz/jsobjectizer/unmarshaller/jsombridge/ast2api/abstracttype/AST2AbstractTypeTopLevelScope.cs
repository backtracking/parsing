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
using com.habelitz.jsobjectizer.jsom;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.abstracttype;
using com.habelitz.jsobjectizer.jsom.util;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype
{

/**
 * This <code>JSOM</code> type supports all those things that can exist within
 * the scope of all kinds of abstract type declarations (i.e. abstract classes 
 * or interfaces).
 * <p>
 * This implementation handles method declarations but no method definitions of
 * an unmarshalled type declaration. Method definitions must be handled by 
 * derived classes.
 * <p>
 * 
 * @author Dieter Habelitz
 */
public abstract class AST2AbstractTypeTopLevelScope  : 
    AST2CommonTypeTopLevelScope , AbstractTypeTopLevelScope {

    // The method declarations from this scope.
    private List<MethodDeclaration> mMethodDecls;
    
    /*
     * Must be set to 'false' by the method declaration resolving code if there
     * are no method declarations.
     */
    private bool mHasMethodDeclarations = true;

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an interface or class type top 
     *               level scope. Note that it's up to derived classes to check 
     *               that the given tree node is of a valid type.
     * @param pJSOMType  One of the <code>JSOMType.???</code> constants defined
     *                   by the interface <code>JSOM</code>.              
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2AbstractTypeTopLevelScope(
            AST2JSOMTree pTree, JSOMType pJSOMType, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, pJSOMType, pTokenRewriteStream)
    {
        
        //base(pTree, pJSOMType, pTokenRewriteStream);
    }

    /**
     * Returns a certain method declaration.
     * <p>
     * Note that method definitions will be ignored by this method, i.e. only
     * abstract methods declarations will be considered.
     * 
     * @param pMethodIdentifier  The identifier of the method.
     *  
     * @return  A method declaration or <code>null</code> if no method 
     *          declaration exists for the stated identifier.
     */
    public MethodDeclaration getMethodDeclaration(String pMethodIdentifier) {
        
        if (!mHasMethodDeclarations) {
            return null; // No method declarations available.
        }
        if (mMethodDecls == null) {
            resolveMethodDeclarations();
            if (!mHasMethodDeclarations) {
                return null; // No method declarations available.
            }
        }
        foreach (MethodDeclaration methodDecl in mMethodDecls) {
            if (methodDecl.getIdentifier().Equals(pMethodIdentifier)) {
                return methodDecl;
            }
        }
        
        return null;
    }
    
    /**
     * Returns a list of this scope's method declarations.
     * <p>
     * Note that method definitions will be ignored by this method, i.e. only
     * abstract methods declarations will be considered.
     * <p>
     * Calling this method equals an <code>getMethodDeclarations(null)</code>
     * call.
     * 
     * @see #getMethodDeclarations(List)
     *  
     * @return  A list of this scope's method declarations. If there are no
     *          method declarations <code>null</code> will be returned. 
     */
    public List<MethodDeclaration> getMethodDeclarations() {
        
        return getMethodDeclarations(null);
    }
    
    /**
     * Returns a list of this scope's method declarations.
     * <p>
     * Note that method definitions will be ignored by this method, i.e. only
     * abstract methods declarations will be considered.
     * 
     * @param  pList  If this argument isn't <code>null</code> the method
     *                declarations will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of this scope's method declarations. If there are no
     *          method declarations <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>. 
     */
    public List<MethodDeclaration> getMethodDeclarations(
            List<MethodDeclaration> pList) {
        
        if (!mHasMethodDeclarations) {
            return null; // No method declarations available.
        }
        if (mMethodDecls == null) {
            resolveMethodDeclarations();
            if (!mHasMethodDeclarations) {
                return null; // No method declarations available.
            }
        }
        
        List<MethodDeclaration> result = pList;
        if (result == null) {
            result = new List<MethodDeclaration>(mMethodDecls.Count);
        }
        result.AddRange(mMethodDecls);
        
        return result;
    }
    
    /**
     * Tells if <code>this</code> has a certain method declaration.
     * <p>
     * Note that method definitions will be ignored by this method, i.e. only
     * abstract methods declarations will be considered.
     * 
     * @param pMethodIdentifier  A method identifier.
     * 
     * @return  <code>true</code> if a method declaration exists for the stated
     *          identifier.
     */
    public bool hasMethodDeclaration(String pMethodIdentifier) {
        
        return getMethodDeclaration(pMethodIdentifier) != null;
    }
    
    /**
     * Tells if <code>this</code> has at least one method declaration.
     * <p>
     * Note that method definitions will be ignored by this method, i.e. only
     * abstract methods declarations will be considered.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one method
     *          declaration.
     */
    public bool hasMethodDeclaration() {
        
        if (mMethodDecls == null && mHasMethodDeclarations) {
            resolveMethodDeclarations();
        }

        return mHasMethodDeclarations;
    }

    /**
     * Resolves the method declarations that belong to <code>this</code>.
     * <p>
     * If there is no method declaration <code>mHasMethodDeclarations</code> 
     * will be set to <code>false</code>.
     */
    private void resolveMethodDeclarations() {
    
        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int childCount = rootNode.ChildCount;
        if (childCount == 0) {
            mHasMethodDeclarations = false;
            return;
        }
        mMethodDecls = new List<MethodDeclaration>();
        // Abstract method declarations mustn't have a block scope.
        for (int offset = 0; offset < childCount; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            int type = child.Type;
            if (   (   type == JavaTreeParser.FUNCTION_METHOD_DECL
                    || type == JavaTreeParser.VOID_METHOD_DECL)
                &&     child.GetChild(child.ChildCount - 1).Type
                    != JavaTreeParser.BLOCK_SCOPE) {
                mMethodDecls.Add(new AST2MethodDeclaration(
                                            child, getTokenRewriteStream()));
            }
        }
        if (mMethodDecls.Count > 0) {
            mMethodDecls.TrimExcess();
        } else {
            mMethodDecls = null;
            mHasMethodDeclarations = false;
        }
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
    public override void traverseAll(TraverseAction pAction) {
        
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            if (hasMethodDeclaration()) {
                foreach (MethodDeclaration declaration in mMethodDecls) {
                    declaration.traverseAll(pAction);
                }
            }
        }
    }
}
}