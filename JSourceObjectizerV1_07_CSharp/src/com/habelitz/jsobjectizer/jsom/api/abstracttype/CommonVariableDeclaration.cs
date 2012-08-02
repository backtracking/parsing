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

using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using com.habelitz.jsobjectizer.jsom;
using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.abstracttype
{
/**
 * This <code>JSOM</code> type represents a common variable declaration.
 * 
 * @author Dieter Habelitz
 */
public interface CommonVariableDeclaration : JSOM {

    /**
     * Returns the variable's modifiers including annotations.
     * 
     * @return  A list of type modifiers or <code>null</code> if the variable
     *          declaration has no modifiers.
     *          
     * @deprecated  Use {@link #getModifierList()} instead.
     */
    [Obsolete]
    ModifierList getModifiers();
 
    /**
     * Returns the variable's modifiers including annotations.
     * 
     * @return  A list of type modifiers which is empty if the variable 
     *          declaration has no modifiers.
     */
    ModifierList getModifierList();

    /**
     * Returns the variable's type.
     * 
     * @return  The variable's type.
     */
    Type getType();
    
    /**
     * Returns a list of variable declarators (i.e. the identifier(s) including 
     * optional initializer(s).
     * 
     * Calling this method equals an <code>getVariableDeclarators(null)</code>
     * call.
     * 
     * @see #getVariableDeclarators(List)
     * 
     * @return  A list of variable declarators.
     */
    List<VariableDeclarator> getVariableDeclarators();
    
    /**
     * Returns a list of variable declarators (i.e. the identifier(s) including 
     * optional initializer(s).
     * 
     * @param  pList  If this argument isn't <code>null</code> the variable 
     *                declarators will be added to this list and this list
     *                object will be returned. Otherwise a new ist will be 
     *                created for the result.
     * 
     * @return  A list of variable declarators.
     */
    List<VariableDeclarator> getVariableDeclarators(
            List<VariableDeclarator> pList);
    
    /**
     * Tells if the variable declaration has at least one modifier or
     * annotation.
     * 
     * @return  <code>true</code> if the variable declaration has at least one
     *          modifier or annotation.
     */
    bool hasModifier();

    /**
     * Removes a certain variable declarator from <code>this</code>.
     * 
     * @param pVariableDeclarator  The variable declarator that should be
     *                             removed. The object passed to this method 
     *                             remains unchanged.
     * 
     * @  if the variable declarator passed to 
     *                                     this method doesn't belong to <code>
     *                                     this</code>.
     */
    void removeVariableDeclarator(VariableDeclarator pVariableDeclarator);
}
}