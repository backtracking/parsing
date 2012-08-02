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

namespace com.habelitz.jsobjectizer.jsom.api.expression
{

/**
 * This <code>PrimaryExpression</code> type represents the access to a static
 * array's element like <code>
 * 'anyPrimaryExpression.arrayIdentifier[anyOffsetExpression]'</code>, where 
 * <code>'anyPrimaryExpression'</code> is an optional qualifier and <code>
 * 'arrayIdentifier'</code> the identifier of the static array.
 * 
 * @author Dieter Habelitz
 */
public interface ArrayElementAccess : PrimaryExpression {

    /**
     * Returns the access to the array.
     * <p>
     * An array access is a more or less complicated primary expression ending
     * with the array's identifier. A formal example could look like: 
     * <pre>
     *     anyMethodCall(anyArgs).arrayIdentifier[anyOffsetExpression]
     * </pre>. 
     * Calling this method for the example above the primary expression
     * representing <code>'anyMethodCall(anyArgs).anyArrayIdentifier'</code> 
     * would be returned.
     * <p>
     * The most trivial primary expression would be the array's identifier, of
     * course.
     * <p>
     * Note that for multidimensional arrays this method returns <code>
     * ArrayElementAccess</code> objects until the least dimension has been
     * reached.
     * 
     * @see #getIdentifier()
     * 
     * @return  The array's accessor.
     */
    /*public*/ PrimaryExpression getArrayAccess();

    /**
     * Returns the array's identifier.
     * <p>
     * This method extracts the array's identifier from the primary expression
     * that represents the array access. 
     * 
     * @see #getArrayAccess()
     * 
     * @return  The array's identifier or <code>null</code> if the array isn't 
     *          accessed via an identifier, i.e. if the accessor is a method 
     *          call (something like <code>anyMethodCall()[]</code> or an <code>
     *          ArrayElementAccess</code> again (multidimensional arrays). Or to
     *          say it in other words: This method only returns an identifier
     *          if <code>getArrayAccess()</code> returns a <code>JSOM</code>
     *          object of type <code>Identifier</code> or of type <code>
     *          DotExpression</code> with a right expression representing an
     *          identifier.
     */
    /*public*/ String getIdentifier();

    /**
     * Returns the array offset.
     * <p>
     * This method extracts offset expression from the primary expression that
     * represents the array access. 
     * 
     * @see #getArrayAccess()
     * 
     * @return  The array offset.
     */
    /*public*/ Expression getOffset();
    
    /**
     * Tells if the array is accessed via an array identifier.
     * 
     * @return  <code>true</code> if the array is accessed via an identifier but
     *          <code>false</code> otherwise, i.e. if the accessor is a method 
     *          call (something like <code>anyMethodCall()[]</code> or an <code>
     *          ArrayElementAccess</code> again (multidimensional arrays). Or to
     *          say it in other words: This method only returns an identifier
     *          if <code>getArrayAccess()</code> returns a <code>JSOM</code>
     *          object of type <code>Identifier</code> or of type <code>
     *          DotExpression</code> with a right expression representing an
     *          identifier.
     */
    /*public*/ bool hasIdentifier();

    /**
     * Replaces the identifier of the array element access.
     * <p>
     * If the array access represented by <code>this</code> isn't accessed via
     * an identifier, i.e. if the accessor is a method call (something like 
     * <code>anyMethodCall()[]</code> or an <code>ArrayElementAccess</code> 
     * again (multidimensional arrays), an implementation of this method is 
     * expected to do nothing but return <code>null</code>.
     * 
     * @param pNewIdentifier  The new array identifier.
     * 
     * @return  The old identifier or <code>null</code> if isn't accessed via an
     *          identifier.
     */
    /*public*/ String setIdentifier(String pNewIdentifier);
}
}