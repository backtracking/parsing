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
     * This <code>JSOM</code> type represents a complex type identifier including
     * the generic type arguments that may follow the type identifier.
     * 
     * @author Dieter Habelitz
     */
    public interface ComplexTypeIdentifier : JSOM
    {

        /**
         * Returns the complex type identifier.
         * 
         * @return  The complex type identifier.
         */
        String getIdentifier();

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
        List<GenericTypeArgument> getGenericTypeArguments();

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
        List<GenericTypeArgument> getGenericTypeArguments(
                List<GenericTypeArgument> pList);

        /**
         * Tells if at least one generic type argument has been stated with the type
         * identifier.
         * 
         * @return  <code>true</code> if at least one generic type argument has been
         *          stated.
         */
        bool hasGenericTypeArgument();

        /**
         * Replaces the identifier of <code>this</code>.
         * 
         * @param pNewIdentifier  The new complex type identifier.
         * 
         * @return  The old identifier.
         */
        String setIdentifier(String pNewIdentifier);
    }
}