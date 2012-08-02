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
using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.abstracttype
{
/**
 * This <code>JSOM</code> type is the base type for all kinds of type 
 * declarations, i.e. for classes, interfaces and so on.
 * 
 * @author Dieter Habelitz
 */
public interface CommonTypeDeclaration : JSOM {

    /**
     * Returns the type declaration's identifier.
     * 
     * @return  The type declaration's identifier.
     */
    String getIdentifier();

    /**
     * Returns the type modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the type
     *          declaration has no modifiers.
     * 
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    ModifierList getModifiers();
    
    /**
     * Returns the type modifiers including annotations.
     * 
     * @return  A list of type modifiers which is empty if the type declaration 
     *          has no modifiers.
     */
    ModifierList getModifierList();
    
    /**
     * Tells if <code>this</code> has at least one modifier or annotation.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          modifier or annotation.
     */
    bool hasModifier();
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new type declaration identifier.
     * 
     * @return  The old identifier.
     */
    String setIdentifier(String pNewIdentifier);
}
}