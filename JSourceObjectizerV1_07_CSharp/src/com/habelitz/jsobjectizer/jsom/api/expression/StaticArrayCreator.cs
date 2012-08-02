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

using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.expression
{

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
    public interface StaticArrayCreator : PrimaryExpression
    {

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
        /*public*/ List<VariableInitializer> getArrayInitializers();

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
        /*public*/ List<VariableInitializer> getArrayInitializers(
                List<VariableInitializer> pList);

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
        /*public*/ List<Expression> getArraySizeDeclarators();

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
        /*public*/ List<Expression> getArraySizeDeclarators(List<Expression> pList);

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
        /*public*/ List<GenericTypeArgument> getGenericTypeArguments();

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
        /*public*/ List<GenericTypeArgument> getGenericTypeArguments(
                List<GenericTypeArgument> pList);

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
        /*public*/ int getNumberOfArrayDeclarators();

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
        /*public*/ PrimitiveType getPrimitiveType();

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
        /*public*/ List<ComplexTypeIdentifier> getQualifiedTypeIdentifier();

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
        /*public*/ List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
                List<ComplexTypeIdentifier> pList);

        /**
         * Tells if <code>this</code> represents an array creator with an explicit
         * initializer.
         * 
         * @return  <code>true</code> if <code>this</code> represents an array 
         *          creator with an explicit initializer.
         */
        /*public*/ bool hasExplicitInitializer();

        /**
         * Tells if <code>this</code> has at least one generic type argument.
         * 
         * @return  <code>true</code> if <code>this</code> has at least one generic
         *          type argument.
         */
        /*public*/ bool hasGenericTypeArgument();

        /**
         * Tells if <code>this</code> represents a creator of a static array of a 
         * primitive type.
         * 
         * @return  <code>true</code> if <code>this</code> represents a creator of 
         *          a static array of a primitive type.
         */
        /*public*/ bool isArrayOfPrimitiveType();
    }
}