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

namespace com.habelitz.jsobjectizer.jsom.api.expression
{

    /**
     * This <code>PrimaryExpression</code> type represents a method invocation.
     * 
     * @author Dieter Habelitz
     */
    public interface MethodCall : PrimaryExpression
    {

        /**
         * Returns a list of the method call's arguments.
         * <p>
         * Calling this method equals an <code>getArguments(null)</code> call.
         * 
         * @see #getArguments(List)
         *  
         * @return  A list of the method call's arguments. If there are no arguments
         *          <code>null</code> will be returned. 
         */
        List<Expression> getArguments();

        /**
         * Returns a list of the method call's arguments.
         * 
         * @param  pList  If this argument isn't <code>null</code> the arguments
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of the method call's arguments. If there are no
         *          arguments <code>null</code> will be returned, even if the 
         *          argument <code>pList</code> isn't <code>null</code>. 
         */
        List<Expression> getArguments(List<Expression> pList);

        /**
         * Returns a list of generic type arguments that may have been stated with 
         * the method invocation.
         * <p>
         * Example: for a method call like <code>
         * '&lt;T&gt; anyMethodCall(anyArgs)'</code> this method would return a list 
         * that contains just one generic type parameter that represents the type 
         * <code>T</code> stated by <code>&lt;T&gt;</code>.
         * 
         * @see #getGenericTypeArguments(List)
         *  
         * @return  A list of generic type arguments. If there are no generic type
         *          arguments <code>null</code> will be returned. 
         */
        List<GenericTypeArgument> getGenericTypeArguments();

        /**
         * Returns a list of generic type arguments that may have been stated with 
         * the method invocation.
         * <p>
         * Example: for a method call like <code>
         * '&lt;T&gt; anyMethodCall(anyArgs)'</code> this method would return a list 
         * that contains just one generic type parameter that represents the type 
         * <code>T</code> stated by <code>&lt;T&gt;</code>.
         * 
         * @param  pList  If this argument isn't <code>null</code> the arguments
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of generic type arguments. If there are no generic type
         *          arguments <code>null</code> will be returned, even if the 
         *          argument <code>pList</code> isn't <code>null</code>. 
         */
        List<GenericTypeArgument> getGenericTypeArguments(
                List<GenericTypeArgument> pList);

        /**
         * Returns the method's identifier.
         * 
         * @return  The method's identifier.  
         */
        String getIdentifier();

        /**
         * Returns the method invocation.
         * <p>
         * Such an invocation is a more or less complicated primary expression 
         * ending with the methods identifier. A formal example could look like: 
         * <pre>
         *     anyPrimaryExpression.anyMethodCall(...).anotherMethodCall(...)
         * </pre>. 
         * Calling this method for the example above the primary expression
         * representing <code>
         * 'anyPrimaryExpression.anyMethodCall(...).anotherMethodCall'</code> will 
         * be returned. This primary expression would be of type <code>DotExpression
         * </code> with another <code>DotExpression</code> as the left expression
         * and an <code>Identifier</code> object (i.e. the method's identifier) as 
         * the right expression. 
         * <p>
         * The most trivial primary expression would be the method's identifier, of
         * course.
         * 
         * @see #getIdentifier()
         * 
         * @return  The method invocation.
         */
        PrimaryExpression getMethodInvocation();

        /**
         * Tells if the method call has at least one argument.
         * 
         * @return  <code>true</code> if the method call has at least one argument.
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
         * Removes all arguments.
         * <p>
         * If there're no arguments passed to the method call an implementation of
         * this method is expected to do nothing than return <code>null</code>.
         * 
         * @return  The removed arguments or <code>null</code> if there're no
         *          arguments.
         */
        List<Expression> removeArguments();

        /**
         * Replaces the identifier of <code>this</code>.
         * 
         * @param pNewIdentifier  The new identifier of the method call.
         * 
         * @return  The old identifier.
         */
        String setIdentifier(String pNewIdentifier);
    }
}