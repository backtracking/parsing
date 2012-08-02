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
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
// VRI
using com.habelitz.jsobjectizer.jsom.util;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>AST2JSOM</code> type is the base type for all kinds of expressions.
 * 
 * @author Dieter Habelitz
 */
public abstract class AST2Expression : AST2JSOM, Expression {

    // The expression type represented by 'this'.
    private ExpressionType mExpressionType;
    
    /**
     * Constructor.
     * 
     * @param pTree  The root or start node of the expression.
     * @param pExpressionType  One of the constants defined by <code>
     *                         ExpressionType</code>.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.
     *                             
     * @throws ArgumentException  if the given tree doesn't represent or
     *                                   represents an unsupported expression
     *                                   type.                                         
     */
    protected AST2Expression(
            AST2JSOMTree pTree, ExpressionType pExpressionType,
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.EXPRESSION, pTokenRewriteStream)
    {
        
        mExpressionType = pExpressionType;
    }
    
     /**
     * Resolves all kinds of expressions.
     * 
     * @param pTree  The expression's root or start node.
     * 
     * @return  The resolved expression.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public static AST2Expression resolveExpression(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {

        AST2JSOMTree tree = pTree;
        if (tree.Type == JavaTreeParser.EXPR) {
            tree = (AST2JSOMTree)tree.GetChild(0);
        }
        
        // At first resolve the primary expressions.
        AST2Expression expression = 
            resolvePrimaryExpression(tree, false, pTokenRewriteStream);
        if (expression != null) {
            return expression;
        }
        
        // It seems to be a non primary expression.
        
        // Next try: binary operator expression.
        expression = AST2BinaryOperatorExpression.createNewInstance(
                tree, pTokenRewriteStream);
        if (expression != null) {
            return expression;
        }
        // Next try: unary operator expression.
        expression = AST2UnaryOperatorExpression.createNewInstance(
                tree, pTokenRewriteStream);
        if (expression != null) {
            return expression;
        }
        // If still here try the rest of supported expression types.
        switch (tree.Type) {
        case JavaTreeParser.UNARY_PLUS:
        case JavaTreeParser.INSTANCEOF: 
            return new AST2InstanceofExpression(tree, pTokenRewriteStream);
        case JavaTreeParser.CAST_EXPR: 
            return new AST2TypeCast(tree, pTokenRewriteStream);
        case JavaTreeParser.QUESTION:
            return new AST2ConditionalExpression(tree, pTokenRewriteStream);
        default:
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Resolves primary expressions only.
     * 
     * @param pTree  The primary expression's root or start node.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     * 
     * @return  The resolved primary.
     */
    public static AST2PrimaryExpression resolvePrimaryExpression(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {
        
        return resolvePrimaryExpression(pTree, true, pTokenRewriteStream);
    }

     /**
     * Resolves primary expressions only.
     * 
     * @param pTree  The primary expression's root or start node.
     * @param pThrowExceptionIfNotResolvable
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     * 
     * @return  The resolved primary.
     */
    private static AST2PrimaryExpression resolvePrimaryExpression(
            AST2JSOMTree pTree, bool pThrowExceptionIfNotResolvable,
            TokenRewriteStream pTokenRewriteStream) {
        
        switch (pTree.Type) {
        case JavaTreeParser.DOT:
            return new AST2DotExpression(pTree, pTokenRewriteStream);
        case JavaTreeParser.PARENTESIZED_EXPR:
            return new AST2ParenthesizedExpression(pTree, pTokenRewriteStream);
        case JavaTreeParser.IDENT:
            return new AST2Identifier(pTree, pTokenRewriteStream);
        case JavaTreeParser.METHOD_CALL:
            return new AST2MethodCall(pTree, pTokenRewriteStream);
        case JavaTreeParser.THIS_CONSTRUCTOR_CALL:
        case JavaTreeParser.SUPER_CONSTRUCTOR_CALL:
            return new AST2ExplicitConstructorCall(pTree, pTokenRewriteStream);
        case JavaTreeParser.ARRAY_ELEMENT_ACCESS:
            return new AST2ArrayElementAccess(pTree, pTokenRewriteStream);
        case JavaTreeParser.HEX_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.HEX_NUMBER, pTokenRewriteStream);
        case JavaTreeParser.OCTAL_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.OCTAL_NUMBER, 
                    pTokenRewriteStream);
        case JavaTreeParser.DECIMAL_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.DECIMAL_NUMBER, 
                    pTokenRewriteStream);
        case JavaTreeParser.FLOATING_POINT_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.FLOATING_POINT_NUMBER, 
                    pTokenRewriteStream);
        case JavaTreeParser.CHARACTER_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.CHARACTER, pTokenRewriteStream);
        case JavaTreeParser.STRING_LITERAL:
            return new AST2Literal(
                    pTree, LiteralType.STRING, pTokenRewriteStream);
        case JavaTreeParser.TRUE:
            return new AST2Literal(
                    pTree, LiteralType.TRUE, pTokenRewriteStream);
        case JavaTreeParser.FALSE:
            return new AST2Literal(
                    pTree, LiteralType.FALSE, pTokenRewriteStream);
        case JavaTreeParser.NULL:
            return new AST2Literal(
                    pTree, LiteralType.NULL, pTokenRewriteStream);
        case JavaTreeParser.STATIC_ARRAY_CREATOR:
            return new AST2StaticArrayCreator(pTree, pTokenRewriteStream);
        case JavaTreeParser.CLASS_CONSTRUCTOR_CALL:
            return new AST2ClassConstructorCall(pTree, pTokenRewriteStream);
        case JavaTreeParser.THIS:
        case JavaTreeParser.SUPER:
            return new AST2PrimaryExpressionKeyword(pTree, pTokenRewriteStream);
        case JavaTreeParser.ARRAY_DECLARATOR:
            return new AST2ArrayTypeDeclarator(pTree, pTokenRewriteStream);
        default:
            if (pThrowExceptionIfNotResolvable) {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, 
                                "pTree"));
            }
            break;
        }
        
        return null; // Should never happen.
    }


    /**
     * Returns the <code>ExpressionType</code> represented by <code>this</code>.
     * 
     * @return The <code>ExpressionType</code> represented by <code>this</code>.
     */
    public ExpressionType getExpressionType() {
        
        return mExpressionType;
    }

    /** 
     * Tells if <code>this</code> is represents an expression of the stated 
     * type.
     *
     * @param pType  One of the <code>ExpressionType.???</code> constants 
     *               defined by the interface <code>Expression</code>.   
     *
     * @return  <code>true</code> if <code>this</code> is an expression of the
     *          stated type.
     */
    public bool isExpressionType(ExpressionType pType) {
        
        return mExpressionType == pType;
    }

}
}