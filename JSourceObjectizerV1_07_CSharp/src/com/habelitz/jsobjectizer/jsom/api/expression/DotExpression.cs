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

using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.expression
{
    /**
     * Defines constants for the various dot expression types.
     * 
     * @author Dieter Habelitz
     */
    public enum DotExprType
    {

        /**
         * Constant for the <code>DotExpression</code> type 1
         * (see the documentation of this interface type).
         */
        DOTEXPR_TYPE_1_VARIANTS,

        /**
         * Constant for the <code>DotExpression</code> type 2.
         * (see the documentation of this interface type).
         */
        PRIMITIVE_TYPE_DOT_CLASS,

        /**
         * Constant for the <code>DotExpression</code> type 3.
         * (see the documentation of this interface type).
         */
        VOID_DOT_CLASS,
    }


    /**
     * This <code>PrimaryExpression</code> type represents a chain of primary
     * expressions separated by dots.
     * <p>      
     * A <code>DotExpression</code> represents something like
     *  <pre>
     *      anyPrimaryExpression.anySimplePrimaryTypeExpression
     *  </pre>
     * where <code>anyPrimaryExpression</code> may be a <code>DotExpression</code>
     * again. The following table shows the possibilities of what concrete types
     * <code>anyPrimaryExpression</code> and <code>anySimplePrimaryTypeExpression
     * </code> could be.
     * <p>
     *  <table border=1>
     *      <th>
     *          <code>DotExpression</code> type
     *      </th>
     *      <th>
     *          anyPrimaryExpression (left primary expression) or primitive type
     *      </th>
     *      <th>
     *          anySimplePrimaryTypeExpression (right primary expression)
     *      </th>
     *      <tr>
     *          <td align=center>
     *              1
     *          </td>
     *          <td>
     *              an object of type <code>PrimaryExpression</code> including the
     *              sub-types of <code>PrimaryExpression</code>
     *          </td>
     *          <td>
     *              <ul>
     *                  <li>
     *                      a <code>ClassConstructorCall</code> object that
     *                      represents an inner new expression
     *                  </li>
     *                  <li>
     *                      an <code>Identifier</code> object
     *                  </li>
     *                  <li>
     *                      a <code>PrimaryExpressionKeyword</code> object.
     *                  </li>
     *              </ul>
     *          </td>
     *      </tr>
     *      <tr>
     *          <td align=center>
     *              2
     *          </td>
     *          <td>
     *              a <code>PrimitiveType</code> object
     *          </td>
     *          <td>
     *              a <code>PrimaryExpressionKeyword</code> object set to <code>
     *              KEYWORD_CLASS</code>
     *          </td>
     *      <tr>
     *          <td align=center>
     *              3
     *          </td>
     *          <td>
     *              a <code>PrimaryExpressionKeyword</code> object set to <code>
     *              KEYWORD_VOID</code>
     *          </td>
     *          <td>
     *              a <code>PrimaryExpressionKeyword</code> object set to <code>
     *              KEYWORD_CLASS</code>
     *          </td>
     *      </tr>
     *  </table>
     *  <p>
     *  This interface also defines appropriate constants for all the <code>
     *  DotExpression</code> types as stated by the table above.
     *  
     *       
     * @author Dieter Habelitz
     */
    public interface DotExpression : PrimaryExpression
    {
        /**
         * One of the <code>DotExpression.DotExprType.???</code> constants.
         * 
         * @return  One of the <code>DotExpression.DotExprType.???</code> constants.
         */
        /*public*/ DotExprType getDotExpressionType();

        /**
         * Returns a list containing all expressions, from the most left to the most 
         * right expression.
         * <p>
         * For instance, if <code>this</code> represents an expression like <code>
         * anyExpr1().anyExpr2.anyExpr2</code> this method would return a list
         * containing these three expressions, starting with <code>anyExpr1</code>
         * and ending with <code>anyExpr3</code>.
         * <p>
         * Note that if <code>this</code> is of the dot expression type <code>
         * PRIMITIVE_TYPE_DOT_CLASS</code> the <code>PrimitiveType</code> object
         * will not be part of the list (because this object isn't of type <code>
         * expression</code>).
         * <p>
         * Calling this method equals an <code>getExpressions(null)
         * </code> call.
         * 
         * @see  #getExpressions(List)
         * 
         * @return  A list containing all expressions, from the most left to the
         *          most right expression. 
         */
        /*public*/ List<Expression> getExpressions();

        /**
         * Returns a list containing all expressions, from the most left to the most 
         * right expression.
         * <p>
         * For instance, if <code>this</code> represents an expression like <code>
         * anyExpr1().anyExpr2.anyExpr2</code> this method would return a list
         * containing these three expressions, starting with <code>anyExpr1</code>
         * and ending with <code>anyExpr3</code>.
         * <p>
         * Note that if <code>this</code> is of the dot expression type <code>
         * PRIMITIVE_TYPE_DOT_CLASS</code> the <code>PrimitiveType</code> object
         * will not be part of the list (because this object isn't of type <code>
         * expression</code>).
         * <p>
         * Calling this method equals an <code>getExpressions(null)
         * </code> call.
         * 
         * @param  pList  If this argument isn't <code>null</code> the expressions
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         * 
         * @return  A list containing all expressions, from the most left to the
         *          most right expression. 
         */
        /*public*/ List<Expression> getExpressions(List<Expression> pList);

        /**
         * Returns the expression from the dot's left side.
         * <p>
         * Note that for dot expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS
         * </code> the left side of the dot is a primitive type and this is not an 
         * expression. Therefore this method will always return <code>null</code> 
         * for that dot expression type.
         * 
         * @see  DotExpression#getPrimitiveTypeFromLeft()
         *  
         * @return The expression from the dot's left side or <code>null</code> for
         *         dot expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code>.
         */
        /*public*/ PrimaryExpression getLeftExpression();

        /**
         * Returns the primitive type if <code>this</code> represents a dot 
         * expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code>.
         * 
         * @see #getLeftExpression()
         * 
         * @return  The primitive type if <code>this</code> represents a dot
         *          expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code> and 
         *          <code>null</code> otherwise.
         */
        /*public*/ PrimitiveType getPrimitiveTypeFromLeft();

        /**
         * Returns the expression from the dot's right side.
         *  
         * @return The expression from the dot's right side.
         */
        /*public*/ PrimaryExpression getRightExpression();
    }
}