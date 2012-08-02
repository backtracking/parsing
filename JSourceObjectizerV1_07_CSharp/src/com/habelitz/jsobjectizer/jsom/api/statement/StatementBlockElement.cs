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

using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
         * Defines constants for each statement block element type.
         * 
         * @author Dieter Habelitz
         */
    public enum ElementType
    {

        /**
         * Constant for <code>assert</code> statements.  
         */
        ASSERT_STATEMENT,

        /**
         * Constant for <code>break</code> statements.
         */
        BREAK_STATEMENT,

        /**
         * Constant for <code>continue</code> statements.
         */
        CONTINUE_STATEMENT,

        /**
         * Constant for <code>DO</code> (... <code>while</code>) statements.
         */
        DO_OR_WHILE_STATEMENT,

        /**
         * Constant for expressions on statement level (assignment expressions, 
         * for instance).
         */
        EXPRESSION_STATEMENT,

        /**
         * Constant for <code>for</code> statements. 
         */
        FOR_STATEMENT,

        /**
         * Constant for <code>for</code> statements that match the <i>forEach</i>
         * specification.
         */
        FOR_EACH_STATEMENT,

        /**
         * Constant for <code>if</code> statements.
         */
        IF_STATEMENT,

        /**
         * Constant for labeled statements.
         */
        LABELED_STATEMENT,

        /**
         * Constant for local class declarations.
         */
        LOCAL_CLASS_DECLARATION,


        /**
         * Constant for local variable declarations. 
         */
        LOCAL_VARIABLE_DECLARATION,

        /**
         * Constant for <code>return</code> statements.
         */
        RETURN_STATEMENT,

        /**
         * Constant for compound statements (i.e. for nested statement block 
         * scopes). 
         */
        STATEMENT_BLOCK_SCOPE,

        /**
         * Constant for <code>switch</code> statements.
         */
        SWITCH_STATEMENT,

        /**
         * Constant for <code>synchronized</code> statements.
         */
        SYNCHRONIZED_STATEMENT,

        /**
         * Constant for <code>throw</code> statements.
         */
        THROW_STATEMENT,

        /**
         * Constant for <code>try</code> statements.
         */
        TRY_STATEMENT
    }

    /**
     * This <code>JSOM</code> type represents a statement block element.
     * 
     * This interface is the base type for all elements that can occur within a
     * statement block scope, i.e. variable declarations, type declarations and all
     * kinds of statements.
     * 
     * @author Dieter Habelitz
     */
    public interface StatementBlockElement : JSOM
    {

        /**
         * Returns the <code>ElementType</code> represented by <code>this</code>.
         * 
         * @return  The <code>ElementType</code> represented by <code>this</code>.
         */
        ElementType getStatementBlockElementType();

        /**
         * Tells if <code>this</code> is a statement or a local variable or type
         * declaration.
         * 
         * @return  <code>true</code> if <code>this</code> is a statement, i.e. if
         *          it isn't a local variable or type declaration.
         */
        bool isStatement();
    }
}