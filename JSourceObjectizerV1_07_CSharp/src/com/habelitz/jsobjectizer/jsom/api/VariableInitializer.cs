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
using com.habelitz.jsobjectizer.jsom.api.expression;

namespace com.habelitz.jsobjectizer.jsom.api
{

    /**
     * This <code>JSOM</code> type represents a variable initializer.
     * <p>
     * A variable initializer can exist in two different incarnations. The first
     * variant is a more or less simple expression that can be most trivially any 
     * literal or even a fairly complex expression. The second variant are array
     * initializers like the following formal example
     * <pre>
     *     {   {"11", "12", "13"},
     *         {"21", "22", "23"},
     *         {"31", "32", "33"},
     *     }
     * </pre>
     * The first variant can be resolved simply by calling the method <code>
     * getExpression()</code> that returns the initializer expression. Resolving an
     * array initializer is a little bit more complex and it starts with calling the
     * method <code>getArrayInitializers()</code> which returns a list of <code>
     * VariableInitializer</code> objects that can represent expressions or further 
     * array initializers.
     * <p>
     * Taking the array initializer example above the first call of <code>
     * getArrayInitializers()</code> would return a list containing three <code>
     * VariableInitializer</code> objects representing array initializers again. 
     * Repeating the <code>getArrayInitializers()</code> call on each of these three 
     * objects will result in getting three further lists of three <code>
     * VariableInitializer</code> objects each, which now represent variable 
     * initializer expressions. Finally the method <code>getExpression()</code> can 
     * be called on each of these nine objects.
     * 
     * @author Dieter Habelitz
     */
    public interface VariableInitializer : JSOM
    {

        /**
         * If <code>this</code> represents an array initializer this method returns 
         * a list of the array initializers (see the documentation of this class 
         * above).
         * <p>
         * Calling this method equals an <code>getArrayInitializers(null)</code>
         * call.
         * 
         * @see #getArrayInitializers(List)
         *  
         * @return  A list of the array initializers. If <code>this</code> doesn't 
         *          represent an array initializer or if <code>this</code> 
         *          represents an empty array initializer (i.e. <code>
         *          isArrayInitializer()</code> will return <code>false</code> for 
         *          the first case but <code>true</code> for the second case) <code>
         *          null</code> will be returned.
         */
        /*public*/ List<VariableInitializer> getArrayInitializers();

        /**
         * If <code>this</code> represents an array initializer this method returns 
         * a list of the array initializers (see the documentation of this class 
         * above).
         * 
         * @param  pList  If this argument isn't <code>null</code> the array
         *                initializers will be added to this list and this list
         *                object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of the array initializers. If <code>this</code> doesn't 
         *          represent an array initializer or if <code>this</code> 
         *          represents an empty array initializer (i.e. <code>
         *          isArrayInitializer()</code> will return <code>false</code> for 
         *          the first case but <code>true</code> for the second case) <code>
         *          null</code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>.
         */
        /*public*/ List<VariableInitializer> getArrayInitializers(
                List<VariableInitializer> pList);

        /**
         * Returns the initializer expression.
         * 
         * @return  The initializer expression or <code>null<code> if <code>this
         *          </code> represents an array initializer.
         */
        /*public*/ Expression getExpression();

        /**
         * Returns <code>true</code> if <code>this</code> represents an array 
         * initializer.
         * 
         * @return  <code>true</code> if <code>this</code> represents an array 
         *          initializer.
         */
        /*public*/ bool isArrayInitializer();
    }
}