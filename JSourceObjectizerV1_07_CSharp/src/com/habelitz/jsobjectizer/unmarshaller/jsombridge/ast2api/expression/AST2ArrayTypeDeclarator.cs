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
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2PrimitiveType = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2PrimitiveType;
using AST2QualifiedIdentifier = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2QualifiedIdentifier;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {

/**
 * This <code>PrimaryExpression</code> type represents an array type declarator.
 * <p>      
 * An array type declarator is something like
 *  <pre>
 *      AnyType[][][...
 *  </pre>
 * i.e. a type identifier, including qualified type identifiers and primitive 
 * types, followed by one ore more <code>'[]'</code> character sequences.
 * <p>
 * <b>Important note:</b> There's no explicit grammar rule for array type 
 * declarators with the grammar used by the JSourceObjectizer. However, this
 * class collects the array's type and all array declarators, i.e. all pairs of
 * opening/closing square brackets. As a result, if using the <code>
 * JSourceMmarshaller</code> on an instance of this class the marshaller will
 * just return a string representing the most right opening/closing square
 * brackets.
 *       
 * @author Dieter Habelitz
 */
public class AST2ArrayTypeDeclarator : AST2PrimaryExpression, ArrayTypeDeclarator {

    /*
     * 'true' if 'this' represents an array type declarator of a primitive type
     * array.
     */
    private bool mIsArrayOfPrimitiveType = true;
    /*
     * The number of array declarators.
     */
    private int mNumberOfArrayDeclarators = 1; // Must have 1+ declarators.
    /*
     * The primitive type for the cases where 'this' represents an array type 
     * declarator of a primitive type array
     */
    private PrimitiveType mPrimitiveType;
    /*
     * The primitive type for the cases where 'this' represents an array type 
     * declarator of a object type array
     */
    private QualifiedIdentifier mQualifiedIdentifier;
    /*
     * Remember the tree that states the array type. 
     */
    private AST2JSOMTree mTypeTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an array type declarator.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ArrayTypeDeclarator(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.ARRAY_TYPE_DECLARATOR, pTokenRewriteStream)
    {

        if (pTree.Type != JavaTreeParser.ARRAY_DECLARATOR) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mTypeTree = (AST2JSOMTree)pTree.GetChild(0);
        // Count all 1+ array declarators (the first array declarator is
        // represented by the root and mustn't counted).
        while (mTypeTree.Type == JavaTreeParser.ARRAY_DECLARATOR) {
            // Walk down the sub-trees until the type has been found, i.e. the
            // current child doesn't represent an array declarator.
            mNumberOfArrayDeclarators++;
            mTypeTree = (AST2JSOMTree)mTypeTree.GetChild(0);
        }
        if (!AST2PrimitiveType.isPrimitiveType(mTypeTree)) {
            mIsArrayOfPrimitiveType = false;
        }
    }

    /**
     * Returns the <i>character in line</i> position where the array type
     * identifier starts.
     * 
     * @return  The <i>character in line</i> position where the array type
     *          identifier starts.
     */
    public int getCharPositionInLine() {
        
        return mTypeTree.CharPositionInLine;
    }
    
    /**
     * Returns the line number of the array type identifier.
     * 
     * @return  The line number of the array type identifier.
     */
    public int getLineNumber() {
        
        return mTypeTree.Line;
    }

    /**
     * Returns the number of array declarators, i.e. the number of <code>[]
     * </code> character sequences.
     *
     * @return  The number of array declarators.
     */
    public int getNumberOfArrayDeclarators() {
        
        return mNumberOfArrayDeclarators;
    }

    /**
     * If <code>this</code> represents an array type declarator for an array of 
     * any primitive type this method returns the primitive type.
     * 
     * @see ArrayTypeDeclarator#getQualifiedIdentifier()
     * 
     * @return  The type of the array elements or <code>null</code> if <code>
     *          'isArrayOfPrimitiveType() == false'</code>.
     */
    public PrimitiveType getPrimitiveType() {
        
        if (!mIsArrayOfPrimitiveType) {
            return null;
        }
        if (mPrimitiveType == null) {
            mPrimitiveType = 
                new AST2PrimitiveType(mTypeTree, getTokenRewriteStream());
        }
        
        return mPrimitiveType;
    }
    
    /**
     * If <code>this</code> represents an array type declarator for an array of 
     * any object type this method returns the appropriate type identifier.
     * 
     * @see ArrayTypeDeclarator#getPrimitiveType()
     * 
     * @return  The type of the array elements or <code>null</code> if <code>
     *          'isArrayOfPrimitiveType() == true'</code>.
     */
    public QualifiedIdentifier getQualifiedIdentifier() {
        
        if (mIsArrayOfPrimitiveType) {
            return null;
        }
        if (mQualifiedIdentifier == null) {
            mQualifiedIdentifier = new AST2QualifiedIdentifier(
                    mTypeTree, getTokenRewriteStream());
        }
        
        return mQualifiedIdentifier;
    }

    /**
     * Tells if <code>this</code> represents an array type declarator for an 
     * array of any primitive type.
     * 
     * @return  <code>true</code> if <code>this</code> represents an array type
     *          declarator for an array of any primitive type.
     */
    public bool isArrayOfPrimitiveType() {
        
        return mIsArrayOfPrimitiveType;
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
            if (mIsArrayOfPrimitiveType) {
                getPrimitiveType().traverseAll(pAction);
            } else {
                getQualifiedIdentifier().traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}