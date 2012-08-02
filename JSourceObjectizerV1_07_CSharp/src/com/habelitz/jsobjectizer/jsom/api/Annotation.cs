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
     * This <code>JSOM</code> type represents an annotation, i.e. something like
     * <pre>
     *     &#0064;AnnotationTypeId(anyAnnotationInitializers)
     * </pre>
     * were the annotation initializers are optional, of course.
     * 
     * @author Dieter Habelitz
     */
    public interface Annotation : JSOM
    {

        /**
         * Returns the annotation's identifier.
         * 
         * @return  The annotation's identifier.
         */
        QualifiedIdentifier getIdentifier();

        /**
         * Returns a list of the annotation's initializers.
         * <p>
         * Calling this method equals an <code>getInitializers(null)</code>
         * call.
         * 
         * @see #getInitializers(List)
         *  
         * @return  A list of the annotation's initializers. If the annotation has 
         *          no initializer <code>null</code> will be returned.
         */
        List<AnnotationInitializer> getInitializers();

        /**
         * Returns a list of the annotation's initializers.
         * 
         * @param  pList  If this argument isn't <code>null</code> the initializers
         *                will be added to this list and this list object will be 
         *                returned. Otherwise a new list will be created for the 
         *                result.
         *  
         * @return  A list of the annotation's initializers. If the annotation has 
         *          no initializer <code>null</code> will be returned, even if the
         *          argument <code>pList</code> isn't <code>null</code>.
         */
        List<AnnotationInitializer> getInitializers(
                List<AnnotationInitializer> pList);

        /**
         * Tells if the annotation has any initializers.
         * 
         * @return  <code>true</code> if the annotations has at least one
         *          initializer.
         */
        bool hasInitializer();
    }
}