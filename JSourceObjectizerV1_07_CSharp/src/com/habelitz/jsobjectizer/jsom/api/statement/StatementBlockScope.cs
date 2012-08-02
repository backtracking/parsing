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

using com.habelitz.jsobjectizer.jsom.api.statement.abstracttype;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
    /**
    * Defines constants for all possible owners of a statement block scope.
    * 
    * @author Dieter Habelitz
    */
    public enum Owner
    {

        /**
         * Constant for a statement block scope that belongs to a constructor. 
         */
        CONSTRUCTOR,

        /**
         * Constant for a statement block scope that belongs to a <code>catch
         * </code> clause of a <code>try</code> statement. 
         */
        CATCH_CLAUSE,

        /**
         * Constant for a statement block scope that belongs to a compound
         * statement.
         * <p>
         * A compound statement may be a nested statement block or a statement 
         * block following an <code>if</code> statement, a <code>while</code> 
         * statement and so on.
         * <p>
         * Note that there are explicitly defined constants for <code>try</code>
         * statement, <code>catch</code> clause and <code>finally</code> clause
         * statement block scopes.
         */
        COMPOUND_STATEMENT,

        /**
         * Constant for a statement block scope that belongs to a <code>finally
         * </code> clause of a <code>try</code> statement. 
         */
        FINALLY_CLAUSE,

        /**
         * Constant for a statement block scope that belongs to a class' 
         * instance initializer. 
         */
        INSTANCE_INITIALIZER,

        /**
         * Constant for a statement block scope that belongs to a method
         * definition. 
         */
        METHOD_DEFINITION,

        /**
         * Constant for a statement block scope that belongs to a class' static
         * initializer. 
         */
        STATIC_INITIALIZER,

        /**
         * Constant for a statement block following the <code>synchronized
         * </code> keyword. 
         */
        SYNCHRONIZED_STATEMENT,

        /**
         * Constant for a statement block that belongs to a <code>try</code>
         * statement. 
         */
        TRY_STATEMENT
    }
/**
 * This <code>Statement</code> type represents a statement block scope, i.e. a 
 * method body, a compound statement and so on.
 * 
 * @author Dieter Habelitz
 */
public interface StatementBlockScope 
    : Statement, StatementBlockElementContainer {

   
    
    /**
     * Returns the appropriate constant for the owner <code>this</code> belongs 
     * to.
     * 
     * @return One of the <code>Owner</code> constants.
     */
    /*public*/ Owner getOwner();
}
}