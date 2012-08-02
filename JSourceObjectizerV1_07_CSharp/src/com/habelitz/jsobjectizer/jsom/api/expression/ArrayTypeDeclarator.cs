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

using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.expression {
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
public interface ArrayTypeDeclarator : PrimaryExpression {

    /**
     * Returns the number of array declarators, i.e. the number of <code>[]
     * </code> character sequences.
     *
     * @return  The number of array declarators.
     */
    /*public*/ int getNumberOfArrayDeclarators();

    /**
     * If <code>this</code> represents an array type declarator for an array of 
     * any primitive type this method returns the primitive type.
     * 
     * @see ArrayTypeDeclarator#getQualifiedIdentifier()
     * 
     * @return  The type of the array elements or <code>null</code> if <code>
     *          'isArrayOfPrimitiveType() == false'</code>.
     */
    /*public*/ PrimitiveType getPrimitiveType();
    
    /**
     * If <code>this</code> represents an array type declarator for an array of 
     * any object type this method returns the appropriate type identifier.
     * 
     * @see ArrayTypeDeclarator#getPrimitiveType()
     * 
     * @return  The type of the array elements or <code>null</code> if <code>
     *          'isArrayOfPrimitiveType() == true'</code>.
     */
    /*public*/ QualifiedIdentifier getQualifiedIdentifier();

    /**
     * Tells if <code>this</code> represents an array type declarator for an 
     * array of any primitive type.
     * 
     * @return  <code>true</code> if <code>this</code> represents an array type
     *          declarator for an array of any primitive type.
     */
    /*public*/ bool isArrayOfPrimitiveType();
}
}