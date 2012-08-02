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
using com.habelitz.jsobjectizer.jsom.api.abstracttype;

namespace com.habelitz.jsobjectizer.jsom.api
{

/**
 * This <code>JSOM</type represents the root of a complete Java source, i.e. of
 * a <i>.java</i> file for the most common case.
 * 
 * @author Dieter Habelitz
 */
public interface JavaSource : JSOM {

    /**
     * Adds a stated import declaration.
     * 
     * @param pImportPath  The path of the imported type. Note that the keyword 
     *                               <code>import</code> and the semicolon at 
     *                               the end of the import declaration will be 
     *                               added automatically by this method.
     * 
     * @  if parsing fails.
     * 
     * @deprecated  JSourceObjectizer 2.xx feature; should be seen as 
     *              experimental.
     */
    [Obsolete]
    /*public*/ void addImportDeclaration(Char[] pImportPath);

    /**
     * Returns the annotation declaration for a stated annotation identifier.
     * 
     * @see  #getTypeDeclaration(String)
     * @param pAnnotationName  The identifier of the annotation declaration.
     * 
     * @return  The annotation declaration for the stated annotation identifier 
     *          or <code>null</code> if there is no appropriate annotation 
     *          declaration.
     */
    /*public*/ AnnotationDeclaration getAnnotationDeclaration(
            String pAnnotationName);
    
    /**
     * Returns a list of the annotation declarations.
     * <p>
     * Calling this method equals an <code>getAnnotationDeclarations(null)
     * </code> call.
     * 
     * @see  #getTypeDeclarations()
     * 
     * @see  #getAnnotationDeclarations(List)
     *  
     * @return  A list of the annotation declarations. If there are no 
     *          annotation declarations <code>null</code> will be returned. 
     */
    /*public*/ List<AnnotationDeclaration> getAnnotationDeclarations();
    
    /**
     * Returns a list of the annotation declarations.
     * 
     * @see  #getTypeDeclarations(List)
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
    /*public*/ List<AnnotationDeclaration> getAnnotationDeclarations(
            List<AnnotationDeclaration> pList);
    
    /**
     * If the Java source is a <i>namespace-info.java</i> file (i.e. a file with
     * namespace annotations) this method returns a list of the annotations.
     * <p>
     * Calling this method equals an <code>getAnnotations(null)</code> call.
     * 
     * @see  #getAnnotations(List)
     * @see  #isPackageInfoSource()
     * 
     * @return  A list of namespace annotations. If the Java source isn't a <i>
     *          namespace-info.java</i> file <code>null</code> will be returned.
     */
    /*public*/ List<Annotation> getAnnotations();
    
    /**
     * If the Java source is a <i>namespace-info.java</i> file (i.e. a file with
     * namespace annotations) this method returns a list of the annotations.
     * 
     * @param  pList  If this argument isn't <code>null</code> the namespace
     *                annotations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @see  #isPackageInfoSource()
     * 
     * @return  A list of namespace annotations. If the Java source isn't a <i>
     *          namespace-info.java</i> file <code>null</code> will be returned, 
     *          even if the argument <code>pList</code> isn't <code>null</code>.
     */
    /*public*/ List<Annotation> getAnnotations(List<Annotation> pList);
    
    /**
     * Implementations of this interface are expected to return 0 for this 
     * <code>JSOM</code> method.
     * 
     * @return  0
     */
    /*public*/ int getCharPositionInLine();
    
    /** 
     * Returns the class declaration for a stated class identifier. 
     * 
     * @see  #getTypeDeclaration(String)
     * 
     * @param pClassName  The identifier of the class declaration.
     * 
     * @return  The class declaration for the stated class identifier or <code>
     *          null</code> if there is no appropriate class declaration.
     */
    /*public*/ ClassDeclaration getClassDeclaration(String pClassName);
    
    /**
     * Returns a list of the class declarations.
     * <p>
     * Calling this method equals an <code>getClassDeclarations(null)</code> 
     * call.
     * 
     * @see  #getClassDeclarations(List)
     * @see  #getTypeDeclarations()
     *  
     * @return  A list of the class declarations. If there are no class 
     *          declarations <code>null</code> will be returned. 
     */
    /*public*/ List<ClassDeclaration> getClassDeclarations();
    
    /**
     * Returns a list of the class declarations.
     * 
     * @see  #getTypeDeclarations(List)
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
    /*public*/ List<ClassDeclaration> getClassDeclarations(
            List<ClassDeclaration> pList);
    
    /**
     * Returns the enumeration declaration for a stated enumeration identifier. 
     * 
     * @see  #getTypeDeclaration(String)
     * 
     * @param pEnumName  The identifier of the enumeration declaration.
     * 
     * @return  The enumeration declaration for the stated enumeration
     *          identifier or <code>null</code> if there is no appropriate 
     *          enumeration declaration.
     */
    /*public*/ EnumDeclaration getEnumDeclaration(String pEnumName);
    
    /**
     * Returns a list of the enumeration declarations.
     * <p>
     * Calling this method equals an <code>getEnumDeclarations(null)</code> 
     * call.
     * 
     * @see  #getEnumDeclarations(List)
     * @see  #getTypeDeclarations()
     *  
     * @return  A list of the enumeration declarations. If there are no 
     *          enumeration declarations <code>null</code> will be returned. 
     */
    /*public*/ List<EnumDeclaration> getEnumDeclarations();
    
    /**
     * Returns a list of the enumeration declarations.
     * 
     * @see  #getTypeDeclarations(List)
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
    /*public*/ List<EnumDeclaration> getEnumDeclarations(
            List<EnumDeclaration> pList);
    
    /**
     * Returns a list of the import declarations.
     * <p>
     * Calling this method equals an <code>getImportDeclarations(null)</code>
     * call.
     * 
     * @see  #getImportDeclarations(List)
     *  
     * @return  A list of the import declarations. If there are no import
     *          declarations <code>null</code> will be returned. 
     */
    /*public*/ List<ImportDeclaration> getImportDeclarations();
    
    /**
     * Returns a list of the import declarations.
     * 
     * @param  pList  If this argument isn't <code>null</code> the import
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of the import declarations. If there are no import
     *          declarations <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<ImportDeclaration> getImportDeclarations(
            List<ImportDeclaration> pList);
    
    /**
     * Returns the interface declaration for a stated interface identifier. 
     * 
     * @see  #getTypeDeclaration(String)
     * 
     * @param pInterfaceName  The identifier of the interface declaration.
     * 
     * @return  The interface declaration for the stated interface identifier 
     *          or <code>null</code> if there is no appropriate interface 
     *          declaration.
     */
    /*public*/ InterfaceDeclaration getInterfaceDeclaration(String pInterfaceName);
    
    /**
     * Returns a list of the interface declarations.
     * <p>
     * Calling this method equals an <code>getInterfaceDeclarations(null)
     * </code> call.
     * 
     * @see  #getInterfaceDeclarations(List)
     * @see  #getTypeDeclarations()
     *  
     * @return  A list of the interface declarations. If there are no interface 
     *          declarations <code>null</code> will be returned. 
     */
    /*public*/ List<InterfaceDeclaration> getInterfaceDeclarations();
    
    /**
     * Returns a list of the interface declarations.
     * 
     * @see  #getTypeDeclarations(List)
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
    /*public*/ List<InterfaceDeclaration> getInterfaceDeclarations(
            List<InterfaceDeclaration> pList);
    
    /**
     * Returns the identifier of the Java source.
     * 
     * @return  The identifier of the Java source.
     */
    /*public*/ String getJavaSourceIdentifier();


    /*public*/ int getLineCount();

    /**
     * Implementations of this interface are expected to return 1 for this 
     * <code>JSOM</code> method.
     * 
     * @return  1
     */
    /*public*/ int getLineNumber();
    

    /**
     * Returns the qualified identifier of the namespace declaration.
     * 
     * @return  The qualified identifier of the namespace declaration or <code>
     *          null</code> if there is no namespace declaration.
     */
    /*public*/ PackageDeclaration getPackageDeclaration();
    
    /**
     * Returns the type declaration for a stated type identifier. 
     *          
     * @see  #getAnnotationDeclaration(String)
     * @see  #getClassDeclaration(String)
     * @see  #getEnumDeclaration(String)
     * @see  #getInterfaceDeclaration(String)          
     * 
     * @param pTypeName  The identifier of the type declaration.
     * 
     * @return  The type declaration for the stated type identifier or <code>
     *          null</code> if there is no appropriate type declaration.
     */
    /*public*/ CommonTypeDeclaration getTypeDeclaration(String pTypeName);
    
    /**
     * Returns a list of the type declarations.
     * <p>
     * Calling this method equals an <code>getTypeDeclarations(null)</code>
     * call.
     * 
     * @see  #getTypeDeclarations(List)
     * @see  #getAnnotationDeclarations()
     * @see  #getClassDeclarations()
     * @see  #getEnumDeclarations()
     * @see  #getInterfaceDeclarations()
     *  
     * @return  A list of the type declarations. If there are no type
     *          declarations <code>null</code> will be returned. 
     */
    /*public*/ List<CommonTypeDeclaration> getTypeDeclarations();
    
    /**
     * Returns a list of the type declarations.
     * 
     * @see  #getAnnotationDeclarations(List)
     * @see  #getClassDeclarations(List)
     * @see  #getEnumDeclarations(List)
     * @see  #getInterfaceDeclarations(List)
     * 
     * @param  pList  If this argument isn't <code>null</code> the type
     *                declarations will be added to this list and this list 
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     * 
     * @return  A list of the type declarations. If there are no type
     *          declarations <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    /*public*/ List<CommonTypeDeclaration> getTypeDeclarations(
            List<CommonTypeDeclaration> pList);
    
    /**
     * Tells if the Java source contains at least one import declaration.
     * 
     * @return  <code>true</code> if the Java source contains at least one 
     *          import declaration.
     */
    /*public*/ bool hasImportDeclaration();
    
    /**
     * Tells if the Java source has a namespace declaration.
     * 
     * @return  <code>true</code> if the Java source has a namespace declaration.
     */
    /*public*/ bool hasPackageDeclaration();
    
    /**
     * Tells if the Java source is a <i>namespace-info.java</i> file (i.e. a file 
     * with namespace annotations).
     * 
     * @return  <code>true</code> if the Java source is a <i>namespace-info.java
     *          </i> file (i.e. a file with namespace annotations).
     */
    /*public*/ bool isPackageInfoSource();
    
    /**
     * Tells if the Java source contains at least one type declaration.
     * 
     * @return  <code>true</code> if the Java source contains at least one type
     *          declaration.
     */
    /*public*/ bool hasTypeDeclaration();
    
    /**
     * Replaces the identifier of the Java source.
     * <p>
     * Note that setting this identifier has no affect to a marshalled Java.
     * 
     * @param pNewIdentifier  The new identifier.
     * 
     * @return  The old identifier.
     */
    /*public*/ String setJavaSourceIdentifier(String pNewIdentifier);
}
}