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
using com.habelitz.jsobjectizer.jsom;
using com.habelitz.jsobjectizer.jsom.api;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using com.habelitz.jsobjectizer.jsom.api.expression;
using com.habelitz.jsobjectizer.jsom.api.statement;

namespace com.habelitz.jsobjectizer.jsom.util {
/**
 * This interface declares call back methods that must be called while 
 * traversing <code>JSOM</code> trees.
 * <p>
 * For each traversable <code>JSOM</code> type there is a pair of methods called
 * <code>performAction(...)</code> and <code>actionPerformed(...)</code>. The 
 * first method must be called as soon as a traversable <code>JSOM</code> object 
 * gets visited with the <code>JSOM</code> object itselfe as argument. Then all 
 * <code>JSOM</code> type members of the visited <code>JSOM</code> object must 
 * be travered. Finally the method <code>actionPerformed(...)</code> must be 
 * called with the same <code>JSOM</code> object as argument that has been 
 * passed to the <code>performAction</code> method.
 * 
 * @see JSOM#traverseAll(TraverseAction)
 * 
 * @author Dieter Habelitz
 */
public interface TraverseAction {
    
    /**
     * Call back method that must be called as soon as the given <code>
     * Annotation</code> object has been traversed.
     * 
     * @param pAnnotation  The <code>Annotation</code> object that has just been
     *                     traversed.
     */
    /*public*/ void actionPerformed(Annotation pAnnotation);

    /**
     * Call back method that must be called as soon as the given <code>
     * AnnotationDeclaration</code> object has been traversed.
     * 
     * @param pAnnotationDeclaration  The <code>AnnotationDeclaration</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(AnnotationDeclaration pAnnotationDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * AnnotationElementValue</code> object has been traversed.
     * 
     * @param pAnnotationElementValue  The <code>AnnotationElementValue</code> 
     *                                 object that has just been traversed.
     */
    /*public*/ void actionPerformed(AnnotationElementValue pAnnotationElementValue);

    /**
     * Call back method that must be called as soon as the given <code>
     * AnnotationInitializer</code> object has been traversed.
     * 
     * @param pAnnotationInitializer  The <code>AnnotationInitializer</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(AnnotationInitializer pAnnotationInitializer);

    /**
     * Call back method that must be called as soon as the given <code>
     * AnnotationMethodDeclaration</code> object has been traversed.
     * 
     * @param pAnnotationMethodDeclaration  The <code>
     *                                      AnnotationMethodDeclaration</code> 
     *                                      object that has just been traversed.
     */
    /*public*/ void actionPerformed(
            AnnotationMethodDeclaration pAnnotationMethodDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * AnnotationTopLevelScope</code> object has been traversed.
     * 
     * @param pAnnotationTopLevelScope  The <code>AnnotationTopLevelScope</code> 
     *                                  object that has just been traversed.
     */
    /*public*/ void actionPerformed(
            AnnotationTopLevelScope pAnnotationTopLevelScope);

    /**
     * Call back method that must be called as soon as the given <code>
     * ArrayElementAccess</code> object has been traversed.
     * 
     * @param pArrayElementAccess  The <code>ArrayElementAccess</code> object 
     *                             that has just been traversed.
     */
    /*public*/ void actionPerformed(ArrayElementAccess pArrayElementAccess);

    /**
     * Call back method that must be called as soon as the given <code>
     * ArrayTypeDeclarator</code> object has been traversed.
     * 
     * @param pArrayTypeDeclarator  The <code>ArrayTypeDeclarator</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(ArrayTypeDeclarator pArrayTypeDeclarator);

    /**
     * Call back method that must be called as soon as the given <code>
     * AssertStatement</code> object has been traversed.
     * 
     * @param pAssertStatement  The <code>AssertStatement</code> object that has 
     *                          just been traversed.
     */
    /*public*/ void actionPerformed(AssertStatement pAssertStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * BinaryOperatorExpression</code> object has been traversed.
     * 
     * @param pBinaryOperatorExpression  The <code>BinaryOperatorExpression
     *                                   </code> object that has just been 
     *                                   traversed.
     */
    /*public*/ void actionPerformed(
            BinaryOperatorExpression pBinaryOperatorExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * BreakStatement</code> object has been traversed.
     * 
     * @param pBreakStatement  The <code>BreakStatement</code> object that has 
     *                         just been traversed.
     */
    /*public*/ void actionPerformed(BreakStatement pBreakStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * ClassConstructorCall</code> object has been traversed.
     * 
     * @param pClassConstructorCall  The <code>ClassConstructorCall</code> 
     *                               object that has just been traversed.
     */
    /*public*/ void actionPerformed(ClassConstructorCall pClassConstructorCall);

    /**
     * Call back method that must be called as soon as the given <code>
     * ClassDeclaration</code> object has been traversed.
     * 
     * @param pClassDeclaration  The <code>ClassDeclaration</code> object that 
     *                           has just been traversed.
     */
    /*public*/ void actionPerformed(ClassDeclaration pClassDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * ClassExtendsClause</code> object has been traversed.
     * 
     * @param pClassExtendsClause  The <code>ClassExtendsClause</code> object 
     *                             that has just been traversed.
     */
    /*public*/ void actionPerformed(ClassExtendsClause pClassExtendsClause);

    /**
     * Call back method that must be called as soon as the given <code>
     * ClassTopLevelScope</code> object has been traversed.
     * 
     * @param pClassTopLevelScope  The <code>ClassTopLevelScope</code> object 
     *                             that has just been traversed.
     */
    /*public*/ void actionPerformed(ClassTopLevelScope pClassTopLevelScope);

    /**
     * Call back method that must be called as soon as the given <code>
     * TypeIdentifier</code> object has been traversed.
     * 
     * @param pTypeIdentifier  The <code>TypeIdentifier</code> object that has 
     *                         just been traversed.
     */
    /*public*/ void actionPerformed(ComplexTypeIdentifier pTypeIdentifier);

    /**
     * Call back method that must be called as soon as the given <code>
     * ConditionalExpression</code> object has been traversed.
     * 
     * @param pConditionalExpression  The <code>ConditionalExpression</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(ConditionalExpression pConditionalExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * ConstructorDefinition</code> object has been traversed.
     * 
     * @param pConstructorDefinition  The <code>ConstructorDefinition</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(ConstructorDefinition pConstructorDefinition);

    /**
     * Call back method that must be called as soon as the given <code>
     * ContinueStatement</code> object has been traversed.
     * 
     * @param pContinueStatement  The <code>ContinueStatement</code> object that 
     *                            has just been traversed.
     */
    /*public*/ void actionPerformed(ContinueStatement pContinueStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * DotExpression</code> object has been traversed.
     * 
     * @param pDotExpression  The <code>DotExpression</code> object that has 
     *                        just been traversed.
     */
    /*public*/ void actionPerformed(DotExpression pDotExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * EnumConstant</code> object has been traversed.
     * 
     * @param pEnumConstant  The <code>EnumConstant</code> object that has just 
     *                       been traversed.
     */
    /*public*/ void actionPerformed(EnumConstant pEnumConstant);

    /**
     * Call back method that must be called as soon as the given <code>
     * EnumDeclaration</code> object has been traversed.
     * 
     * @param pEnumDeclaration  The <code>EnumDeclaration</code> object that has
     *                          just been traversed.
     */
    /*public*/ void actionPerformed(EnumDeclaration pEnumDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * EnumTopLevelScope</code> object has been traversed.
     * 
     * @param pEnumTopLevelScope  The <code>EnumTopLevelScope</code> object that
     *                            has just been traversed.
     */
    /*public*/ void actionPerformed(EnumTopLevelScope pEnumTopLevelScope);

    /**
     * Call back method that must be called as soon as the given <code>
     * ExplicitConstructorCall</code> object has been traversed.
     * 
     * @param pExplicitConstructorCall  The <code>ExplicitConstructorCall</code>
     *                                  object that has just been traversed.
     */
    /*public*/ void actionPerformed(
            ExplicitConstructorCall pExplicitConstructorCall);

    /**
     * Call back method that must be called as soon as the given <code>
     * ExpressionStatement</code> object has been traversed.
     * 
     * @param pExpressionStatement  The <code>ExpressionStatement</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(ExpressionStatement pExpressionStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * ForEachStatement</code> object has been traversed.
     * 
     * @param pForEachStatement  The <code>ForEachStatement</code> object that 
     *                           has just been traversed.
     */
    /*public*/ void actionPerformed(ForEachStatement pForEachStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * FormalParameterDeclaration</code> object has been traversed.
     * 
     * @param pFormalParameterDeclaration  The <code>FormalParameterDeclaration
     *                                     </code> object that has just been 
     *                                     traversed.
     */
    /*public*/ void actionPerformed(
            FormalParameterDeclaration pFormalParameterDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * FormalParameterList</code> object has been traversed.
     * 
     * @param pFormalParameterList  The <code>FormalParameterList</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(FormalParameterList pFormalParameterList);

    /**
     * Call back method that must be called as soon as the given <code>
     * ForStatement</code> object has been traversed.
     * 
     * @param pForStatement  The <code>ForStatement</code> object that has just 
     *                       been traversed.
     */
    /*public*/ void actionPerformed(ForStatement pForStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * GenericTypeArgument</code> object has been traversed.
     * 
     * @param pGenericTypeArgument  The <code>GenericTypeArgument</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(GenericTypeArgument pGenericTypeArgument);

    /**
     * Call back method that must be called as soon as the given <code>
     * GenericTypeParameter</code> object has been traversed.
     * 
     * @param pGenericTypeParameter  The <code>GenericTypeParameter</code> 
     *                               object that has just been traversed.
     */
    /*public*/ void actionPerformed(GenericTypeParameter pGenericTypeParameter);
    
    /**
     * Call back method that must be called as soon as the given <code>
     * Identifier</code> object has been traversed.
     * 
     * @param pIdentifier  The <code>Identifier</code> object that has just been
     *                     traversed.
     */
    /*public*/ void actionPerformed(Identifier pIdentifier);

    /**
     * Call back method that must be called as soon as the given <code>
     * IfStatement</code> object has been traversed.
     * 
     * @param pIfStatement  The <code>IfStatement</code> object that has just 
     *                      been traversed.
     */
    /*public*/ void actionPerformed(IfStatement pIfStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * ImplementsClause</code> object has been traversed.
     * 
     * @param pImplementsClause  The <code>ImplementsClause</code> object that 
     *                           has just been traversed.
     */
    /*public*/ void actionPerformed(ImplementsClause pImplementsClause);

    /**
     * Call back method that must be called as soon as the given <code>
     * ImportDeclaration</code> object has been traversed.
     * 
     * @param pImportDeclaration  The <code>ImportDeclaration</code> object that
     * has just been traversed.
     */
    /*public*/ void actionPerformed(ImportDeclaration pImportDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * InstanceofExpression</code> object has been traversed.
     * 
     * @param pInstanceofExpression  The <code>InstanceofExpression</code> 
     *                               object that has just been traversed.
     */
    /*public*/ void actionPerformed(InstanceofExpression pInstanceofExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * InterfaceDeclaration</code> object has been traversed.
     * 
     * @param pInterfaceDeclaration  The <code>InterfaceDeclaration</code> 
     *                               object that has just been traversed.
     */
    /*public*/ void actionPerformed(InterfaceDeclaration pInterfaceDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * InterfaceExtendsClause</code> object has been traversed.
     * 
     * @param pInterfaceExtendsClause  The <code>InterfaceExtendsClause</code> 
     *                                 object that has just been traversed.
     */
    /*public*/ void actionPerformed(InterfaceExtendsClause pInterfaceExtendsClause);

    /**
     * Call back method that must be called as soon as the given <code>
     * InterfaceTopLevelScope</code> object has been traversed.
     * 
     * @param pInterfaceTopLevelScope  The <code>InterfaceTopLevelScope</code> 
     *                                 object that has just been traversed.
     */
    /*public*/ void actionPerformed(InterfaceTopLevelScope pInterfaceTopLevelScope);

    /**
     * Call back method that must be called as soon as the given <code>
     * JavaSource</code> object has been traversed.
     * 
     * @param pJavaSource  The <code>JavaSource</code> object that has just been
     *                     traversed.
     */
    /*public*/ void actionPerformed(JavaSource pJavaSource);

    /**
     * Call back method that must be called as soon as the given <code>
     * LabeledStatement</code> object has been traversed.
     * 
     * @param pLabeledStatement  The <code>LabeledStatement</code> object that 
     *                           has just been traversed.
     */
    /*public*/ void actionPerformed(LabeledStatement pLabeledStatement);

    /**
     * Call back method that must be called as soon as the given <code>Literal
     * </code> object has been traversed.
     * 
     * @param pLiteral  The <code>Literal</code> object that has just been 
     *                  traversed.
     */
    /*public*/ void actionPerformed(Literal pLiteral);

    /**
     * Call back method that must be called as soon as the given <code>
     * LocalClassDeclaration</code> object has been traversed.
     * 
     * @param pLocalClassDeclaration  The <code>LocalClassDeclaration</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(LocalClassDeclaration pLocalClassDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * LocalVariableDeclaration</code> object has been traversed.
     * 
     * @param pLocalVariableDeclaration  The <code>LocalVariableDeclaration
     *                                   </code> object that has just been 
     *                                   traversed.
     */
    /*public*/ void actionPerformed(
            LocalVariableDeclaration pLocalVariableDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * MethodCall</code> object has been traversed.
     * 
     * @param pMethodCall  The <code>MethodCall</code> object that has just been
     *                     traversed.
     */
    /*public*/ void actionPerformed(MethodCall pMethodCall);

    /**
     * Call back method that must be called as soon as the given <code>
     * MethodDeclaration</code> object has been traversed.
     * 
     * @param pMethodDeclaration  The <code>MethodDeclaration</code> object that 
     *                            has just been traversed.
     */
    /*public*/ void actionPerformed(MethodDeclaration pMethodDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * MethodDefinition</code> object has been traversed.
     * 
     * @param pMethodDefinition  The <code>MethodDefinition</code> object that 
     *                           has just been traversed.
     */
    /*public*/ void actionPerformed(MethodDefinition pMethodDefinition);

    /**
     * Call back method that must be called as soon as the given <code>
     * ModifierList</code> object has been traversed.
     * 
     * @param pModifierList  The <code>ModifierList</code> object that has just 
     *                       been traversed.
     */
    /*public*/ void actionPerformed(ModifierList pModifierList);


    /**
     * Call back method that must be called as soon as the given <code>
     * ParenthesizedExpression</code> object has been traversed.
     * 
     * @param pParenthesizedExpression  The <code>ParenthesizedExpression</code> 
     *                                  object that has just been traversed.
     */
    /*public*/ void actionPerformed(PackageDeclaration pParenthesizedExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * ParenthesizedExpression</code> object has been traversed.
     * 
     * @param pParenthesizedExpression  The <code>ParenthesizedExpression</code> 
     *                                  object that has just been traversed.
     */
    /*public*/ void actionPerformed(
            ParenthesizedExpression pParenthesizedExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * PrimaryExpressionKeyword</code> object has been traversed.
     * 
     * @param pPrimaryExpressionKeyword  The <code>PrimaryExpressionKeyword
     *                                   </code> object that has just been 
     *                                   traversed.
     */
    /*public*/ void actionPerformed(
            PrimaryExpressionKeyword pPrimaryExpressionKeyword);

    /**
     * Call back method that must be called as soon as the given <code>
     * PrimitiveType</code> object has been traversed.
     * 
     * @param pPrimitiveType  The <code>PrimitiveType</code> object that has 
     *                        just been traversed.
     */
    /*public*/ void actionPerformed(PrimitiveType pPrimitiveType);

    /**
     * Call back method that must be called as soon as the given <code>
     * QualifiedIdentifier</code> object has been traversed.
     * 
     * @param pQualifiedIdentifier  The <code>QualifiedIdentifier</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(QualifiedIdentifier pQualifiedIdentifier);

    /**
     * Call back method that must be called as soon as the given <code>
     * ReturnStatement</code> object has been traversed.
     * 
     * @param pReturnStatement  The <code>ReturnStatement</code> object that has
     *                          just been traversed.
     */
    /*public*/ void actionPerformed(ReturnStatement pReturnStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * StatementBlockScope</code> object has been traversed.
     * 
     * @param pStatementBlockScope  The <code>StatementBlockScope</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(StatementBlockScope pStatementBlockScope);

    /**
     * Call back method that must be called as soon as the given <code>
     * StaticArrayCreator</code> object has been traversed.
     * 
     * @param pStaticArrayCreator  The <code>StaticArrayCreator</code> object 
     *                             that has just been traversed.
     */
    /*public*/ void actionPerformed(StaticArrayCreator pStaticArrayCreator);

    /**
     * Call back method that must be called as soon as the given <code>
     * SwitchStatement</code> object has been traversed.
     * 
     * @param pSwitchStatement  The <code>SwitchStatement</code> object that has 
     *                          just been traversed.
     */
    /*public*/ void actionPerformed(SwitchStatement pSwitchStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * SwitchLabel</code> object has been traversed.
     * 
     * @param pSwitchLabel  The <code>SwitchLabel</code> object 
     *                      that has just been traversed.
     */
    /*public*/ void actionPerformed(SwitchLabel pSwitchLabel);

    /**
     * Call back method that must be called as soon as the given <code>
     * SynchronizedStatement</code> object has been traversed.
     * 
     * @param pSynchronizedStatement  The <code>SynchronizedStatement</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(SynchronizedStatement pSynchronizedStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * ThrowsClause</code> object has been traversed.
     * 
     * @param pThrowsClause  The <code>ThrowsClause</code> object that has just 
     *                       been traversed.
     */
    /*public*/ void actionPerformed(ThrowsClause pThrowsClause);

    /**
     * Call back method that must be called as soon as the given <code>
     * ThrowStatement</code> object has been traversed.
     * 
     * @param pThrowStatement  The <code>ThrowStatement</code> object that has 
     *                         just been traversed.
     */
    /*public*/ void actionPerformed(ThrowStatement pThrowStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * TryStatement</code> object has been traversed.
     * 
     * @param pTryStatement  The <code>TryStatement</code> object that has just
     *                       been traversed.
     */
    /*public*/ void actionPerformed(TryStatement pTryStatement);

    /**
     * Call back method that must be called as soon as the given <code>
     * Catch</code> object has been traversed.
     * 
     * @param pCatchClause  The <code>Catch</code> object that has 
     *                      just been traversed.
     */
    /*public*/ void actionPerformed(Catch pCatchClause);

    /**
     * Call back method that must be called as soon as the given <code>Type
     * </code> object has been traversed.
     * 
     * @param pType  The <code>Type</code> object that has just been traversed.
     */
    /*public*/ void actionPerformed(Type pType);

    /**
     * Call back method that must be called as soon as the given <code>TypeCast
     * </code> object has been traversed.
     * 
     * @param pTypeCast  The <code>TypeCast</code> object that has just been 
     *                   traversed.
     */
    /*public*/ void actionPerformed(TypeCast pTypeCast);

    /**
     * Call back method that must be called as soon as the given <code>
     * TypeMemberDeclaration</code> object has been traversed.
     * 
     * @param pTypeMemberDeclaration  The <code>TypeMemberDeclaration</code> 
     *                                object that has just been traversed.
     */
    /*public*/ void actionPerformed(TypeMemberDeclaration pTypeMemberDeclaration);

    /**
     * Call back method that must be called as soon as the given <code>
     * UnaryOperatorExpression</code> object has been traversed.
     * 
     * @param pUnaryOperatorExpression  The <code>UnaryOperatorExpression</code> 
     *                                  object that has just been traversed.
     */
    /*public*/ void actionPerformed(
            UnaryOperatorExpression pUnaryOperatorExpression);

    /**
     * Call back method that must be called as soon as the given <code>
     * VariableDeclarator</code> object has been traversed.
     * 
     * @param pVariableDeclarator  The <code>VariableDeclarator</code> object 
     *                             that has just been traversed.
     */
    /*public*/ void actionPerformed(VariableDeclarator pVariableDeclarator);

    /**
     * Call back method that must be called as soon as the given <code>
     * VariableDeclaratorIdentifier</code> object has been traversed.
     * 
     * @param pVariableDeclaratorIdentifier  The <code>
     *                                       VariableDeclaratorIdentifier</code> 
     *                                       object that has just been 
     *                                       traversed.
     */
    /*public*/ void actionPerformed(
            VariableDeclaratorIdentifier pVariableDeclaratorIdentifier);

    /**
     * Call back method that must be called as soon as the given <code>
     * VariableInitializer</code> object has been traversed.
     * 
     * @param pVariableInitializer  The <code>VariableInitializer</code> object 
     *                              that has just been traversed.
     */
    /*public*/ void actionPerformed(VariableInitializer pVariableInitializer);

    /**
     * Call back method that must be called as soon as the given <code>
     * WhileAndDoStatements</code> object has been traversed.
     * 
     * @param pWhileAndDoStatements  The <code>WhileAndDoStatements</code> 
     *                               object that has just been traversed.
     */
    /*public*/ void actionPerformed(WhileAndDoStatements pWhileAndDoStatements);

    /**
     * If an <code>if</code> statement has an <code>else</code> clause this call 
     * back method must be called as soon as the statement following the <code>
     * else</code> clause has been traversed.
     *  
     * @param pIfStatement  The <code>if</code> statement the <code>else</code>
     *                      clause belongs to.
     */
    /*public*/ void actionPerformedForElseClause(IfStatement pIfStatement);
    
    /**
     * Tells if the members of a <code>JSOM</code> type that is being traversed
     * should get traversed, too.
     *  
     * @return  <code>true</code> if the members of a <code>JSOM</code> type 
     *          that is being traversed should get traversed, too. Note that the 
     *          default value is <code>true</code> for the case that this state
     *          hasn't been changes explicitly by calling 
     *          {@link #setMemberTraversingEnabledState(bool)}.
     */
    /*public*/ bool isMemberTraversingEnabled();
    
    /**
     * Call back method that must be called when the given <code>Annotation
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pAnnotation  The <code>Annotation</code> object that will become 
     *                     the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(Annotation pAnnotation);

    /**
     * Call back method that must be called when the given <code>
     * AnnotationDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pAnnotationDeclaration  The <code>AnnotationDeclaration</code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(AnnotationDeclaration pAnnotationDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * AnnotationElementValue</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pAnnotationElementValue  The <code>AnnotationElementValue</code> 
     *                                 object that will become the next <i>
     *                                 traverse candidate</i>.
     */
    /*public*/ void performAction(AnnotationElementValue pAnnotationElementValue);

    /**
     * Call back method that must be called when the given <code>
     * AnnotationInitializer</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pAnnotationInitializer  The <code>AnnotationInitializer</code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(AnnotationInitializer pAnnotationInitializer);

    /**
     * Call back method that must be called when the given <code>
     * AnnotationMethodDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pAnnotationMethodDeclaration  The <code>
     *                                      AnnotationMethodDeclaration</code> 
     *                                      object that will become the next <i>
     *                                      traverse candidate</i>.
     */
    /*public*/ void performAction(
            AnnotationMethodDeclaration pAnnotationMethodDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * AnnotationTopLevelScope</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pAnnotationTopLevelScope  The <code>AnnotationTopLevelScope</code> 
     *                                  object that will become the next <i>
     *                                  traverse candidate</i>.
     */
    /*public*/ void performAction(AnnotationTopLevelScope pAnnotationTopLevelScope);

    /**
     * Call back method that must be called when the given <code>
     * ArrayElementAccess</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pArrayElementAccess  The <code>ArrayElementAccess</code> object 
     *                             that will become the next <i>traverse 
     *                             candidate</i>.
     */
    /*public*/ void performAction(ArrayElementAccess pArrayElementAccess);

    /**
     * Call back method that must be called when the given <code>
     * ArrayTypeDeclarator</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pArrayTypeDeclarator  The <code>ArrayTypeDeclarator</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(ArrayTypeDeclarator pArrayTypeDeclarator);

    /**
     * Call back method that must be called when the given <code>AssertStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pAssertStatement  The <code>AssertStatement</code> object that 
     *                          will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(AssertStatement pAssertStatement);

    /**
     * Call back method that must be called when the given <code>
     * BinaryOperatorExpression</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pBinaryOperatorExpression  The <code>BinaryOperatorExpression
     *                                   </code> object that will become the 
     *                                   next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(
            BinaryOperatorExpression pBinaryOperatorExpression);

    /**
     * Call back method that must be called when the given <code>BreakStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pBreakStatement  The <code>BreakStatement</code> object that will 
     *                         become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(BreakStatement pBreakStatement);

    /**
     * Call back method that must be called when the given <code>
     * ClassConstructorCall</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pClassConstructorCall  The <code>ClassConstructorCall</code> 
     *                               object that will become the next <i>
     *                               traverse candidate</i>.
     */
    /*public*/ void performAction(ClassConstructorCall pClassConstructorCall);

    /**
     * Call back method that must be called when the given <code>
     * ClassDeclaration</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pClassDeclaration  The <code>ClassDeclaration</code> object that 
     *                           will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ClassDeclaration pClassDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * ClassExtendsClause</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pClassExtendsClause  The <code>ClassExtendsClause</code> object 
     *                             that will become the next <i>traverse 
     *                             candidate</i>.
     */
    /*public*/ void performAction(ClassExtendsClause pClassExtendsClause);

    /**
     * Call back method that must be called when the given <code>
     * ClassTopLevelScope</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pClassTopLevelScope  The <code>ClassTopLevelScope</code> object 
     *                             that will become the next <i>traverse 
     *                             candidate</i>.
     */
    /*public*/ void performAction(ClassTopLevelScope pClassTopLevelScope);

    /**
     * Call back method that must be called when the given <code>TypeIdentifier
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pTypeIdentifier  The <code>TypeIdentifier</code> object that will 
     *                         become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ComplexTypeIdentifier pTypeIdentifier);

    /**
     * Call back method that must be called when the given <code>
     * ConditionalExpression</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pConditionalExpression  The <code>ConditionalExpression</code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(ConditionalExpression pConditionalExpression);

    /**
     * Call back method that must be called when the given <code>
     * ConstructorDefinition</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pConstructorDefinition  The <code>ConstructorDefinition<code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(ConstructorDefinition pConstructorDefinition);

    /**
     * Call back method that must be called when the given <code>
     * ContinueStatement</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pContinueStatement  The <code>ContinueStatement</code> object that 
     *                            will become the next <i>traverse 
     *                            candidate</i>.
     */
    /*public*/ void performAction(ContinueStatement pContinueStatement);

    /**
     * Call back method that must be called when the given <code>DotExpression
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pDotExpression  The <code>DotExpression</code> object that will 
     *                        become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(DotExpression pDotExpression);

    /**
     * Call back method that must be called when the given <code>EnumConstant
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pEnumConstant  The <code>EnumConstant</code> object that will 
     *                       become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(EnumConstant pEnumConstant);

    /**
     * Call back method that must be called when the given <code>EnumDeclaration
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pEnumDeclaration  The <code>EnumDeclaration</code> object that will
     *                          become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(EnumDeclaration pEnumDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * EnumTopLevelScope</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pEnumTopLevelScope  The <code>EnumTopLevelScope</code> object that 
     *                            will become the next <i>traverse 
     *                            candidate</i>.
     */
    /*public*/ void performAction(EnumTopLevelScope pEnumTopLevelScope);

    /**
     * Call back method that must be called when the given <code>
     * ExplicitConstructorCall</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pExplicitConstructorCall  The <code>ExplicitConstructorCall</code> 
     *                                  object that will become the next <i>
     *                                  traverse candidate</i>.
     */
    /*public*/ void performAction(ExplicitConstructorCall pExplicitConstructorCall);

    /**
     * Call back method that must be called when the given <code>
     * ExpressionStatement</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pExpressionStatement  The <code>ExpressionStatement</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(ExpressionStatement pExpressionStatement);

    /**
     * Call back method that must be called when the given <code>
     * ForEachStatement</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pForEachStatement  The <code>ForEachStatement</code> object that 
     *                           will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ForEachStatement pForEachStatement);

    /**
     * Call back method that must be called when the given <code>
     * FormalParameterDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pFormalParameterDeclaration  The <code>FormalParameterDeclaration
     *                                     </code> object that will become the 
     *                                     next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(
            FormalParameterDeclaration pFormalParameterDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * FormalParameterList</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pFormalParameterList  The <code>FormalParameterList</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(FormalParameterList pFormalParameterList);

    /**
     * Call back method that must be called when the given <code>ForStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pForStatement  The <code>ForStatement</code> object that will 
     *                       become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ForStatement pForStatement);

    /**
     * Call back method that must be called when the given <code>
     * GenericTypeArgument</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pGenericTypeArgument  The <code>GenericTypeArgument</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(GenericTypeArgument pGenericTypeArgument);

    /**
     * Call back method that must be called when the given <code>
     * GenericTypeParameter</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pGenericTypeParameter  The <code>GenericTypeParameter</code> 
     *                               object that will become the next <i>
     *                               traverse candidate</i>.
     */
    /*public*/ void performAction(GenericTypeParameter pGenericTypeParameter);

    /**
     * Call back method that must be called when the given <code>Identifier
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pIdentifier  The <code>Identifier</code> object that will become 
     *                     the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(Identifier pIdentifier);

    /**
     * Call back method that must be called when the given <code>IfStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @see  #performActionForElseClause(IfStatement)
     * 
     * @param pIfStatement  The <code>IfStatement</code> object that will become
     *                      the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(IfStatement pIfStatement);

    /**
     * Call back method that must be called when the given <code>
     * ImplementsClause</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pImplementsClause  The <code>ImplementsClause</code> object that 
     *                           will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ImplementsClause pImplementsClause);

    /**
     * Call back method that must be called when the given <code>
     * ImportDeclaration</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pImportDeclaration  The <code>ImportDeclaration</code> object that 
     *                            will become the next <i>traverse 
     *                            candidate</i>.
     */
    /*public*/ void performAction(ImportDeclaration pImportDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * InstanceofExpression</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pInstanceofExpression  The <code>InstanceofExpression</code> object 
     *                               that will become the next <i>traverse 
     *                               candidate</i>.
     */
    /*public*/ void performAction(InstanceofExpression pInstanceofExpression);

    /**
     * Call back method that must be called when the given <code>
     * InterfaceDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pInterfaceDeclaration  The <code>InterfaceDeclaration</code> 
     *                               object that will become the next <i>
     *                               traverse candidate</i>.
     */
    /*public*/ void performAction(InterfaceDeclaration pInterfaceDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * InterfaceExtendsClause</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pInterfaceExtendsClause  The <code>InterfaceExtendsClause</code> 
     *                                 object that will become the next <i>
     *                                 traverse candidate</i>.
     */
    /*public*/ void performAction(InterfaceExtendsClause pInterfaceExtendsClause);

    /**
     * Call back method that must be called when the given <code>
     * InterfaceTopLevelScope</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pInterfaceTopLevelScope  The <code>InterfaceTopLevelScope</code> 
     *                                 object that will become the next <i>
     *                                 traverse candidate</i>.
     */
    /*public*/ void performAction(InterfaceTopLevelScope pInterfaceTopLevelScope);

    /**
     * Call back method that must be called when the given <code>JavaSource
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pJavaSource  The <code>JavaSource</code> object that will become 
     *                     the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(JavaSource pJavaSource);

    /**
     * Call back method that must be called when the given <code>
     * LabeledStatement</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pLabeledStatement  The <code>LabeledStatement</code> object that 
     *                           will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(LabeledStatement pLabeledStatement);

    /**
     * Call back method that must be called when the given <code>Literal</code> 
     * will become the next <i>traverse candidate</i>.
     * 
     * @param pLiteral  The <code>Literal</code> object that will become the 
     *                  next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(Literal pLiteral);

    /**
     * Call back method that must be called when the given <code>
     * LocalClassDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pLocalClassDeclaration  The <code>LocalClassDeclaration</code> 
     *                                object that will become the next<i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(LocalClassDeclaration pLocalClassDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * LocalVariableDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pLocalVariableDeclaration  The <code>LocalVariableDeclaration
     *                                   </code> object that will become the 
     *                                   next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(
            LocalVariableDeclaration pLocalVariableDeclaration);

    /**
     * Call back method that must be called when the given <code>MethodCall
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pMethodCall  The <code>MethodCall</code> object that will become 
     *                     the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(MethodCall pMethodCall);

    /**
     * Call back method that must be called when the given <code>
     * MethodDeclaration</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pMethodDeclaration  The <code>MethodDeclaration</code> object that 
     *                            will become the next <i>traverse 
     *                            candidate</i>.
     */
    /*public*/ void performAction(MethodDeclaration pMethodDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * MethodDefinition</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pMethodDefinition  The <code>MethodDefinition</code> object that 
     *                           will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(MethodDefinition pMethodDefinition);

    /**
     * Call back method that must be called when the given <code>ModifierList
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pModifierList  The <code>ModifierList</code> object that will 
     *                       become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ModifierList pModifierList);



    /*public*/
    void performAction(PackageDeclaration pPackageDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * ParenthesizedExpression</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pParenthesizedExpression  The <code>ParenthesizedExpression</code> 
     *                                  object that will become the next <i>
     *                                  traverse candidate</i>.
     */
    /*public*/ void performAction(ParenthesizedExpression pParenthesizedExpression);

    /**
     * Call back method that must be called when the given <code>
     * PrimaryExpressionKeyword</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pPrimaryExpressionKeyword  The <code>PrimaryExpressionKeyword
     *                                   <code> object that will become the next 
     *                                   <i>traverse candidate</i>.
     */
    /*public*/ void performAction(
            PrimaryExpressionKeyword pPrimaryExpressionKeyword);

    /**
     * Call back method that must be called when the given <code>PrimitiveType
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pPrimitiveType  The <code>PrimitiveType</code> object that will 
     *                        become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(PrimitiveType pPrimitiveType);

    /**
     * Call back method that must be called when the given <code>
     * QualifiedIdentifier</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pQualifiedIdentifier  The <code>QualifiedIdentifier</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(QualifiedIdentifier pQualifiedIdentifier);

    /**
     * Call back method that must be called when the given <code>ReturnStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pReturnStatement  The <code>ReturnStatement</code> object that 
     *                          will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ReturnStatement pReturnStatement);

    /**
     * Call back method that must be called when the given <code>
     * StatementBlockScope</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pStatementBlockScope  The <code>StatementBlockScope</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(StatementBlockScope pStatementBlockScope);

    /**
     * Call back method that must be called when the given <code>
     * StaticArrayCreator</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pStaticArrayCreator  The <code>StaticArrayCreator</code> object 
     *                             that will become the next <i>traverse 
     *                             candidate</i>.
     */
    /*public*/ void performAction(StaticArrayCreator pStaticArrayCreator);

    /**
     * Call back method that must be called when the given <code>
     * SwitchStatement</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pSwitchStatement  The <code>SwitchStatement</code> object that 
     *                          will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(SwitchStatement pSwitchStatement);

    /**
     * Call back method that must be called when the given <code>
     * SwitchLabel</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pSwitchLabel  The <code>SwitchLabel</code> object
     *                      that will become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(SwitchLabel pSwitchLabel);

    /**
     * Call back method that must be called when the given <code>
     * SynchronizedStatement</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pSynchronizedStatement  The <code>SynchronizedStatement</code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(SynchronizedStatement pSynchronizedStatement);

    /**
     * Call back method that must be called when the given <code>ThrowsClause
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pThrowsClause  The <code>ThrowsClause</code> object that will 
     *                       become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ThrowsClause pThrowsClause);

    /**
     * Call back method that must be called when the given <code>ThrowStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pThrowStatement  The <code>ThrowStatement</code> object that will 
     *                         become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(ThrowStatement pThrowStatement);

    /**
     * Call back method that must be called when the given <code>TryStatement
     * </code> will become the next <i>traverse candidate</i>.
     * 
     * @param pTryStatement  The <code>TryStatement</code> object that will 
     *                       become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(TryStatement pTryStatement);

    /**
     * Call back method that must be called when the given <code>
     * Catch</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pCatchClause  The <code>Catch</code> object that will 
     *                      become the next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(Catch pCatchClause);

    /**
     * Call back method that must be called when the given <code>Type</code> 
     * will become the next <i>traverse candidate</i>.
     * 
     * @param pType  The <code>Type</code> object that will become the next <i>
     *               traverse candidate</i>.
     */
    /*public*/ void performAction(Type pType);

    /**
     * Call back method that must be called when the given <code>TypeCast</code> 
     * will become the next <i>traverse candidate</i>.
     * 
     * @param pTypeCast  The <code>TypeCast</code> object that will become the 
     *                   next <i>traverse candidate</i>.
     */
    /*public*/ void performAction(TypeCast pTypeCast);

    /**
     * Call back method that must be called when the given <code>
     * TypeMemberDeclaration</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pTypeMemberDeclaration  The <code>TypeMemberDeclaration</code> 
     *                                object that will become the next <i>
     *                                traverse candidate</i>.
     */
    /*public*/ void performAction(TypeMemberDeclaration pTypeMemberDeclaration);

    /**
     * Call back method that must be called when the given <code>
     * UnaryOperatorExpression</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pUnaryOperatorExpression  The <code>UnaryOperatorExpression</code> 
     *                                  object that will become the next <i>
     *                                  traverse candidate</i>.
     */
    /*public*/ void performAction(UnaryOperatorExpression pUnaryOperatorExpression);

    /**
     * Call back method that must be called when the given <code>
     * VariableDeclarator</code> will become the next <i>traverse candidate</i>.
     * 
     * @param pVariableDeclarator  The <code>VariableDeclarator</code> object 
     *                             that will become the next <i>traverse 
     *                             candidate</i>.
     */
    /*public*/ void performAction(VariableDeclarator pVariableDeclarator);

    /**
     * Call back method that must be called when the given <code>
     * VariableDeclaratorIdentifier</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pVariableDeclaratorIdentifier  The <code>
     *                                       VariableDeclaratorIdentifier</code> 
     *                                       object that will become the next 
     *                                       <i>traverse candidate</i>.
     */
    /*public*/ void performAction(
            VariableDeclaratorIdentifier pVariableDeclaratorIdentifier);

    /**
     * Call back method that must be called when the given <code>
     * VariableInitializer</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pVariableInitializer  The <code>VariableInitializer</code> object 
     *                              that will become the next <i>traverse 
     *                              candidate</i>.
     */
    /*public*/ void performAction(VariableInitializer pVariableInitializer);

    /**
     * Call back method that must be called when the given <code>
     * WhileAndDoStatements</code> will become the next <i>traverse 
     * candidate</i>.
     * 
     * @param pWhileAndDoStatements  The <code>WhileAndDoStatements</code> 
     *                               object that will become the next <i>
     *                               traverse candidate</i>.
     */
    /*public*/ void performAction(WhileAndDoStatements pWhileAndDoStatements);

    /**
     * If an <code>if</code> statement has an <code>else</code> clause this call 
     * back method must be called just before the statement following the <code>
     * else</code> clause gets traversed.
     *  
     * @param pIfStatement  The <code>if</code> statement the <code>else</code>
     *                      clause belongs to.
     */
    /*public*/ void performActionForElseClause(IfStatement pIfStatement);

    /**
     * Sets the new state of whether the members of a currently traversed <code>
     * JSOM</code> type should get traversed, too. 
     * 
     * @param pNewState  <code>true</code> if the members of a currently 
     *                   traversed <code>JSOM</code> type should get traversed, 
     *                   too.
     */
    /*public*/ void setMemberTraversingEnabledState(bool pNewState);
}
}