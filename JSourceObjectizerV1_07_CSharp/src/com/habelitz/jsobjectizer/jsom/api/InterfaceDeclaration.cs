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
using com.habelitz.jsobjectizer.jsom.api.abstracttype;

namespace com.habelitz.jsobjectizer.jsom.api
{

    /**
     * This <code>JSOM</code> represents an interface type declaration.
     * 
     * @author Dieter Habelitz
     */
    public interface InterfaceDeclaration : CommonTypeDeclaration
    {

        /**
         * Returns the <code>:</code> clause.
         * 
         * @return  The <code>:</code> clause or <code>null</code> if <code> 
         *          this</code> has no <code>:</code> clause.
         */
        InterfaceExtendsClause getExtendsClause();

        /**
         * Returns a list of the generic type parameters stated with the interface
         * header.
         * <p>
         * Calling this method equals an <code>getGenericTypeParameters(null)</code>
         * call.
         * 
         * @see #getGenericTypeParameters(List)
         *  
         * @return  A list of the generic type parameters. If no generic type 
         *          parameters have been declared <code>null</code> will be 
         *          returned.
         */
        List<GenericTypeParameter> getGenericTypeParameters();

        /**
         * Returns a list of the generic type parameters stated with the interface
         * header.
         * 
         * @param  pList  If this argument isn't <code>null</code> the generic type
         *                parameters will be added to this list and this list object
         *                will be returned. Otherwise a new list will be created for
         *                the result.
         *  
         * @return  A list of the generic type parameters. If no generic type 
         *          parameters have been declared <code>null</code> will be 
         *          returned, even if the argument <code>pList</code> isn't <code>
         *          null</code>.
         */
        List<GenericTypeParameter> getGenericTypeParameters(
                List<GenericTypeParameter> pList);

        /**
         * Returns the content of the interface declaration body.
         * 
         * @return  The content of the interface declaration body.
         */
        InterfaceTopLevelScope getTopLevelScope();

        /**
         * Tells if the interface declaration has an <code>:</code> clause.
         * 
         * @return  <code>true</code> if the interface declaration has an <code>
         *          :</code> clause.
         */
        bool hasExtendsClause();

        /**
         * Tells if the interface declaration has at least one generic type 
         * parameter.
         * 
         * @return  <code>true</code> if the interface declaration has at least one
         *          generic type parameter.
         */
        bool hasGenericTypeParameter();
    }
}