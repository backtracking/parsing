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

namespace com.habelitz.jsobjectizer.jsom.api
{

    /** 
     * This <code>JSOM</code> type represents a qualified identifier.
     * <p>
     * <i>Qualified identifier</i> means that a certain identifier <b>may
     * </b> be a qualified identifier. It is not obligatory that the
     * identifier is actually a qualified identifier, i.e. it may also be
     * a single identifier. 
     * 
     * @author Dieter Habelitz
     */
    public interface QualifiedIdentifier : JSOM
    {

        /**
         * Returns a certain identifier of the qualifiedIdentifier.
         * 
         * @param pOffset  The offset of the identifier starting with 0 for the most
         *                 left identifier.
         *                 
         * @return  The identifier.
         *
         * @throws IndexOutOfRangeException  An implementation of this method is
         *                                    expected to throw an exeption if the
         *                                    stated offset is lower than 0 or
         *                                    higher than <i>identifier count - 
         *                                    1</i>.
         */
        /*public*/ String getIdentifier(int pOffset);

        /**
         * Returns the number of identifiers the qualified identifier consists of.
         * 
         * @return  The number of identifiers.
         */
        /*public*/ int getIdentifierCount();

        /**
         * Returns a list of the identifiers of the qualified identifier.
         * <p>
         * The returned list contains the dot separated identifiers (without any 
         * dots, of course), were the first list entry corresponds to the most left 
         * identifier. For the simplest case this list contains only one identifier.
         * <p>
         * Calling this method equals an <code>getQualifiedIdentifier(null)</code>
         * call.
         * 
         * @see #getQualifiedIdentifier(List)
         *  
         * @return  A list of the identifiers of the qualified identifier.
         */
        /*public*/ List<String> getQualifiedIdentifier();

        /**
         * Returns a list of the identifiers of the qualified identifier.
         * <p>
         * The returned list contains the dot separated identifiers (without any 
         * dots, of course), were the first list entry corresponds to the most left 
         * identifier. For the simplest case this list contains only one identifier.
         * 
         * @param  pList  If this argument isn't <code>null</code> the identifiers
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of the identifiers of the qualified identifier.
         */
        /*public*/ List<String> getQualifiedIdentifier(List<String> pList);

        /**
         * Replaces a certain identifier of the qualifiedIdentifier.
         * 
         * @param pOffset  The offset of the identifier starting with 0 for the most
         *                 left identifier.
         * @param pNewIdentifier  The new identifier.                 
         *                 
         * @return  The old identifier.
         *
         * @throws IndexOutOfRangeException  An implementation of this method is
         *                                    expected to throw an exception if the
         *                                    stated offset is lower than 0 or
         *                                    higher than <i>identifier count - 
         *                                    1</i>.
         */
        /*public*/ String setIdentifier(int pOffset, String pNewIdentifier);

        /**
         * Returns the qualified identifier as string.
         * <p>
         * The returned string will only contain the dot separated identifiers or a
         * single identifier for the most trivial case. For instance, whitespaces
         * stated within the qualified identifier in the Java source will not be
         * part of the returned string. To get also such hidden things the <code>
         * JSourceMarshaller should be used.
         * 
         * @see JSOM#getMarshaller()
         * 
         * @return  The qualified identifier as string.
         */
        /*public*/ String ToString();
    }
}