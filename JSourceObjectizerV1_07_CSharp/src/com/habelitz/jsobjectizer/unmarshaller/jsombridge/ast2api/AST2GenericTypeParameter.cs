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
 * This <code>JSOM</code> represents a generic type parameter as can be stated
 * within a declaration's generic type parameter list.
 * <p>
 * Note that there's no public constructor to crate instances of this class.
 * Instead, the static method 
 * {@link #resolveGenericTypeParameterList(AST2JSOMTree, TokenRewriteStream)} 
 * must be used that resolves a generic type parameter list and that returns
 * instances of this class representing the generic type parameters stated 
 * within a certain generic type parameter list.
 * 
 * @author Dieter Habelitz
 */
public class AST2GenericTypeParameter : AST2JSOM , GenericTypeParameter {
    
    private List<com.habelitz.jsobjectizer.jsom.api.Type> mBoundTypes;
    
    private bool mHasBoundType = false;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a generic type parameter.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    private AST2GenericTypeParameter(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        : base(pTree, JSOMType.GENERIC_TYPE_PARAMETER, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.IDENT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (pTree.ChildCount == 1) {
            mHasBoundType = true;
        }
    }

    /**
     * Returns a list of the bound types.
     * <p>
     * Example: for the generic type parameter <code>&lt;T : A & B & C&gt;
     * </code> this method would return the types for <code>A</code>, <code>B
     * </code> and <code>C</code> respectively.
     * <p>
     * Calling this method equals an <code>getBoundTypes(null)</code>
     * call.
     * 
     * @see #getBoundTypes(List)
     *  
     * @return  A list of the bound types. If no bound type has been stated
     *          <code>null</code> will be returned.
     */
    public List<com.habelitz.jsobjectizer.jsom.api.Type> getBoundTypes() {
        
        return getBoundTypes(null);
    }
    
    /**
     * Returns a list of the bound types.
     * <p>
     * Example: for the generic type parameter <code>&lt;T : A & B & C&gt;
     * </code> this method would return the types for <code>A</code>, <code>B
     * </code> and <code>C</code> respectively.
     * 
     * @param  pList  If this argument isn't <code>null</code> the types will be 
     *                added to this list and this list object will be returned. 
     *                Otherwise a new list will be created for the result.
     *  
     * @return  A list of the bound types. If no bound type has been stated
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    public List<com.habelitz.jsobjectizer.jsom.api.Type> getBoundTypes(List<com.habelitz.jsobjectizer.jsom.api.Type> pList) {
        
        if (!mHasBoundType) {
            return null; // There're no bound types.
        }
        if (mBoundTypes == null) {
            resolveBoundTypes();
        }
        List<com.habelitz.jsobjectizer.jsom.api.Type> result = pList;
        if (result == null) {
            result = new List<com.habelitz.jsobjectizer.jsom.api.Type>(mBoundTypes.Count);
        }
        result.AddRange(mBoundTypes);
        
        return result;
    }

    /**
     * Returns the <i>character in line</i> position where the generic type 
     * identifier starts.
     * 
     * @return  The <i>character in line</i> position where the generic type 
     * identifier starts.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the line number of the generic type identifier.
     * 
     * @return  The line number of the generic type identifier.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the type identifier of the generic type.
     * 
     * @return  The type identifier of the generic type.
     */
    public String getTypeIdentifier() {
        
        return getTreeNode().Text;
    }
    
    /**
     * Tells if the generic type parameter has at least one bound type.
     * 
     * @return  <code>true</code> if the generic type parameter has at least one
     *          bound type.
     */
    public bool hasBoundType() {
        
        return mHasBoundType;
    }    

    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new generic type parameter identifier.
     * 
     * @return  The old identifier.
     */
    public String setTypeIdentifier(String pNewIdentifier) {

        AST2JSOMTree root = (AST2JSOMTree)getTreeNode();
        String oldId = root.Text;
        root.Token.Text = pNewIdentifier;
        
        return oldId;
    }

    /**
     * Resolves the optional bound types.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * bound type.
     */
    private void resolveBoundTypes() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(0);
        int size = tree.ChildCount;
        mBoundTypes = new List<com.habelitz.jsobjectizer.jsom.api.Type>(size);
        for (int offset = 0; offset < size; offset++) {
            mBoundTypes.Add(new AST2Type((AST2JSOMTree)
                    tree.GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Resolves a generic type parameter list.
     * 
     * @param pTree  The generic type parameter list's root node.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     * 
     * @return  A list containing the generic type parameters.
     */
    public static List<AST2GenericTypeParameter> 
    resolveGenericTypeParameterList(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {
        
        if (pTree.Type != JavaTreeParser.GENERIC_TYPE_PARAM_LIST) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        int size = pTree.ChildCount;
        List<AST2GenericTypeParameter> result = 
            new List<AST2GenericTypeParameter>(size);
        for (int offset = 0; offset < size; offset++) {
            result.Add(new AST2GenericTypeParameter((AST2JSOMTree)
                    pTree.GetChild(offset), pTokenRewriteStream));
        }
        
        return result;
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
            if (mHasBoundType) {
                if (mBoundTypes == null) {
                    resolveBoundTypes();
                }
                foreach (com.habelitz.jsobjectizer.jsom.api.Type type in mBoundTypes) {
                    type.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}