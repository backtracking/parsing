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
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.abstracttype;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using CommonJSOMMessages = com.habelitz.jsobjectizer.resource.resbundle.CommonJSOMMessages;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{

    /**
     * This <code>JSOM</code> type supports all those things that can exist within
     * all kinds type declarations excepting enumeration types.
     * <p>
     * This implementation handles field declarations and inner type declarations.
     * Everything else must be handled by derived classes.
     * <p>
     * Furthermore this class provides the method <code>getScopeDeclarations()
     * </code>
     * that returns a list containing all the content from the scope.
     * 
     * @author Dieter Habelitz
     */
    public class AST2CommonTypeTopLevelScope : AST2JSOM, CommonTypeTopLevelScope
    {

        /*
         * The variable/constant declarations from this scope.
         */
        private List<AST2TypeMemberDeclaration> mFieldDeclarations;

        /*
         * The inner type declarations from this scope.
         */
        private List<CommonTypeDeclaration> mInnerTypeDeclarations;

        /*
         * Must be set to 'false' by the field declaration resolving code if there
         * are no field declarations.
         */
        private bool mHasFieldDeclarations = true;

        /*
         * Must be set to 'false' by the inner type declaration resolving code if
         * there are no inner type declarations.
         */
        private bool mHasInnerTypeDeclarations = true;

        /**
         * Constructor.
         * 
         * @param pTree
         *            The tree node representing any type top level scope, i.e. a
         *            class top level scope, for example. Note that it's up to
         *            derived classes to check that the given tree node is of a
         *            valid type.
         * @param pJSOMType
         *            One of the <code>JSOMType.???</code> constants defined by
         *            the interface <code>JSOM</code>.
         * @param pTokenRewriteStream
         *            The token stream the token of the stated tree node belongs to.
         */
        protected AST2CommonTypeTopLevelScope(
            AST2JSOMTree pTree, JSOMType pJSOMType,
            TokenRewriteStream pTokenRewriteStream)
            : base(pTree, pJSOMType, pTokenRewriteStream)
        {

        }

        /**
         * Returns the <i>character in line</i> position of the opening curly
         * bracket.
         * 
         * @return The <i>character in line</i> position of the opening curly
         *         bracket.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns a list of this scope's field declarations.
         * <p>
         * Calling this method equals an <code>getFieldDeclarations(null)</code>
         * call.
         * 
         * @see #getFieldDeclarations(List)
         * 
         * @return A list of this scope's field declarations. If there are no field
         *         declarations <code>null</code> will be returned.
         */
        public List<TypeMemberDeclaration> getFieldDeclarations()
        {

            return getFieldDeclarations(null);
        }

        /**
         * Returns a list of this scope's field declarations.
         * 
         * @param pList
         *            If this argument isn't <code>null</code> the field
         *            declarations will be added to this list and this list object
         *            will be returned. Otherwise a new list will be created for the
         *            result.
         * 
         * @return A list of this scope's field declarations. If there are no field
         *         declarations <code>null</code> will be returned, even if the
         *         argument <code>pList</code> isn't <code>null</code>.
         */
        public List<TypeMemberDeclaration> getFieldDeclarations(
                List<TypeMemberDeclaration> pList)
        {

            if (!mHasFieldDeclarations)
            {
                return null;
            }
            if (mFieldDeclarations == null)
            {
                resolveFieldDeclarations();
                if (!mHasFieldDeclarations)
                {
                    return null;
                }
            }
            List<TypeMemberDeclaration> result = pList;
            if (result == null)
            {
                result = new List<TypeMemberDeclaration>(mFieldDeclarations.Count);
            }
            foreach (TypeMemberDeclaration decl in mFieldDeclarations)
            {
                result.Add(decl);
            }

            return result;
        }

        /**
         * Returns the annotation declaration for a stated annotation identifier.
         * 
         * @see #getInnerTypeDeclaration(String)
         * 
         * @param pAnnotationName
         *            The identifier of the annotation declaration.
         * 
         * @return The annotation declaration for the stated annotation identifier
         *         or <code>null</code> if there is no appropriate annotation
         *         declaration.
         */
        public AnnotationDeclaration getInnerAnnotationDeclaration(
                String pAnnotationName)
        {

            CommonTypeDeclaration decl = getInnerTypeDeclaration(pAnnotationName);
            if (decl != null && decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION))
            {
                return (AnnotationDeclaration)decl;
            }

            return null;
        }

        /**
         * Returns a list of the annotation declarations.
         * <p>
         * Calling this method equals an <code>getInnerAnnotationDeclarations(null)
         * </code>
         * call.
         * 
         * @see #getInnerTypeDeclarations()
         * @see #getInnerAnnotationDeclarations(List)
         * 
         * @return A list of the annotation declarations. If there are no annotation
         *         declarations <code>null</code> will be returned.
         */
        public List<AnnotationDeclaration> getInnerAnnotationDeclarations()
        {

            return getInnerAnnotationDeclarations(null);
        }

        /**
         * Returns a list of the annotation declarations.
         * 
         * @see #getInnerTypeDeclarations(List)
         * 
         * @param pList
         *            If this argument isn't <code>null</code> the annotation
         *            declarations will be added to this list and this list object
         *            will be returned. Otherwise a new list will be created for the
         *            result.
         * 
         * @return A list of the annotation declarations. If there are no annotation
         *         declarations <code>null</code> will be returned, even if the
         *         argument <code>pList</code> isn't <code>null</code>.
         */
        public List<AnnotationDeclaration> getInnerAnnotationDeclarations(
                List<AnnotationDeclaration> pList)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            List<AnnotationDeclaration> result = pList;
            if (result == null)
            {
                int size = 0;
                foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
                {
                    if (decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION))
                    {
                        size++;
                    }
                }
                result = new List<AnnotationDeclaration>(size);
            }
            foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
            {
                if (decl.isJSOMType(JSOMType.ANNOTATION_DECLARATION))
                {
                    result.Add((AnnotationDeclaration)decl);
                }
            }

            return result;
        }

        /**
         * Returns the class declaration for a stated class identifier.
         * 
         * @see #getInnerTypeDeclaration(String)
         * 
         * @param pClassName
         *            The identifier of the class declaration.
         * 
         * @return The class declaration for the stated class identifier or <code>
         *          null</code>
         *         if there is no appropriate class declaration.
         */
        public ClassDeclaration getInnerClassDeclaration(String pClassName)
        {

            CommonTypeDeclaration decl = getInnerTypeDeclaration(pClassName);
            if (decl != null && decl.isJSOMType(JSOMType.CLASS_DECLARATION))
            {
                return (ClassDeclaration)decl;
            }

            return null;
        }

        /**
         * Returns a list of the class declarations.
         * <p>
         * Calling this method equals an <code>getInnerClassDeclarations(null)
         * </code>call.
         * 
         * @see #getInnerClassDeclarations(List)
         * @see #getInnerTypeDeclarations()
         * 
         * @return A list of the class declarations. If there are no class
         *         declarations <code>null</code> will be returned.
         */
        public List<ClassDeclaration> getInnerClassDeclarations()
        {

            return getInnerClassDeclarations(null);
        }

        /**
         * Returns a list of the class declarations.
         * 
         * @see #getInnerTypeDeclarations(List)
         * 
         * @param pList
         *            If this argument isn't <code>null</code> the class
         *            declarations will be added to this list and this list object
         *            will be returned. Otherwise a new list will be created for the
         *            result.
         * 
         * @return A list of the class declarations. If there are no class
         *         declarations <code>null</code> will be returned, even if the
         *         argument <code>pList</code> isn't <code>null</code>.
         */
        public List<ClassDeclaration> getInnerClassDeclarations(
                List<ClassDeclaration> pList)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            List<ClassDeclaration> result = pList;
            if (result == null)
            {
                int size = 0;
                foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
                {
                    if (decl.isJSOMType(JSOMType.CLASS_DECLARATION))
                    {
                        size++;
                    }
                }
                result = new List<ClassDeclaration>(size);
            }
            foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
            {
                if (decl.isJSOMType(JSOMType.CLASS_DECLARATION))
                {
                    result.Add((ClassDeclaration)decl);
                }
            }

            return result;
        }

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
        public EnumDeclaration getInnerEnumDeclaration(String pEnumName)
        {

            CommonTypeDeclaration decl = getInnerTypeDeclaration(pEnumName);
            if (decl != null && decl.isJSOMType(JSOMType.ENUM_DECLARATION))
            {
                return (EnumDeclaration)decl;
            }

            return null;
        }

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
        public List<EnumDeclaration> getInnerEnumDeclarations()
        {

            return getInnerEnumDeclarations(null);
        }

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
        public List<EnumDeclaration> getInnerEnumDeclarations(
                List<EnumDeclaration> pList)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            List<EnumDeclaration> result = pList;
            if (result == null)
            {
                int size = 0;
                foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
                {
                    if (decl.isJSOMType(JSOMType.ENUM_DECLARATION))
                    {
                        size++;
                    }
                }
                result = new List<EnumDeclaration>(size);
            }
            foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
            {
                if (decl.isJSOMType(JSOMType.ENUM_DECLARATION))
                {
                    result.Add((EnumDeclaration)decl);
                }
            }

            return result;
        }

        /**
         * Returns the interface declaration for a stated interface identifier.
         * 
         * @see #getInnerTypeDeclaration(String)
         * 
         * @param pInterfaceName
         *            The identifier of the interface declaration.
         * 
         * @return The interface declaration for the stated interface identifier or
         *         <code>null</code> if there is no appropriate interface
         *         declaration.
         */
        public InterfaceDeclaration getInnerInterfaceDeclaration(
                String pInterfaceName)
        {

            CommonTypeDeclaration decl = getInnerTypeDeclaration(pInterfaceName);
            if (decl != null && decl.isJSOMType(JSOMType.INTERFACE_DECLARATION))
            {
                return (InterfaceDeclaration)decl;
            }

            return null;
        }

        /**
         * Returns a list of the interface declarations.
         * <p>
         * Calling this method equals an <code>getInterfaceDeclarations(null)
         * </code>
         * call.
         * 
         * @see #getInnerInterfaceDeclarations(List)
         * @see #getInnerTypeDeclarations()
         * 
         * @return A list of the interface declarations. If there are no interface
         *         declarations <code>null</code> will be returned.
         */
        public List<InterfaceDeclaration> getInnerInterfaceDeclarations()
        {

            return getInnerInterfaceDeclarations(null);
        }

        /**
         * Returns a list of the interface declarations.
         * 
         * @see #getInnerTypeDeclarations(List)
         * 
         * @param pList
         *            If this argument isn't <code>null</code> the interface
         *            declarations will be added to this list and this list object
         *            will be returned. Otherwise a new list will be created for the
         *            result.
         * 
         * @return A list of the interface declarations. If there are no interface
         *         declarations <code>null</code> will be returned, even if the
         *         argument <code>pList</code> isn't <code>null</code>.
         */
        public List<InterfaceDeclaration> getInnerInterfaceDeclarations(
                List<InterfaceDeclaration> pList)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            List<InterfaceDeclaration> result = pList;
            if (result == null)
            {
                int size = 0;
                foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
                {
                    if (decl.isJSOMType(JSOMType.INTERFACE_DECLARATION))
                    {
                        size++;
                    }
                }
                result = new List<InterfaceDeclaration>(size);
            }
            foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
            {
                if (decl.isJSOMType(JSOMType.INTERFACE_DECLARATION))
                {
                    result.Add((InterfaceDeclaration)decl);
                }
            }

            return result;
        }

        /**
         * Returns a certain inner type declaration.
         * 
         * @see #getInnerAnnotationDeclaration(String)
         * @see #getInnerClassDeclaration(String)
         * @see #getInnerEnumDeclaration(String)
         * @see #getInnerInterfaceDeclaration(String)
         * 
         * @param pTypeIdentifier
         *            The identifier of the inner type.
         * 
         * @return An inner type declaration or <code>null</code> if no type
         *         declaration exists for the stated identifier.
         */
        public CommonTypeDeclaration getInnerTypeDeclaration(
                String pTypeIdentifier)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            foreach (CommonTypeDeclaration typeDecl in mInnerTypeDeclarations)
            {
                if (typeDecl.getIdentifier().Equals(pTypeIdentifier))
                {
                    return typeDecl;
                }
            }

            return null;
        }

        /**
         * Returns a list of this scope's inner type declarations.
         * 
         * Calling this method equals an <code>getInnerTypeDeclarations(null)</code>
         * call.
         * 
         * @see #getInnerTypeDeclarations(List)
         * @see #getInnerAnnotationDeclarations()
         * @see #getInnerClassDeclarations()
         * @see #getInnerEnumDeclarations()
         * @see #getInnerInterfaceDeclarations()
         * 
         * @return A list of this scope's inner type declarations. If there is no
         *         inner type declaration <code>null</code> will be returned.
         */
        public List<CommonTypeDeclaration> getInnerTypeDeclarations()
        {

            return getInnerTypeDeclarations(null);
        }

        /**
         * Returns a list of this scope's inner type declarations.
         * 
         * @see #getInnerAnnotationDeclarations(List)
         * @see #getInnerClassDeclarations(List)
         * @see #getInnerEnumDeclarations(List)
         * @see #getInnerInterfaceDeclarations(List)
         * 
         * @param pList
         *            If this argument isn't <code>null</code> the inner type
         *            declarations will be added to this list and this list object
         *            will be returned. Otherwise a new list will be created for the
         *            result.
         * 
         * @return A list of this scope's inner type declarations. If there is no
         *         inner type declaration <code>null</code> will be returned, even
         *         if the argument <code>pList</code> isn't <code>null</code>.
         */
        public List<CommonTypeDeclaration> getInnerTypeDeclarations(
                List<CommonTypeDeclaration> pList)
        {

            if (!mHasInnerTypeDeclarations)
            {
                return null;
            }
            if (mInnerTypeDeclarations == null)
            {
                resolveInnerTypeDeclarations();
                if (!mHasInnerTypeDeclarations)
                {
                    return null;
                }
            }
            List<CommonTypeDeclaration> result = pList;
            if (result == null)
            {
                result = new List<CommonTypeDeclaration>(
                        mInnerTypeDeclarations.Count);
            }
            result.AddRange(mInnerTypeDeclarations);

            return result;
        }

        /**
         * Returns the line number of the opening curly bracket.
         * 
         * @return The line number of the opening curly bracket.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Tells if <code>this</code> has at least one field declaration.
         * 
         * @return <code>true</code> if <code>this</code> has at least one field
         *         declaration.
         */
        public bool hasFieldDeclaration()
        {

            if (mFieldDeclarations == null && mHasFieldDeclarations)
            {
                getFieldDeclarations();
            }

            return mHasFieldDeclarations;
        }

        /**
         * Tells if <code>this</code> has a certain inner type declaration.
         * 
         * @param pTypeIdentifier
         *            A method identifier.
         * 
         * @return <code>true</code> if an inner type declaration exists for the
         *         stated identifier.
         */
        public bool hasInnerTypeDeclaration(String pTypeIdentifier)
        {

            return getInnerTypeDeclaration(pTypeIdentifier) != null;
        }

        /**
         * Tells if <code>this</code> has at least one inner type declaration.
         * 
         * @return <code>true</code> if <code>this</code> has at least one inner
         *         type declaration.
         */
        public bool hasInnerTypeDeclaration()
        {

            if (mInnerTypeDeclarations == null && mHasInnerTypeDeclarations)
            {
                getInnerTypeDeclarations();
            }

            return mHasInnerTypeDeclarations;
        }

        /**
         * Removes a certain type member declaration from <code>this</code>.
         * <p>
         * Calling this method equals an <code>
         * removeTypeMemberDeclaration(TypeMemberDeclaration, true)</code>
         * call.
         * 
         * @param pTypeMemberDeclaration
         *            The type member declaration that should be removed. The
         *            argument passed to this method remains unchanged.
         * 
         * @
         *             if the type member declaration passed to this method doesn't
         *             belong to <code>this</code>.
         * 
         * __TEST__
         */
        public void removeTypeMemberDeclaration(TypeMemberDeclaration pTypeMemberDeclaration)
        {

            removeTypeMemberDeclaration(pTypeMemberDeclaration, false);
        }

        /**
         * Removes a certain type member declaration from <code>this</code>.
         * 
         * @param pTypeMemberDeclaration
         *            The type member declaration that should be removed. The
         *            argument passed to this method remains unchanged.
         * @param pRemovingOfSurroundingHiddenTokensEnabled
         *            If <code>true</code> the method also tries to remove
         *            surrounding whitespaces and comments that most likely belongs
         *            to the type member declaration.
         * 
         * @
         *             if the type member declaration passed to this method doesn't
         *             belong to <code>this</code>.
         * 
         * __TEST__
         */
        public void removeTypeMemberDeclaration(
                TypeMemberDeclaration pTypeMemberDeclaration,
                bool pRemovingOfSurroundingHiddenTokensEnabled)
        {

            AST2TypeMemberDeclaration removedMember = null;
            if (mFieldDeclarations != null)
            {
                int offset = mFieldDeclarations.IndexOf((AST2TypeMemberDeclaration)pTypeMemberDeclaration);
                if (offset != -1)
                {
                    removedMember = mFieldDeclarations[offset];
                    mFieldDeclarations.RemoveAt(offset);
                }
            }
            if (removedMember == null)
            {
                // The stated type member declaration doesn't belong to 'this'.
                throw new JSourceObjectizerException(CommonJSOMMessages
                        .getTypeMemberDeclarationDoesNotExistMessage(
                                pTypeMemberDeclaration.getJSOMType().ToString()
                                        + " ("
                                        + pTypeMemberDeclaration.getLineNumber()
                                        + ':'
                                        + pTypeMemberDeclaration.getCharPositionInLine() + ")",
                                getLineNumber() + ":" + getCharPositionInLine()));
            }
            // If still here a matching type declaration has been found.
            if (pRemovingOfSurroundingHiddenTokensEnabled)
            {
                removeTreeNode(removedMember,
                        ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING,
                        ChangeTokenBorder.NEXT_NEWLINE_INCLUDING);

            }
            else
            {
                removeTreeNode(removedMember);
            }
            if (mFieldDeclarations.Count == 0)
            {
                mFieldDeclarations = null;
            }
        }

        /**
         * Resolves the field declarations that belong to <code>this</code>.
         * <p>
         * If there is no method declaration <code>mHasFieldDeclarations</code>
         * will be set to <code>false</code>.
         */
        private void resolveFieldDeclarations()
        {

            AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
            int numberOfScopeDecls = rootNode.ChildCount;
            if (numberOfScopeDecls == 0)
            {
                mHasFieldDeclarations = false;
                return;
            }
            if (mFieldDeclarations == null)
            {
                int size = 0;
                for (int offset = 0; offset < numberOfScopeDecls; offset++)
                {
                    if (rootNode.GetChild(offset).Type == JavaTreeParser.VAR_DECLARATION)
                    {
                        size++;
                    }
                }
                if (size == 0)
                {
                    mHasFieldDeclarations = false;
                    return;
                }
                mFieldDeclarations = new List<AST2TypeMemberDeclaration>(size);
                for (int offset = 0; offset < numberOfScopeDecls; offset++)
                {
                    AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
                    if (child.Type == JavaTreeParser.VAR_DECLARATION)
                    {
                        mFieldDeclarations.Add(new AST2TypeMemberDeclaration(child,
                                getTokenRewriteStream()));
                    }
                }
            }
        }

        /**
         * Resolves the inner type declarations that belong to <code>this</code>.
         * <p>
         * If there is no method declaration <code>mHasInnerTypeDeclarations</code>
         * will be set to <code>false</code>.
         */
        private void resolveInnerTypeDeclarations()
        {

            AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
            int numberOfScopeDecls = rootNode.ChildCount;
            if (numberOfScopeDecls == 0)
            {
                mHasInnerTypeDeclarations = false;
                return;
            }
            int size = 0;
            for (int offset = 0; offset < numberOfScopeDecls; offset++)
            {
                int type = rootNode.GetChild(offset).Type;
                if (type == JavaTreeParser.CLASS
                        || type == JavaTreeParser.INTERFACE
                        || type == JavaTreeParser.ENUM || type == JavaTreeParser.AT)
                {
                    size++;
                }
            }
            if (size == 0)
            {
                mHasInnerTypeDeclarations = false;
                return;
            }
            mInnerTypeDeclarations = new List<CommonTypeDeclaration>(size);
            for (int offset = 0; offset < numberOfScopeDecls; offset++)
            {
                AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
                switch (child.Type)
                {
                    case JavaTreeParser.CLASS:
                        mInnerTypeDeclarations.Add(new AST2ClassDeclaration(child,
                                getTokenRewriteStream()));
                        break;
                    case JavaTreeParser.INTERFACE:
                        mInnerTypeDeclarations.Add(new AST2InterfaceDeclaration(child,
                                getTokenRewriteStream()));
                        break;
                    case JavaTreeParser.ENUM:
                        mInnerTypeDeclarations.Add(new AST2EnumDeclaration(child,
                                getTokenRewriteStream()));
                        break;
                    case JavaTreeParser.AT:
                        mInnerTypeDeclarations.Add(new AST2AnnotationDeclaration(child,
                                getTokenRewriteStream()));
                        break;
                }
            }
        }

        /**
         * If <code>pAction.isMemberTraversionEnabled() == true</code> this method
         * traverses all <code>JSOM</code> members that belong to
         * <code>this</code> by calling the <code>traverseAll(...)</code> method
         * on these members with <code>pAction</code> as argument.
         * <p>
         * Calling the methods <code>pAction.performAction(this)</code> and <code>
         * pAction.actionPerformed(this)</code>
         * is up to classes that implement all the abstract methods not implemented
         * by this class.
         * 
         * @see JSOM#traverseAll(TraverseAction)
         * 
         * @param pAction
         *            User define traverse actions.
         * 
         * @throws NullPointerException
         *             if <code>pAction</code> is <code>
         *          null</code>.
         */
        public virtual void traverseAll(TraverseAction pAction)
        {

            if (pAction.isMemberTraversingEnabled())
            {
                // Traverse the members.
                if (hasFieldDeclaration())
                {
                    foreach (TypeMemberDeclaration decl in mFieldDeclarations)
                    {
                        decl.traverseAll(pAction);
                    }
                }
                if (hasInnerTypeDeclaration())
                {
                    foreach (CommonTypeDeclaration decl in mInnerTypeDeclarations)
                    {
                        decl.traverseAll(pAction);
                    }
                }
            }
        }
    }
}
