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

using com.habelitz.jsobjectizer.jsom.api.abstracttype;

namespace com.habelitz.jsobjectizer.jsom.api
{
    /**
     * This <code>JSOM</code> type represents the top level scope of an annotation
     * declaration.
     * 
     * @author Dieter Habelitz
     */
    public interface AnnotationTopLevelScope : CommonTypeTopLevelScope
    {

        /**
         * Returns a certain annotation method declaration.
         * 
         * @param pMethodIdentifier  The identifier of the annotation method.
         *  
         * @return  An annotation method declaration or <code>null</code> if no 
         *          method declaration exists for the stated identifier.
         */
        AnnotationMethodDeclaration getMethodDeclaration(
                                                        String pMethodIdentifier);

        /**
         * Returns a list of this annotation scope's annotation method declarations.
         * <p>
         * Calling this method equals an <code>getMethodDeclarations(null)</code>
         * call.
         * 
         * @see #getMethodDeclarations(List)
         *  
         * @return  A list of this annotation scope's annotation method 
         *          declarations. If there are no annotation method declarations
         *          <code>null</code> will be returned.
         */
        List<AnnotationMethodDeclaration> getMethodDeclarations();

        /**
         * Returns a list of this annotation scope's annotation method declarations.
         * 
         * @param  pList  If this argument isn't <code>null</code> the annotation
         *                method declarations will be added to this list and this 
         *                list object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @return  A list of this annotation scope's annotation method 
         *          declarations. If there are no annotation method declarations
         *          <code>null</code> will be returned, even if the argument <code>
         *          pList</code> isn't <code>null</code>.
         */
        List<AnnotationMethodDeclaration> getMethodDeclarations(
                                        List<AnnotationMethodDeclaration> pList);

        /**
         * Tells if <code>this</code> has a certain annotation method declaration.
         * 
         * @param pMethodIdentifier  A method identifier.
         * 
         * @return  <code>true</code> if an annotation method declaration exists for
         *          the stated identifier.
         */
        bool hasMethodDeclaration(String pMethodIdentifier);

        /**
         * Tells if <code>this</code> has at least one annotation method
         * declaration.
         * 
         * @return  <code>true</code> if <code>this</code> has at least one 
         *          annotation method declaration.
         */
        bool hasMethodDeclaration();

        /**
         * Returns the annotation declaration this top level scope belongs to.
         * 
         * @return  The annotation declaration this top level scope belongs to.
         */
        AnnotationDeclaration getOwner();
    }
}