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
using Annotation = com.habelitz.jsobjectizer.jsom.api.Annotation;
using ClassExtendsClause = com.habelitz.jsobjectizer.jsom.api.ClassExtendsClause;
using ComplexTypeIdentifier = com.habelitz.jsobjectizer.jsom.api.ComplexTypeIdentifier;
using EnumConstant = com.habelitz.jsobjectizer.jsom.api.EnumConstant;
using FormalParameterList = com.habelitz.jsobjectizer.jsom.api.FormalParameterList;
using GenericTypeArgument = com.habelitz.jsobjectizer.jsom.api.GenericTypeArgument;
using ImplementsClause = com.habelitz.jsobjectizer.jsom.api.ImplementsClause;
using ImportDeclaration = com.habelitz.jsobjectizer.jsom.api.ImportDeclaration;
using InterfaceExtendsClause = com.habelitz.jsobjectizer.jsom.api.InterfaceExtendsClause;
using JavaSource = com.habelitz.jsobjectizer.jsom.api.JavaSource;
using ModifierList = com.habelitz.jsobjectizer.jsom.api.ModifierList;
using PrimitiveType = com.habelitz.jsobjectizer.jsom.api.PrimitiveType;
using QualifiedIdentifier = com.habelitz.jsobjectizer.jsom.api.QualifiedIdentifier;
using ThrowsClause = com.habelitz.jsobjectizer.jsom.api.ThrowsClause;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using VariableDeclaratorIdentifier = com.habelitz.jsobjectizer.jsom.api.VariableDeclaratorIdentifier;
using VariableInitializer = com.habelitz.jsobjectizer.jsom.api.VariableInitializer;
using CommonTypeDeclaration = com.habelitz.jsobjectizer.jsom.api.abstracttype.CommonTypeDeclaration;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using AssertStatement = com.habelitz.jsobjectizer.jsom.api.statement.AssertStatement;
using BreakStatement = com.habelitz.jsobjectizer.jsom.api.statement.BreakStatement;
using ContinueStatement = com.habelitz.jsobjectizer.jsom.api.statement.ContinueStatement;
using ExpressionStatement = com.habelitz.jsobjectizer.jsom.api.statement.ExpressionStatement;
using ForEachStatement = com.habelitz.jsobjectizer.jsom.api.statement.ForEachStatement;
using ForStatement = com.habelitz.jsobjectizer.jsom.api.statement.ForStatement;
using IfStatement = com.habelitz.jsobjectizer.jsom.api.statement.IfStatement;
using LabeledStatement = com.habelitz.jsobjectizer.jsom.api.statement.LabeledStatement;
using LocalClassDeclaration = com.habelitz.jsobjectizer.jsom.api.statement.LocalClassDeclaration;
using LocalVariableDeclaration = com.habelitz.jsobjectizer.jsom.api.statement.LocalVariableDeclaration;
using ReturnStatement = com.habelitz.jsobjectizer.jsom.api.statement.ReturnStatement;
using Statement = com.habelitz.jsobjectizer.jsom.api.statement.Statement;
using StatementBlockElement = com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockElement;
using StatementBlockScope = com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockScope;
using SwitchStatement = com.habelitz.jsobjectizer.jsom.api.statement.SwitchStatement;
using SynchronizedStatement = com.habelitz.jsobjectizer.jsom.api.statement.SynchronizedStatement;
using ThrowStatement = com.habelitz.jsobjectizer.jsom.api.statement.ThrowStatement;
using TryStatement = com.habelitz.jsobjectizer.jsom.api.statement.TryStatement;
using WhileAndDoStatements = com.habelitz.jsobjectizer.jsom.api.statement.WhileAndDoStatements;
using JSourceUnmarshallerException = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshallerException;
using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.statement;
using com.habelitz.core;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge
{


/**
 * Base class for public unmarshallers.
 * 
 * __TEST__  Most unmarshalble code fragments still untested for unmarshalling
 *           failure.
 *           
 * @author Dieter Habelitz
 */
public class JSourceUnmarshallerBase : AST2JSOM.AST2JSOMUnmarshaller {

    /*
     * All unmarshaller methods provided by this class must only return object
     * that are super types of the <code>AST2JSOM</code> base type!
     */
    
    /**
     * Standard constructor.
     */
    protected JSourceUnmarshallerBase() : base() {
        
    }
    
    /**
     * Unmarshals a complete Java source file.
     * 
     * @param pJavaSource  The Java source that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>JavaSource</code>. If 
     *          marshalling the file has been failed but no exception has been 
     *          thrown <code>null</code> will be returned and it's very likely 
     *          that there's at least one message within the message list passed 
     *          to this method (if a list has been passed at all, of course).
     * 
     * @  if marshalling the Java file 
     *                                       failed.
     */
    public JavaSource unmarshal(JFile pJavaSource, List<String> pErrorMessages) 
    {

        return base.unmarshalAST2JavaSource(pJavaSource, pErrorMessages);
    }
    
    /**
     * Unmarshals a complete Java source file stated as string.
     * 
     * @param pJavaSource  The Java source that should get unmarshalled.
     * @param pJavaSourceIdentifier  The identifier of the Java source.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>JavaSource</code>. If 
     *          marshalling the file has been failed but no exception has been 
     *          thrown <code>null</code> will be returned and it's very likely 
     *          that there's at least one message within the message list passed 
     *          to this method (if a list has been passed at all, of course).
     * 
     * @  if marshalling the Java file 
     *                                       failed.
     */
    public JavaSource unmarshal(String pJavaSource, String pJavaSourceIdentifier, List<String> pErrorMessages) 
    {

        return base.unmarshalAST2JavaSource(
                pJavaSource, pJavaSourceIdentifier, pErrorMessages);
    }
    
    /**
     * Unmarshals an annotation stated as string.
     * 
     * @param pAnnotation  The annotation that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>Annotation</code>. If 
     *          marshalling the code fragment has been failed but no exception
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list has been passed at all, of 
     *          course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public Annotation unmarshalAnnotation(
            String pAnnotation, List<String> pErrorMessages)
    {
        
        return base.unmarshalAST2Annotation(pAnnotation, pErrorMessages);
    }
    
    /**
     * Unmarshals an <code>assert</code> statement stated by a string.
     * 
     * @param pAssertStatement  The <code>assert</code> statement that should
     *                          get unmarshalled. Note that the stated string
     *                          must include the terminating semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>assertStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public AssertStatement unmarshalAssertStatement(
            String pAssertStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2AssertStatement(
                pAssertStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>break</code> statement stated by a string.
     * 
     * @param pBreakStatement  The <code>break</code> statement that should get 
     *                         unmarshalled. Note that the stated string must
     *                         include the terminating semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>breakStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public BreakStatement unmarshalBreakStatement(
            String pBreakStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2BreakStatement(
                pBreakStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a class <code>:</code> clause stated as string.
     * 
     * @param pExtendsClause  The class <code>:</code> clause that should
     *                        get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error 
     *                        messages will be written to <code>
     *                        System.err</code>. Ohterwise the error messages 
     *                        will be added to the given list and each list
     *                        entry will correspond to one error line as
     *                        reported by the parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          ClassExtendsClause</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ClassExtendsClause unmarshalClassExtendsClause(
            String pExtendsClause, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ClassExtendsClause(
                pExtendsClause, pErrorMessages);
    }
    
    /**
     * Unmarshals a complex type identifier stated as string.
     * 
     * @param pComplexTypeIdentifier  The complex type identifier that should 
     *                                get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>ComplexTypeIdentifier
     *          </code>. If marshalling the code fragment has been failed but no 
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the 
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ComplexTypeIdentifier unmarshalComplexTypeIdentifier(
            String pComplexTypeIdentifier, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ComplexTypeIdentifier(
                pComplexTypeIdentifier, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>continue</code> statement stated by a string.
     * 
     * @param pContinueStatement  The <code>continue</code> statement that
     *                            should get unmarshalled. Note that the stated
     *                            string must include the terminating semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          ContinueStatement</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ContinueStatement unmarshalContinueStatement(
            String pContinueStatement, List<String> pErrorMessages)
        {
        
        return base.unmarshalAST2ContinueStatement(
                pContinueStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>do ... while</code> statement stated by a string.
     * 
     * @param pDoWhileStatement  The <code>do ... while</code> statement that
     *                           should get unmarshalled. Note that the stated
     *                           string must contain the complete statement
     *                           including the closing semicolon and the
     *                           statement following the <code>do</code>
     *                           keyword.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          WhileAndDoStatements</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public WhileAndDoStatements unmarshalDoWhileStatement(
            String pDoWhileStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2DoWhileStatement(
                pDoWhileStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals an enumeration constant stated as string.
     * 
     * @param pEnumConstant  The enumeration constant that should get 
     *                       unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>EnumConstant</code>. 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public EnumConstant unmarshalEnumConstant(
            String pEnumConstant, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2EnumConstant(pEnumConstant, pErrorMessages);
    }
    
    /**
     * Unmarshals any kind of expressions stated as string.
     * <p>
     * <b>Important note:</b> The given string must represent a complete 
     * expression in a sematical point of view, i.e. an assignment statement, a
     * 'new' expression, a method call and so on. Unmarshalling of a fraction of
     * a complete expression <i><b>may</b></i> succeed but this is not
     * guaranteed. For instance, unmarshalling just a primiary expression
     * representing an array type declaration (something like <code>anyType[]
     * </code>) will always fail.
     * 
     * @param pExpression  The expression that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>Expression</code>. 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public Expression unmarshalExpression(
            String pExpression, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2Expression(pExpression, pErrorMessages);
    }
    
    /**
     * Unmarshals an expression statement stated by a string.
     * <p>
     * An expression statement is a statement that could also be an expression
     * anywhere else. This could be an assignment expression or a method call,
     * for instance.
     * 
     * @param pExpressionStatement  The expression statement that should get
     *                              unmarshalled. Note that the stated string
     *                              must include the terminating semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          ExpressionStatement</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ExpressionStatement unmarshalExpressionStatement(
            String pExpressionStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ExpressionStatement(
                pExpressionStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a so called <code>forEach</code> statement stated by a string.
     * 
     * @param pForEachStatement  The <code>forEach</code> statement that should
     *                           get unmarshalled. Note that the stated string
     *                           must also contain the statement following the
     *                           <code>forEach </code> statement.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          ForEachStatement</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ForEachStatement unmarshalForEachStatement(
            String pForEachStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ForEachStatement(
                pForEachStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a formal parameter declaration list stated as string.
     * 
     * @param pFormalParameterList  The formal parameter declaration list
     *                              that should get unmarshalled. Note that this
     *                              must be a complete formal parameter list
     *                              containing 0 or more formal parameter
     *                              declarations enclosed within parentheses.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          FormalParameterList</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public FormalParameterList unmarshalFormalParameterList(
            String pFormalParameterList, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2FormalParameterList(
                pFormalParameterList, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>for</code> statement stated by a string.
     * <p>
     * This method can't be used to unmarshal a so called <code>forEach</code>
     * statement. For <code>forEach</code> statements use the
     * method {@link #unmarshalForEachStatement(String, List)}.
     * 
     * @param pForStatement  The <code>for</code> statement that should get
     *                       unmarshalled. Note that the stated string must also 
     *                       contain the statement following the <code>for
     *                       </code> statement.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>ForStatement</code>. 
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ForStatement unmarshalForStatement(
            String pForStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ForStatement(pForStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a generic type argument list stated as string.
     * <p>
     * Note that this method doesn't return an object representing a generic
     * type argument list. Instead the generic type arguments will be resolved
     * from the parsed generic type argument list and these resolved generic
     * type arguments will be returned.
     * 
     * @param pGenericTypeArgumentList  The generic type argument list that 
     *                                  should get unmarshalled. Note that this
     *                                  must be a complete generic type argument
     *                                  list including the angle brackets.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A list containing one or more <code>JSOM</code> objects of type
     *          <code>GenericTypeArgument</code> resolved from the given generic
     *          type argument list. If marshalling the code fragment has been 
     *          failed but no exception has been thrown <code>null</code> will 
     *          be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    //public List<GTA> unmarshalGenericTypeArgumentList<GTA>(
    //        String pGenericTypeArgumentList, List<String> pErrorMessages) where GTA : GenericTypeArgument
    //{
    //    return base.unmarshalAST2GenericTypeArgumentList(
    //            pGenericTypeArgumentList, pErrorMessages);
    //}

    public static IEnumerable<TBase> SafeConvert<TBase, TDerived>(IEnumerable<TDerived> source)
    where TDerived : TBase
    {
        foreach (TDerived element in source)
        {
            yield return element; // Implicit conversion to TBase
        }
    }

    public List<GenericTypeArgument> unmarshalGenericTypeArgumentList(
            String pGenericTypeArgumentList, List<String> pErrorMessages)
    {
        var tempList = base.unmarshalAST2GenericTypeArgumentList(
            pGenericTypeArgumentList, pErrorMessages);

        return (List<GenericTypeArgument>)
            SafeConvert<GenericTypeArgument, 
            com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2GenericTypeArgument>(
            tempList);
    }
    
    /**
     * Unmarshals a generic type parameter list stated as string.
     * <p>
     * Note that this method doesn't return an object representing a generic
     * type parameter list. Instead the generic type parameters will be resolved
     * from the parsed generic type parameter list and these resolved generic
     * type parameters will be returned.
     * 
     * @param pGenericTypeParameterList  The generic type parameter list that 
     *                                   should get unmarshalled. Note that this
     *                                   must be a complete generic type 
     *                                   parameter list including the angle 
     *                                   brackets.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A list containing one or more <code>JSOM</code> objects of type
     *          <code>GenericTypeParameter</code> resolved from the given 
     *          generic type parameter list. If marshalling the code fragment 
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at 
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public List<GenericTypeParameter>
    unmarshalGenericTypeParameterList(
            String pGenericTypeParameterList, List<String> pErrorMessages)
         {
        
        var tempList = base.unmarshalAST2GenericTypeParameterList(
            pGenericTypeParameterList, pErrorMessages);

        return (List<GenericTypeParameter>)
            SafeConvert<GenericTypeParameter, 
            com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2GenericTypeParameter>(
            tempList);
    }
    
    /**
     * Unmarshals an <code>if</code> statement stated by a string.
     * 
     * @param pIfStatement  The <code>if</code> statement that should get
     *                      unmarshalled. Note that the stated string must also
     *                      contain the statement following the <code>if</code>
     *                      statement.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>IfStatement</code>. 
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public IfStatement unmarshalIfStatement(
            String pIfStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2IfStatement(pIfStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals an <code>,</code> clause stated as string.
     * 
     * @param pImplementsClause  The <code>,</code> clause that should 
     *                           get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          ImplementsClause</code>. If marshalling the code fragment has 
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ImplementsClause unmarshalImplementsClause(
            String pImplementsClause, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ImplementsClause(
                pImplementsClause, pErrorMessages);
    }
    
    /**
     * Unmarshals an <code>import</code> declaration stated as string.
     * 
     * @param pImportDeclaration  The import declaratio that should get 
     *                            unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          ImportDeclaration</code>. If marshalling the code fragment has 
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ImportDeclaration unmarshalImportDeclaration(
            String pImportDeclaration, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ImportDeclaration(
                pImportDeclaration, pErrorMessages);
    }
    
    /**
     * Unmarshals an interface <code>:</code> clause stated as string.
     * 
     * @param pExtendsClause  The interface <code>:</code> clause that 
     *                        should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error 
     *                        messages will be written to <code>
     *                        System.err</code>. Ohterwise the error messages
     *                        will be added to the given list and each list 
     *                        entry will correspond to one error line as
     *                        reported by the parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          InterfaceExtendsClause</code>. If marshalling the code fragment
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course).
     * 
     * @  if marshalling the code fragment
     *                                       failed.
     */
    public InterfaceExtendsClause unmarshalInterfaceExtendsClause(
            String pExtendsClause, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2InterfaceExtendsClause(
                pExtendsClause, pErrorMessages);
    }
    
    /**
     * Unmarshals a labeled statement stated by a string.
     * 
     * @param pLabeledStatement  The labeled statement that should get 
     *                           unmarshalled. Note that the stated string must
     *                           include the colon following the label
     *                           identifier and the statement following the
     *                           colon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          LabeledStatement</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public LabeledStatement unmarshalLabeledStatement(
            String pLabeledStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2LabeledStatement(
                pLabeledStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a local class declaration stated as string.
     * 
     * @param pClassDeclaration  The local class declaration that should get 
     *                           unmarshalled.
     *                          unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          LocalClassDeclaration</code>. If marshalling the code fragment 
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course). 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public LocalClassDeclaration unmarshalLocalClassDeclarationDeclaration(
            String pClassDeclaration, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2LocalClassDeclaration(
                pClassDeclaration, pErrorMessages);
    }

    /**
     * Unmarshals a local variable declaration, with or without an initializer.
     * 
     * @param pVariableDeclaration  The local variable declaration that should
     *                              get get unmarshalled. Note that the given
     *                              string must include the terminating
     *                              semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          LocalVariableDeclaration</code>. If marshalling the code
     *          fragment has been failed but no exception has been thrown <code>
     *          null</code> will be returned and it's very likely that there's
     *          at least one message within the message list passed to this
     *          method (if a list has been passed at all, of course). 
     * 
     * @  if marshalling the code fragment
     *                                       failed.
     */
    public LocalVariableDeclaration unmarshalLocalVariableDeclaration(
            String pVariableDeclaration, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2LocalVariableDeclaration(
                pVariableDeclaration, pErrorMessages);
    }
    
    /**
     * Unmarshals a modifier list stated as string.
     * 
     * @param pModifierList  The modifier list that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>ModifierList</code>. If
     *          marshalling the code fragment has been failed but no exception
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list has been passed at all, of
     *          course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ModifierList unmarshalModifierList(
            String pModifierList, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ModifierList(pModifierList, pErrorMessages);
    }
     
    /**
     * Unmarshals a primitive stated as string.
     * 
     * @param pPrimitiveType  The primitive type that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>PrimitiveType. If 
     *          marshalling the code fragment has been failed but no exception
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list has been passed at all, of
     *          course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public PrimitiveType unmarshalPrimitiveType(
            String pPrimitiveType, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2PrimitiveType(pPrimitiveType, pErrorMessages);
    }
     
    /**
     * Unmarshals a simple qualified identifier, i.e. something that typically
     * occurs for namespace and import declarations.
     * 
     * @param pQualifiedIdentifier  The qualified identifier that should get
     *                              unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          QualifiedIdentifier</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list 
     *          as been passed at all, of course).
     * 
     * @  if marshalling the code 
     *                                       fragment failed.
     */
    public QualifiedIdentifier unmarshalQualifiedIdentifier(
            String pQualifiedIdentifier, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2QualifiedIdentifier(
                pQualifiedIdentifier, pErrorMessages);
    }

    /**
     * Unmarshals a <code>return</code> statement stated by a string.
     * 
     * @param pReturnStatement  The <code>return</code> statement that should 
     *                          get unmarshalled. Note that the stated string
     *                          must include the terminating semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>ReturnStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ReturnStatement unmarshalReturnStatement(
            String pReturnStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ReturnStatement(
                pReturnStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a statement stated as string.
     * <p>
     * Note that this doesn't include any element that may occur within a
     * compound statement block, i.e. only real statements can get unmarshalled
     * by this this method but no local variables or local class declarations.
     * 
     * @param pStatement  The statement that should get unmarshalled. Note that
     *                    the given string must include the terminating
     *                    semicolon.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>Statement</code>. If
     *          marshalling the code fragment has been failed but no exception 
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list as been passed at all, of
     *          course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public Statement unmarshalStatement(
            String pStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2Statement(pStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a compound statement block.
     * <p>
     * Note that the owner of the returned object will be <code>
     * StatementBlockScope.Owner.COMPOUND_STATEMENT</code>.
     * 
     * @param pCompoundStatement  The compound statement that should get
     *                            unmarshalled. Note that the given string must 
     *                            contain the opening and closing curly
     *                            brackets.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Ohterwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          StatementBlockScope</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code> 
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list 
     *          as been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public StatementBlockScope unmarshalStatementBlockScope(
            String pCompoundStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2StatementBlock(
                pCompoundStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals any kind of statement block elements stated as string.
     * <p>
     * Note that it's up to the caller to find out if the returned object
     * represents a local variable declaration, a local class declaration or a
     * statement (if this is of interest at all).
     * 
     * 
     * @param pStatementBlockElement  The statement block element that should 
     *                                get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          StatementBlockElement</code>. 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public StatementBlockElement unmarshalStatementBlockElement(
            String pStatementBlockElement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2StatementBlockElement(
                pStatementBlockElement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>case</code> label of a <code>switch</code> statement
     * stated by a string.
     * <p>
     * This includes the optional statement block elements that may follow the
     * <code>case</code> label.
     * 
     * @param pSwitchCaseLabel  The <code>case</code> label that should get
     *                          unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          AST2SwitchStatement.SwitchLabelImpl</code> representing a <code>
     *          case</code> label. If marshalling the code fragment has been 
     *          failed but no exception has been thrown <code>null</code> will
     *          be returned and it's very likely that there's at least one 
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public SwitchLabel unmarshalSwitchStatementCaseLabel(
            String pSwitchCaseLabel, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2SwitchStatementCaseLabel(
                pSwitchCaseLabel, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>default</code> label of a <code>switch</code>
     * statement stated by a string.
     * <p>
     * This includes the optional statement block elements that may follow the
     * <code>default</code> label.
     * 
     * @param pSwitchDefaulLabel  The <code>default</code> label that should get
     *                            unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          AST2SwitchStatement.SwitchLabelImpl</code> representing a <code>
     *          default</code> label. If marshalling the code fragment has been 
     *          failed but no exception has been thrown <code>null</code> will
     *          be returned and it's very likely that there's at least one 
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public SwitchLabel unmarshalSwitchStatementDefaultLabel(
            String pSwitchDefaulLabel, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2SwitchStatementDefaultLabel(
                pSwitchDefaulLabel, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>switch</code> statement stated by a string.
     * 
     * @param pSwitchStatement  The <code>switch</code> statement that should
     *                          get unmarshalled. Note that the stated string
     *                          must contain the complete statement including
     *                          the <code>switch</code> expression and the
     *                          <code>case</code> block following - even then if
     *                          the block should be empty.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>SwitchStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public SwitchStatement unmarshalSwitchStatement(
            String pSwitchStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2SwitchStatement(
                pSwitchStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>synchronized</code> statement stated by a string.
     * 
     * @param pSynchronizedStatement  The <code>synchronized</code>statement 
     *                                that should get unmarshalled. Note that
     *                                the stated string must contain the
     *                                complete statement including the
     *                                parenthesized elements and the statement
     *                                block to synchronize.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          SynchronizedStatement</code>. If marshalling the code fragment
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public SynchronizedStatement unmarshalSynchronizedStatement(
            String pSynchronizedStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2SynchronizedStatement(
                pSynchronizedStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>throw</code> statement stated by a string.
     * 
     * @param pThrowStatement  The <code>throw</code> statement that should get
     *                         unmarshalled. Note that the stated string must
     *                         contain the complete statement including the
     *                         closing semicolon and the expression that states
     *                         the object to throw.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>ThrowStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ThrowStatement unmarshalThrowStatement(
            String pThrowStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ThrowStatement(
                pThrowStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>throws</code> clause stated as string.
     * 
     * @param pThrowsClause  The <code>throws</code> clause that should get
     *                       unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>ThrowsClause</code>. If
     *          marshalling the code fragment has been failed but no exception
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list has been passed at all, of 
     *          course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public ThrowsClause unmarshalThrowsClause(
            String pThrowsClause, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2ThrowsClause(pThrowsClause, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>try</code> statement stated by a string.
     * 
     * @param pTryStatement  The <code>try</code> statement that should get
     *                       unmarshalled. Note that the stated string must
     *                       contain the complete statement including a <code>
     *                       catch</code> clause and/or a <code>finally</code>
     *                       clause and including the statement blocks following
     *                       the the <code>try/catch/finally</code> keywords.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>TryStatement</code>.
     *          If marshalling the code fragment has been failed but no
     *          exception has been thrown <code>null</code> will be returned and
     *          it's very likely that there's at least one message within the
     *          message list passed to this method (if a list has been passed at
     *          all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public TryStatement unmarshalTryStatement(
            String pTryStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2TryStatement(
                pTryStatement, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>catch</code> clause of a <code>try</code> statement
     * stated by a string.
     * 
     * @param pCatchClause  The <code>catch</code> clause that should get
     *                      unmarshalled. Note that the stated string must
     *                      contain the complete <code>catch</code> clause
     *                      including the statement block scope.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          Catch</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public Catch unmarshalTryStatementCatchClause(
            String pCatchClause, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2TryStatementCatchClause(
                pCatchClause, pErrorMessages);
    }
    
    /**
     * Unmarshals a primitive or complex type including static arrays stated as 
     * string.
     * 
     * @param pType  The type that should get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it 
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error 
     *                        messages will be written to <code>
     *                        System.err</code>. Otherwise the error messages
     *                        will be added to the given list and each list
     *                        entry will correspond to one error line as
     *                        reported by the parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>Type</code>. If 
     *          marshalling the code fragment has been failed but no exception
     *          has been thrown <code>null</code> will be returned and it's very
     *          likely that there's at least one message within the message list
     *          passed to this method (if a list has been passed at all, of
     *          course). 
     * 
     * @  if marshalling the code 
     *                                       fragment failed.
     */
    public Type unmarshalType(String pType, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2Type(pType, pErrorMessages);
    }

    /**
     * Unmarshals any kind of type declarations stated as string.
     * 
     * <p>
     * Note that this method shouldn't be used to create local class
     * declarations. Do do this the methods 
     * {@link #unmarshalLocalClassDeclarationDeclaration(String, List)} or even
     * {@link #unmarshalStatementBlockElement(String, List)} should be used
     * instead.
     * 
     * @param pTypeDeclaration  The type declaration that should get 
     *                          unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          CommonTypeDeclaration</code>. If marshalling the code fragment 
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course). 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public CommonTypeDeclaration unmarshalTypeDeclaration(
            String pTypeDeclaration, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2TypeDeclaration(
                pTypeDeclaration, pErrorMessages);
    }

    /**
     * 
     * Unmarshals a variable declarator identifier.
     * <p>
     * These are identifiers of type fields, local variables and formal 
     * parameters followed by 0 or more array declarators
     * 
     * @param pVariableDeclaratorIdentifier  The variable identifier that should 
     *                                       get unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          VariableDeclaratorIdentifier</code>. If marshalling the code 
     *          fragment has been failed but no exception has been thrown <code>
     *          null</code> will be returned and it's very likely that there's
     *          at least one message within the message list passed to this
     *          method (if a list has been passed at all, of course). 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public VariableDeclaratorIdentifier unmarshalVariableDeclaratorIdentifier(
            String pVariableDeclaratorIdentifier, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2VariableDeclaratorIdentifier(
                pVariableDeclaratorIdentifier, pErrorMessages);
    }

    /**
     * 
     * Unmarshals a variable initializer.
     * <p>
     * These are identifiers of type fields, local variables and formal 
     * parameters followed by 0 or more array declarators
     * 
     * @param pVariableInitializer  The variable initializer that should get 
     *                              unmarshalled.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     *                        
     * @return  A <code>JSOM</code> object of type <code>
     *          VariableInitializer</code>. If marshalling the code fragment has
     *          been failed but no exception has been thrown <code>null</code>
     *          will be returned and it's very likely that there's at least one
     *          message within the message list passed to this method (if a list
     *          has been passed at all, of course). 
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public VariableInitializer unmarshalVariableInitializer(
            String pVariableInitializer, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2VariableInitializer(
                pVariableInitializer, pErrorMessages);
    }
    
    /**
     * Unmarshals a <code>while</code> statement stated by a string.
     * 
     * @param pWhileStatement  The <code>while</code> statement that should get
     *                         unmarshalled. Note that the stated string must
     *                         also contain the statement following the <code>
     *                         while</code> statement.
     * @param pErrorMessages  If the parser reports one or more errors it
     *                        depends on this argument what will happen. If this
     *                        argument is <code>null</code> all the error
     *                        messages will be written to <code>System.err
     *                        </code>. Otherwise the error messages will be 
     *                        added to the given list and each list entry will 
     *                        correspond to one error line as reported by the
     *                        parser.
     * 
     * @return  A <code>JSOM</code> object of type <code>
     *          WhileAndDoStatements</code>. If marshalling the code fragment
     *          has been failed but no exception has been thrown <code>null
     *          </code> will be returned and it's very likely that there's at
     *          least one message within the message list passed to this method
     *          (if a list has been passed at all, of course).
     * 
     * @  if marshalling the code fragment 
     *                                       failed.
     */
    public WhileAndDoStatements unmarshalWhileStatement(
            String pWhileStatement, List<String> pErrorMessages)
         {
        
        return base.unmarshalAST2WhileStatement(
                pWhileStatement, pErrorMessages);
    }
}
}