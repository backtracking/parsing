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
     * This <code>JSOM</code> represents a generic type parameter as can be stated
     * within a declaration's generic type parameter list.
     * 
     * @author Dieter Habelitz
     */
    public interface GenericTypeParameter : JSOM
    {

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
        List<Type> getBoundTypes();

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
        List<Type> getBoundTypes(List<Type> pList);

        /**
         * Returns the type identifier of the generic type.
         * 
         * @return  The type identifier of the generic type.
         */
        String getTypeIdentifier();

        /**
         * Tells if the generic type parameter has at least one bound type.
         * 
         * @return  <code>true</code> if the generic type parameter has at least one
         *          bound type.
         */
        bool hasBoundType();

        /**
         * Replaces the identifier of <code>this</code>.
         * 
         * @param pNewIdentifier  The new generic type parameter identifier.
         * 
         * @return  The old identifier.
         */
        String setTypeIdentifier(String pNewIdentifier);
    }
}