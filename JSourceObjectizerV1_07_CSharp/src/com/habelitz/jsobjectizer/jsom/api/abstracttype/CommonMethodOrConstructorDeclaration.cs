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
using com.habelitz.jsobjectizer.jsom.api;
 
namespace com.habelitz.jsobjectizer.jsom.api.abstracttype
{
/**
 * This interface is the base type for all method or constructor declarations.
 * 
 * @author Dieter Habelitz
 */
public interface CommonMethodOrConstructorDeclaration : JSOM {

    /**
     * Adds a stated (simple) annotation to <code>this</code>.
     * 
     * @param pAnnotationIdentifier  The annotation's identifier. Note that this 
     *                               identifier must not start with the 
     *                               character <code>@</code> because is will be
     *                               added by this method automatically.
     * 
     * @  if parsing fails.
     * 
     * @deprecated  JSourceObjectizer 2.xx feature; should be seen as 
     *              experimental.
     */
    [Obsolete]
    void addAnnotation(Char[] pAnnotationIdentifier);

    /**
     * Returns the method's formal parameter list.
     * 
     * @return  The method's formal parameter list or <code>null</code> if no
     *          parameters have been stated.
     */
    FormalParameterList getFormalParameters();
    
    /**
     * Returns a list of generic type parameters that may have been stated left 
     * from the method's return type.
     * <p>
     * Example: <code>&lt;T&gt; T foo(T argument) {...}</code>
     * <p>
     * For the example above this method would return a list that contains just 
     * one generic type parameter representing the type <code>T</code> stated 
     * by <code>&lt;T&gt;</code>.
     * <p>
     * Calling this method equals an <code>getGenericTypeParameters(null)</code>
     * call.
     * 
     * @see #getGenericTypeParameters(List)
     * 
     * @return  A list of generic type parameters. If there is no generic type
     *          parameter <code>null</code> will be returned. 
     */
    List<GenericTypeParameter> getGenericTypeParameters();

    /**
     * Returns a list of generic type parameters that may have been stated left 
     * from the method's return type.
     * <p>
     * Example: <code>public &lt;T&gt; T foo(T argument) {...}</code>
     * <p>
     * For the example above this method would return a list that contains just 
     * one generic type parameter representing the type <code>T</code> stated 
     * by <code>&lt;T&gt;</code>.
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type
     *                parameters will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of generic type parameters. If there is no generic type
     *          parameter <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    List<GenericTypeParameter> getGenericTypeParameters(
            List<GenericTypeParameter> pList);

    /**
     * Returns the method's or constructor's modifiers including annotations.
     * 
     * @return  A list of modifiers or <code>null</code> if the method or
     *          constructor declaration has no modifiers.
     *          
     * @deprecated  Use {@link #getModifierList()} instead.         
     */
    [Obsolete]
    ModifierList getModifiers();
 
    /**
     * Returns the method's or constructor's modifiers including annotations.
     * 
     * @return  A list of modifiers which is empty if the method or constructor 
     *          declaration has no modifiers.
     */
    ModifierList getModifierList();
 
    /**
     * Returns the method's <code>throws</code> clause.
     * 
     * @return  The method's <code>throws</code> clause or <code>null</code> if
     *          no <code>throws</code> clause has been stated.
     */
    ThrowsClause getThrowsClause();
    
    /**
     * Tells if <code>this</code> has at least one formal parameter
     * declaration.
     *  
     * @return  <code>true</code> if <code>this</code> has at least one formal
     *          parameter declaration.
     */
    bool hasFormalParameter();
    
    /**
     * Tells if <code>this</code> at least one generic type parameter has been
     * stated.
     * 
     * @see #getGenericTypeParameters() for more details about generic type
     *                                  parameters.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type parameter.
     */
    bool hasGenericTypeParameter();
    
    /**
     * Tells if <code>this</code> has at least one modifier or annotation.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          modifier or annotation.
     */
    bool hasModifier();
    
    /**
     * Tells if <code>this</code> has a <code>throws</code> clause.
     * 
     * @return  <code>true</code> if <code>this</code> has <code>throws</code>
     *          clause.
     */
    bool hasThrowsClause();
    
    /**
     * Removes all formal parameter list.
     * <p>
     * If <code>this</code> has no formal parameters an implementation of this
     * method is expected to do nothing than return <code>null</code>.
     * 
     * @return  The removed formal parameter list or <code>null</code> if <code>
     *          this hasn't formal parameters.
     */
    FormalParameterList removeFormalParameters();
}
}