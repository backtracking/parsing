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

using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.expression {
/**
 * This <code>PrimaryExpression</code> type represents an explicit <code>this
 * </code> or </code>super</code> constructor call.
 * 
 * @author Dieter Habelitz
 */
public interface ExplicitConstructorCall : PrimaryExpression {

    /**
     * Returns a list of the explicit constructor call's arguments.
     * <p>
     * Calling this method equals an <code>getMethodDeclarations(null)</code>
     * call.
     * 
     * @see #getArguments(List)
     *  
     * @return  A list of the explicit constructor call's arguments. If there 
     *          are no arguments <code>null</code> will be returned. 
     */
    List<Expression> getArguments();
    
    /**
     * Returns a list of the explicit constructor call's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments 
     *                will be added to this list and this list object will be
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the explicit constructor call's arguments. If there 
     *          are no arguments <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>. 
     */
    List<Expression> getArguments(List<Expression> pList);
    
    /**
     * Returns a list of the generic type arguments that may have been stated 
     * with the <code>this</code> or </code>super</code> constructor invocation.
     * <p>
     * Calling this method equals an <code>getMethodDeclarations(null)</code>
     * call.
     * 
     * @see #getGenericTypeArguments(List)
     *  
     * @return  A list of the generic type arguments that may have been stated 
     *          with the <code>this</code> or </code>super</code> constructor 
     *          invocation. If there are no generic type arguments <code>null
     *          </code> will be returned. 
     */
    List<GenericTypeArgument> getGenericTypeArguments();
    
    /**
     * Returns a list of the generic type arguments that may have been stated 
     * with the <code>this</code> or </code>super</code> constructor invocation.
     * 
     * @param  pList  If this argument isn't <code>null</code> the generic type
     *                arguments will be added to this list and this list object
     *                will be returned. Otherwise a new list will be created for
     *                the result.
     *  
     * @return  A list of the generic type arguments that may have been stated 
     *          with the <code>this</code> or </code>super</code> constructor 
     *          invocation. If there are no generic type arguments <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>. 
     */
    List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList);
    
    /**
     * Returns the expression that may precede the <code>super</code>
     * keyword of an explicit <code>super</code> constructor call.
     * <p>
     * A returned expression states the type a called <code>super</code>
     * constructor belongs to. For most cases this is something like <code>
     * ACertainType.this.base(...)</code>
     * 
     * @return  The expression that precedes the <code>super</code>
     *          keyword or <code>null</code> if there is no such expression. If
     *          <code>this</code> represents an explicit <code>this</code> 
     *          constructor call this method always returns<code>null</code>.
     */
    PrimaryExpression getSuperType();

    /**
     * This method equals to a {@link #getSuperType()} call.
     * 
     * @deprecated  Replaced by {@link #getSuperType()}.
     * 
     * @return  Same as {@link #getSuperType()}
     */
    [Obsolete]
    PrimaryExpression getPrimaryExpression();

    /**
     * Tells if the explicit constructor call has at least one argument.
     * 
     * @return  <code>true</code> if the explicit constructor call has at least
     *          one argument.
     */
    bool hasArgument();
    
    /**
     * Tells if <code>this</code> has at least one generic type argument.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type argument.
     */
    bool hasGenericTypeArgument();
    
    /**
     * @deprecated  Replaced by {@link #hasGenericTypeArgument()}
     * 
     * @return  Same as {@link #hasGenericTypeArgument()}
     */
    [Obsolete]
    bool hasGenericTypeParameter();
    
    /**
     * @deprecated  Replaced by {@link #hasSuperTypeExpression()}
     * 
     * @return  Same as {@link #hasSuperTypeExpression()}
     */
    [Obsolete]
    bool hasPrimaryExpression();
    
    /**
     * Tells if an explicit <code>super</code> constructor call is preceded by
     * an expression stating the super type explicitly.
     * 
     * @return  <code>true</code> if an explicit <code>super</code> constructor
     *          call is preceded by an expression stating the super type. If 
     *          <code>this</code> represents an explicit <code>this</code>
     *          constructor call this method always returns <code>false</code>.
     */
    bool hasSuperTypeExpression();
    
    /**
     * Tells if <code>this</code> represents an explicit <code>this</code> or 
     * </code>super</code> constructor call.
     * 
     * @return  <code>true</code> for explicit <code>super</code> constructor
     *          calls and <code>false</code> for explicit <code>this</code>
     *          constructor calls.
     */
    bool isSuperConstructorCall();
}
}