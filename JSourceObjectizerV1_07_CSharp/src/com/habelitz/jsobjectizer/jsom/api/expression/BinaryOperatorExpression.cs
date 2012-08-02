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
using System.Reflection;

//import sun.tools.tree.InstanceOfExpression; ????

namespace com.habelitz.jsobjectizer.jsom.api.expression
{

    /**
     * This <code>Expression</code> type represents all kinds of binary operator
     * expressions.
     * <p>
     * The kind of the used binary operator can be found out by calling the method 
     * <code>getOperatorType()</code>.
     * <p>
     * Note that this class doesn't deal with the <code>instanceof</code> operator. 
     * 
     * @see InstanceOfExpression
     * 
     * @author Dieter Habelitz
     */
    /**
     * Defines constants for all binary operators.
     * 
     * @author Dieter Habelitz
     */
    class BinaryOperatorAttr : Attribute
    {
        private bool mIsAssignmentOperator;

        internal BinaryOperatorAttr(bool isAssignmentOperator)
        {
            mIsAssignmentOperator = isAssignmentOperator;
        }
        public bool isAssignmentOperator()
        {
            return mIsAssignmentOperator;
        }
    }

    public static class Operators
    {
        public static bool isAssignmentOperator(this BinaryOperator p)
        {
            BinaryOperatorAttr attr = GetAttr(p);
            return attr.isAssignmentOperator();
        }

        private static BinaryOperatorAttr GetAttr(BinaryOperator p)
        {
            return (BinaryOperatorAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(BinaryOperatorAttr));
        }

        private static MemberInfo ForValue(BinaryOperator p)
        {
            return typeof(BinaryOperator).GetField(Enum.GetName(typeof(BinaryOperator), p));
        }

        // Methods for nullable enum
        public static bool isAssignmentOperator(this BinaryOperator? p)
        {
            BinaryOperatorAttr attr = GetAttr(p);
            return attr.isAssignmentOperator();
        }

        private static BinaryOperatorAttr GetAttr(BinaryOperator? p)
        {
            return (BinaryOperatorAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(BinaryOperatorAttr));
        }

        private static MemberInfo ForValue(BinaryOperator? p)
        {
            return typeof(BinaryOperator).GetField(Enum.GetName(typeof(BinaryOperator), p));
        }
    }

    public enum BinaryOperator
    {

        /**
        * Constant for the arithmetic operator <code>'+'</code>.
        */
        [BinaryOperatorAttr(false)]
        ADD,

        /**
         * Constant for the compound assignment operator <code>'+='</code>.
         */
        [BinaryOperatorAttr(true)]
        ADD_ASSIGN,

        /**
         * Constant for the assignment operator <code>'='</code>.
         */
        [BinaryOperatorAttr(true)]
        ASSIGN,

        /**
         * Constant for the bitwise operator <code>'&'</code>.
         */
        [BinaryOperatorAttr(false)]
        BITWISE_AND,

        /**
         * Constant for the compound assignment operator <code>'&='</code>.
         */
        [BinaryOperatorAttr(true)]
        BITWISE_AND_ASSIGN,

        /**
         * Constant for the bitwise operator <code>'|'</code>.
         */
        [BinaryOperatorAttr(false)]
        BITWISE_OR,

        /**
         * Constant for the compound assignment operator <code>'|='</code>.
         */
        [BinaryOperatorAttr(true)]
        BITWISE_OR_ASSIGN,

        /**
         * Constant for the bitwise operator <code>'^'</code>.
         */
        [BinaryOperatorAttr(false)]
        BITWISE_XOR,

        /**
        * Constant for the compound assignment operator <code>'^='</code>.
        */
        [BinaryOperatorAttr(true)]
        BITWISE_XOR_ASSIGN,

        /**
         * Constant for the shift operator <code>'&gt;&gt;&gt;'
         * </code>.
         */
        [BinaryOperatorAttr(false)]
        BIT_SHIFT_RIGHT,

        /**
         * Constant for the compound assignment operator <code>'&gt;&gt;&gt;='
         * </code>.
         */
        [BinaryOperatorAttr(true)]
        BIT_SHIFT_RIGHT_ASSIGN,

        /**
         * Constant for the arithmetic operator <code>'/'</code>.
         */
        [BinaryOperatorAttr(false)]
        DIV,

        /**
         * Constant for the compound assignment operator <code>'/='</code>.
         */
        [BinaryOperatorAttr(true)]
        DIV_ASSIGN,

        /**
         * Constant for the comparison operator <code>'=='</code>.
         */
        [BinaryOperatorAttr(false)]
        EQUAL,

        /**
        * Constant for the comparison operator operator <code>'>='</code>.
        */
        [BinaryOperatorAttr(false)]
        GREATER_OR_EQUAL,

        /**
        * Constant for the comparison operator operator <code>'>'</code>.
        */
        [BinaryOperatorAttr(false)]
        GREATER_THAN,

        /**
         * Constant for the comparison operator operator <code>'<='</code>.
         */
        [BinaryOperatorAttr(false)]
        LESS_OR_EQUAL,

        /**
         * Constant for the comparison operator operator <code>'<'</code>.
         */
        [BinaryOperatorAttr(false)]
        LESS_THAN,

        /**
         * Constant for the logical operator <code>'&&'</code>.
         */
        [BinaryOperatorAttr(false)]
        LOGICAL_AND,

        /**
         * Constant for the logical operator <code>'||'</code>.
         */
        [BinaryOperatorAttr(false)]
        LOGICAL_OR,

        /**
         * Constant for the arithmetic operator <code>'%'</code>.
         */
        [BinaryOperatorAttr(false)]
        MOD,

        /**
         * Constant for the compound assignment operator <code>'%='</code>.
         */
        [BinaryOperatorAttr(true)]
        MOD_ASSIGN,

        /**
         * Constant for the arithmetic operator <code>'*'</code>.
         */
        [BinaryOperatorAttr(false)]
        MUL,

        /**
         * Constant for the compound assignment operator <code>'*='</code>.
         */
        [BinaryOperatorAttr(true)]
        MUL_ASSIGN,

        /**
         * Constant for the comparison operator <code>'!='</code>.
         */
        [BinaryOperatorAttr(false)]
        NOT_EQUAL,

        /**
         * Constant for the shift operator <code>'&lt;&lt;'</code>.
         */
        [BinaryOperatorAttr(false)]
        SHIFT_LEFT,

        /**
        * Constant for the compound assignment operator <code>'&lt;&lt;='</code>.
        */
        [BinaryOperatorAttr(true)]
        SHIFT_LEFT_ASSIGN,

        /**
        * Constant for the shift operator <code>'&gt;&gt;'</code>.
        */
        [BinaryOperatorAttr(false)]
        SHIFT_RIGHT,

        /**
         * Constant for the compound assignment operator <code>'&gt;&gt;='</code>.
         */
        [BinaryOperatorAttr(true)]
        SHIFT_RIGHT_ASSIGN,

        /**
         * Constant for the arithmetic operator <code>'-'</code>.
         */
        [BinaryOperatorAttr(false)]
        SUB,

        /**
         * Constant for the compound assignment operator <code>'-='</code>.
         */
        [BinaryOperatorAttr(true)]
        SUB_ASSIGN
    }

    public interface BinaryOperatorExpression : Expression
    {

        /**
         * Returns the operand from the operator's left side.
         * <p>
         * For assignment expressions the left operand corresponds to the lValue.
         * 
         * @return  The operand from the operator's left side.
         */
        /*public*/ Expression getLeftOperand();

        /**
         * Returns the kind of the binary operator.
         * 
         * @return  One of the <code>BinaryOperatorExpression.Operator.???</code> 
         *          constants.
         */
        /*public*/ BinaryOperator? getOperatorType();

        /**
         * Returns the operand from the operator's right side.
         * <p>
         * For assignment expressions the right operand corresponds to the rValue.
         * 
         * @return  The operand from the operator's right side.
         */
        /*public*/ Expression getRightOperand();

        /**
         * Tells if the operator of <code>this/code> is an assignment operator.
         * <p>
         * For cases where it is of interest to know if an operator is an assignment
         * operator but where it is not of interest to know what assignment
         * assignment operator it actually is (the standard assignment operator
         * <code>'='</code> or one of the compound assignment operators like <code>
         * '+='</code>, <code>'-='</code>, <code>'<<='</code> and so on) this method
         * can be used to get the answer without the need of a load of <i>ORed</i>
         * conditions. 
         * 
         * @return  <code>true</code> if the operator of <code>this/code> is an 
         *          assignment operator. 
         */
        /*public*/ bool isAssignmentOperator();
    }
}