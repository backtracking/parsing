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
     * This <code>JSOM</code> type represents the top level scope of an enumeration 
     * declaration.
     * 
     * @author Dieter Habelitz
     */
    public interface EnumTopLevelScope : JSOM
    {

        /**
         * The enumeration constant declaration part can be followed by the contents
         * of a class body.
         * 
         * @return  The class top level scope following the enumeration constant 
         *          declaration part or <code>null</code> of no appropriate class 
         *          body like content has been stated.
         */
        ClassTopLevelScope getClassTopLevelScope();

        /**
         * Returns a list of the enumeration constants.
         * <p>
         * Calling this method equals an <code>getEnumConstants(null)</code> call.
         * 
         * @see #getEnumConstants(List)
         *  
         * @return  A list of the enumeration constants. If no enumeration constant
         *          has been declared <code>null</code> will be returned.
         */
        List<EnumConstant> getEnumConstants();

        /**
         * Returns a list of the enumeration constants.
         * 
         * @param  pList  If this argument isn't <code>null</code> the enumeration
         *                constants will be added to this list and this list object
         *                will be returned. Otherwise a new list will be created for 
         *                the result.
         *  
         * @return  A list of the enumeration constants. If no enumeration constant
         *          has been declared <code>null</code> will be returned, even if
         *          the argument <code>pList</code> isn't <code>null</code>.
         */
        List<EnumConstant> getEnumConstants(List<EnumConstant> pList);

        /**
         * Returns the enumeration declaration this top level scope belongs to.
         * 
         * @return  The enumeration declaration this top level scope belongs to.
         */
        EnumDeclaration getOwner();

        /**
         * Tells if the enumeration constant declaration part is followed by any
         * class top level scope content.
         * 
         * @see #getClassTopLevelScope()
         * 
         * @return  <code>true</code> if the enumeration constant declaration part
         *          is followed by any class top level scope content.
         */
        bool hasClassTopLevelScope();

        /**
         * Tells if <code>this</code> has at least one enumeration constant 
         * declaration.
         * 
         * @return  <code>true</code> if <code>this</code> has at least one 
         *          enumeration constant declaration.
         */
        bool hasEnumConstant();
    }
}