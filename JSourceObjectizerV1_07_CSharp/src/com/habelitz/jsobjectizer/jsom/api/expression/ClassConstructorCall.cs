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

namespace com.habelitz.jsobjectizer.jsom.api.expression {
/**
 * This <code>PrimaryExpression</code> type represents a <code>new</code>
 * expression via a class constructor invocation, i.e. something like <code>
 * 'new AnyClassType(constructorArgs)'</code>.
 * <p>      
 * This class also supports <i>inner new expressions</code> for creating
 * instances of an inner member class from outside the outer class.
 * <pre>
 *  OuterType outer = new OuterType();
 *  InnerType inner = outer.new InnerType(); // 'InnerType' is an inner member
 *                                           // class within 'OuterType'.
 * </pre>
 * The difference between the two constructor invocation variants is that
 *  <ul>
 *      <li>
 *          inner new expressions are preceded by a primary expression (which is
 *          not a member of this class!) and ...
 *      </li>
 *      <li>
 *          ... the constructor's name is never a qualified identifier, but 
 *          always just a simple identifier for inner new expressions.
 *      </li>
 *  </ul> 
 * 
 * @see StaticArrayCreator  for <code>new</code> expressions that instantiate 
 *                          static arrays.
 *       
 * @author Dieter Habelitz
 */
public interface ClassConstructorCall : PrimaryExpression {

    /**
     * Returns a list of the constructor call's arguments.
     * <p>
     * Calling this method equals an <code>getArguments(null)</code> call.
     * 
     * @see #getArguments(List)
     *  
     * @return  A list of the constructor call's arguments. If there are no
     *          arguments <code>null</code> will be returned. 
     */
    /*public*/ List<Expression> getArguments();

    /**
     * Returns a list of the constructor call's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the constructor call's arguments. If there are no
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<Expression> getArguments(List<Expression> pList);

    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the constructor invocation.
     * <p>
     * Example: <code>new &lt;T1&gt; Foo&lt;T2&gt;(anyArgs)</code>
     * <p>
     * For the example above this method would return list that contains just 
     * one generic type parameter that represents the type <code>T1</code> 
     * stated by <code>&lt;T1&gt;</code>. The generic type argument <code>
     * &lt;T2&gt;</code> would be part of the qualified identifier.
     * <p>
     * Calling this method equals an <code>getGenericTypeArguments(null)</code>
     * call.
     * 
     * @see #getGenericTypeArguments(List)
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned. 
     */
    /*public*/ List<GenericTypeArgument> getGenericTypeArguments();
    
    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the constructor invocation.
     * <p>
     * Example: <code>new &lt;T1&gt; Foo&lt;T2&gt;(anyArgs)</code>
     * <p>
     * For the example above this method would return list that contains just 
     * one generic type parameter that represents the type <code>T1</code> 
     * stated by <code>&lt;T1&gt;</code>. The generic type argument <code>
     * &lt;T2&gt;</code> would be part of the qualified identifier.
     *
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList);
    
    /**
     * If <code>this</code> represents an <i>inner new expression</code>) this 
     * method returns the identifier of the constructor. Otherwise, i.e. for
     * normal constructor calls, the last identifier from the qualified
     * identifier will be returned.
     * 
     * @see  ClassConstructorCall#getGenericTypeArguments()
     * 
     * @return  The identifier of the constructor, i.e. the type of the new
     *          instance.
     */
    /*public*/ String getIdentifier();
    
    /**
     * If <code>this</code> represents a standard constructor call (i.e. not the
     * constructor call of an <i>inner new expression</code>) this method
     * returns a list of identifiers representing a qualified identifier.
     * <p>
     * The first entry is the most left identifier and the last one is the type 
     * (i.e. the constructor) identifier. For the most trivial case only one
     * identifier, the type identifier, will be added to the list.
     * <p>
     * Calling this method equals an <code>getQualifiedTypeIdentifier(null)</code>
     * call.
     * 
     * @see #getQualifiedTypeIdentifier(List)
     * @see  ClassConstructorCall#getIdentifier()
     * 
     * @return  A list of identifiers representing a qualified identifier. If 
     *          'isInnerNewExpression() == true'</code> <code>null</code> will 
     *          be returned.
     */
    /*public*/ List<ComplexTypeIdentifier> getQualifiedTypeIdentifier();

    /**
     * If <code>this</code> represents a standard constructor call (i.e. not the
     * constructor call of an <i>inner new expression</code>) this method
     * returns a list of identifiers representing a qualified identifier.
     * <p>
     * The first entry is the most left identifier and the last one is the type 
     * (i.e. the constructor) identifier. For the most trivial case only one
     * identifier, the type identifier, will be added to the list.
     * 
     * @see  ClassConstructorCall#getIdentifier()
     * 
     * @param  pList  If this argument isn't <code>null</code> the identifiers
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *                
     * @return  A list of identifiers representing a qualified identifier. If 
     *          'isInnerNewExpression() == true'</code> <code>null</code> will 
     *          be returned, even if the argument <code>pList</code> isn't 
     *          <code>null</code>.
     */
    /*public*/ List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
            List<ComplexTypeIdentifier> pList);

    /**
     * If an anonymous class declaration follows the constructor call this
     * method returns the appropriate <code>ClassTopLevelScope</code> object.
     * 
     * @return  A <code>ClassTopLevelScope</code> object if an anonymous class 
     *          definition follows the constructor call (i.e. if <code>'
     *          isAnonymousClassCreator == true'</code>) but <code>null</code>
     *          otherwise.
     */
    /*public*/ ClassTopLevelScope getTopLevelScope();

    /**
     * Tells if the constructor call has at least one argument.
     * 
     * @return  <code>true</code> if the constructor call has at least one 
     *          argument.
     */
    /*public*/ bool hasArgument();
    
    /**
     * Tells if <code>this</code> has at least one generic type argument.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type argument.
     */
    /*public*/ bool hasGenericTypeArgument();
    
    /**
     * Tells if the class constructor call is followed by an anonymous class
     * definition.
     * 
     * @return  <code>true</code> if the class constructor call is followed by
     *          an anonymous class definition.
     */
    /*public*/ bool isAnonymousClassCreator();
    
    /**
     * Tells if <code>this</code> represents an <i>inner new expression</i> or
     * not.
     * 
     * @return  <code>true</code> if <code>this</code> represents an <i>inner 
     *          new expression</i>.
     */
    /*public*/ bool isInnerNewExpression();
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new identifier of the constructor call.
     * 
     * @return  The old identifier.
     */
    /*public*/ String setIdentifier(String pNewIdentifier);
}
}