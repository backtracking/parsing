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
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using OwnerType = com.habelitz.jsobjectizer.jsom.api.OwnerType;
using ClassConstructorCall = com.habelitz.jsobjectizer.jsom.api.expression.ClassConstructorCall;
using StatementBlockScope = com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockScope;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement;
using com.habelitz.jsobjectizer.jsom.api.statement;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/**
 * The main purpose of this <code>JSOM</code> type is the representation of a
 * top level scope of a certain class including anonymous class declarations.
 * <p>
 * Instances of this class may also be part of an enumeration declaration and 
 * there are two possible locations where most of the content of a class top 
 * level scope can also be stated within an enumeration declaration.
 * <p>
 * The first possibility is a cut down class top level scope that may follow an
 * enumeration constant declaration which can have it's own members, method 
 * definitions, inner type declarations and so on (but no constructor definition
 * or abstract method declaration for instance). The second possibility a cut 
 * down class top level scope may occur within an enumeration declaration is
 * behind the list of the enumeration constants. The formal example stated below
 * demonstrates these two possibilities a class top level scope may occur within
 * an enumeration declaration in a more visual way: 
 * <p>
 *  <pre>
 *      enum AnyEnum {
 *          CONST_1,
 *          CONST_2 {
 *              // A cut down class top level scope that belongs to a certain 
 *              // enum constant declaration.
 *              int exampleMember = 0;
 *              public void doSomething() {
 *                  // do something
 *              }
 *              final class InnerClass {
 *                  int innerClassMember = 0;
 *                  public void doSomethingVerySpecial() {
 *                      // do something
 *                  }
 *              }
 *          },
 *          CONST_3;
 *          // ... 
 *          CONST_n;
 *          // A cut down class top level scope that follows the list of the 
 *          // enum constants. I.e. this class top level scope content is
 *          // nested within an enum top level scope.
 *          int exampleMember = 0;
 *          public void doSomething() {
 *              // do something
 *          }
 *          public class InnerClass {
 *              int innerClassMember = 0;
 *              public void doSomethingVerySpecial() {
 *                  // do something
 *              }
 *          }
 *      }
 *  </pre>
 * <p>
 * Even if an enumeration declaration can contain only cut down versions of a 
 * class top level scope at different locations the <i>JSourceObjectizer</i>
 * doesn't define appropriate <code>JSOM</code> types for these cut down 
 * versions, i.e. fully featured <code>ClassTopLevelScope</code> objects are 
 * used to represent these cut down versions, too.
 * 
 * @author Dieter Habelitz
 */
public class AST2ClassTopLevelScope : AST2AbstractTypeTopLevelScope, ClassTopLevelScope {

    // The constructor definitions from this scope.
    private List<ConstructorDefinition> mConstructorDefs;
    // The instance initializers from this scope.
    private List<StatementBlockScope> mInstanceInitializers;
    // The static initializers from this scope.
    private List<StatementBlockScope> mStaticInitializers;
    // The method definitions from this scope.
    private List<MethodDefinition> mMethodDefs;

    private bool mHasConstructorDefinitions = true;
    private bool mHasInstanceInitializers = true;
    private bool mHasStaticInitializers = true;
    private bool mHasMethodDefinitions = true;
    
    // The owner of 'this'.
    private ClassConstructorCall mOwnerClassConstructorCall;
    private ClassDeclaration mOwnerClassDeclaration;
    private EnumConstant mOwnerEnumConstant;
    private EnumTopLevelScope mOwnerEnumTopLevelScope;

    private OwnerType mOwnerType;
    
    private List<MethodDeclaration> mTempMethodDecls = new List<MethodDeclaration>();
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    private AST2ClassTopLevelScope(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.CLASS_TOP_LEVEL_SCOPE, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.CLASS_TOP_LEVEL_SCOPE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pOwner  The class constructor call if the anonymous class
     *                declaration the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassTopLevelScope(
        AST2JSOMTree pTree, ClassConstructorCall pOwner, 
        TokenRewriteStream pTokenRewriteStream) 
        : this(pTree, pTokenRewriteStream)
    {
        mOwnerClassConstructorCall = pOwner;
        mOwnerType = OwnerType.ANONYMOUS_CLASS_DECLARATION;
    }
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pOwner  The class declaration the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassTopLevelScope(
        AST2JSOMTree pTree, ClassDeclaration pOwner,
        TokenRewriteStream pTokenRewriteStream) 
        : this(pTree, pTokenRewriteStream)
    {
        mOwnerClassDeclaration = pOwner;
        mOwnerType = OwnerType.CLASS_DECLARATION;
    }

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pOwner  The enum constant the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassTopLevelScope(
        AST2JSOMTree pTree, EnumConstant pOwner, 
        TokenRewriteStream pTokenRewriteStream) 
        :  this(pTree, pTokenRewriteStream)
    {
        mOwnerEnumConstant = pOwner;
        mOwnerType = OwnerType.ENUM_CONSTANT_DECLARATION;
    }
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pOwner  The enum top level scope the new object belongs to.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassTopLevelScope(
            AST2JSOMTree pTree, EnumTopLevelScope pOwner,
            TokenRewriteStream pTokenRewriteStream) : this(pTree, pTokenRewriteStream) {

        mOwnerEnumTopLevelScope = pOwner;
        mOwnerType = OwnerType.ENUM_TOP_LEVEL_SCOPE;
    }
    
    /**
     * Returns a list of this scope's constructor definitions.
     * <p>
     * Calling this method equals an <code>getConstructorDefinitions(null)
     * </code> call.
     * 
     * @see #getConstructorDefinitions(List)
     *  
     * @return  A list of this scope's constructor definitions. If there are no 
     *          constructor definitions <code>null</code> will be returned.
     */
    public List<ConstructorDefinition> getConstructorDefinitions() {
        
        return getConstructorDefinitions(null);
    }

    /**
     * Returns a list of this scope's constructor definitions.
     * 
     * @param  pList  If this argument isn't <code>null</code> the constructor
     *                definitions will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of this scope's constructor definitions. If there are no 
     *          constructor definitions <code>null</code> will be returned, even 
     *          if the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<ConstructorDefinition> getConstructorDefinitions(
            List<ConstructorDefinition> pList) {
        
        if (!mHasConstructorDefinitions) {
            return null; // No constructor definitions available.
        }
        if (mConstructorDefs == null) {
            resolveConstructorDefinitions();
            if (!mHasConstructorDefinitions) {
                return null; // No constructor definitions available.
            }
        }
        List<ConstructorDefinition> result = pList;
        if (result == null) {
            result = new List<ConstructorDefinition>(
                                                    mConstructorDefs.Count);
        }
        result.AddRange(mConstructorDefs);
        
        return result;
    }

    /**
     * Returns a list of the statement block scopes of instance initializers 
     * (i.e. initializers like <code>static</code> initializers but without the 
     * <code>static</code> keyword).
     * <p>
     * Calling this method equals an <code>getInstanceInitializers(null)
     * </code> call.
     * 
     * @see #getInstanceInitializers(List)
     *                
     * @return  A list of the statement block scopes of instance initializers.
     *          If the class represented by <code>this</code> doesn't define any
     *          instance initializer <code>null</code> will be returned.
     */
    public List<StatementBlockScope> getInstanceInitializers() {
        
        return getInstanceInitializers(null);
    }
    
    /**
     * Returns a list of the statement block scopes of instance initializers 
     * (i.e. initializers like <code>static</code> initializers but without the 
     * <code>static</code> keyword).
     * 
     * @param  pList  If this argument isn't <code>null</code> the statement
     *                block scopes will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *                
     * @return  A list of the statement block scopes of instance initializers.
     *          If the class represented by <code>this</code> doesn't define any
     *          instance initializer <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<StatementBlockScope> getInstanceInitializers(
            List<StatementBlockScope> pList) {
        
        if (!mHasInstanceInitializers) {
            return null; // No instance initializers available.
        }
        if (mInstanceInitializers == null) {
            resolveInstanceInitializers(); 
            if (!mHasInstanceInitializers) {
                return null; // No instance initializers available.
            }
        }
        List<StatementBlockScope> result = pList;
        if (result == null) {
            result = new List<StatementBlockScope>(
                                                mInstanceInitializers.Count);
        }
        result.AddRange(mInstanceInitializers);
        
        return result;
    }
    
    /**
     * Returns this scope's method declarations.
     * <p>
     * Calling this method equals an <code>
     * getMethodDeclarations(anyBoolState, null)</code> call.
     * 
     * @see #getMethodDeclarations(bool, List)
     * 
     * @param pIncludeMethodDefinitions  If <code>true</code> this method also
     *                                   returns method definitions. Otherwise
     *                                   the behavior of this method is equal to 
     *                                   the method <code>getMethodDeclaration()
     *                                   </code> (i.e. without any argument)
     *                                   from the super class <code>
     *                                   AbstractTypeTopLevelScope</code>.
     * 
     * @return  This scope's method declarations/definitions. If there are no 
     *          method declarations/definitions <code>null</code> will be 
     *          returned.
     */
    public List<MethodDeclaration> getMethodDeclarations(
            bool pIncludeMethodDefinitions) {
        
        return getMethodDeclarations(pIncludeMethodDefinitions, null);
    }
    
    /**
     * Returns this scope's method declarations.
     * 
     * @param pIncludeMethodDefinitions  If <code>true</code> this method also
     *                                   returns method definitions. Otherwise
     *                                   the behavior of this method is equal to 
     *                                   the method <code>getMethodDeclaration()
     *                                   </code> (i.e. without any argument)
     *                                   from the super class <code>
     *                                   AbstractTypeTopLevelScope</code>.
     * @param  pList  If this argument isn't <code>null</code> the method
     *                declarations will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *                
     * @return  This scope's method declarations/definitions. If there are no 
     *          method declarations/definitions <code>null</code> will be 
     *          returned, even if the argument <code>pList</code> isn't <code>
     *          null</code>.
     */
    public List<MethodDeclaration> getMethodDeclarations(
            bool pIncludeMethodDefinitions, List<MethodDeclaration> pList) {
        
        mTempMethodDecls.Clear();
        List<MethodDeclaration> methodDecls = 
                                        getMethodDeclarations(mTempMethodDecls);
        int size = 0;
        if (methodDecls != null) {
            size = methodDecls.Count;
        }
        List<MethodDefinition> methodDefs = null;
        if (pIncludeMethodDefinitions) {
            if (mMethodDefs == null && mHasMethodDefinitions) {
                resolveMethodDefinitions();
            }
            if (mMethodDefs != null) {
                methodDefs = mMethodDefs;
                size += methodDefs.Count;
            }
        }
        if (size == 0) {
            return null;
        }
        List<MethodDeclaration> result = pList;
        if (result == null) {
            result = new List<MethodDeclaration>(size);
        }
        // Fill the temporary list in any case because JSOM may change in the
        // future to enable changes to the JSOM objects.
        if (methodDecls != null) {
            result.AddRange(methodDecls);
        }
        if (methodDefs != null) {
            result.AddRange(methodDefs);
        }
        
        return result;
    }
    
    /**
     * Returns a certain method definition.
     * 
     * @param pMethodName  The identifier of the method.
     *  
     * @return  A method definition or <code>null</code> if no method definition 
     *          exists for the stated identifier.
     */
    public MethodDefinition getMethodDefinition(String pMethodName) {
        
        if (!mHasMethodDefinitions) {
            return null; // No method definitions available.
        }
        if (mMethodDefs == null) {
            resolveMethodDefinitions();
            if (!mHasMethodDefinitions) {
                return null; // No method definitions available.
            }
        }
        foreach (MethodDefinition methodDef in mMethodDefs) {
            if (methodDef.getIdentifier().Equals(pMethodName)) {
                return methodDef;
            }
        }
        
        return null;
    }
    
    /**
     * Returns a list of this scope's method definitions (excluding abstract 
     * method declarations).
     * <p>
     * Calling this method equals an <code>getMethodDefinitions(null)
     * </code> call.
     * 
     * @see #getMethodDefinitions(List)
     *                
     * @return  A list of this scope's method definitions. If there are no 
     *          method definitions <code>null</code> will be returned.
     */
    public List<MethodDefinition> getMethodDefinitions() {
        
        return getMethodDefinitions(null);
    }
    
    /**
     * Returns a list of this scope's method definitions (excluding abstract 
     * method declarations).
     *  
     * @param  pList  If this argument isn't <code>null</code> the method
     *                definitions will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *                
     * @return  A list of this scope's method definitions. If there are no 
     *          method definitions <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<MethodDefinition> getMethodDefinitions(
            List<MethodDefinition> pList) {
        
        if (!mHasMethodDefinitions) {
            return null; // No method definitions available.
        }
        if (mMethodDefs == null) {
            resolveMethodDefinitions();
            if (!mHasMethodDefinitions) {
                return null; // No method definitions available.
            }
        }
        List<MethodDefinition> result = pList;
        if (result == null) {
            result = new List<MethodDefinition>(mMethodDefs.Count);
        }
        result.AddRange(mMethodDefs);
        
        return result;
    }
    
    /**
     * If <code>this</code> belongs to an anonymous class declaration this 
     * method returns the appropriate owner object.
     * <p>
     * For more information about the owner types of a class top level scope see
     * the main documentation of this type.
     * <p>
     * @see #getOwnerClassDeclaration()
     * @see #getOwnerEnumConstant()
     * @see #getOwnerEnumTopLevelScope()
     * 
     * @return  The class declaration this top level scope belongs to or <code>
     *          null</code> if <code>
     *          getOwnerType() != OwnerType.ANONYMOUS_CLASS_DECLARATION</code>.
     */
    public ClassConstructorCall getOwnerAnonymousClassDeclaration() {
        
        return mOwnerClassConstructorCall;
    }
    
    /**
     * If <code>this</code> belongs to a class declaration (expecting anonymous
     * class declarations) this method returns the appropriate owner object.
     * <p>
     * @see #getOwnerAnonymousClassDeclaration()
     * @see #getOwnerEnumConstant()
     * @see #getOwnerEnumTopLevelScope()
     * 
     * @return  The class declaration this top level scope belongs to or <code>
     *          null</code> if <code>
     *          getOwnerType() != OwnerType.CLASS_DECLARATION</code>.
     */
    public ClassDeclaration getOwnerClassDeclaration() {
        
        return mOwnerClassDeclaration;
    }
    
    /**
     * If <code>this</code> belongs to an enumeration constant declaration this
     * method returns the appropriate owner object.
     * <p>
     * For more information about the owner types of a class top level scope see
     * the main documentation of this type.
     * <p>
     * @see #getOwnerAnonymousClassDeclaration()
     * @see #getOwnerClassDeclaration()
     * @see #getOwnerEnumTopLevelScope()
     * 
     * @return  The enumeration top level scope the content of this class top 
     *          level scope belongs to or <code>null</code> <code>
     *          getOwnerType() != OwnerType.ENUM_CONSTANT_DECLARATION</code>. 
     */
    public EnumConstant getOwnerEnumConstant() {
        
        return mOwnerEnumConstant;
    }
    
    /**
     * If <code>this</code> belongs to an enumeration top level scope this 
     * method returns the appropriate owner object.
     * <p>
     * For more information about the owner types of a class top level scope see
     * the main documentation of this type.
     * <p>
     * @see #getOwnerAnonymousClassDeclaration()
     * @see #getOwnerClassDeclaration()
     * @see #getOwnerEnumConstant()
     * 
     * @return  The enumeration top level scope the content of this class top 
     *          level scope belongs to or <code>null</code> <code>
     *          getOwnerType() != OwnerType.ENUM_TOP_LEVEL_SCOPE</code>. 
     */
    public EnumTopLevelScope getOwnerEnumTopLevelScope() {
        
        return mOwnerEnumTopLevelScope;
    }

    /**
     * Returns the owner type <code>this belongs to.
     * <p>
     * For more information about the owner types of a class top level scope see
     * the main documentation of this type.
     *  
     * @return  One of the constants defined by <code>
     *          ClassTopLevelScope.OwnerType</code>.
     */
    public OwnerType getOwnerType() {
        
        return mOwnerType;
    }

    /**
     * Returns a list of the statement block scopes of static initializers.
     * <p>
     * Calling this method equals an <code>getStaticInitializers(null)
     * </code> call.
     * 
     * @see #getStaticInitializers(List)
     *                
     * @return  A list of the statement block scopes of static initializers. If
     *          the class represented by <code>this</code> doesn't define any
     *          static initializer <code>null</code> will be returned.
     */
    public List<StatementBlockScope> getStaticInitializers() {
        
        return getStaticInitializers(null);
    }
    
    /**
     * Returns a list of the statement block scopes of static initializers.
     * 
     * @param  pList  If this argument isn't <code>null</code> the statement
     *                block scopes will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *                
     * @return  A list of the statement block scopes of static initializers. If
     *          the class represented by <code>this</code> doesn't define any
     *          static initializer <code>null</code> will be returned, even if
     *          the argument <code>pList</code> isn't <code>null</code>.
     */
    public List<StatementBlockScope> getStaticInitializers(
            List<StatementBlockScope> pList) {
        
        if (!mHasStaticInitializers) {
            return null; // No static initializers available.
        }
        if (mStaticInitializers == null) {
            resolveStaticInitializers();
            if (!mHasStaticInitializers) {
                return null; // No static initializers available.
            }
        }
        List<StatementBlockScope> result = pList;
        if (result == null) {
            result = new List<StatementBlockScope>(
                    mStaticInitializers.Count);
        }
        result.AddRange(mStaticInitializers);
        
        return result;
    }
    
    /**
     * Tells if <code>this</code> has at least one constructor definition. 
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          constructor definition.
     */
    public bool hasConstructorDefinition() {
        
        if (mConstructorDefs == null && mHasConstructorDefinitions) {
            resolveConstructorDefinitions();
        }
        
        return mHasConstructorDefinitions;
    }
    
    /**
     * Tells if <code>this</code> has at least one instance initializer. 
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          instance initializer.
     */
    public bool hasInstanceInitializer() {

        if (mInstanceInitializers == null && mHasInstanceInitializers) {
            resolveInstanceInitializers();
        }
        
        return mHasInstanceInitializers;
    }
    
    /**
     * Tells if <code>this</code> has at least one method declaration.
     * 
     * @param includeMethodDefinitions  If <code>true</code> this method also
     *                                  considers method definitions. Otherwise
     *                                  the behavior of this method is equal to
     *                                  the method <code>hasMethodDeclaration()
     *                                  </code> (i.e. without any argument) from 
     *                                  the super class <code>
     *                                  AbstractTypeTopLevelScope</code>.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one method
     *          declaration.
     */
    public bool hasMethodDeclaration(bool includeMethodDefinitions) {
        
        bool hasMethodDecl = hasMethodDeclaration();
        if (!hasMethodDecl && includeMethodDefinitions) {
            hasMethodDecl = hasMethodDefinition();
        }
        
        return hasMethodDecl;
    }
    
    /**
     * Tells if <code>this</code> has a certain method definition.
     * <p>
     * Note that abstract method declarations will be ignored by this method, 
     * i.e. only non abstract methods will be considered.
     * 
     * @param pMethodIdentifier  A method identifier.
     * 
     * @return  <code>true</code> if a method definition exists for the stated
     *          identifier.
     */
    public bool hasMethodDefinition(String pMethodIdentifier) {
        
        return getMethodDefinition(pMethodIdentifier) != null;
    }
    
    /**
     * Tells if <code>this</code> has at least one method definition.
     * <p>
     * Note that abstract method declarations will be ignored by this method, 
     * i.e. only non abstract methods will be considered.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one method
     *          definition.
     */
    public bool hasMethodDefinition() {
        
        if (mMethodDefs == null && mHasMethodDefinitions) {
            resolveMethodDefinitions();
        }
        
        return mHasMethodDefinitions;
    }
    
    /**
     * Tells if <code>this</code> has at least one static initializer. 
     * 
     * @return  <code>true</code> if <code>this</code> has at least one
     *          static initializer.
     */
    public bool hasStaticInitializer() {
        
        if (mStaticInitializers == null && mHasStaticInitializers) {
            resolveStaticInitializers();
        }
        
        return mHasStaticInitializers;
    }

    /**
     * Resolves the constructor definitions that belong to <code>this</code>.
     * <p>
     * If there is no constructor definition <code>mHasConstructorDefinitions
     * </code> will be set to <code>false</code>.
     */
    private void resolveConstructorDefinitions() {

        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int numberOfContentElements = rootNode.ChildCount;
        if (numberOfContentElements == 0) {
            mHasConstructorDefinitions = false;
            return;
        }
        int size = 0;
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            if (   rootNode.GetChild(offset).Type 
                == JavaTreeParser.CONSTRUCTOR_DECL) {
                size++;
            }
        }
        if (size == 0) {
            mHasConstructorDefinitions = false;
            return;
        }
        mConstructorDefs = new List<ConstructorDefinition>(size);
        TokenRewriteStream stream = getTokenRewriteStream(); 
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            if (child.Type == JavaTreeParser.CONSTRUCTOR_DECL) {
                mConstructorDefs.Add(
                        new AST2ConstructorDefinition(child, stream));
            }
        }
    }

    /**
     * Resolves the instance initializers that belong to <code>this</code>.
     * <p>
     * If there is no instance initializer <code>mHasInstanceInitializers</code>
     * will be set to <code>false</code>.
     */
    private void resolveInstanceInitializers() {

        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int numberOfContentElements = rootNode.ChildCount;
        if (numberOfContentElements == 0) {
            mHasInstanceInitializers = false;
            return;
        }
        int size = 0;
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            if (   rootNode.GetChild(offset).Type
                == JavaTreeParser.CLASS_INSTANCE_INITIALIZER) {
                size++;
            }
        }
        if (size == 0) {
            mHasInstanceInitializers = false;
            return;
        }
        mInstanceInitializers = new List<StatementBlockScope>(size);
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            if (   child.Type 
                == JavaTreeParser.CLASS_INSTANCE_INITIALIZER) {
                mInstanceInitializers.Add(
                        new AST2StatementBlockScope((AST2JSOMTree)
                                child.GetChild(0),
                                Owner.INSTANCE_INITIALIZER,
                                getTokenRewriteStream()));
            }
        }
    }
    
    /**
     * Resolves the method definitions that belong to <code>this</code>.
     * <p>
     * If there is no method definition <code>mHasMethodDefinitions</code> will 
     * be set to <code>false</code>.
     */
    private void resolveMethodDefinitions() {

        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int numberOfContentElements = rootNode.ChildCount;
        if (numberOfContentElements == 0) {
            mHasMethodDefinitions = false;
            return;
        }
        int size = 0;
        // Method definitions must have a block scope.
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            ITree child = rootNode.GetChild(offset);
            int type = child.Type;
            if (   (   type == JavaTreeParser.FUNCTION_METHOD_DECL
                    || type == JavaTreeParser.VOID_METHOD_DECL)
                &&     child.GetChild(child.ChildCount - 1).Type
                    == JavaTreeParser.BLOCK_SCOPE) {
                size++;
            }
        }
        if (size == 0) {
            mHasMethodDefinitions = false;
            return;
        }
        mMethodDefs = new List<MethodDefinition>(size);
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            int type = child.Type;
            if (   (   type == JavaTreeParser.FUNCTION_METHOD_DECL
                    || type == JavaTreeParser.VOID_METHOD_DECL)
                &&     child.GetChild(child.ChildCount - 1).Type
                    == JavaTreeParser.BLOCK_SCOPE) {
                mMethodDefs.Add(new AST2MethodDefinition(
                                            child, getTokenRewriteStream()));
            }
        }
    }
    
    /**
     * Resolves the static initializers that belong to <code>this</code>.
     * <p>
     * If there is no static initializer <code>mHasStaticInitializers</code> 
     * will be set to <code>false</code>.
     */
    private void resolveStaticInitializers() {

        AST2JSOMTree rootNode = (AST2JSOMTree)getTreeNode();
        int numberOfContentElements = rootNode.ChildCount;
        if (numberOfContentElements == 0) {
            mHasStaticInitializers = false;
            return;
        }
        int size = 0;
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            if (   rootNode.GetChild(offset).Type
                == JavaTreeParser.CLASS_STATIC_INITIALIZER) {
                size++;
            }
        }
        if (size == 0) {
            mHasStaticInitializers = false;
            return;
        }
        mStaticInitializers = new List<StatementBlockScope>(size);
        for (int offset = 0; offset < numberOfContentElements; offset++) {
            AST2JSOMTree child = (AST2JSOMTree)rootNode.GetChild(offset);
            if (   child.Type 
                == JavaTreeParser.CLASS_STATIC_INITIALIZER) {
                mStaticInitializers.Add(
                        new AST2StatementBlockScope((AST2JSOMTree)
                                child.GetChild(0),
                                Owner.STATIC_INITIALIZER,
                                getTokenRewriteStream()));
            }
        }
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
    public override void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            if (hasStaticInitializer()) {
                foreach (StatementBlockScope scope in mStaticInitializers) {
                    scope.traverseAll(pAction);
                }
            }
            if (hasInstanceInitializer()) {
                foreach (StatementBlockScope scope in mInstanceInitializers) {
                    scope.traverseAll(pAction);
                }
            }
            if (hasConstructorDefinition()) {
                foreach (ConstructorDefinition ctorDef in mConstructorDefs) {
                    ctorDef.traverseAll(pAction);
                }
            }
            if (hasMethodDefinition()) {
                foreach (MethodDefinition metodDef in mMethodDefs) {
                    metodDef.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}