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
     * This <code>JSOM</code> type represents a variable declarator.
     * <p>
     * A variable declarator contains the variable identifier and optionally a
     * variable initializer. This class also represents declarators for constants
     * (i.e. variables with the modifier <code>final</code> within the modifier
     * list).
     * 
     * For some constant declarators the variable initializer is <b>not</b>
     * optional, i.e. it must exist (field declarations within interface 
     * declarations), but ensuring this is up to a parser or whatever.
     * 
     * @author Dieter Habelitz
     */
    public interface VariableDeclarator : JSOM
    {

        /**
         * Returns the variable's identifier.
         * 
         * @return  The variable's identifier.
         */
        VariableDeclaratorIdentifier getIdentifier();

        /**
         * Returns the variable initializer.
         * 
         * @return  The variable initializer or <code>null<code> if the variable
         *          declarator has no initializer.
         */
        VariableInitializer getInitializer();

        /**
         * Tells if the variable declarator has an initializer.
         * 
         * @return  <code>true</code> if the variable declarator has an initializer.
         */
        bool hasInitializer();
    }
}