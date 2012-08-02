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
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/**
 * This <code>CommonTypeDeclaration</code> represents a class type declaration.
 * 
 * @author Dieter Habelitz
 */
public class AST2ClassDeclaration : AST2CommonTypeDeclaration, ClassDeclaration {

    // The optional generic type parameters.
    private List<AST2GenericTypeParameter> mGenericTypeParams;
    // An optional ':' clause.
    private AST2ClassExtendsClause mExtendsClause; 
    // An optional ',' clause.
    private AST2ImplementsClause mImplementsClause;
    // This class' top level scope.
    private AST2ClassTopLevelScope mScope;
    
    // The class tree children that must get handled by this class.
    private AST2JSOMTree mGenericTypeParamTree;
    private AST2JSOMTree mExtendsClauseTree;
    private AST2JSOMTree mImplementsClauseTree;
    private AST2JSOMTree mScopeTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a class declaration.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassDeclaration(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        : this(pTree, JSOMType.CLASS_DECLARATION, pTokenRewriteStream)
    {
    }
        
    /**
     * Constructor.
     * <p>
     * If classes derived from this class should be recognized by another JSOM
     * type than <code>JSOMType.CLASS_DECLARATION</code> they must call this
     * constructor via the explicit super constructor call and state the
     * appropriate <code>JSOMType</code> explicitly.
     * 
     * @param pTree  The tree node representing a class declaration.
     * @param pJSOMType  The JSOM type of the new instance.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2ClassDeclaration(
            AST2JSOMTree pTree, JSOMType pJSOMType, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, pJSOMType, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.CLASS) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        int childOffset = 2;
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(childOffset);
        if (child.Type == JavaTreeParser.GENERIC_TYPE_PARAM_LIST) {
            mGenericTypeParamTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        if (child.Type == JavaTreeParser.EXTENDS_CLAUSE) {
            mExtendsClauseTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        if (child.Type == JavaTreeParser.IMPLEMENTS_CLAUSE) {
            mImplementsClauseTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        mScopeTree = child;
    }

    /**
     * Returns the <code>:</code> clause.
     * 
     * @return  The <code>:</code> clause or <code>null</code> if <code> 
     *          this</code> has no <code>:</code> clause.
     */
    public ClassExtendsClause getExtendsClause()
    {
        
        if (mExtendsClauseTree == null) {
            return null; // There's no ':' clause.
        }
        if (mExtendsClause == null) {
            mExtendsClause = new AST2ClassExtendsClause(
                    mExtendsClauseTree, getTokenRewriteStream());
        }
        
        return mExtendsClause;
    }
    
    /**
     * Returns a list of the generic type parameters stated with the interface
     * header.
     * <p>
     * Calling this method equals an <code>getGenericTypeParameters(null)</code>
     * call.
     * 
     * @see #getGenericTypeParameters(List)
     *  
     * @return  A list of the generic type parameters. If no generic type 
     *          parameters have been declared <code>null</code> will be 
     *          returned.
     */
    public List<GenericTypeParameter> getGenericTypeParameters() {
        
        return getGenericTypeParameters(null);
    }

    /**
     * Returns a list of the generic type parameters stated with the interface
     * header.
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type
     *                parameters will be added to this list and this list object
     *                will be returned. Otherwise a new list will be created for
     *                the result.
     *  
     * @return  A list of the generic type parameters. If no generic type 
     *          parameters have been declared <code>null</code> will be 
     *          returned, even if the argument <code>pList</code> isn't <code>
     *          null</code>.
     */
    public List<GenericTypeParameter> getGenericTypeParameters(
            List<GenericTypeParameter> pList) {
        
        if (mGenericTypeParamTree == null) {
            return null; // There're no generic type parameters.
        }
        if (mGenericTypeParams == null) {
            resolveGenericTypeParameters();
        }
        List<GenericTypeParameter> result = pList;
        if (result == null) {
            result = new List<GenericTypeParameter>(
                                                    mGenericTypeParams.Count);
        }
        result.AddRange(mGenericTypeParams);
        
        return result;
    }

    /**
     * Returns the <code>,</code> clause.
     * 
     * @return  The <code>,</code> clause or <code>null</code> if
     *          <code>this</code> has no <code>,</code> clause.
     */
    public ImplementsClause getImplementsClause() {
        
        if (mImplementsClauseTree == null) {
            return null; // There's no ',' clause.
        }
        if (mImplementsClause == null) {
            mImplementsClause = new AST2ImplementsClause(
                    mImplementsClauseTree, getTokenRewriteStream());
        }
        
        return mImplementsClause;
    }

    /**
     * Returns the content of the class declaration body.
     * 
     * @return  The content of the class declaration body.
     */
    public ClassTopLevelScope getTopLevelScope()
    {
        
        if (mScope == null) {
            mScope = new AST2ClassTopLevelScope(
                    mScopeTree, this, getTokenRewriteStream());
        }
        
        return mScope;
    }
    
    /**
     * Tells if the class declaration has an <code>:</code> clause.
     * 
     * @return  <code>true</code> if the class declaration has an <code>:
     *          </code> clause.
     */
    public bool hasExtendsClause() {
        
        return mExtendsClauseTree != null;
    }
    
    /**
     * Tells if the class declaration has at least one generic type parameter.
     * 
     * @return  <code>true</code> if the class declaration has at least one
     *          generic type parameter.
     */
    public bool hasGenericTypeParameter() {
        
        return mGenericTypeParamTree != null;
    }
    
    /**
     * Tells if the class declaration has an <code>,</code> clause.
     * 
     * @return  <code>true</code> if the class declaration has an <code>
     *          ,</code> clause.
     */
    public bool hasImplementsClause() {
        
        return mImplementsClauseTree != null;
    }

    /**
     * Removes the <code>:</code> clause from <code>this</code>.
     * <p>
     * If <code>this</code> has no <code>:</code> clause this method does
     * nothing. 
     *                                                       
     * @return  The removed <code>:</code> clause or <code>null</code> if
     *          <code>this</code> has no <code>:</code> clause.                                     
     * 
     * __TEST__                                         
     */
    public ClassExtendsClause removeExtendsClause() {
        
        // Ensure that an existing : clause gets resolved.
        ClassExtendsClause result = null;
        if (mExtendsClauseTree != null) {
            // Ensure that an existing : clause gets resolved.
            result = getExtendsClause();
            removeTreeNode(mExtendsClause);            
            mExtendsClauseTree = null;
            mExtendsClause = null;
        }
        
        return result;
    }
    
    /**
     * Resolves the optional generic type parameters.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * generic type parameter.
     */
    private void resolveGenericTypeParameters() {
        
        mGenericTypeParams = 
            AST2GenericTypeParameter.resolveGenericTypeParameterList(
                    mGenericTypeParamTree, getTokenRewriteStream());
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
        
        traverseAll(pAction, false);
    }
    
    /**
     * @see #traverseAll(TraverseAction)
     * 
     * @param pAction  A user define action.
     * @param pTraverseMembersOnly  If <code>true</code> the methods <code>
     *                              pAction.performAction()</code> and 
     *                              <code>pAction.actionPerformed</code> will 
     *                              not be called by this method.
     */
    protected void traverseAll(
            TraverseAction pAction, bool pTraverseMembersOnly) {
        
        if (!pTraverseMembersOnly) {
            pAction.performAction(this);
        }
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            if (mGenericTypeParamTree != null) {
                if (mGenericTypeParams == null) {
                    resolveGenericTypeParameters();
                }
                foreach (GenericTypeParameter param in mGenericTypeParams) {
                    param.traverseAll(pAction);
                }
            }
            ClassExtendsClause extendsClause = (ClassExtendsClause) getExtendsClause();
            if (extendsClause != null) {
                extendsClause.traverseAll(pAction);
            }
            ImplementsClause implementsClause = (ImplementsClause) getImplementsClause();
            if (implementsClause != null) {
                implementsClause.traverseAll(pAction);
            }
            getTopLevelScope().traverseAll(pAction);
        }
        if (!pTraverseMembersOnly) {
            pAction.actionPerformed(this);
        }
    }
}
}