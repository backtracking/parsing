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

using com.habelitz.jsobjectizer.jsom.api.expression;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
         * Defines constants for the various types of <code>for</code> statement
         * initializers.
         * 
         * @author Dieter Habelitz
         */
    public enum ForInitType
    {

        /**
         * Constant for the case where no <code>for</code> initializer has been
         * stated.
         */
        NONE,

        /**
         * Constant for the case where the <code>for</code> initializer is a
         * variable declaration.
         */
        VAR_DECL,

        /**
         * Constant for the case where the <code>for</code> initializer contains 
         * one ore more expressions.
         */
        EXPRESSION
    }

    /**
     * This <code>Statement</code> type represents a <code>for</code> statement.
     * <p>
     * Note that this interface represents classic <code>for</code> statements only.
     * The <i>forEach</i> variant is represented by it's own interface <code>
     * ForEachStatement</code>. 
     * <p>
     * The JSOM abstraction of <code>for</code> statements looks like
     * <pre>
     *     for(initializer; condition; updater) statement
     * </pre>
     * and matches the following rules:
     *  <ul>
     *      <li>
     *          there're two variants for the <i>initializer</i>
     *          <ul>
     *              <li>
     *                  zero or one local variable declaration
     *              </li>
     *              <li>
     *                  zero or more expressions
     *              </li>
     *          </ul>
     *      </li>
     *      <li>
     *          the <i>condition</i> can be stated by zero or one expression and
     *      </li>  
     *      <li>
     *          the <i>updater</i> can be stated by zero or more expressions.
     *      </li>  
     *  </ul>
     * The method <code>getForInitType()</code> can be used to find out of what
     * variant the <i>initializer</i> is.
     * 
     * @see ForEachStatement
     * 
     * @author Dieter Habelitz
     */
    public interface ForStatement : Statement
    {



        /**
         * Returns the <code>for</code> statement's condition expression.
         * 
         * @return  The <code>for</code> statement's condition expression or <code>
         *          null</code> if no condition expression has been stated.
         */
        /*public*/ Expression getForCondition();

        /**
         * Returns the type of the <code>for</code> statement's initializer variant.
         * 
         * @return  One of the <code>ForStatement.ForInitType</code> constants.
         */
        /*public*/ ForInitType getForInitType();

        /**
         * Returns a list of the <code>for</code> statement's updater expressions.
         * <p>
         * Calling this method equals an <code>getForUpdaters(null)</code>
         * call.
         * 
         * @see #getForUpdaters(List)
         *                
         * @return  A list of the <code>for</code> statement's updater expressions.
         *          If no updaters have been stated <code>null</code> will be 
         *          returned.
         */
        /*public*/ List<Expression> getForUpdaters();

        /**
         * Returns a list of the <code>for</code> statement's updater expressions.
         * 
         * @param  pList  If this argument isn't <code>null</code> the expressions
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *                
         * @return  A list of the <code>for</code> statement's updater expressions.
         *          If no updaters have been stated <code>null</code> will be 
         *          returned, even if the argument <code>pList</code> isn't <code>
         *          null</code>.
         */
        /*public*/ List<Expression> getForUpdaters(List<Expression> pList);

        /**
         * Returns a list of the expressions stated within the <code>for</code> 
         * statement's initializer.
         * <p>
         * Calling this method equals an <code>getInitializerExpressions(null)
         * </code> call.
         * 
         * @see #getInitializerExpressions(List)
         *                
         * @return  A list of the <code>for</code> statement's initializer 
         *          expressions. If <code>
         *          'getForInitType() != ForInitType.EXPRESSION</code> <code>null
         *          </code> will be returned.
         */
        /*public*/ List<Expression> getInitializerExpressions();

        /**
         * Returns a list of the expressions stated within the <code>for</code> 
         * statement's initializer.
         * 
         * @param  pList  If this argument isn't <code>null</code> the expressions
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *                
         * @return  A list of the <code>for</code> statement's initializer 
         *          expressions. If <code>
         *          'getForInitType() != ForInitType.EXPRESSION</code> <code>null
         *          </code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>.
         */
        /*public*/ List<Expression> getInitializerExpressions(List<Expression> pList);

        /**
         * Returns the local variable declaration stated within the <code>for</code> 
         * statement's initializer.
         * 
         * @return  The <code>for</code> statement's initializer variable 
         *          declaration or <code>null</code> if <code>getForInitType() != 
         *          ForInitType.VAR_DECL</code>.
         */
        /*public*/ LocalVariableDeclaration getInitializerVarDecl();


        /**
         * Returns the statement that should be executed by the <code>for</code> 
         * loop.
         * 
         * @return  The statement that should be executed by the <code>for</code> 
         *          loop.
         */
        /*public*/ Statement getStatement();

        /**
         * Tells if the <code>for</code> statement has a condition expression.
         * 
         * @return  <code>true</code> if the <code>for</code> statement has a 
         *          condition expression.
         */
        /*public*/ bool hasForCondition();

        /**
         * Tells if the <code>for</code> statement has at least one updater 
         * expression.
         * 
         * @return  <code>true</code> if the <code>for</code> statement has at least 
         *          one updater expression.
         */
        /*public*/ bool hasForUpdater();
    }
}