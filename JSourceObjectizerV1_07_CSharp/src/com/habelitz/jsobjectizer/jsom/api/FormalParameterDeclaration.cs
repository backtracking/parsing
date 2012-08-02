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
using com.habelitz.jsobjectizer;
using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
{
/** 
 * This <code>JSOM</code> type represents a formal parameter declaration
 * including <i>vararg</i> parameter declarations, i.e. a parameter declarations 
 * of a variable number of arguments like <code>anyType ... typeId</code>.
 * 
 * @author Dieter Habelitz
 */
public interface FormalParameterDeclaration : JSOM {
    
    /**
     * Adds a stated (simple) annotation to <code>this</code>.
     * 
     * @param pAnnotationIdentifier  The annotation's identifier. Note that this 
     *                               identifier must not start with the character 
     *                               <code>@</code> because is will be added by 
     *                               this method automatically.
     * 
     * @  if parsing fails.
     * 
     * @deprecated  JSourceObjectizer 2.xx feature; should be seen as 
     *              experimental.
     */
    [Obsolete]
    void addAnnotation(Char[] pAnnotationIdentifier);

    /**
     * Returns the formal parameter declaration's modifiers including
     * annotations. 
     * 
     * @return  The modifiers of the formal parameter declaration or <code>null
     *          </code> if no modifiers have been stated.
     *          
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    ModifierList getModifiers();
    
    /**
     * Returns the formal parameter declaration's modifiers including
     * annotations. 
     * 
     * @return  A list of type modifiers which is empty if the parameter 
     *          declaration has no modifiers.
     */
    ModifierList getModifierList();

    /**
     * Returns the identifier of the formal parameter. 
     * 
     * @return  The the identifier of the formal parameter.
     */
    VariableDeclaratorIdentifier getIdentifier();
    
    /**
     * Returns the type of the formal parameter. 
     * 
     * @return  The the type of the formal parameter.
     */
    Type getType();

    /**
     * Tells if <code>this</code> represents a <i>vararg</i> parameter 
     * declaration.
     * 
     * @return  <code>true</code> if <code>this</code> represents a <i>vararg
     *          </i>parameter declaration.  
     */
    bool isVarargParameterDeclaration();

    /**
     * Tells if the formal parameter declaration has at least one modifier or
     * annotation.
     * 
     * @return  <code>true</code> if the formal parameter declaration has at 
     *          least one modifier or annotation.
     */
    bool hasModifier();
}
}