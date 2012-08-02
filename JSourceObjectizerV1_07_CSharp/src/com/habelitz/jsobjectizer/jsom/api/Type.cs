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
using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
{

    /**
     * This <code>JSOM</code> represents a type identifier for both primitive and
     * complex types.
     * 
     * @author Dieter Habelitz
     */
    public interface Type : JSOM
    {

        /**
         * Returns the number of array declarators, i.e. the number of <code>[]
         * </code> character sequences that have been stated with the type.
         * <p>
         * If <code>this</code> doesn't represent a static array type <code>0</code>
         * will be returned.
         *
         * @return  The number of array declarators.
         */
        int getNumberOfArrayDeclarators();

        /**
         * Returns a list of the identifiers of the qualified type identifier.
         * <p>
         * Calling this method equals an <code>getQualifiedTypeIdentifier(null)
         * </code> call.
         * 
         * @see #getQualifiedTypeIdentifier(List)
         *  
         * @return  A list of the identifiers of the qualified type identifier. The
         *          first entry corresponds to the most left identifier. If <code>
         *          this</code> doesn't represent a complex type (i.e. <code>
         *          isComplexType() == false</code> <code>null</code> will be 
         *          returned.
         */
        List<ComplexTypeIdentifier> getQualifiedTypeIdentifier();

        /**
         * Returns a list of the identifiers of the qualified type identifier.
         * 
         * @param  pList  If this argument isn't <code>null</code> the identifiers
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of the identifiers of the qualified type identifier. The
         *          first entry corresponds to the most left identifier. If <code>
         *          this</code> doesn't represent a complex type (i.e. <code>
         *          isComplexType() == false</code> <code>null</code> will be 
         *          returned, even if the argument <code>pList</code> isn't <code>
         *          null</code>.
         */
        List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
                List<ComplexTypeIdentifier> pList);

        /**
         * If <code>this</code> represents a primitive type this method returns the
         * appropriate <code>PrimitiveType</code> object, Otherwise, i.e. if <code>
         * isComplexType()</code> returns <code>true</code>, <code>null</code> will 
         * be returned.
         * 
         * @return  A <code>PrimitiveType</code> object or <code>null</code> if 
         *          <code>this</code> represents a complex type.
         */
        PrimitiveType getPrimitiveType();

        /**
         * Tells if <code>this</code> represents a complex type.
         * 
         * @return  <code>true</code> if <code>this</code> represents a complex 
         *          type.
         */
        bool isComplexType();

        /**
         * Tells if <code>this</code> represents a static array type.
         * 
         * @return  <code>true</code> if <code>this</code> represents a static array 
         *          type.
         */
        bool isStaticArrayType();
    }
}
