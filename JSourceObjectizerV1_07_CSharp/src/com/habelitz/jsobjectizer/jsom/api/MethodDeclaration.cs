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
     * This <code>JSOM</code> type represents a method declarations.
     * 
     * @author Dieter Habelitz
     */
    public interface MethodDeclaration : CommonMethodOrConstructorDeclaration
    {

        /**
         * Returns the method's identifier.
         * 
         * @return  The method's identifier.
         */
        String getIdentifier();

        /**
         * Returns the number of array declarators stated behind the formal
         * parameter list.
         * <p>
         * Methods like
         * <pre>
         *     AnyType[][] foo() {...}
         * </pre>
         * can also be declared like this:
         * <pre>
         *     AnyType foo() [][] {...}
         * </pre>
         * For the first (and most common) variant this method would return <code>0
         * </code> but <code>2</code> for the second variant. Furthermore for the 
         * first variant the array declarators are part of the type returned by the 
         * method <code>getReturnType()</code>.
         * 
         * @return  The number of array declarators stated behind the formal
         *          parameter list; for void method always 0 will be returned, of 
         *          course.
         */
        int getNumberOfArrayDeclarators();

        /**
         * Returns the method's return type or <code>null</code> for <code>void
         * </code> methods.
         * 
         * @return  The method's return type or <code>null</code> for <code>void 
         *          </code> methods.
         */
        Type getReturnType();

        /**
         * Returns <code>true</code> if <code>this</code> represents a <code>void
         * </code> method.
         * 
         * @return  <code>true</code> if <code>this</code> represents a <code>void
         *          </code> method.
         */
        bool isVoidMethod();

        /**
         * Replaces the identifier of <code>this</code>.
         * 
         * @param pNewIdentifier  The new method identifier.
         * 
         * @return  The old identifier.
         */
        String setIdentifier(String pNewIdentifier);
    }

}