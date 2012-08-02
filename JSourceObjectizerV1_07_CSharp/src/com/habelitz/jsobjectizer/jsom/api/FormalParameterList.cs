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
using com.habelitz.jsobjectizer;
using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
{
/** 
 * This <code>JSOM</code> type represents a formal parameter list.
 * 
 * @author Dieter Habelitz
 */
public interface FormalParameterList : JSOM {
    
    /**
     * Returns a list of the formal parameter declarations.
     * <p>
     * The last <code>FormalParameterDeclaration</code> object (or the only one)
     * may be a <i>vararg</i> parameter declaration, i.e. a parameter 
     * declaration of a variable number of arguments like <code>public void 
     * foo(anyType ... typeId) {...}</code>. 
     * <p>
     * Calling this method equals an <code>getFormalParameterDeclarations(null)
     * </code> call.
     * 
     * @see #getFormalParameterDeclarations(List)
     * @see FormalParameterDeclaration#isVarargParameterDeclaration()
     * 
     * @return  A list of the formal parameter declarations. If <code>this
     *          </code> represents an empty formal parameter list <code>null
     *          </code> will be returned.
     */
    /*public*/ List<FormalParameterDeclaration> getFormalParameterDeclarations();
    
    /**
     * Returns a list of the formal parameter declarations.
     * <p>
     * The last <code>FormalParameterDeclaration</code> object (or the only one)
     * may be a <i>vararg</i> parameter declaration, i.e. a parameter 
     * declaration of a variable number of arguments like <code>public void 
     * foo(anyType ... typeId) {...}</code>. 
     * 
     * @param  pList  If this argument isn't <code>null</code> the formal
     *                parameter declarations will be added to this list and this 
     *                list object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @see FormalParameterDeclaration#isVarargParameterDeclaration()
     * 
     * @return  A list of the formal parameter declarations. If <code>this
     *          </code> represents an empty formal parameter list <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    /*public*/ List<FormalParameterDeclaration> getFormalParameterDeclarations(
                                        List<FormalParameterDeclaration> pList);
    
    /**
     * Tells if the formal parameter list is empty, i.e. if there are no
     * formal parameter declarations.
     * 
     * @return  <code>true</code> if the formal parameter list is empty.
     */
    /*public*/ bool isEmptyFormalParameterList();
    
    /**
     * Replaces a certain parameter declaration by a new one stated as string.
     * 
     * @param pOldParameterDeclaration  The parameter declaration that should be
     *                                  replaced.
     * @param pNewParameterDeclaration  The new parameter declaration.
     *
     * @  if the stated old parameter doesn't
     *                                     exist or if parsing the new parameter
     *                                     declaration fails.
     */
    /*public*/ void replaceFormalParameter(
            FormalParameterDeclaration pOldParameterDeclaration,
            String pNewParameterDeclaration);
}
}