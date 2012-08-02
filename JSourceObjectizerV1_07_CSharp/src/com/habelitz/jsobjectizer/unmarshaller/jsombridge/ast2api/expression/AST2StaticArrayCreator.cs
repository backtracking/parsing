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
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>PrimaryExpression</code> type represents a <code>new</code>
 * expression for creating static arrays.
 * <p>      
 * This class handles the creators for both static arrays of primitive types and
 * static arrays of <code>Object</code> types. The method <code>
 * isArrayOfPrimitiveType</code> can be used to find out which variant is 
 * represented by an instance of this class.
 * <p>
 * Furthermore the behavior of some methods depends on if an instance of this
 * class represents an array creator with an explicitly stated initializer like
 *  <pre>
 *      new AnyType[][] { {initializer, ...}, {initializer, ...}}
 *  </pre>
 * or like
 *  <pre>
 *      new AnyType[expression][expression]
 *      new AnyType[expression][][][]
 *  </pre>
 * what can be found out easily by calling the method <code>
 * hasExplicitInitializer()</code>.
 * 
 * @see ClassConstructorCall  for <code>new</code> expressions that instantiate 
 *                            objects via a constructor call.
 *       
 * @author Dieter Habelitz
 */
public class AST2StaticArrayCreator : AST2PrimaryExpression , StaticArrayCreator {

    // The primitive type for primitive type array creators.
    private PrimitiveType mPrimitiveType;
    // The optional generic type arguments for object type array creators.
    private List<AST2GenericTypeArgument> mGenericTypeArguments;
    // The type identifier for object type array creators.
    private List<AST2ComplexTypeIdentifier> mQualifiedTypeIdentifier;
    // The number of array declarators.
    private int mNumberOfArrayDeclarators;
    // The array initializers for the cases where the array get's initialized
    // explicitly.
    private List<VariableInitializer> mArrayInitializers;
    // The array size expressions for the cases where no initializers have been
    // stated.
    private List<Expression> mArrayDims;
    // 'true' if 'this' is an array of a primitive type.
    private bool mIsArrayOfPrimitiveType = false;
    // 'true' if 'this' has an explicit array initializer.
    private bool mHasExplicitInitializer = false;

    // Some children from the static array creator's root node.
    private AST2JSOMTree mPrimitiveTypeTree;
    private AST2JSOMTree mGenericTypeArgsTree;
    private AST2JSOMTree mQualifiedTypeIdentTree;
    private AST2JSOMTree mArrayInitializersTree;
    private List<AST2JSOMTree> mArrayDimTrees;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a variable initializer, i.e.
     *               an expression or an array initializer.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2StaticArrayCreator(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.STATIC_ARRAY_CREATOR,pTokenRewriteStream)
    {
        
        
        if (pTree.Type != JavaTreeParser.STATIC_ARRAY_CREATOR) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        int childOffset = 0;
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(childOffset);
        if (AST2PrimitiveType.isPrimitiveType(child)) {
            mIsArrayOfPrimitiveType = true;
            mPrimitiveTypeTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        } else {
            if (child.Type == JavaTreeParser.GENERIC_TYPE_ARG_LIST) {
                mGenericTypeArgsTree = child;
                childOffset++;
                child = (AST2JSOMTree)pTree.GetChild(childOffset);
            }
            mQualifiedTypeIdentTree = child;
            childOffset++;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
        }
        if (child.Type == JavaTreeParser.EXPR) {
            int numberOfExpressions = 1;
            int childOffsetBuffer = childOffset + 1;
            while (   childOffsetBuffer < pTree.ChildCount
                   &&    pTree.GetChild(childOffsetBuffer).Type 
                      == JavaTreeParser.EXPR) {
                numberOfExpressions++;
                childOffsetBuffer++;
            }
            mArrayDimTrees = new List<AST2JSOMTree>(numberOfExpressions);
            mArrayDimTrees.Add(child); // Add the first expressions.
            for (int offset = 1; offset < numberOfExpressions; offset++) {
                // Add rest of expressions.
                childOffset++;
                mArrayDimTrees.Add((AST2JSOMTree)pTree.GetChild(childOffset));
            }
            // Check if there is still an array declarator list.
            childOffset++;
            if (childOffset == pTree.ChildCount - 1) {
                mNumberOfArrayDeclarators = 
                    pTree.GetChild(childOffset).ChildCount;
            }
        } else {
            mHasExplicitInitializer = true;
            // The array creator has an explicit initializer.
            mNumberOfArrayDeclarators = 
                pTree.GetChild(childOffset).ChildCount;
            // Get the initializers
            child = (AST2JSOMTree)pTree.GetChild(childOffset + 1);
            int numberOfInitializers = child.ChildCount;
            if (numberOfInitializers > 0) {
                mArrayInitializersTree = child;
            }
        }
    }

    /**
     * If <code>this</code> represents an array creator with an explicit
     * initializer this method returns a list of the array initializers.
     * <p>
     * Calling this method equals an <code>getArrayInitializers(null)</code>
     * call.
     * 
     * @see #getArrayInitializers(List)
     * @see StaticArrayCreator#getArraySizeDeclarators()
     * 
     * @return  A list of the array initializers. If <code>
     *          'hasExplicitInitializer() != true'</code> or if <code>
     *          'hasExplicitInitializer() == true'</code> but the initializer is
     *          an empty initializer <code>null</code> will be returned.
     */
    public List<VariableInitializer> getArrayInitializers() {
        
        return getArrayInitializers(null);
    }
    
    /**
     * If <code>this</code> represents an array creator with an explicit
     * initializer this method returns a list of the array initializers.
     * 
     * @param  pList  If this argument isn't <code>null</code> the array 
     *                initializers will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @see StaticArrayCreator#getArraySizeDeclarators()
     * 
     * @return  A list of the array initializers. If <code>
     *          'hasExplicitInitializer() != true'</code> or if <code>
     *          'hasExplicitInitializer() == true'</code> but the initializer is
     *          an empty initializer <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<VariableInitializer> getArrayInitializers(
            List<VariableInitializer> pList) {
        
        // Note: 'mHasExplicitInitializer' may be 'true' but
        //       'mArrayInitializersTree == null'
        if (mArrayInitializersTree == null) {
            return null; // There're no initializers.
        }
        if (mArrayInitializers == null) {
            resolveArrayInitializers();
        }
        List<VariableInitializer> result = pList;
        if (result == null) {
            result = new List<VariableInitializer>(
                    mArrayInitializers.Count);
        }
        result.AddRange(mArrayInitializers);
        
        return result;
    }
    
    /**
     * If <code>this</code> represents an array creator without an explicit
     * initializer this method returns a list of the array size declarators.
     * <p>
     * Calling this method equals an <code>getArraySizeDeclarators(null)</code>
     * call.
     * 
     * @see #getArraySizeDeclarators(List)
     * @see StaticArrayCreator#getArrayInitializers()
     * 
     * @return  A list of the array size declarators. If <code>
     *          'hasExplicitInitializer() == true'</code> <code>null</code> will 
     *          be returned.
     */
    public List<Expression> getArraySizeDeclarators() {
        
        return getArraySizeDeclarators(null);
    }
    
    /**
     * If <code>this</code> represents an array creator without an explicit
     * initializer this method returns a list of the array size declarators.
     * 
     * @param  pList  If this argument isn't <code>null</code> the array size 
     *                declarators will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *                
     * @see StaticArrayCreator#getArrayInitializers()
     * 
     * @return  A list of the array size declarators. If <code>
     *          'hasExplicitInitializer() == true'</code> <code>null</code> will 
     *          be returned, even if the argument <code>pList</code> isn't 
     *          <code>null</code>.
     */
    public List<Expression> getArraySizeDeclarators(List<Expression> pList) {
        
        if (mHasExplicitInitializer) {
            return null; // If there's an explicit initializer there can't be
                         // any expressions.
        }
        if (mArrayDims == null) {
            resolveArraySizeDeclarators();
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mArrayDims.Count);
        }
        result.AddRange(mArrayDims);
        
        return result;
    }
    
    /**
     * Returns the <i>character in line</i> position where the type identifier 
     * starts.
     * 
     * @return  The <i>character in line</i> position where the type identifier 
     *          starts.
     */
    public int getCharPositionInLine() {
        
        if (mIsArrayOfPrimitiveType) {
            if (mPrimitiveType == null) {
                // Force resolving the primitive type.
                getPrimitiveType();
            }
            return mPrimitiveType.getCharPositionInLine();
        }
        // If still here it's an array of a complex type.
        if (mQualifiedTypeIdentifier == null) {
            mQualifiedTypeIdentifier = 
                AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier(
                        mQualifiedTypeIdentTree, getTokenRewriteStream());
        }

        return mQualifiedTypeIdentifier[mQualifiedTypeIdentifier.Count - 1]
                                       .getCharPositionInLine();
    }

    /**
     * If <code>this</code> represents a creator of a static array of objects
     * this method returns a list of the optional generic type arguments that 
     * may precede the qualified type identifier.
     * <p>
     * Calling this method equals an <code>getGenericTypeArguments(null)</code>
     * call.
     * 
     * @see #getGenericTypeArguments(List)
     * 
     * @return  A list of generic type arguments that may precede the 
     *          qualified type identifier. If no generic type argument has been 
     *          stated or if <code>'isArrayOfPrimitiveType() == true'</code> 
     *          <code>null</code> will be returned.
     */
    public List<GenericTypeArgument> getGenericTypeArguments() {
        
        return getGenericTypeArguments(null);
    }
    
    /**
     * If <code>this</code> represents a creator of a static array of objects
     * this method returns a list of the optional generic type arguments that 
     * may precede the qualified type identifier.
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type 
     *                arguments will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of generic type arguments that may precede the 
     *          qualified type identifier. If no generic type argument has been 
     *          stated or if <code>'isArrayOfPrimitiveType() == true'</code> 
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    public List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList) {
        
        if (mGenericTypeArgsTree == null) {
            return null; // There're no generic type arguments.
        }
        if (mGenericTypeArguments == null) {
            mGenericTypeArguments = 
                AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                        mGenericTypeArgsTree, getTokenRewriteStream());
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
     * Returns the line number of the type identifier.
     * 
     * @return  The line number of the type identifier.
     */
    public int getLineNumber() {
        
        if (mIsArrayOfPrimitiveType) {
            if (mPrimitiveType == null) {
                // Force resolving the primitive type.
                getPrimitiveType();
            }
            return mPrimitiveType.getLineNumber();
        }
        // If still here it's an array of a complex type.
        if (mQualifiedTypeIdentifier == null) {
            mQualifiedTypeIdentifier = 
                AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier(
                        mQualifiedTypeIdentTree, getTokenRewriteStream());
        }

        return mQualifiedTypeIdentifier[0].getLineNumber();
    }

    /**
     * Returns the number of array declarators, i.e. the number of <code>[]
     * </code> character sequences.
     * <p>
     * The interpretation of this method's result depends on if <code>this
     * </code> represents an array creator with an explicit initializer or not.
     * For the three formal examples given within this class' head documentation
     * this method would return the values <code>2</code>, <code>0</code> and
     * <code>3</code> respectively.
     *
     * @return  The number of array declarators.
     */
    public int getNumberOfArrayDeclarators() {
        
        return mNumberOfArrayDeclarators;
    }

    /**
     * If <code>this</code> represents a creator of a static array of a 
     * primitive type this method returns the primitive type of the array 
     * elements.
     * 
     * @see StaticArrayCreator#getQualifiedTypeIdentifier()
     * 
     * @return  The type of the array elements or <code>null</code> if <code>
     *          'isArrayOfPrimitiveType() == false'</code>.
     */
    public PrimitiveType getPrimitiveType() {
        
        if (!mIsArrayOfPrimitiveType) {
            return null; // This is an object type array creator.
        }
        if (mPrimitiveType == null) {
            mPrimitiveType = new AST2PrimitiveType(
                    mPrimitiveTypeTree, getTokenRewriteStream());
        }
        
        return mPrimitiveType;
    }
    
    /**
     * If <code>this</code> represents a creator of a static array of objects
     * this method returns a list of the type (which may be a qualified type) of
     * the array elements.
     * <p>
     * Calling this method equals an <code>getQualifiedTypeIdentifier(null)
     * </code> call.
     * 
     * @see #getQualifiedTypeIdentifier(List)
     * @see StaticArrayCreator#getPrimitiveType()
     * 
     * @return  A list containing the (qualified) type of the array elements. If
     *          if <code>'isArrayOfPrimitiveType() == true'</code> <code>null
     *          </code> will be returned.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier() {
        
        return getQualifiedTypeIdentifier(null);
    }

    /**
     * If <code>this</code> represents a creator of a static array of objects
     * this method returns a list of the type (which may be a qualified type) of
     * the array elements.
     * 
     * @param  pList  If this argument isn't <code>null</code> the array element
     *                type will be added to this list and this list object will 
     *                be returned. Otherwise a new list will be created for the 
     *                result. For a qualified type the most left identifier is
     *                the first list entry and the actual array element type the
     *                last one. 
     * 
     * @see StaticArrayCreator#getPrimitiveType()
     * 
     * @return  A list containing the (qualified) type of the array elements. If
     *          if <code>'isArrayOfPrimitiveType() == true'</code> <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
            List<ComplexTypeIdentifier> pList) {
        
        if (mIsArrayOfPrimitiveType) {
            return null; // This is an primitive type array creator.
        }
        if (mQualifiedTypeIdentifier == null) {
            mQualifiedTypeIdentifier = 
                AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier(
                        mQualifiedTypeIdentTree, getTokenRewriteStream());
        }
        List<ComplexTypeIdentifier> result = pList;
        if (result == null) {
            result = new List<ComplexTypeIdentifier>(
                                            mQualifiedTypeIdentifier.Count);
        }
        result.AddRange(mQualifiedTypeIdentifier);
        
        return result;
    }

    /**
     * Tells if <code>this</code> represents an array creator with an explicit
     * initializer.
     * 
     * @return  <code>true</code> if <code>this</code> represents an array 
     *          creator with an explicit initializer.
     */
    public bool hasExplicitInitializer() {
        
        return mHasExplicitInitializer;
    }

    /**
     * Tells if <code>this</code> has at least one generic type argument.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type argument.
     */
    public bool hasGenericTypeArgument() {
        
        return mGenericTypeArgsTree != null;
    }
    
    /**
     * Tells if <code>this</code> represents a creator of a static array of a 
     * primitive type.
     * 
     * @return  <code>true</code> if <code>this</code> represents a creator of 
     *          a static array of a primitive type.
     */
    public bool isArrayOfPrimitiveType() {
        
        return mIsArrayOfPrimitiveType;
    }

    /**
     * Resolves the array initializers.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one array
     * initializer.
     */
    private void resolveArrayInitializers() {
        
        int size = mArrayInitializersTree.ChildCount;
        mArrayInitializers = new List<VariableInitializer>(size);
        for (int offset = 0; offset < size; offset++) {
            mArrayInitializers.Add(new AST2VariableInitializer((AST2JSOMTree)
                    mArrayInitializersTree.GetChild(offset), 
                    getTokenRewriteStream()));
        }
    }

    /**
     * Resolves the array size declarators.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one array
     * size declarator.
     */
    private void resolveArraySizeDeclarators() {
        
        int size = mArrayDimTrees.Count;
        mArrayDims = new List<Expression>(size);
        for (int offset = 0; offset < size; offset++) {
            mArrayDims.Add(AST2Expression.resolveExpression(
                    mArrayDimTrees[offset], getTokenRewriteStream()));
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
            if (mIsArrayOfPrimitiveType) {
                getPrimitiveType().traverseAll(pAction);
            } else {
                if (mGenericTypeArgsTree != null) {
                    if (mGenericTypeArguments == null) {
                        mGenericTypeArguments = AST2GenericTypeArgument
                            .resolveGenericTypeArgumentList(
                                    mGenericTypeArgsTree, 
                                    getTokenRewriteStream());
                    }
                    foreach (GenericTypeArgument arg in mGenericTypeArguments) {
                        arg.traverseAll(pAction);
                    }
                }
                List<ComplexTypeIdentifier> typeIds = 
                                                getQualifiedTypeIdentifier();
                foreach (ComplexTypeIdentifier typeId in typeIds) {
                    typeId.traverseAll(pAction);
                }
            }
            // There's either an explicit initializer (which may be empty) or
            // one or more expressions that defining the array dimensions. But
            // there can't be both.
            if (mHasExplicitInitializer) {
                if (mArrayInitializersTree != null) {
                    if (mArrayInitializers == null) {
                        resolveArrayInitializers();
                    }
                    foreach (VariableInitializer initializer in mArrayInitializers) {
                        initializer.traverseAll(pAction);
                    }
                }
            } else {
                if (mArrayDims == null) {
                    resolveArraySizeDeclarators();
                }
                foreach (Expression expression in mArrayDims) {
                    expression.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}