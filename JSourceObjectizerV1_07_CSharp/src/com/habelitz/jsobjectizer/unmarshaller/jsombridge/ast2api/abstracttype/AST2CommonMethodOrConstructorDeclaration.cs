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
using System.Reflection;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using com.habelitz.core;
using com.habelitz.jsobjectizer;
using com.habelitz.jsobjectizer.jsom;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.abstracttype;
using com.habelitz.jsobjectizer.jsom.util;
using com.habelitz.jsobjectizer.unmarshaller;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype {

/**
 * This class is the base type for all method or constructor declarations.
 * 
 * @author Dieter Habelitz
 */
public abstract class AST2CommonMethodOrConstructorDeclaration 
    : AST2JSOM, CommonMethodOrConstructorDeclaration {

    // The optional modifier list.
    private ModifierList mModifierList;
    // Optional generic type parameters.
    private List<AST2GenericTypeParameter> mGenericTypeParams;
    // The formal parameter list.
    private FormalParameterList mParameters;
    // An optional 'throws' clause.
    private ThrowsClause mThrowsClause;
   
    // Some child trees fetched from the tree passed to the constructor.
    private AST2JSOMTree mModifierListTree;
    private AST2JSOMTree mGenericTypeParamTree;
    private AST2JSOMTree mParamsTree;
    private AST2JSOMTree mThrowsClauseTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing any method or constructor
     *               declaration. Note that it's up to derived classes to check 
     *               that the given tree node is of a valid type.
     * @param pJSOMType  One of the <code>JSOMType.???</code> constants defined
     *                   by the interface <code>JSOM</code>.              
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2CommonMethodOrConstructorDeclaration(AST2JSOMTree pTree, JSOMType pJSOMType, TokenRewriteStream pTokenRewriteStream)
        :base(pTree, pJSOMType, pTokenRewriteStream)
    {
        // All types of method or constructor declarations start with a modifier
        // list (that may be empty).
        mModifierListTree = (AST2JSOMTree)pTree.GetChild(0);
        // Then there may follow a generic type parameter list.
        int childOffset = 1;
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(childOffset);
        if (child.Type == JavaTreeParser.GENERIC_TYPE_PARAM_LIST) {
            mGenericTypeParamTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        // Get the formal parameter list.
        while (child.Type != JavaTreeParser.FORMAL_PARAM_LIST) {
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        if (child.ChildCount > 0) {
            mParamsTree = child;
        }
        // Finally check if there is a 'throws' clause
        childOffset++;
        int numberOfChildren = pTree.ChildCount;
        while (childOffset < numberOfChildren) {
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
            if (child.Type == JavaTreeParser.THROWS_CLAUSE) {
                mThrowsClauseTree = child;
                break;
            }
            childOffset++;
        }
    }
    
    /**
     * Adds a stated (simple) annotation to <code>this</code>.
     * 
     * @param pAnnotationIdentifier  The annotation's identifier. Note that this 
     *                               identifier must not start with the 
     *                               character <code>@</code> because is will be
     *                               added by this method automatically.
     * 
     * @  if parsing fails.
     * 
     * @deprecated  JSourceObjectizer 2.xx feature; should be seen as 
     *              experimental.
     * 
     * __TEST__                                         
     */
    [Obsolete]
    public void addAnnotation(Char[] pAnnotationIdentifier) {
        
        StringBuilder sbModifierList = 
                        new StringBuilder('@').Append(pAnnotationIdentifier);
        ModifierList oldModifierList = getModifiers();
        if (oldModifierList != null) {
            sbModifierList.Append(' ')
                          .Append(oldModifierList.getMarshaller().ToString());
        }
        List<String> errorMessages = new List<String>();
        try {
            AST2ModifierList modifierList = 
                getUnmarshaller().unmarshalAST2ModifierList(
                        sbModifierList.ToString(), errorMessages);
            if (modifierList != null) {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Check if error messages have been emitted by the parser.
                mModifierListTree = (AST2JSOMTree)modifierList.getTreeNode();
                mModifierList = modifierList;
                getTreeNode().SetChild(0, mModifierListTree);
            }
        } catch (JSourceUnmarshallerException e) {
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "Parsing the annotation '" + pAnnotationIdentifier +
                    "' failed.");
        }
        // Update the token stream.
        // TODO  After implementation of adding JSOMs to JSOMs:
        //       Move this stuff to 'AST2JSOM'.
        TokenRewriteStream stream = getTokenRewriteStream();
        int rightOffset = getTreeNode().TokenStartIndex;
        int leftOffset = rightOffset - 1;
        List<IToken> indentationTokens = new List<IToken>();
        while (   leftOffset > 0 
               && !Constants.NL.Equals(stream.Get(leftOffset).Text)) {
            indentationTokens.Add(stream.Get(leftOffset));
            leftOffset--;
        }
        sbModifierList.Remove(0, sbModifierList.Length);
        for (int offset = indentationTokens.Count - 1; offset >= 0; offset--) {
            stream.InsertBefore(rightOffset, indentationTokens[offset].Text);
        }
        sbModifierList.Append('@').Append(pAnnotationIdentifier)
                      .Append(Constants.NL);
        stream.InsertBefore(rightOffset, sbModifierList.ToString());
    }

    /**
     * Returns the method's formal parameter list.
     * 
     * @return  The method's formal parameter list or <code>null</code> if no
     *          parameters have been stated.
     */
    public FormalParameterList getFormalParameters() {
        
        if (mParamsTree == null) {
            return null; // No parameters available.
        }
        if (mParameters == null) {
            mParameters = new AST2FormalParameterList(mParamsTree, getTokenRewriteStream());
        }
        
        return mParameters;
    }
    
    /**
     * Returns a list of generic type parameters that may have been stated left 
     * from the method's return type.
     * <p>
     * Example: <code>public &lt;T&gt; T foo(T argument) {...}</code>
     * <p>
     * For the example above this method would return a list that contains just 
     * one generic type parameter representing the type <code>T</code> stated 
     * by <code>&lt;T&gt;</code>.
     * <p>
     * Calling this method equals an <code>getGenericTypeParameters(null)</code>
     * call.
     * 
     * @see #getGenericTypeParameters(List)
     * 
     * @return  A list of generic type parameters. If there is no generic type
     *          parameter <code>null</code> will be returned. 
     */
    public List<GenericTypeParameter> getGenericTypeParameters() {
        
        return getGenericTypeParameters(null);
    }

    /**
     * Returns a list of generic type parameters that may have been stated left 
     * from the method's return type.
     * <p>
     * Example: <code>public &lt;T&gt; T foo(T argument) {...}</code>
     * <p>
     * For the example above this method would return a list that contains just 
     * one generic type parameter representing the type <code>T</code> stated 
     * by <code>&lt;T&gt;</code>.
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type
     *                parameters will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of generic type parameters. If there is no generic type
     *          parameter <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
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
     * Returns the method's or constructor's modifiers including annotations.
     * 
     * @return  A list of modifiers or <code>null</code> if the method or
     *          constructor declaration has no modifiers.
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
     * Returns the method's or constructor's modifiers including annotations.
     * 
     * @return  A list of modifiers which is empty if the method or constructor 
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
     * Returns the method's <code>throws</code> clause.
     * 
     * @return  The method's <code>throws</code> clause or <code>null</code> if
     *          no <code>throws</code> clause has been stated.
     */
    public ThrowsClause getThrowsClause() {
        
        if (mThrowsClauseTree == null) {
            return null; // There's no ':' clause.
        }
        if (mThrowsClause == null) {
            mThrowsClause = new AST2ThrowsClause(
                    mThrowsClauseTree, getTokenRewriteStream());
        }
        
        return mThrowsClause;
    }
    
    /**
     * Tells if <code>this</code> has at least one formal parameter
     * declaration.
     *  
     * @return  <code>true</code> if <code>this</code> has at least one formal
     *          parameter declaration.
     */
    public bool hasFormalParameter() {
        
        return mParamsTree != null;
    }
    
    /**
     * Tells if <code>this</code> at least one generic type parameter has been
     * stated.
     * 
     * @see #getGenericTypeParameters() for more details about generic type
     *                                  parameters.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type parameter.
     */
    public bool hasGenericTypeParameter() {
        
        return mGenericTypeParamTree != null;
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
     * Tells if <code>this</code> has a <code>throws</code> clause.
     * 
     * @return  <code>true</code> if <code>this</code> has <code>throws</code>
     *          clause.
     */
    public bool hasThrowsClause() {
        
        return mThrowsClauseTree != null;
    }
    
    /**
     * Removes the formal parameter list.
     * <p>
     * If <code>this</code> has no formal parameters an implementation of this
     * method is expected to do nothing than return <code>null</code>.
     * 
     * @return  The removed formal parameter list or <code>null</code> if <code>
     *          this hasn't formal parameters.
     */
    public FormalParameterList removeFormalParameters() {
        
        FormalParameterList paramList = getFormalParameters();
        if (paramList == null) {
            return null;
        }
        mParameters = null;
        AST2JSOMTree rootTree = (AST2JSOMTree)getTreeNode();
        int childCount = rootTree.ChildCount;
        for (int offset = 0; offset < childCount; offset++) {
            if (rootTree.GetChild(offset) == mParamsTree) {
                rootTree.DeleteChild(offset);
                break;
            }
        }
        // Update the token stream.
        // For that remove all tokens between the opening and closing brackets
        // but excluding the brackets, of course.
        TokenRewriteStream stream = getTokenRewriteStream();
        stream.Delete(mParamsTree.TokenStartIndex + 1, 
                      mParamsTree.TokenStopIndex - 1);
        mParamsTree = null;
        
        return paramList;
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
            if (mGenericTypeParamTree != null) {
                if (mGenericTypeParams == null) {
                    resolveGenericTypeParameters();
                }
                foreach (GenericTypeParameter param in mGenericTypeParams) {
                    param.traverseAll(pAction);
                }
            }
            FormalParameterList formalParams = getFormalParameters();
            if (formalParams != null) {
                formalParams.traverseAll(pAction);
            }
            ThrowsClause throwsClause = getThrowsClause();
            if (throwsClause != null) {
                throwsClause.traverseAll(pAction);
            }
        }
    }
}
}