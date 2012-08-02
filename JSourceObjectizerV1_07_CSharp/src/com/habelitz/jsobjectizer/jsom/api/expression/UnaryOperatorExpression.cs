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

namespace com.habelitz.jsobjectizer.jsom.api.expression
{
    /**
         * Defines constants for all binary operators.
         * 
         * @author Dieter Habelitz
         */
    public enum Operator
    {

        /**
         * Constant for the logical operator <code>'~'</code>.
         */
        BITWISE_NOT,

        /**
         * Constant for the logical operator <code>'!'</code>.
         */
        LOGICAL_NOT,

        /**
         * Constant for post increment operator <code>'++'</code>, i.e. <code>
         * 'whatever++'</code>.
         */
        POST_INCREMENT,

        /**
         * Constant for post decrement operator <code>'--'</code>, i.e. <code>
         * 'whatever--'</code>.
         */
        POST_DECREMENT,

        /**
         * Constant for pre increment operator <code>'++'</code>, i.e. <code>
         * '++whatever'</code>.
         */
        PRE_INCREMENT,

        /**
         * Constant for pre decrement operator <code>'--'</code>, i.e. <code>
         * '--whatever'</code>.
         */
        PRE_DECREMENT,

        /**
         * Constant for unary plus operator, i.e. <code>'+whatever'</code>.
         */
        UNARY_PLUS,

        /**
         * Constant for unary minus operator, i.e. <code>'-whatever'</code>.
         */
        UNARY_MINUS
    }

    /**
     * This <code>Expression</code> type represents all kinds of unary operator
     * expressions.
     * <p>
     * The kind of the used unary operator can be found out by calling the method 
     * <code>getOperatorType()</code>.
     * 
     * @author Dieter Habelitz
     */
    public interface UnaryOperatorExpression : Expression
    {

        

        /**
         * Returns the operand.
         * 
         * @return  The operand.
         */
        /*public*/ Expression getOperand();

        /**
         * Returns the kind of the unary operator.
         * 
         * @return  One of the <code>UnaryOperatorExpression.Operator.???</code> 
         *          constants.
         */
        /*public*/ Operator? getOperatorType();
    }
}