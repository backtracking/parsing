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
using com.habelitz.jsobjectizer.jsom.api.expression;

namespace com.habelitz.jsobjectizer.jsom.api
{
    /** 
     * This <code>JSOM</code> type represents an annotation initialization value.
     * <p>
     * There are three variants of how annotation initialization values can occur:
     *  <ol>
     *      <li>
     *          a list of annotation element values (for initializing an
     *          annotation array element) 
     *      </li>
     *      <li>
     *          an annotation
     *      </li>
     *      <li>
     *          an expression
     *      </li>
     *  </ol>
     * <p>
     * This interface defines constants for each of these variants. Furthermore 
     * there are appropriate getter methods for each variant.
     * 
     * @author Dieter Habelitz
     */
    /**
     * Defines constants for the annotation initialization variants.
     * 
     * @author Dieter Habelitz
     */
    public enum RValueType
    {

        /**
         * Constant for annotation initialization value variant 1 (see the
         * documentation of this class).
         */
        ANNOTATION_ELEMENT_VALUES,

        /**
         * Constant for annotation initialization value variant 2 (see the
         * documentation of this class).
         */
        ANNOTATION,

        /**
         * Constant for annotation initialization value variant 3 (see the
         * documentation of this class).
         */
        EXPRESSION
    }

    public interface AnnotationElementValue : JSOM
    {



        /**
         * Returns the annotation for the cases where <code>
         * getAnnotationRValueType() == RValueType.ANNOTATION</code>.
         * 
         * @return  The annotation  or <code>null</code> if <code>
         *          getAnnotationRValueType() != RValueType.ANNOTATION</code>.
         */
        /*public*/ Annotation getAnnotation();

        /**
         * Returns a list of the annotation element values for the cases where 
         * <code>getAnnotationRValueType() == 
         * RValueType.ANNOTATION_ELEMENT_VALUES</code>.
         * <p>
         * Calling this method equals an <code>getAnnotationElementValues(null)
         * </code> call.
         * 
         * @see #getAnnotationElementValues(List)
         *  
         * @return  A list of the annotation element values. If <code>
         *          getAnnotationRValueType() != 
         *          RValueType.ANNOTATION_ELEMENT_VALUES</code> <code>null</code> 
         *          will be returned.
         */
        /*public*/ List<AnnotationElementValue> getAnnotationElementValues();

        /**
         * Returns a list of the annotation element values for the cases where 
         * <code>getAnnotationRValueType() == 
         * RValueType.ANNOTATION_ELEMENT_VALUES</code>.
         * 
         * @param  pList  If this argument isn't <code>null</code> the annotation
         *                element values will be added to this list and this list
         *                object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of the annotation element values. If <code>
         *          getAnnotationRValueType() != 
         *          RValueType.ANNOTATION_ELEMENT_VALUES</code> <code>null</code> 
         *          will be returned, even if the argument <code>pList</code> isn't 
         *          <code>null</code>.
         */
        /*public*/ List<AnnotationElementValue> getAnnotationElementValues(
                List<AnnotationElementValue> pList);

        /**
         * Returns the constant for the annotation element value variant represented
         * by <code>this</code>.
         * 
         * @return  One of the <code>AnnotationElementValue.RValueType.???</code> 
         *          constants.
         */
        /*public*/ RValueType getAnnotationRValueType();

        /**
         * Returns the expression for the cases where <code>
         * getAnnotationRValueType() == RValueType.EXPRESSION</code>.
         * 
         * @return  The expression or <code>null</code> if <code>
         *          getAnnotationRValueType() != RValueType.EXPRESSION</code>.
         */
        /*public*/ Expression getExpression();
    }
}