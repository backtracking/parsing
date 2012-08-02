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

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
     * This <code>Statement</code> type represents a <code>try</code> statement.
     * <p>
     * This interface also defines an inner interface <code>Catch</code> 
     * representing <code>catch</code> clauses.
     *  
     * @author Dieter Habelitz
     */
    public interface TryStatement : Statement
    {
        /**
         * Returns a list of the <code>catch</code> clauses.
         * <p>
         * Calling this method equals an <code>getCatchClauses(null)</code>
         * call.
         * 
         * @see #getCatchClauses(List)
         *  
         * @return  A list of the <code>catch</code> clauses. If the <code>try
         *          </code> statement has no <code>catch</code> clause <code>null
         *          </code> will be returned..
         */
        List<Catch> getCatchClauses();

        /**
         * Returns a list of the <code>catch</code> clauses.
         * 
         * @param  pList  If this argument isn't <code>null</code> the <code>catch
         *                </code> clauses will be added to this list and this list
         *                object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of the <code>catch</code> clauses. If the <code>try
         *          </code> statement has no <code>catch</code> clause <code>null
         *          </code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>.
         */
        List<Catch> getCatchClauses(List<Catch> pList);

        /**
         * Returns the <code>finally</code> clause's statement block scope, i.e. the 
         * content of the <code>finally</code> block.
         * 
         * @return  The <code>finally</code> clause's statement block scope or 
         *          <code>null</code> if the <code>try</code> statement has no 
         *          <code>finally</code> clause.
         */
        StatementBlockScope getFinallyStatementBlockScope();

        /**
         * Returns the <code>try</code> statement's statement block scope, i.e. the 
         * content of the <code>try</code> block.
         * 
         * @return  The <code>try</code> statement's statement block scope.
         */
        StatementBlockScope getStatementBlockScope();

        /**
         * Tells if the <code>try</code> statement has at least one catch clause.
         * 
         * @return  <code>true</code> if the <code>try</code> statement has at least 
         *          one <code>catch</code> clause.
         */
        bool hasCatchClause();

        /**
         * Tells if the <code>try</code> statement has a finally clause.
         * 
         * @return  <code>true</code> if the <code>try</code> statement has a <code> 
         *          finally</code> clause.
         */
        bool hasFinallyClause();
    }

    /**
         * Represents <code>catch</code> clauses.
         * <p>
         * The JSOM abstraction of <i>catch</i> clauses looks like
         * <pre>
         *     catch(localModifierList type variableDeclaratorIdentifier)
         * </pre>
         * 
         * @author Dieter Habelitz
         */
    public interface Catch : JSOM
    {

        /**
         * Returns the formal parameter of the <code>catch</code> clause.
         * 
         * @return  The formal parameter of the <code>catch</code> clause.
         */
        FormalParameterDeclaration getFormalParameter();

        /**
         * Returns the <code>catch</code> clause's statement block scope, i.e. 
         * the content of the <code>catch</code> block.
         * 
         * @return  The <code>catch</code> clause's statement block scope.
         */
        StatementBlockScope getStatementBlockScope();
    }

}