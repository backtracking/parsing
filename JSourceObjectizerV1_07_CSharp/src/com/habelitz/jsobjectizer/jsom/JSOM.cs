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


using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using com.habelitz.jsobjectizer.jsom.util;
using com.habelitz.jsobjectizer.marshaller;

namespace com.habelitz.jsobjectizer.jsom {
/**
 * This is the base type for all kinds of <code>JSOM</code> types.
 *   
 * @author Dieter Habelitz
 */
    public enum JSOMType
    {

        /**
         * Constant for a JSOM type representing an annotation.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.Annotation
         */
        ANNOTATION,

        /**
         * Constant for a JSOM type representing an annotation declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.AnnotationDeclaration
         */
        ANNOTATION_DECLARATION,

        /**
         * Constant for a JSOM type representing an annotation element value.
         * <p>
         * An annotation element value is the value stated by an annotation
         * initializer.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.AnnotationElementValue
         */
        ANNOTATION_ELEMENT_VALUE,

        /**
         * Constant for a JSOM type representing an annotation initializer.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.AnnotationInitializer
         */
        ANNOTATION_INITIALIZER,

        /**
         * Constant for a JSOM type representing an annotation method 
         * declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.AnnotationMethodDeclaration
         */
        ANNOTATION_METHOD_DECLARATION,

        /**
         * Constant for a JSOM type representing an annotation declaration's top
         * level scope, i.e. the body of an annotation declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.AnnotationTopLevelScope
         */
        ANNOTATION_TOP_LEVEL_SCOPE,

        /**
         * Constant for a JSOM type representing a class declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ClassDeclaration
         */
        CLASS_DECLARATION,

        /**
         * Constant for a JSOM type representing an <code>:</code> clause
         * for class declarations.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ClassExtendsClause
         */
        CLASS_EXTENDS_CLAUSE,

        /**
         * Constant for a JSOM type representing a class declaration's top level
         * scope, i.e. the body of a class declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ClassTopLevelScope
         */
        CLASS_TOP_LEVEL_SCOPE,

        /**
         * Constant for a JSOM type representing the identifier of a complex
         * type, for instance, a class type identifier.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ComplexTypeIdentifier
         */
        COMPLEX_TYPE_IDENTIFIER,

        /**
         * Constant for a JSOM type representing a constructor definition.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ConstructorDefinition
         */
        CONSTRUCTOR_DEFINITION,

        /**
         * Constant for a JSOM type representing an enumeration constant. This 
         * are the constants defined within an enumeration type declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.EnumConstant
         */
        ENUM_CONSTANT,

        /**
         * Constant for a JSOM type representing an enumeration declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.EnumDeclaration
         */
        ENUM_DECLARATION,

        /**
         * Constant for a JSOM type representing an enumeration declaration's
         * top level scope, i.e. the body of an enumeration declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.EnumTopLevelScope
         */
        ENUM_TOP_LEVEL_SCOPE,

        /**
         * Constant for a JSOM type representing an expression.
         * <p>
         * Note that this constant will be used for all JSOM types representing
         * an expression. There are various subtypes of the type <code>
         * Expression</code> and it's up to the <code>Expression</code> base
         * type to define appropriate constants for the various expression 
         * types.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.expression.Expression
         */
        EXPRESSION,

        /**
         * Constant for a JSOM type representing a formal parameter declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.FormalParameterDeclaration
         */
        FORMAL_PARAMETER_DECLARATION,

        /**
         * Constant for a JSOM type representing a formal parameter list.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.FormalParameterList
         */
        FORMAL_PARAMETER_LIST,

        /**
         * Constant for a JSOM type representing a generic type argument.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.GenericTypeArgument
         */
        GENERIC_TYPE_ARGUMENT,

        /**
         * Constant for a JSOM type representing a generic type parameter.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.GenericTypeParameter
         */
        GENERIC_TYPE_PARAMETER,

        /**
         * Constant for a JSOM type representing an <code>,</code>
         * clause.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ImplementsClause
         */
        IMPLEMENTS_CLAUSE,

        /**
         * Constant for a JSOM type representing an <code>package</code>
         * declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ImportDeclaration
         */
        PACKAGE_DECLARATION,

        /**
         * Constant for a JSOM type representing an <code>import</code>
         * declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ImportDeclaration
         */
        IMPORT_DECLARATION,

        /**
         * Constant for a JSOM type representing an interface declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.InterfaceDeclaration
         */
        INTERFACE_DECLARATION,

        /**
         * Constant for a JSOM type representing an <code>:</code> clause
         * for interface declarations.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.InterfaceExtendsClause
         */
        INTERFACE_EXTENDS_CLAUSE,

        /**
         * Constant for a JSOM type representing an interface declaration's top 
         * level scope, i.e. the body of an interface declaration.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.EnumTopLevelScope
         */
        INTERFACE_TOP_LEVEL_SCOPE,

        /**
         * Constant for a JSOM type representing a Java source.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.JavaSource
         */
        JAVA_SOURCE,

        /**
         * Constant for a JSOM type representing a method declaration.
         * <p>
         * Note that for a JSOM type representing non-abstract methods the
         * constant <code>METHOD_DEFINITION</code> instead of this constant.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.MethodDeclaration
         * @see com.habelitz.jsobjectizer.jsom.api.MethodDefinition
         */
        METHOD_DECLARATION,

        /**
         * Constant for a JSOM type representing a method definition.
         * <p>
         * Note that for a JSOM type representing abstract methods the constant
         * <code>METHOD_DECLARATION</code> instead of this constant.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.MethodDefinition
         * @see com.habelitz.jsobjectizer.jsom.api.MethodDeclaration
         */
        METHOD_DEFINITION,

        /**
         * Constant for a JSOM type representing a modifier list.
         * <p>
         * Note that a modifier list may also contain annotations. This is
         * because annotations can be stated everywhere modifiers can occur.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ModifierList
         */
        MODIFIER_LIST,

        /**
         * Constant for a JSOM type representing a primitive type.
         * <p>
         * This constant will be used for type representations that can only be
         * primitive type. If a type respresentation may be a primitive type but
         * also a complex type the constant <code>TYPE</code> must be used.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.PrimitiveType
         * @see com.habelitz.jsobjectizer.jsom.api.Type
         */
        PRIMITIVE_TYPE,

        /**
         * Constant for a JSOM type representing a qualified identifier.
         * <p>
         * <i>Qualified identifier</i> means that a certain identifier <b>may
         * </b> be a qualified identifier. It is not obligatory that the
         * identifier is acutally a qualified identifier, i.e. it may also be
         * a single identifier. 
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.QualifiedIdentifier
         */
        QUALIFIED_IDENTIFIER,

        /**
         * Constant for a JSOM type representing a statement block element.
         * <p>
         * A statement block element can be a local variable declaration, a
         * local type declaration or any statement type. A more formal
         * description of a statement block element is that such elements are
         * direct children of a statement block scope (method or constructor
         * bodies, compound statements, etc). 
         * <p>
         * Note that this constant will be used for all JSOM types representing
         * a statement block element. There are various subtypes of the type 
         * <code>StatementBlockElement</code> and it's up to the <code>
         * StatementBlockElement</code> base type to define appropriate
         * constants for the various statement block element types.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement
         */
        STATEMENT_BLOCK_ELEMENT,

        /**
         * Constant for JSOM types that represent more or less closed parts of 
         * statements, i.e. statement clauses and so on.
         * <p>
         * For some examples ...
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.statement.SwitchLabel
         * @see com.habelitz.jsobjectizer.jsom.api.statement.Catch
         */
        STATEMENT_BLOCK_ELEMENT_HELPER,

        /**
         * Constant for a JSOM type representing a <code>throws</code> clause.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.ThrowsClause
         */
        THROWS_CLAUSE,

        /**
         * Constant for a JSOM type representing a type.
         * <p>
         * This constant must be used for types that may be primitive types but
         * also complex types.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.Type
         * @see com.habelitz.jsobjectizer.jsom.api.PrimitiveType
         */
        TYPE,

        /**
         * Constant for a JSOM type representing type member declarations, i.e.
         * variable declarations within a type declaration's top level scope.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.TypeMemberDeclaration
         */
        TYPE_MEMBER_DECLARATION,

        /**
         * Constant for a JSOM type representing a variable declarator.
         * <p>
         * A variable declarator is the part of a variable declaration that
         * contains the variable identifier and the initializer.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.VariableDeclarator
         */
        VARIABLE_DECLARATOR,

        /**
         * Constant for a JSOM type representing a variable declarator
         * identifier which states the variable identifier and the number of
         * array declarators (i.e. the number of <code>[]</code> character
         * sequences) that follow the identifier.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.VariableDeclaratorIdentifier
         */
        VARIABLE_DECLARATOR_IDENTIFIER,

        /**
         * Constant for a JSOM type representing a variable initializer.
         * 
         * @see com.habelitz.jsobjectizer.jsom.api.VariableInitializer
         */
        VARIABLE_INITIALIZER,

        /**
         * This constant is free to use for <code>JSOM</code> implementors for
         * whatever purposes. It isn't referenced nowhere by the <code>JSOM
         * </code> interfaces.
         */
        XTRA
    }

public interface JSOM {

    /**
     * Defines constants for all non-abstract <code>JSOM</code> types, excepting 
     * those types derived from <code>Expression</code> (which is the base type 
     * for all kind of expression types) and <code>StatementBlockElement</code> 
     * (which is the base type for all kind of statements).
     * <p>
     * From a <code>JSOMType</code>'s view all <code>Expression</code> types and 
     * <code>StatementBlockElement</code> types are bound to the <code>JSOMType
     * </code> <code>EXPRESSION</code> and <code>STATEMENT_BLOCK_ELEMENT</code> 
     * respectively.
     * <p>
     * The constant names correspond to the appropriate <code>JSOM</code>
     * subtype class names.
     * 
     * @author Dieter Habelitz
     */
    

    /**
     * Returns the <i>character in line</i> position where the Java code
     * represented by this <code>JSOM</code> object starts.
     * 
     * @return  The <i>character in line</i> position where the Java code
     *          represented by this <code>JSOM</code> object starts.
     */
    int getCharPositionInLine();
    
    /**
     * Returns the <code>JSOMType</code> represented by <code>this</code>.
     * 
     * @return The <code>JSOMType</code> represented by <code>this</code>.
     */
     JSOMType? getJSOMType();
    
    /**
     * Returns the line number of the Java code represented by this <code>JSOM
     * </code> object.
     * 
     * @return  The line number of the Java code represented by this <code>JSOM
     *          </code> object.
     */
     int getLineNumber();
    
    /**
     * Returns the marshaller to rewrite the Java source represented by <code>
     * this</code>.
     * <p>
     * This method can be called for every <code>JSOM</code> type and the 
     * returned marshaller will only rewrite those Java sources represented by 
     * the appropriate <code>JSOM</code> type.
     * 
     * @return  A marshaller to rewrite the Java source represented by <code>
     *          this</code>.
     */
    JSourceMarshaller getMarshaller();
    
    /** 
     * Tells if <code>this</code> represents an expression of the stated type.
     *
     * @param pType  One of the <code>ExpressionType.???</code> constants 
     *               defined by the interface <code>Expression</code>.   
     *
     * @return  <code>false</code> if <code>this</code> doesn't represents an 
     *          expression at all or if it represents an expression but the 
     *          stated type doesn't match.
     */
    bool isExpressionType(ExpressionType pType);
    
    /** 
     * Tells if <code>this</code> is of the stated <code>JSOM</code> type.
     *
     * @param pType  One of the <code>JSOMType.???</code> constants defined by
     *               the interface <code>JSOM</code>.
     *
     * @return  <code>true</code> if <code>this</code> is of the stated <code>
     *          JSOM</code> type.
     */
    bool isJSOMType(JSOMType pType);
    
    /** 
     * Tells if <code>this</code> represents a statement block element of the 
     * stated type.
     *
     * @param pType  One of the <code>ElementType.???</code> constants defined 
     *               by the interface <code>StatementBlockElement</code>.   
     *
     * @return  <code>false</code> if <code>this</code> doesn't represents a 
     *          statement block element at all or if it represents a statement 
     *          block element but the stated type doesn't match.
     */
    bool isStatementBlockElementType(ElementType pType);
    
    /**
     * Traverses all <code>JSOM</code> members that belong to <code>this</code> 
     * and calls the <code>traverseAll()</code> method of these members.
     * <p>
     * Implementation of this method must perform the following steps in the
     * stated order:
     * <p>
     *  <ol>
     *      <li>
     *          Call <code>pAction.performAction(this)</code>.
     *      </li>
     *      <li>
     *          If an implementation of this interface has any <code>JSOM</code>
     *          type members and if <code>pAction.isMemberTraversingEnabled()
     *          == true</code> it must traverse these members, i.e. it must call
     *          the <code>traverseAll(...)</code> method on these members with
     *          <code>pAction</code> as argument, i.e. <code>pAction</code> must
     *          be passed through all the members, submembers and so on.
     *      </li>
     *      <li>
     *          Call <code>pAction.actionPerformed(this)</code>.
     *      </li>
     *  </ol>  
     * 
     * @param pAction  An <code>TraverseAction</code> object that provided user 
     *                 defined traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>null
     *          </code>. Because it makes no sense to pass <code>null</code> to 
     *          this method implementations of this method shouldn't ask if 
     *          <code>pAction != null</code> for instance. Note that depending 
     *          on the amount of parsed code that should get traversed this 
     *          method could be called billions of times and is therefore not a
     *          candidate for defensive error handling.
     */
    void traverseAll(TraverseAction pAction);
}
}