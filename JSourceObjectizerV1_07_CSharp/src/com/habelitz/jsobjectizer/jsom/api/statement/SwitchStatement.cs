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
using com.habelitz.jsobjectizer.jsom.api.statement.abstracttype;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
     * This <code>Statement</code> type represents a <code>switch</code> statement.
     * <p>
     * This interface also defines an inner interface <code>SwitchLabel</code> 
     * representing <code>case</code> and <code>default</code>.
     * <p>
     * <b>Problem:</b> <code>SwitchLabel</code> : <code>
     * StatementBlockElementContainer</code> and therefore each <code>SwitchLabel
     * </code> knows about the statements and local class and variable declarations
     * that have been stated following this <code>SwitchLabel</code> up to the next
     * one or up to the end of the <code>switch</code> statement for the last <code>
     * SwitchLabel</code>. However, this doesn't actually match the visibility of 
     * the content in the real Java world because <code>SwitchLabel</code>s haven't
     * their own local scopes - there's only one local scope bound to the <code>
     * switch</code> statement.    
     * <b>Solution:</b> Also <code>SwitchStatement</code> : <code>
     * StatementBlockElementContainer</code> but an implementation mustn't have it's
     * own content but operate on the statement block element content of the <code>
     * SwitchLabel</code>s instead.  
     *  
     * @author Dieter Habelitz
     */
    public interface SwitchStatement : Statement, StatementBlockElementContainer
    {



        /**
         * Returns the <code>switch</code> expression.
         * 
         * @return  The <code>switch</code> expression.
         */
        /*public*/ Expression getExpression();

        /**
         * Returns a list of the <code>case</code> and <code>default</code> clauses.
         * <p>
         * Calling this method equals an <code>getSwitchLabels(null)</code>
         * call.
         * 
         * @see #getSwitchLabels(List)
         *  
         * @return  A list of <code>case</code> and/or <code>default</code> clauses. 
         *          If there are no <code>case</code> and <code>default</code> 
         *          clauses <code>null</code> will be returned.
         */
        /*public*/ List<SwitchLabel> getSwitchLabels();

        /**
         * Returns a list of the <code>case</code> and <code>default</code> clauses.
         * 
         * @param  pList  If this argument isn't <code>null</code> the <code>case
         *                </code> and <code>default</code> clauses will be added to 
         *                this list and this list object will be returned. Otherwise 
         *                a new list will be created for the result.  
         * 
         * @return  A list of <code>case</code> and/or <code>default</code> clauses. 
         *          If there are no <code>case</code> and <code>default </code> 
         *          clauses <code>null</code> will be returned, even if the argument
         *          <code>pList</code> isn't <code>null</code>.
         */
        /*public*/ List<SwitchLabel> getSwitchLabels(List<SwitchLabel> pList);

        /**
         * Tells if the <code>switch</code> statement has at least one <code>case
         * </code> or <code>default</code> clause.
         * 
         * @return  <code>true</code> if the <code>switch</code> statement has at 
         *          least one <code>case</code> or <code>default</code> clause.
         */
        /*public*/ bool hasSwitchLabel();
    }
    /**
     * Represents <code>case</code> and <code>default</code> clauses.
     * <p>
     * The difference between the two clauses is that a <code>case</code> clause
     * always has a constant expression whereas a <code>default</code> clause
     * never has one, of course. However, there's also the method <code>
     * isDefaultClause()</code> to find out if a certain clause is a <code>
     * default</code> clause or a <code>case</code> clause. 
     * 
     * @author Dieter Habelitz
     */
    public interface SwitchLabel : StatementBlockElementContainer
    {

        /**
         * Tells if <code>this</code> is a <code>default</code> clause.
         * 
         * @return  <code>true</code> if <code>this</code> is a <code>default
         *          </code> clause.
         */
        /*public*/ bool isDefaultClause();

        /**
         * Returns the expression of the <code>case<code> clause.
         * 
         * @return  The expression of the <code>case<code> clause or <code>null
         *          </code> if <code>this</code> is actually a <code>default
         *          </code> clause.
         */
        /*public*/ Expression getExpression();
    }
}