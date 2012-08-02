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

using com.habelitz.jsobjectizer;

namespace com.habelitz.jsobjectizer.jsom.api.expression {

    /**
     * Defines constants for the various <code>Literal</code> types.
     * 
     * @author Dieter Habelitz
     */
    public enum LiteralType
    {

        /**
         *  Constant for hexadecimal number literals. 
         */
        HEX_NUMBER,
        /**
         *  Constant for octal number literals. 
         */
        OCTAL_NUMBER,
        /**
         *  Constant for decimal number literals. 
         */
        DECIMAL_NUMBER,
        /**
         *  Constant for floating point literals. 
         */
        FLOATING_POINT_NUMBER,
        /**
         *  Constant for character literals. 
         */
        CHARACTER,
        /**
         *  Constant for string literals. 
         */
        STRING,
        /**
         *  Constant for the bool literal <code>true</code>. 
         */
        TRUE,
        /**
         *  Constant for the bool literal <code>true</code>. 
         */
        FALSE,
        /**
         *  Constant for the <code>null</code> literal. 
         */
        NULL
    }

/**
 * This <code>PrimaryExpression</code> represents a literal.
 * 
 * @author Dieter Habelitz
 */
public interface Literal : PrimaryExpression {
    
    

    /**
     * Returns the literal.
     * <p>
     * For the number, character or string literals the appropriate literal
     * string will be returned. For the literal types <code>LiteralType.TRUE
     * </code>, <code>LiteralType.FALSE</code> and <code>LiteralType.NULL</code> 
     * this method returns <code>"true"</code>, <code>"false"</code> and <code>
     * "null"</code>, respectively.
     * 
     * @return  The literal.
     */
    /*public*/ String getLiteral();
    
    /**
     * Returns one of the <code>LiteralType.???</code> constants.
     * 
     * @return  One of the <code>LiteralType.???</code> constants.
     */
    /*public*/ LiteralType getType();
    
    /**
     * Changes <code>this</code> to become a <code>Literal</code> object
     * representing a literal stated as string.
     * <p>
     * Literals like numbers, bool values, the <code>null</code> literal,
     * characters and so on can be stated as expected, i.e. like
     * <ul>
     *  <li>
     *      <i>"123"</i> (an integer)
     *  </li>
     *  <li>
     *      <i>"true"</i> (a bool literal)
     *  </li>
     *  <li>
     *      <i>"null"</i> (the <code>null</code> literal)
     *  </li>
     *  <li>
     *      <i>"'a'"</i> (the character literal <code>a</code>)
     *  </li>
     *  <li>
     *      <i>"'\''"</i> (the character literal <code>'</code>)
     *  </li>
     * </ul> 
     * For string literals it must be considered that they must be stated
     * including the quotation marks that belong to the string literal. Examples
     * are
     * <ul>
     *  <li>
     *      <i>"\"\""</i> (the empty string)
     *  </li>
     *  <li>
     *      <i>"\"anyString\""</i> (a simple non-empty string)
     *  </li>
     *  <li>
     *      <i>"\"with \\\" character\""</i> (a string containing one escaped 
     *      <code>'"'</code> character)
     *  </li>
     * </ul>
     * 
     * @param pLiteral  The new literal stated as string.
     * 
     * @return  The old literal.
     *
     * @  if the given literal isn't a valid
     *                                     literal; note that the passed literal
     *                                     string must be parsable by the
     *                                     unmarshaller.
     * 
     * @see #setLiteralChecked(String)
     */
    /*public*/ String setLiteral(String pLiteral);
    
    /**
     * Changes <code>this</code> to become a <code>Literal</code> object
     * representing a literal stated as string.
     * <p>
     * Calling this method equals to a {@link #setLiteral(String)} call with
     * the exception that this method doesn't throw an exception if the given
     * literal is invalid, i.e. not parsable. In such cases this method just
     * returns <code>null</code>.
     * <p>
     * Literals like numbers, bool values, the <code>null</code> literal,
     * characters and so on can be stated as expected, i.e. like
     * <ul>
     *  <li>
     *      <i>"123"</i> (an integer)
     *  </li>
     *  <li>
     *      <i>"true"</i> (a bool literal)
     *  </li>
     *  <li>
     *      <i>"null"</i> (the <code>null</code> literal)
     *  </li>
     *  <li>
     *      <i>"'a'"</i> (the character literal <code>a</code>)
     *  </li>
     *  <li>
     *      <i>"'\''"</i> (the character literal <code>'</code>)
     *  </li>
     * </ul> 
     * For string literals it must be considered that they must be stated
     * including the quotation marks that belong to the string literal. Examples
     * are
     * <ul>
     *  <li>
     *      <i>"\"\""</i> (the empty string)
     *  </li>
     *  <li>
     *      <i>"\"anyString\""</i> (a simple non-empty string)
     *  </li>
     *  <li>
     *      <i>"\"with \\\" character\""</i> (a string containing one escaped 
     *      <code>'"'</code> character)
     *  </li>
     * </ul>
     * 
     * @param pLiteral  The new literal stated as string.
     * 
     * @return  The old literal or <code>null</code> if the passed literal is
     *          invalid, i.e. not parsable.
     *
     * @see #setLiteral(String)
     */
    /*public*/ String setLiteralChecked(String pLiteral);
}
}