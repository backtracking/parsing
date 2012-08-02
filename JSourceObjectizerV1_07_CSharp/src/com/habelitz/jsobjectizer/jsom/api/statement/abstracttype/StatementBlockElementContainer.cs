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

using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using com.habelitz.jsobjectizer.jsom;
using com.habelitz.jsobjectizer.jsom.api.statement;
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;

namespace com.habelitz.jsobjectizer.jsom.api.statement.abstracttype
{
/**
 * Contains and deals with all those <code>JSOM</code> elements that represent
 * statement block elements and that belong to a certain local statement scope.
 * <p>
 * This class bundles the functionality for all the content a statement block 
 * scope can have, i.e. statements and local variable/type declarations, but
 * that may also occur within local scopes that behave like statement block
 * scopes but aren't such scopes from a grammatical point of view (think about 
 * the statement scope of <code>case/default</code> labels of a <code>switch
 * </code> statement.
 * 
 * @author Dieter Habelitz
 */
public interface StatementBlockElementContainer : JSOM {

    /** 
     * Returns the local class declaration for a stated class identifier. 
     * 
     * @param pClassName  The identifier of the local class declaration.
     * 
     * @return  The local class declaration for the stated class identifier or 
     *          <code>null</code> if there is no appropriate class declaration.
     */
    /*public*/ LocalClassDeclaration getLocalClassDeclaration(String pClassName);
    
    /**
     * Returns a list of local class declarations.
     * <p>
     * Calling this method equals an <code>getLocalClassDeclarations(null)
     * </code> call.
     * 
     * @see  #getLocalClassDeclarations(List)
     * 
     * @return  A list of the local class declarations. If there are no local
     *          class declarations <code>null</code> will be returned. 
     */
    /*public*/ List<LocalClassDeclaration> getLocalClassDeclarations();
    
    /**
     * Returns a list of local class declarations.
     * 
     * @param  pList  If this argument isn't <code>null</code> the class
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the local class declarations. If there are no local
     *          class declarations <code>null</code> will be returned, even if 
     *          the argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<LocalClassDeclaration> getLocalClassDeclarations(
            List<LocalClassDeclaration> pList);
    
    /**
     * Returns a list of local variable declarations.
     * <p>
     * Calling this method equals an <code>getLocalVariableDeclarations(null)
     * </code> call.
     * 
     * @see  #getLocalVariableDeclarations(List)
     * 
     * @return  A list of the local variable declarations. If there are no local
     *          variable declarations <code>null</code> will be returned. 
     */
    /*public*/ List<LocalVariableDeclaration> getLocalVariableDeclarations();
    
    /**
     * Returns a list of local variable declarations.
     * 
     * @param  pList  If this argument isn't <code>null</code> the variable
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the local variable declarations. If there are no local
     *          variable declarations <code>null</code> will be returned, even 
     *          if the argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<LocalVariableDeclaration> getLocalVariableDeclarations(
            List<LocalVariableDeclaration> pList);
    
    /**
     * Returns selected statement block elements.
     * <p>
     * Calling this method equals an <code>
     * getSelectedStatementBlockElements(anyElementType, null)</code> call.
     * 
     * @param pStatementBlockElementType  A <code>
     *                                    StatementBlockElement.ElementType.???
     *                                    </code> constant.
     * 
     * @see #getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType, List)
     *  
     * @return  A list of selected statement block elements. If no statement 
     *          block element matches the given statement block element type
     *          <code>null</code> will be returned.
     */
    /*public*/ List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType);
    
    /**
     * Returns selected statement block elements.
     * 
     * @param pStatementBlockElementType  A <code>
     *                                    StatementBlockElement.ElementType.???
     *                                    </code> constant.
     * @param  pList  If this argument isn't <code>null</code> the statement
     *                block elements will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of selected statement block elements. If no statement 
     *          block element matches the given statement block element type
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    /*public*/ List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType pStatementBlockElementType, 
            List<StatementBlockElement> pList);
    
    /**
     * Returns selected statement block elements.
     * <p>
     * Calling this method equals an <code>
     * getSelectedStatementBlockElements(anyElementTypes[], null)</code> call.
     * 
     * @param pStatementBlockElementTypes  An array of <code>
     *                                     StatementBlockElement.ElementType.???
     *                                     </code> constants.
     * 
     * @see #getSelectedStatementBlockElements(com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement.ElementType[], List)
     *  
     * @return  A list of selected statement block elements. If no statement 
     *          block element matches the given statement block element types
     *          <code>null</code> will be returned.
     */
    /*public*/ List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes);
    
    /**
     * Returns selected statement block elements.
     * 
     * @param pStatementBlockElementTypes  An array of <code>
     *                                     StatementBlockElement.ElementType.???
     *                                     </code> constants. If this argument
     *                                     is <code>null</code> implementations
     *                                     are expected to return <code>
     *                                     null</code>. Furthermore <code>null
     *                                     </code> for array elements must be
     *                                     ignored.
     * @param  pList  If this argument isn't <code>null</code> the statement
     *                block elements will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of selected statement block elements. If no statement 
     *          block element matches the given statement block element types
     *          <code>null</code> will be returned, even if the argument <code>
     *          pList</code> isn't <code>null</code>.
     */
    /*public*/ List<StatementBlockElement> getSelectedStatementBlockElements(
            ElementType[] pStatementBlockElementTypes,
            List<StatementBlockElement> pList);
    
    /**
     * Returns a list of the statement block elements.
     * <p>
     * Statement block elements can be variable declarations, type declarations
     * and all kind of statements.
     * <p>
     * Calling this method equals an <code>getStatementBlockElements(null)
     * </code> call.
     * 
     * @see #getStatementBlockElements(List)
     *  
     * @return  A list of the statement block elements. If the statement block 
     *          contains no elements (not even an empty statement) <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    /*public*/ List<StatementBlockElement> getStatementBlockElements();

    /**
     * Returns a list of the statement block elements.
     * <p>
     * Statement block elements can be variable declarations, type declarations
     * and all kind of statements.
     * 
     * @param  pList  If this argument isn't <code>null</code> the statement
     *                block elements will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of the statement block elements. If the statement block 
     *          contains no elements (not even an empty statement) <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    /*public*/ List<StatementBlockElement> getStatementBlockElements(
                                            List<StatementBlockElement> pList);

    /**
     * Returns a list of all statements.
     * <p>
     * This method returns a list of all the statements that belong to the
     * statement block scope represented by <code>this</code>. I.e. the returned
     * list will contain all the content of <code>this</code> excepting local
     * variable and type declarations.
     * <p>
     * Of course, the list will contain the statements in the same order they
     * have been stated within the Java source code and the first list entry
     * corresponds to the first statement within the statement block scope.
     * <p>
     * Calling this method equals an <code>getStatements(null)</code> call.
     * 
     * @see  #getStatements(List)
     * 
     * @return  A list of all statements or <code>null</code> if the <code>
     *          this</code> has no statement. 
     */
    /*public*/ List<Statement> getStatements();
    
    /**
     * Returns a list of all statements.
     * <p>
     * This method returns a list of all the statements that belong to the
     * statement block scope represented by <code>this</code>. I.e. the returned
     * list will contain all the content of <code>this</code> excepting local
     * variable and type declarations.
     * <p>
     * Of course, the list will contain the statements in the same order they
     * have been stated within the Java source code and the first list entry
     * corresponds to the first statement within the statement block scope.
     * <p>
     * 
     * @param  pList  If this argument isn't <code>null</code> the statements
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     * 
     * @return  A list of all statements. If the statement block contains no 
     *          statements (not even an empty statement) <code>null</code> will 
     *          be returned, even if the argument <code>pList</code> isn't 
     *          <code>null</code>. 
     */
    /*public*/ List<Statement> getStatements(List<Statement> pList);
    
    /**
     * Tells if the statement block scope has at least one statement block 
     * element.
     * 
     * @return  <code>true</code> if the statement block scope has at least one
     *          statement block element.
     */
    /*public*/ bool hasStatementBlockElement();

    /**
     * Tells if a stated statement block element belongs to <code>this</code>.
     * 
     * @param pStatementBlockElement  The statement block element that should be
     *                                searched within <code>this</code>.
     * 
     * @return  <code>true</code> if the stated statement block element belongs 
     *          to <code>this</code>.
     */
    /*public*/ bool hasStatementBlockElement(
            StatementBlockElement pStatementBlockElement);

    /**
     * Removes a certain statement block element from <code>this</code>.
     * <p>
     * Calling this method equals an <code>
     * removeStatementBlockElement(StatementBlockElement, true)</code> call.
     * 
     * @param pStatementBlockElement  The statement block element that should be
     *                                removed. The argument passed to this
     *                                method remains unchanged.
     * 
     * @  if the statement block element passed 
     *                                     to this method doesn't belong to 
     *                                     <code>this</code>.
     */
    /*public*/ void removeStatementBlockElement(
            StatementBlockElement pStatementBlockElement);
    
    /**
     * Removes a certain statement block element from <code>this</code>.
     * 
     * @param pStatementBlockElement  The statement block element that should be
     *                                removed. The argument passed to this
     *                                method remains unchanged.
     * @param pRemovingOfSurroundingHiddenTokensEnabled  If <code>true</code>
     *                                                    the method also tries
     *                                                    to remove surrounding
     *                                                    whitespaces and 
     *                                                    comments that most
     *                                                    likely belongs to the
     *                                                    statement block 
     *                                                    element.
     * 
     * @  if the statement block element passed 
     *                                     to this method doesn't belong to 
     *                                     <code>this</code>.
     */
    /*public*/ void removeStatementBlockElement(
            StatementBlockElement pStatementBlockElement,
            bool pRemovingOfSurroundingHiddenTokensEnabled);
    
    /**
     * Replaces a certain statement block element by a new one stated as string.
     * 
     * @param pOldElement  The parameter declaration that should be
     *                                  replaced.
     * @param pNewElement  The new parameter declaration.
     *
     * @  if the stated old statement block
     *                                     element doesn't exist or if 
     *                                     unmarshalling the new statement block
     *                                     element failed.
     */
    /*public*/ void replaceStatementBlockElement(
            StatementBlockElement pOldElement, String pNewElement);
}
}