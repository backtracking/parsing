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

using com.habelitz.jsobjectizer.jsom.api.expression;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
     * This <code>Statement</code> type represents an <code>if</code> statement.
     * 
     * @author Dieter Habelitz
     */
    public interface IfStatement : Statement
    {

        /**
         * Returns the <code>if</code> statement's condition expression.
         * 
         * @return  The <code>if</code> statement's condition expression.
         */
        Expression getCondition();

        /**
         * Returns the statement that belongs to the optional <code>else</code> 
         * clause that belongs to <code>this</code>, i.e. this is the statement
         * that should be executed if the <code>if</code> statement's condition 
         * expression is <code>false</code>.
         * 
         * @return  The statement that belongs an <code>else</code> clause or <code>
         *          null</code> if no <code>else</code> clause has been stated.
         */
        Statement getElseStatement();

        /**
         * Returns the statement that should be executed if the <code>if</code> 
         * statement condition is <code>true</code>.
         * 
         * @return  The statement that should be executed if the <code>if</code> 
         *          statement condition is <code>true</code>.
         */
        Statement getStatement();

        /**
         * Tells if the <code>if</code> statement has an <code>else</code> branch.
         * 
         * @return  <code>true</code> if the <code>if</code> statement has an <code>
         *          else</code> branch.
         */
        bool hasElseClause();
    }
}