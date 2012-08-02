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
 * This <code>JSOM</code> type represents an enumeration constant declaration.
 * 
 * @author Dieter Habelitz
 */
public interface EnumConstant : JSOM {

    /**
     * Returns a list of the annotations that belong to the enumeration constant
     * declaration.
     * <p>
     * Calling this method equals an <code>getAnnotations(null)</code> call.
     * 
     * @see #getAnnotations(List)
     *
     * @return  A list of the annotations that belong to the enumeration 
     *          constant declaration. If no annotation has been stated <code>
     *          null</code> will be returned.
     */
    List<Annotation> getAnnotations();

    /**
     * Returns a list of the annotations that belong to the enumeration constant
     * declaration.
     * 
     * @param  pList  If this argument isn't <code>null</code> the annotations
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *
     * @return  A list of the annotations that belong to the enumeration 
     *          constant declaration. If no annotation has been stated <code>
     *          null</code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    List<Annotation> getAnnotations(List<Annotation> pList);

    /**
     * Returns a list of the enumeration constant declaration's arguments.
     * <p>
     * Calling this method equals an <code>getArguments(null)</code> call.
     * 
     * @see #getArguments(List)
     *  
     * @return  An list of the enumeration constant declaration's arguments. If
     *          no argument has been stated <code>null</code> will be returned.
     */
    List<Expression> getArguments();
    
    /**
     * Returns a list of the enumeration constant declaration's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  An list of the enumeration constant declaration's arguments. If 
     *          no argument has been stated <code>null</code> will be returned, 
     *          even if the argument <code>pList</code> isn't <code>null</code>.
     */
    List<Expression> getArguments(List<Expression> pList);
    
    /**
     * Returns the identifier of the enumeration constant.
     * 
     * @return  The identifier of the enumeration constant.
     */
    String getIdentifier();
    
    /**
     * An enumeration constant can be followed by it's own class body that 
     * corresponds to a class bodies of an anonymous class declaration. However,
     * to keep things simple this method returns a fully featured <code>
     * ClassTopLevelScope</code> object.
     * 
     * @return  The class top level scope following the enumeration constant or
     *          <code>null</code> if no appropriate class body has been stated.
     */
    ClassTopLevelScope getClassTopLevelScope();
    
    /**
     * Tells if the enumeration constant has at least one annotation.
     * 
     * @return  <code>true</code> if the enumeration constant has at least one 
     *          annotation.
     */
    bool hasAnnotation();
    
    /**
     * Tells if the enumeration constant has at least one argument.
     * 
     * @return  <code>true</code> if the enumeration constant has at least one 
     *          argument.
     */
    bool hasArgument();
    
    /**
     * Tells if the enumeration constant is followed by a class declaration 
     * body.
     * 
     * @see #hasClassTopLevelScope()
     * 
     * @return  <code>true</code> if the enumeration constant is followed by a 
     *          class declaration body.
     */
    bool hasClassTopLevelScope();
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new constant identifier.
     * 
     * @return  The old identifier.
     */
    String setIdentifier(String pNewIdentifier);
}
}