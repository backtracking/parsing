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

//import java.util.List;
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using com.habelitz.jsobjectizer.jsom;
using com.habelitz.jsobjectizer.jsom.api;

namespace com.habelitz.jsobjectizer.jsom.api.abstracttype
{
/**
 * This <code>JSOM</code> type supports all those things that can exist within
 * all kinds type declarations excepting enumeration types.
 * 
 * @author Dieter Habelitz
 */
public interface CommonTypeTopLevelScope : JSOM {

    /**
     * Returns a list of this scope's field declarations.
     * <p>
     * Calling this method equals an <code>getFieldDeclarations(null)</code>
     * call.
     * 
     * @see #getFieldDeclarations(List)
     *  
     * @return  A list of this scope's field declarations. If there are no
     *          field declarations <code>null</code> will be returned. 
     */
    List<TypeMemberDeclaration> getFieldDeclarations(); 

    /**
     * Returns a list of this scope's field declarations.
     *  
     * @param  pList  If this argument isn't <code>null</code> the field
     *                declarations will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of this scope's field declarations. If there are no
     *          field declarations <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>. 
     */
    List<TypeMemberDeclaration> getFieldDeclarations(
                                            List<TypeMemberDeclaration> pList); 

    /**
     * Returns the annotation declaration for a stated annotation identifier.
     * 
     * @see  #getInnerTypeDeclaration(String)
     * 
     * @param pAnnotationName  The identifier of the annotation declaration.
     * 
     * @return  The annotation declaration for the stated annotation identifier 
     *          or <code>null</code> if there is no appropriate annotation 
     *          declaration.
     */
    AnnotationDeclaration getInnerAnnotationDeclaration(
            String pAnnotationName);
    
    /**
     * Returns a list of the annotation declarations.
     * <p>
     * Calling this method equals an <code>getInnerAnnotationDeclarations(null)
     * </code> call.
     * 
     * @see  #getInnerTypeDeclarations()
     * @see  #getInnerAnnotationDeclarations(List)
     *  
     * @return  A list of the annotation declarations. If there are no 
     *          annotation declarations <code>null</code> will be returned. 
     */
    List<AnnotationDeclaration> getInnerAnnotationDeclarations();
    
    /**
     * Returns a list of the annotation declarations.
     * 
     * @see  #getInnerTypeDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the annotation
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the annotation declarations. If there are no 
     *          annotation declarations <code>null</code> will be returned, even 
     *          if the argument <code>pList</code> isn't <code>null</code>. 
     */
    List<AnnotationDeclaration> getInnerAnnotationDeclarations(
                                            List<AnnotationDeclaration> pList);
        
    /** 
     * Returns the class declaration for a stated class identifier. 
     * 
     * @see  #getInnerTypeDeclaration(String)
     * 
     * @param pClassName  The identifier of the class declaration.
     * 
     * @return  The class declaration for the stated class identifier or <code>
     *          null</code> if there is no appropriate class declaration.
     */
    ClassDeclaration getInnerClassDeclaration(String pClassName);
    
    /**
     * Returns a list of the class declarations.
     * <p>
     * Calling this method equals an <code>getInnerClassDeclarations(null)
     * </code>call.
     * 
     * @see  #getInnerClassDeclarations(List)
     * @see  #getInnerTypeDeclarations()
     *  
     * @return  A list of the class declarations. If there are no class 
     *          declarations <code>null</code> will be returned. 
     */
    List<ClassDeclaration> getInnerClassDeclarations();
    
    /**
     * Returns a list of the class declarations.
     * 
     * @see  #getInnerTypeDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the class
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the class declarations. If there are no class 
     *          declarations <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    List<ClassDeclaration> getInnerClassDeclarations(
            List<ClassDeclaration> pList);
    
    /**
     * Returns the enumeration declaration for a stated enumeration identifier. 
     * 
     * @see  #getInnerTypeDeclaration(String)
     * 
     * @param pEnumName  The identifier of the enumeration declaration.
     * 
     * @return  The enumeration declaration for the stated enumeration 
     *          identifier or <code>null</code> if there is no appropriate 
     *          enumeration declaration.
     */
    EnumDeclaration getInnerEnumDeclaration(String pEnumName);
    
    /**
     * Returns a list of the enumeration declarations.
     * <p>
     * Calling this method equals an <code>getInnerEnumDeclarations(null)</code> 
     * call.
     * 
     * @see  #getInnerEnumDeclarations(List)
     * @see  #getInnerTypeDeclarations()
     *  
     * @return  A list of the enumeration declarations. If there are no 
     *          enumeration declarations <code>null</code> will be returned. 
     */
    List<EnumDeclaration> getInnerEnumDeclarations();
    
    /**
     * Returns a list of the enumeration declarations.
     * 
     * @see  #getInnerTypeDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the enumeration
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the enumeration declarations. If there are no 
     *          enumeration declarations <code>null</code> will be returned, 
     *          even if the argument <code>pList</code> isn't <code>null</code>. 
     */
    List<EnumDeclaration> getInnerEnumDeclarations(
            List<EnumDeclaration> pList);
    
    /**
     * Returns the interface declaration for a stated interface identifier. 
     * 
     * @see  #getInnerTypeDeclaration(String)
     * 
     * @param pInterfaceName  The identifier of the interface declaration.
     * 
     * @return  The interface declaration for the stated interface identifier 
     *          or <code>null</code> if there is no appropriate interface 
     *          declaration.
     */
    InterfaceDeclaration getInnerInterfaceDeclaration(
            String pInterfaceName);
    
    /**
     * Returns a list of the interface declarations.
     * <p>
     * Calling this method equals an <code>getInterfaceDeclarations(null)
     * </code> call.
     * 
     * @see  #getInnerInterfaceDeclarations(List)
     * @see  #getInnerTypeDeclarations()
     *  
     * @return  A list of the interface declarations. If there are no interface 
     *          declarations <code>null</code> will be returned. 
     */
    List<InterfaceDeclaration> getInnerInterfaceDeclarations();
    
    /**
     * Returns a list of the interface declarations.
     * 
     * @see  #getInnerTypeDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the interface
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the interface declarations. If there are no interface 
     *          declarations <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    List<InterfaceDeclaration> getInnerInterfaceDeclarations(
            List<InterfaceDeclaration> pList);
    
    /**
     * Returns a certain inner type declaration.
     * 
     * @see  #getInnerAnnotationDeclaration(String)
     * @see  #getInnerClassDeclaration(String)
     * @see  #getInnerEnumDeclaration(String)
     * @see  #getInnerInterfaceDeclaration(String)          
     * 
     * @param pTypeIdentifier  The identifier of the inner type.
     *  
     * @return  An inner type declaration or <code>null</code> if no type 
     *          declaration exists for the stated identifier.
     */
    CommonTypeDeclaration getInnerTypeDeclaration(
            String pTypeIdentifier);

    /**
     * Returns a list of this scope's inner type declarations.
     * 
     * Calling this method equals an <code>getInnerTypeDeclarations(null)</code>
     * call.
     * 
     * @see  #getInnerTypeDeclarations(List)
     * @see  #getInnerAnnotationDeclarations()
     * @see  #getInnerClassDeclarations()
     * @see  #getInnerEnumDeclarations()
     * @see  #getInnerInterfaceDeclarations()
     *  
     * @return  A list of this scope's inner type declarations. If there is no
     *          inner type declaration <code>null</code> will be returned. 
     */
    List<CommonTypeDeclaration> getInnerTypeDeclarations();
    
    /**
     * Returns a list of this scope's inner type declarations.
     * 
     * @see  #getInnerAnnotationDeclarations(List)
     * @see  #getInnerClassDeclarations(List)
     * @see  #getInnerEnumDeclarations(List)
     * @see  #getInnerInterfaceDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the inner type
     *                declarations will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of this scope's inner type declarations. If there is no
     *          inner type declaration <code>null</code> will be returned, even 
     *          if the argument <code>pList</code> isn't <code>null</code>. 
     */
    List<CommonTypeDeclaration> getInnerTypeDeclarations(
            List<CommonTypeDeclaration> pList);
    
    /**
     * Tells if <code>this</code> has at least one field declaration.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one field
     *          declaration.
     */
    bool hasFieldDeclaration();
    
    /**
     * Tells if <code>this</code> has a certain inner type declaration.
     * 
     * @param pTypeIdentifier  A method identifier.
     * 
     * @return  <code>true</code> if an inner type declaration exists for the 
     *          stated identifier.
     */
    bool hasInnerTypeDeclaration(String pTypeIdentifier);
    
    /**
     * Tells if <code>this</code> has at least one inner type declaration.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one inner
     *          type declaration.
     */
    bool hasInnerTypeDeclaration();
    
    /**
     * Removes a certain type member declaration from <code>this</code>.
     * <p>
     * Calling this method equals an <code>
     * removeTypeMemberDeclaration(TypeMemberDeclaration, true)</code>
     * call.
     * 
     * @param pTypeMemberDeclaration  The type member declaration that should be
     *                                removed. The argument passed to this
     *                                method remains unchanged.
     * 
     * @  if the type member declaration passed 
     *                                     to this method doesn't belong to 
     *                                     <code>this</code>.
     */
    void removeTypeMemberDeclaration(
            TypeMemberDeclaration pTypeMemberDeclaration);
    
    /**
     * Removes a certain type member declaration from <code>this</code>.
     * 
     * @param pTypeMemberDeclaration  The type member declaration that should be
     *                                removed. The argument passed to this
     *                                method remains unchanged.
     * @param pRemovingOfSurroundingHiddenTokensEnabled  If <code>true</code>
     *                                                    the method also tries
     *                                                    to remove surrounding
     *                                                    whitespaces and 
     *                                                    comments that most
     *                                                    likely belongs to the
     *                                                    type member 
     *                                                    declaration.
     * 
     * @  if the type member declaration passed 
     *                                     to this method doesn't belong to 
     *                                     <code>this</code>.
     */
    void removeTypeMemberDeclaration(
            TypeMemberDeclaration pTypeMemberDeclaration,
            bool pRemovingOfSurroundingHiddenTokensEnabled);
}
}