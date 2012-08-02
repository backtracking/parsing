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

using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api.expression {

    /**
      * Defines constants for all <code>Expression</code> suptypes.
      * 
      * @author Dieter Habelitz
      */
    public enum ExpressionType
    {

        /**
         * Constant for static array element accesses, i.e. something like 
         * <code>'AnyArray[offset]'</code>.
         */
        ARRAY_ELEMENT_ACCESS,

        /**
         * Constant for array type declarators, i.e. something like <code>
         * 'AnyArray[]'</code>.
         */
        ARRAY_TYPE_DECLARATOR,

        /**
         * Constant for all expressions with one operator and two operands.
         * <p>
         * Examples for such expressions are assignment expressions, shift
         * expressions, comparison expressions and so on. I.e. all expressions 
         * with one operator and an operand on the left and right side of that 
         * operator must be marked by this constant.
         */
        BINARY_OPERATOR_EXPRESSION,

        /**
         * Constant for new expressions in the form of class constructor calls, 
         * i.e. something like <code>'new AnyType(constructorArgs)</code>.
         * 
         * @see ExpressionType#STATIC_ARRAY_CREATOR
         */
        CLASS_CONSTRUCTOR_CALL,

        /**
         * Constant for conditional expressions.
         */
        CONDITIONAL_EXPRESSION,

        /**
         * Constant for <code>DotExpression</code> expression types, i.e. dot
         * separated primary expressions
         */
        DOT_EXPRESSION,

        /**
         * Constant for explicit <code>this</code> or </code>super</code> 
         * constructor call expressions.
         */
        EXPLICIT_CONSTRUCTOR_CALL,

        /**
         * Constant for identifier expressions.
         * <p>
         * An identifier expression is nothing else than a not qualified 
         * identifier.
         */
        IDENTIFIER,

        /**
         * Constant for <code>instanceof</code> expressions.
         */
        INSTANCEOF_EXPRESSION,

        /**
         * Constant for the primary expression keywords that are not handled by
         * anything else; these are the keywords <code>class</code>, <code>this
         * </code>, <code>super</code> and <code>void</code>.
         */
        KEYWORD,

        /**
         * Constant for all kinds of literals.
         */
        LITERAL,

        /**
         * Constant for method call expressions, i.e. method invocations.
         */
        METHOD_CALL,

        /**
         * Constant for parenthesized expressions, i.e. expressions enclosed 
         * within parentheses.
         */
        PARENTHESIZED_EXPRESSION,

        /**
         * Constant for new expressions in the form of static array creators, 
         * i.e. something like <code>'new AnyType[expression]'</code> or <code>
         * 'new AnyType[] {anyInitializers}'</code>.
         * <p>
         * @see ExpressionType#CLASS_CONSTRUCTOR_CALL
         */
        STATIC_ARRAY_CREATOR,

        /**
         * Constant for type cast expressions.
         */
        TYPE_CAST,

        /**
         * Constant for all expressions with one operator and one operands.
         * <p>
         * Examples for such expressions are pre/post increment/decrement 
         * expressions.
         */
        UNARY_OPERATOR_EXPRESSION
    }

    
    /**
 * This <code>JSOM</code> type is the base type for all kinds of expressions.
 * 
 * @author Dieter Habelitz
 */
public interface Expression : JSOM {

    /**
     * Returns the <code>ExpressionType</code> represented by <code>this</code>.
     * 
     * @return The <code>ExpressionType</code> represented by <code>this</code>.
     */
    /*public*/ ExpressionType getExpressionType();
}
}