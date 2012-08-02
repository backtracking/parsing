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
 * This <code>JSOM</code> type represents an annotation method declarations.
 * 
 * @author Dieter Habelitz
 */
public interface AnnotationMethodDeclaration : JSOM {

    /**
     * Returns the annotation method declaration's default value.
     * 
     * @return  The annotation method declaration's default value or <code>null
     *          </code> if no default value has been stated.
     */
    AnnotationElementValue getDefaultValue();
    
    /**
     * Returns the annotation method's identifier.
     * 
     * @return  The annotation method's identifier.
     */
    String getIdentifier();

    /**
     * Returns the method's modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the method
     *          declaration has no modifiers.
     *          
     * @deprecated  Use {@link #getModifierList()} instead.         
     */
    [Obsolete]
    ModifierList getModifiers();
 
    /**
     * Returns the method's modifiers including annotations.
     * 
     * @return  A list of type modifiers which is empty if the method 
     *          declaration has no modifiers.
     */
    ModifierList getModifierList();
 
    /**
     * Returns the annotation method's return type.
     * 
     * @return  The annotation method's return type.
     */
    Type getType();
    
    /**
     * Tells if a default value has been stated for the annotation method
     * declaration.
     * 
     * @return  <code>true</code> if a default value has been stated for the 
     *          annotation method declaration.
     */
    bool hasDefaultValue();
    
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
     * @param pNewIdentifier  The new initializer identifier.
     * 
     * @return  The old identifier.
     */
    String setIdentifier(String pNewIdentifier);
}
}