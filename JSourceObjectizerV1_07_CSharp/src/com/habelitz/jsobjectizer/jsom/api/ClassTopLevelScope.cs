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
using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.jsom.api.statement;

namespace com.habelitz.jsobjectizer.jsom.api
{
    /**
     * Defines constants for the various owners a class top level scope can
     * belong to.
     */
    public enum OwnerType
    {

        /**
         * Constant for the case where a class top level scope belongs to an
         * anonymous class declaration.
         */
        ANONYMOUS_CLASS_DECLARATION,

        /**
         * Constant for the case where a class top level scope belongs to a
         * class declaration exception anonymous class declarations.
         */
        CLASS_DECLARATION,

        /**
         * Constant for the case where a class top level scope belongs to a
         * certain enumeration constant.
         */
        ENUM_CONSTANT_DECLARATION,

        /**
         * Constant for the case where a class top level scope belongs to an
         * enumeration top level scope, i.e. this is the optional class top
         * level scope content that may follow the list of enumeration constant
         * declarations.
         */
        ENUM_TOP_LEVEL_SCOPE
    }

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
    public interface ClassTopLevelScope : AbstractTypeTopLevelScope
    {



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
        /*public*/ List<ConstructorDefinition> getConstructorDefinitions();

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
        /*public*/ List<ConstructorDefinition> getConstructorDefinitions(
                                                List<ConstructorDefinition> pList);

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
        /*public*/ List<StatementBlockScope> getInstanceInitializers();

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
        /*public*/ List<StatementBlockScope> getInstanceInitializers(
                                                List<StatementBlockScope> pList);

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
        /*public*/ List<MethodDeclaration> getMethodDeclarations(
                                               bool pIncludeMethodDefinitions);

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
        /*public*/ List<MethodDeclaration> getMethodDeclarations(
                bool pIncludeMethodDefinitions, List<MethodDeclaration> pList);

        /**
         * Returns a certain method definition.
         * 
         * @param pMethodIdentifier  The identifier of the method.
         *  
         * @return  A method definition or <code>null</code> if no method definition 
         *          exists for the stated identifier.
         */
        /*public*/ MethodDefinition getMethodDefinition(String pMethodIdentifier);

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
        /*public*/ List<MethodDefinition> getMethodDefinitions();

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
        /*public*/ List<MethodDefinition> getMethodDefinitions(
                                                    List<MethodDefinition> pList);

        /**
         * If <code>this</code> belongs to an inner class declaration this method 
         * returns the appropriate owner object.
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
        /*public*/ ClassConstructorCall getOwnerAnonymousClassDeclaration();

        /**
         * If <code>this</code> belongs to a class declaration (expecting anonymous
         * class declarations) this method returns the appropriate owner object.
         * <p>
         * For more information about the owner types of a class top level scope see
         * the main documentation of this type.
         * <p>
         * @see #getOwnerAnonymousClassDeclaration()
         * @see #getOwnerEnumConstant()
         * @see #getOwnerEnumTopLevelScope()
         * 
         * @return  The class declaration this top level scope belongs to or <code>
         *          null</code> if <code>
         *          getOwnerType() != OwnerType.CLASS_DECLARATION</code>.
         */
        /*public*/ ClassDeclaration getOwnerClassDeclaration();

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
        /*public*/ EnumConstant getOwnerEnumConstant();

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
        /*public*/ EnumTopLevelScope getOwnerEnumTopLevelScope();

        /**
         * Returns the owner type <code>this belongs to.
         * <p>
         * For more information about the owner types of a class top level scope see
         * the main documentation of this type.
         *  
         * @return  One of the constants defined by <code>
         *          ClassTopLevelScope.OwnerType</code>.
         */
        /*public*/ OwnerType getOwnerType();

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
        /*public*/ List<StatementBlockScope> getStaticInitializers();

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
        /*public*/ List<StatementBlockScope> getStaticInitializers(
                                                List<StatementBlockScope> pList);

        /**
         * Tells if <code>this</code> has at least one constructor definition. 
         * 
         * @return  <code>true</code> if <code>this</code> has at least one
         *          constructor definition.
         */
        /*public*/ bool hasConstructorDefinition();

        /**
         * Tells if <code>this</code> has at least one instance initializer. 
         * 
         * @return  <code>true</code> if <code>this</code> has at least one
         *          instance initializer.
         */
        /*public*/ bool hasInstanceInitializer();

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
        /*public*/ bool hasMethodDeclaration(bool includeMethodDefinitions);

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
        /*public*/ bool hasMethodDefinition(String pMethodIdentifier);

        /**
         * Tells if <code>this</code> has at least one method definition.
         * <p>
         * Note that abstract method declarations will be ignored by this method, 
         * i.e. only non abstract methods will be considered.
         * 
         * @return  <code>true</code> if <code>this</code> has at least one method
         *          definition.
         */
        /*public*/ bool hasMethodDefinition();

        /**
         * Tells if <code>this</code> has at least one static initializer. 
         * 
         * @return  <code>true</code> if <code>this</code> has at least one
         *          static initializer.
         */
        /*public*/ bool hasStaticInitializer();
    }
}