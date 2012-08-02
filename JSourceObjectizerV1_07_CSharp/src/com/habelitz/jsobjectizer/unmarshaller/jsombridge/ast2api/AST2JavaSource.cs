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
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using com.habelitz.core;
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using CommonTypeDeclaration = com.habelitz.jsobjectizer.jsom.api.abstracttype.CommonTypeDeclaration;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using JSourceUnmarshallerException = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshallerException;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {
/**
 * This <code>JSOM</type represents the root of a complete Java source, i.e. of
 * a <i>.java</i> file for the most common case.
 * 
 * @author Dieter Habelitz
 */
public class AST2JavaSource : AST2JSOM , JavaSource {

    // The 'namespace-info.java' annotations.
    private List<Annotation> mAnnotations;
    // An optional namespace declaration.
    //private QualifiedIdentifier mPackageDecl;
    private PackageDeclaration mPackageDecl;

    // The optional import declarations.
    private List<ImportDeclaration> mImportDecls;
    // The optional type declarations.
    private List<CommonTypeDeclaration> mTypeDecls;

    private int mLineCount;
    private String mJavaSourceIdentifier;

    // The children from the Java source tree.
    private AST2JSOMTree mAnnotationsTree;
    private AST2JSOMTree mPackageDeclTree;
    private List<AST2JSOMTree> mImportDeclTrees;
    private List<AST2JSOMTree> mTypeDeclTrees;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pJavaSourceIdentifier  The identifier of the Java source, for
     *                               example the Java file name (without the
     *                               <i>.java</code> suffix). If the origin of
     *                               the parsed Java source isn't a file then a 
     *                               name must be stated if it would be a file. 
     *                               That means that the name should match the 
     *                               public type declaration within the Java
     *                               source. However, this will not be checked 
     *                               by this class and it's up to the caller to 
     *                               pass the correct file name or at least to
     *                               interpret what's <i>correct</i>.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2JavaSource(
            AST2JSOMTree pTree, String pJavaSourceIdentifier, 
            TokenRewriteStream pTokenRewriteStream, int pLineCount) 
        : base(pTree, JSOMType.JAVA_SOURCE, pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.JAVA_SOURCE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mLineCount = pLineCount;
        mJavaSourceIdentifier = pJavaSourceIdentifier;
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(0);
        if (child.ChildCount > 0) {
            mAnnotationsTree = child;
        }
        int numberOfChildren = pTree.ChildCount;
        if (numberOfChildren > 1) {
            int childOffset = 1;
            child = (AST2JSOMTree)pTree.GetChild(childOffset);
            if (child.Type == JavaTreeParser.PACKAGE) {
                mPackageDeclTree = child;
                childOffset++;
            }
            int importDeclCtr = 0;
            int typeDeclCtr = 0;
            int childOffsetBuffer = childOffset;
            while (   childOffset < numberOfChildren
                   &&    pTree.GetChild(childOffset).Type
                      == JavaTreeParser.IMPORT) {
                importDeclCtr++;
                childOffset++;
            }
            typeDeclCtr = numberOfChildren - childOffset;
            if (importDeclCtr > 0) {
                mImportDeclTrees = new List<AST2JSOMTree>(importDeclCtr);
                while (importDeclCtr > 0) {
                    mImportDeclTrees.Add((AST2JSOMTree)pTree.GetChild(childOffsetBuffer));
                    childOffsetBuffer++;
                    importDeclCtr--;
                }
                
            }
            if (typeDeclCtr > 0) {
                mTypeDeclTrees = new List<AST2JSOMTree>(typeDeclCtr);
                while (typeDeclCtr > 0) {
                    mTypeDeclTrees.Add((AST2JSOMTree)pTree.GetChild(childOffsetBuffer));
                    childOffsetBuffer++;
                    typeDeclCtr--;
                }
            }
        }
    }

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
     * 
     * __TEST__
     */
    [Obsolete]
    public void addImportDeclaration(Char[] pImportPath) 
         {
        
        StringBuilder sbImportDecl = new StringBuilder(Constants.NL)
            .Append("import ").Append(pImportPath).Append(';');
        if (mImportDeclTrees == null) {
            mImportDeclTrees = new List<AST2JSOMTree>();
        }
        List<String> errorMessages = new List<String>();
        try {
            AST2ImportDeclaration importDecl =
                getUnmarshaller().unmarshalAST2ImportDeclaration(
                                    sbImportDecl.ToString(), errorMessages);
            if (importDecl != null) {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Check if error messages have been emitted by the parser.
                mImportDeclTrees.Add((AST2JSOMTree)importDecl.getTreeNode());
                if (mImportDecls != null) {
                    mImportDecls.Add(importDecl);
                }
            }
        } catch (JSourceUnmarshallerException e) {
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "Parsing the import declaration '" + sbImportDecl +
                    "' failed.");
        }
        // Update the token stream.
        // TODO  After implementation of adding JSOMs to JSOMs:
        //       Move this stuff to 'AST2JSOM'.
        TokenRewriteStream stream = getTokenRewriteStream();
        int offset = 0;
        if (mImportDeclTrees.Count > 1) {
            offset = mImportDeclTrees[mImportDeclTrees.Count - 2].TokenStopIndex;
        } else if (mPackageDeclTree != null) {
            offset = mPackageDeclTree.TokenStopIndex;
            sbImportDecl.Insert(0, Constants.NL);
        } else {
            sbImportDecl.Append(Constants.NL).Append(Constants.NL);
        }
        stream.InsertAfter(offset, sbImportDecl.ToString());
    }

    /**
     * Returns the annotation declaration for a stated annotation identifier.
     * 
     * @see  #getTypeDeclaration(String)
     * 
     * @param pAnnotationName  The identifier of the annotation declaration.
     * 
     * @return  The annotation declaration for the stated annotation identifier 
     *          or <code>null</code> if there is no appropriate annotation 
     *          declaration.
     */
    public AnnotationDeclaration getAnnotationDeclaration(
            String pAnnotationName) {
        
        CommonTypeDeclaration decl = getTypeDeclaration(pAnnotationName);
        if (decl != null && decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION)) {
            return (AnnotationDeclaration) decl;
        }
        
        return null;
    }
    
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
    public List<AnnotationDeclaration> getAnnotationDeclarations() {
        
        return getAnnotationDeclarations(null);
    }
    
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
    public List<AnnotationDeclaration> getAnnotationDeclarations(
            List<AnnotationDeclaration> pList) {
        
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        int count = 0;
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION)) {
                count++;
            }
        }
        if (count == 0) {
            return null;
        }
        List<AnnotationDeclaration> result = pList;
        if (result == null) {
            result = new List<AnnotationDeclaration>(count);
        }
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION)) {
                result.Add((AnnotationDeclaration) decl);
            }
        }
        
        return result;
    }
    
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
    public List<Annotation> getAnnotations() {
        
        return getAnnotations(null);
    }
    
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
    public List<Annotation> getAnnotations(List<Annotation> pList) {
        
        if (mAnnotationsTree == null) {
            return null; // No annotations available.
        }
        if (mAnnotations == null) {
            resolveAnnotations();
        }
        List<Annotation> result = pList;
        if (result == null) {
            result = new List<Annotation>(mAnnotations.Count);
        }
        result.AddRange(mAnnotations);
        
        return result;
    }
    
    /**
     * Always returns 1.
     * 
     * @return  0.
     */
    public int getCharPositionInLine() {
        
        return 0;
    }
    
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
    public ClassDeclaration getClassDeclaration(String pClassName) {
        
        CommonTypeDeclaration decl = getTypeDeclaration(pClassName);
        if (decl != null && decl.isJSOMType(JSOMType.CLASS_DECLARATION)) {
            return (ClassDeclaration) decl;
        }
        
        return null;
    }
    
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
    public List<ClassDeclaration> getClassDeclarations() {
       
        return getClassDeclarations(null);
    }
    
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
    public List<ClassDeclaration> getClassDeclarations(
            List<ClassDeclaration> pList) {
                                                    
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        int count = 0;
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.CLASS_DECLARATION)) {
                count++;
            }
        }
        if (count == 0) {
            return null;
        }
        List<ClassDeclaration> result = pList;
        if (result == null) {
            result = new List<ClassDeclaration>(count);
        }
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.CLASS_DECLARATION)) {
                result.Add((ClassDeclaration) decl);
            }
        }
        
        return result;
    }
    
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
    public EnumDeclaration getEnumDeclaration(String pEnumName) {
        
        CommonTypeDeclaration decl = getTypeDeclaration(pEnumName);
        if (decl != null && decl.isJSOMType(JSOMType.ENUM_DECLARATION)) {
            return (EnumDeclaration) decl;
        }
        
        return null;
    }
    
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
    public List<EnumDeclaration> getEnumDeclarations() {
        
        return getEnumDeclarations(null);
    }
    
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
    public List<EnumDeclaration> getEnumDeclarations(
            List<EnumDeclaration> pList) {
                                                    
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        int count = 0;
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.ENUM_DECLARATION)) {
                count++;
            }
        }
        if (count == 0) {
            return null;
        }
        List<EnumDeclaration> result = pList;
        if (result == null) {
            result = new List<EnumDeclaration>(count);
        }
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.ENUM_DECLARATION)) {
                result.Add((EnumDeclaration) decl);
            }
        }
        
        return result;
    }
    
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
    public InterfaceDeclaration getInterfaceDeclaration(String pInterfaceName) {
        
        CommonTypeDeclaration decl = getTypeDeclaration(pInterfaceName);
        if (decl != null && decl.isJSOMType(JSOMType.INTERFACE_DECLARATION)) {
            return (InterfaceDeclaration) decl;
        }
        
        return null;
    }
    
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
    public List<InterfaceDeclaration> getInterfaceDeclarations() {
        
        return getInterfaceDeclarations(null);
    }
    
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
    public List<InterfaceDeclaration> getInterfaceDeclarations(
            List<InterfaceDeclaration> pList) {
                                                
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        int count = 0;
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.INTERFACE_DECLARATION)) {
                count++;
            }
        }
        if (count == 0) {
            return null;
        }
        List<InterfaceDeclaration> result = pList;
        if (result == null) {
            result = new List<InterfaceDeclaration>(count);
        }
        foreach (CommonTypeDeclaration decl in mTypeDecls) {
            if (decl.isJSOMType(JSOMType.INTERFACE_DECLARATION)) {
                result.Add((InterfaceDeclaration) decl);
            }
        }
        
        return result;
    }

    public int getLineCount()
    {
        return mLineCount;
    }

    /**
     * Always returns 1.
     * 
     * @return  1.
     */
    public int getLineNumber() {
        
        return 1;
    }

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
    public List<ImportDeclaration> getImportDeclarations() {
        
        return getImportDeclarations(null);
    }
    
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
    public List<ImportDeclaration> getImportDeclarations(
            List<ImportDeclaration> pList) {
        
        if (mImportDeclTrees == null) {
            return null; // No import declarations available.
        }
        if (mImportDecls == null) {
            resolveImportDeclarations();
        }
        List<ImportDeclaration> result = pList;
        if (result == null) {
            result = new List<ImportDeclaration>(mImportDecls.Count);
        }
        result.AddRange(mImportDecls);
        
        return result;
    }
    
    /**
     * Returns the identifier of the Java source.
     * 
     * @return  The identifier of the Java source.
     */
    public String getJavaSourceIdentifier() {
        
        return mJavaSourceIdentifier;
    }
    
    /**
     * Returns the qualified identifier of the namespace declaration.
     * 
     * @return  The qualified identifier of the namespace declaration or <code>
     *          null</code> if there is no namespace declaration.
     */
    //public QualifiedIdentifier getPackageDeclaration() {
        
    //    if (mPackageDeclTree == null) {
    //        return null; // There's no namespace declaration.
    //    }
    //    if (mPackageDecl == null) {
    //        mPackageDecl = new AST2QualifiedIdentifier((AST2JSOMTree)
    //                    mPackageDeclTree.GetChild(0), getTokenRewriteStream());
    //    }
        
    //    return mPackageDecl;
    //}
    public PackageDeclaration getPackageDeclaration()
    {

        if (mPackageDeclTree == null)
        {
            return null; // There's no namespace declaration.
        }
        if (mPackageDecl == null)
        {
            mPackageDecl = new AST2PackageDeclaration((AST2JSOMTree)
                        mPackageDeclTree.GetChild(0), getTokenRewriteStream());
        }

        return mPackageDecl;
    }

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
    public CommonTypeDeclaration getTypeDeclaration(String pTypeName) {
        
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        foreach (CommonTypeDeclaration typeDecl in mTypeDecls) {
            if (typeDecl.getIdentifier().Equals(pTypeName)) {
                return typeDecl;
            }
        }
        
        return null;
    }
    
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
    public List<CommonTypeDeclaration> getTypeDeclarations() {
        
        return getTypeDeclarations(null);
    }
    
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
    public List<CommonTypeDeclaration> getTypeDeclarations(
            List<CommonTypeDeclaration> pList) {
        
        if (mTypeDeclTrees == null) {
            return null; // No type declarations available.
        }
        if (mTypeDecls == null) {
            resolveTypeDeclarations();
        }
        List<CommonTypeDeclaration> result = pList;
        if (result == null) {
            result = new List<CommonTypeDeclaration>(mTypeDecls.Count);
        }
        result.AddRange(mTypeDecls);
        
        return result;
    }
    
    /**
     * Tells if the Java source contains at least one import declaration.
     * 
     * @return  <code>true</code> if the Java source contains at least one 
     *          import declaration.
     */
    public bool hasImportDeclaration() {
        
        return mImportDeclTrees != null;
    }
    
    /**
     * Tells if the Java source has a namespace declaration.
     * 
     * @return  <code>true</code> if the Java source has a namespace declaration.
     */
    public bool hasPackageDeclaration() {
        
        return mPackageDeclTree != null;
    }
    
    /**
     * Tells if the Java source contains at least one type declaration.
     * 
     * @return  <code>true</code> if the Java source contains at least one type
     *          declaration.
     */
    public bool hasTypeDeclaration() {
        
        return mTypeDeclTrees != null;
    }

    /**
     * Tells if the Java source is a <i>namespace-info.java</i> file (i.e. a file 
     * with namespace annotations).
     * 
     * @return  <code>true</code> if the Java source is a <i>namespace-info.java
     *          </i> file (i.e. a file with namespace annotations).
     */
    public bool isPackageInfoSource() {
        
        return mAnnotationsTree != null;
    }
    
    /**
     * Resolves the annotations that belong to <code>this</code>.
     * <p>
     * Note that it's up to the caller to ensure that <code>this</code>
     * represents a <i>namespace-info.java</i> source.
     */
    private void resolveAnnotations() {
        
        int size = mAnnotationsTree.ChildCount;
        mAnnotations = new List<Annotation>(size);
        for (int offset = 0; offset < size; offset++) {
            mAnnotations.Add(new AST2Annotation((AST2JSOMTree)
                    mAnnotationsTree.GetChild(offset), 
                    getTokenRewriteStream()));
        }
    }

    /**
     * Resolves the type declarations that belong to <code>this</code>.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * import declaration.
     */
    private void resolveImportDeclarations() {
        
        int size = mImportDeclTrees.Count;
        mImportDecls = new List<ImportDeclaration>(size);
        foreach (AST2JSOMTree tree in mImportDeclTrees) {
            mImportDecls.Add(
                    new AST2ImportDeclaration(tree, getTokenRewriteStream()));
        }
    }

    private void resolvePackageDeclaration()
    {
        mPackageDecl = new AST2PackageDeclaration(mPackageDeclTree, getTokenRewriteStream());
    }



    /**
     * Resolves the type declarations that belong to <code>this</code>.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * type declaration.
     */
    private void resolveTypeDeclarations() {

        if (mTypeDecls == null) {
            int size = mTypeDeclTrees.Count;
            mTypeDecls = new List<CommonTypeDeclaration>(size);
            for (int offset = 0; offset < size; offset++) {
                AST2JSOMTree tree = mTypeDeclTrees[offset];
                switch (tree.Type) {
                case JavaTreeParser.CLASS:
                    mTypeDecls.Add(new AST2ClassDeclaration(
                                                tree, getTokenRewriteStream()));
                    break;
                case JavaTreeParser.INTERFACE:
                    mTypeDecls.Add(new AST2InterfaceDeclaration(
                                                tree, getTokenRewriteStream()));
                    break;
                case JavaTreeParser.ENUM:
                    mTypeDecls.Add(new AST2EnumDeclaration(
                                                tree, getTokenRewriteStream()));
                    break;
                case JavaTreeParser.AT:
                    mTypeDecls.Add(new AST2AnnotationDeclaration(
                                                tree, getTokenRewriteStream()));
                    break;
                }
            }
        }
    }

    /**
     * Replaces the identifier of the Java source.
     * <p>
     * Note that setting this identifier has no affect to a marshalled Java.
     * 
     * @param pNewIdentifier  The new identifier.
     * 
     * @return  The old identifier.
     */
    public String setJavaSourceIdentifier(String pNewIdentifier) {
        
        String result = mJavaSourceIdentifier;
        mJavaSourceIdentifier = pNewIdentifier;
        
        return result;
    }
    
    /**
     * Calls the methods <code>pAction.performAction(...)</code> and <code>
     * pAction.actionPerformed(...)</code> with <code>this</code> as argument.
     * <P>
     * Furthermore, if <code>pAction.isMemberTraversionEnabled() == true</code>
     * all <code>JSOM</code> members that belong to <code>this
     * </code> will be traversed by calling the <code>traverseAll(...)</code> 
     * method on these members with <code>pAction</code> as argument. This will
     * be done after the <code>pAction.performAction(...)</code> call but before
     * the <code>pAction.actionPerformed(...)</code> call.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            if (mAnnotationsTree != null) {
                if (mAnnotations == null) {
                    resolveAnnotations();
                }
                foreach (Annotation annotation in mAnnotations) {
                    annotation.traverseAll(pAction);
                }
            }

            if (mPackageDeclTree != null)
            {
                if (mPackageDecl == null)
                {
                    resolvePackageDeclaration();
                }
                mPackageDecl.traverseAll(pAction);
            }


            //QualifiedIdentifier namespaceDecl = getPackageDeclaration();
            //if (namespaceDecl != null) {
            //    if (mPackageDecl == null)
            //    {
            //        resolvePackageDeclaration();
            //    }

            //    namespaceDecl.traverseAll(pAction);
            //}
            if (mImportDeclTrees != null) {
                if (mImportDecls == null) {
                    resolveImportDeclarations();
                }
                foreach (ImportDeclaration importDecl in mImportDecls) {
                    importDecl.traverseAll(pAction);
                }
            }
            if (mTypeDeclTrees != null) {
                if (mTypeDecls == null) {
                    resolveTypeDeclarations();
                }
                foreach (CommonTypeDeclaration typeDecl in mTypeDecls) {
                    typeDecl.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}