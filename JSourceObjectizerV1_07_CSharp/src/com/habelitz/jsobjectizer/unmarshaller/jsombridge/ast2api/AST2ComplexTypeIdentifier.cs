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

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {
/**
 * This <code>JSOM</code> type represents a complex type identifier including
 * the generic type arguments that may follow the type identifier.
 * 
 * @author Dieter Habelitz
 */
public class AST2ComplexTypeIdentifier 
    : AST2JSOM, ComplexTypeIdentifier {
    
    /*
     * The generic type arguments.
     */
    private List<AST2GenericTypeArgument> mGenericTypeArguments;

    private bool mHasGenericTypeArg = false;

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type identifier.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ComplexTypeIdentifier(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        : base(pTree, JSOMType.COMPLEX_TYPE_IDENTIFIER, pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.IDENT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        
        if (pTree.ChildCount == 1) {
            mHasGenericTypeArg = true;
        }
    }

    /**
     * Returns the <i>character in line</i> position where the type identifier
     * starts.
     * 
     * @return  The <i>character in line</i> position where the type identifier
     * starts.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns a list of the generic type arguments that may follow the complex 
     * type identifier.
     * 
     * Formal example: for a type identifier like
     * <pre>
     *     AnyType<GenType1, GenType2>
     * </pre>
     * the returned list would contain the two <code>GenericTypeArgument</code> 
     * objects representing <code>GenType1</code> and <code>GenType2</code> 
     * respectively. 
     * <p>
     * Calling this method equals an <code>getGenericTypeArguments(null)</code>
     * call.
     * 
     * @see #getGenericTypeArguments(List)
     *  
     * @return  A list of the generic type arguments that may follow the complex 
     *          type identifier. If no generic type argument has been stated 
     *          <code>null</code> will be returned.
     */
    public List<GenericTypeArgument> getGenericTypeArguments() {
        
        return getGenericTypeArguments(null);
    }
    
    /**
     * Returns a list of the generic type arguments that may follow the complex 
     * type identifier.
     * 
     * Formal example: for a type identifier like
     * <pre>
     *     AnyType<GenType1, GenType2>
     * </pre>
     * the returned list would contain the two <code>GenericTypeArgument</code> 
     * objects representing <code>GenType1</code> and <code>GenType2</code> 
     * respectively. 
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type
     *                arguments will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of the generic type arguments that may follow the complex 
     *          type identifier. If no generic type argument has been stated 
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    public List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList) {
        
        if (!mHasGenericTypeArg) {
            return null;
        }
        if (mGenericTypeArguments == null) {
            resolveGenericTypeArguments();
        }
        List<GenericTypeArgument> result = pList;
        if (result == null) {
            result = new List<GenericTypeArgument>(
                                                mGenericTypeArguments.Count);
        }
        result.AddRange(mGenericTypeArguments);
        
        return result;
    }
    
    /**
     * Returns the complex type identifier.
     * 
     * @return  The complex type identifier.
     */
    public String getIdentifier() {
                
        return getTreeNode().Text;
    }

    /**
     * Returns the line number of the type identifier.
     * 
     * @return  The line number of the type identifier.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Tells if at least one generic type argument has been stated with the type
     * identifier.
     * 
     * @return  <code>true</code> if at least one generic type argument has been
     *          stated.
     */
    public bool hasGenericTypeArgument() {
        
        return mHasGenericTypeArg;
    }

    /**
     * Resolves the optional generic type arguments.
     * <p>
     * Note that it's up to the caller to ensure there's at least one generic
     * type argument.
     */
    private void resolveGenericTypeArguments() {
        
        mGenericTypeArguments =
            AST2GenericTypeArgument.resolveGenericTypeArgumentList((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
    }

    /**
     * Resolves a qualified type identifier.
     * 
     * @param pTree  The qualified type identifier's root node.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     * 
     * @return  A list containing the identifiers from the qualified type
     *          identifier.
     */
    public static List<AST2ComplexTypeIdentifier> 
    resolveQualifiedTypeIdentifier(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {
        
        if (pTree.Type != JavaTreeParser.QUALIFIED_TYPE_IDENT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        int size = pTree.ChildCount;
        List<AST2ComplexTypeIdentifier> result = 
            new List<AST2ComplexTypeIdentifier>(size);
        for (int offset = 0; offset < size; offset++) {
            result.Add(new AST2ComplexTypeIdentifier((AST2JSOMTree)
                    pTree.GetChild(offset), pTokenRewriteStream));
        }
        
        return result;
    }    
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new complex type identifier.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {

        AST2JSOMTree root = (AST2JSOMTree)getTreeNode();
        String oldId = root.Text;
        root.Token.Text = pNewIdentifier;
        
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
            if (mHasGenericTypeArg) {
                if (mGenericTypeArguments == null) {
                    resolveGenericTypeArguments();
                }
                foreach (GenericTypeArgument arg in mGenericTypeArguments) {
                    arg.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}