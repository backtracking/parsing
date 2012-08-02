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
using InterfaceExtendsClause = com.habelitz.jsobjectizer.jsom.api.InterfaceExtendsClause;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using com.habelitz.jsobjectizer.jsom.api.expression;
using DotExprType = com.habelitz.jsobjectizer.jsom.api.expression.DotExprType;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using PrimitiveType = com.habelitz.jsobjectizer.jsom.api.PrimitiveType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2PrimitiveType = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2PrimitiveType;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>PrimaryExpression</code> type represents a chain of primary
 * expressions separated by dots.
 * <p>      
 * A <code>DotExpression</code> represents something like
 *  <pre>
 *      anyPrimaryExpression.anySimplePrimaryTypeExpression
 *  </pre>
 * where <code>anyPrimaryExpression</code> may be a <code>DotExpression</code>
 * again. The following table shows the possibilities of what concrete types
 * <code>anyPrimaryExpression</code> and <code>anySimplePrimaryTypeExpression
 * </code> could be.
 * <p>
 *  <table border=1>
 *      <th>
 *          <code>DotExpression</code> type
 *      </th>
 *      <th>
 *          anyPrimaryExpression (left primary expression) or primitive type
 *      </th>
 *      <th>
 *          anySimplePrimaryTypeExpression (right primary expression)
 *      </th>
 *      <tr>
 *          <td align=center>
 *              1
 *          </td>
 *          <td>
 *              an object of type <code>PrimaryExpression</code> including the
 *              sub-types of <code>PrimaryExpression</code>
 *          </td>
 *          <td>
 *              <ul>
 *                  <li>
 *                      a <code>ClassConstructorCall</code> object that
 *                      represents an inner new expression
 *                  </li>
 *                  <li>
 *                      an <code>Identifier</code> object
 *                  </li>
 *                  <li>
 *                      a <code>PrimaryExpressionKeyword</code> object.
 *                  </li>
 *              </ul>
 *          </td>
 *      </tr>
 *      <tr>
 *          <td align=center>
 *              2
 *          </td>
 *          <td>
 *              a <code>PrimitiveType</code> object
 *          </td>
 *          <td>
 *              a <code>PrimaryExpressionKeyword</code> object set to <code>
 *              KEYWORD_CLASS</code>
 *          </td>
 *      <tr>
 *          <td align=center>
 *              3
 *          </td>
 *          <td>
 *              a <code>PrimaryExpressionKeyword</code> object set to <code>
 *              KEYWORD_VOID</code>
 *          </td>
 *          <td>
 *              a <code>PrimaryExpressionKeyword</code> object set to <code>
 *              KEYWORD_CLASS</code>
 *          </td>
 *      </tr>
 *  </table>
 *  <p>
 *  The interface <code>DotExpression</code> implemented by this class defines 
 *  appropriate constants for all the <code>DotExpression</code> types as 
 *  stated by the table above.
 *  
 *       
 * @author Dieter Habelitz
 */
public class AST2DotExpression : AST2PrimaryExpression , DotExpression {

    // Note: the inner new expression is not a 'stand-alone' primary expression 
    //       within the grammar but the class 'AST2ClassConstructorCall' handles
    //       also inner new expression and this is supported by the standard 
    //       primary expression resolver, of course.
    
    // The expression left from the dot.
    private AST2PrimaryExpression mLeftExpr;
    // The expression right from the dot.
    private AST2PrimaryExpression mRightExpr;
    // The primitive type for the cases where the dot expression is of type
    // 'DotExpression.DOTEXPR_TYPE_2'
    private PrimitiveType mPrimitiveType;
    // One of the 'DotExpression.DOTEXPR_TYPE_?' constants.
    private DotExprType mDotExprType;
    
    /**
     * Constructor.
     * 
     * @param pTree  The root tree of a dot expression.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2DotExpression(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.DOT_EXPRESSION, pTokenRewriteStream)
    {

        if (pTree.Type != JavaTreeParser.DOT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        // Resolve the dot expression type.
        ITree leftTree = pTree.GetChild(0);
        if (AST2PrimitiveType.isPrimitiveType(leftTree)) {
            mDotExprType = DotExprType.PRIMITIVE_TYPE_DOT_CLASS;
        } else if (leftTree.Type == JavaTreeParser.VOID) {
            // The keywords 'void' and 'class' can't get resolved by the 
            // standard expression resolvers. 
            mDotExprType = DotExprType.VOID_DOT_CLASS;
        } else {
            // There's any primary Expression at the left side from the dot.
            mDotExprType = DotExprType.DOTEXPR_TYPE_1_VARIANTS;
        }
    }

    /**
     * Returns the <i>character in line</i> position of the <code>'.'</code>
     * character.
     * 
     * @return  The <i>character in line</i> position of the <code>'.'</code>
     *          character.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * One of the <code>DotExpression.DotExprType.???</code> constants.
     * 
     * @return  One of the <code>DotExpression.DotExprType.???</code> constants.
     */
    public DotExprType getDotExpressionType() {
        
        return mDotExprType;
    }

    /**
     * Returns a list containing all expressions, from the most left to the most 
     * right expression.
     * <p>
     * For instance, if <code>this</code> represents an expression like <code>
     * anyExpr1().anyExpr2.anyExpr2</code> this method would return a list
     * containing these three expressions, starting with <code>anyExpr1</code>
     * and ending with <code>anyExpr3</code>.
     * <p>
     * Note that if <code>this</code> is of the dot expression type <code>
     * PRIMITIVE_TYPE_DOT_CLASS</code> the <code>PrimitiveType</code> object
     * will not be part of the list (because this object isn't of type <code>
     * expression</code>).
     * <p>
     * Calling this method equals an <code>getExpressions(null)
     * </code> call.
     * 
     * @see  #getExpressions(List)
     * 
     * @return  A list containing all expressions, from the most left to the
     *          most right expression. 
     */
    public List<Expression> getExpressions() {
        
        return getExpressions(null);
    }
    
    /**
     * Returns a list containing all expressions, from the most left to the most 
     * right expression.
     * <p>
     * For instance, if <code>this</code> represents an expression like <code>
     * anyExpr1().anyExpr2.anyExpr2</code> this method would return a list
     * containing these three expressions, starting with <code>anyExpr1</code>
     * and ending with <code>anyExpr3</code>.
     * <p>
     * Note that if <code>this</code> is of the dot expression type <code>
     * PRIMITIVE_TYPE_DOT_CLASS</code> the <code>PrimitiveType</code> object
     * will not be part of the list (because this object isn't of type <code>
     * expression</code>).
     * <p>
     * Calling this method equals an <code>getExpressions(null)
     * </code> call.
     * 
     * @param  pList  If this argument isn't <code>null</code> the expressions
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     * 
     * @return  A list containing all expressions, from the most left to the
     *          most right expression. 
     */
    public List<Expression> getExpressions(List<Expression> pList) {
        
        
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>();
        }
        result.Add(getRightExpression());  // There's always a right expression.
        Expression expr = getLeftExpression();
        if (expr != null) {
            result.Add(expr); // There's also a left expression.
            while (expr.isExpressionType(ExpressionType.DOT_EXPRESSION)) {
                expr = ((DotExpression) expr).getLeftExpression();
                if (expr == null) {
                    break;
                }
                result.Add(expr); // There's another left expression.
            }
        }
        
        return result;
    }
    
    /**
     * Returns the expression from the dot's left side.
     * <p>
     * Note that for dot expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS
     * </code> the left side of the dot is a primitive type and this is not an 
     * expression. Therefore this method will always return <code>null</code> 
     * for that dot expression type.
     * 
     * @see  DotExpression#getPrimitiveTypeFromLeft()
     *  
     * @return The expression from the dot's left side or <code>null</code> for
     *         dot expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code>.
     */
    public PrimaryExpression getLeftExpression() {
        
        if (mDotExprType == DotExprType.PRIMITIVE_TYPE_DOT_CLASS) {
            return null; // Nothing to return for 'DOTEXPR_TYPE_2'
        }
        if (mLeftExpr == null) {
            if (mDotExprType != DotExprType.VOID_DOT_CLASS) {
                mLeftExpr = AST2Expression.resolvePrimaryExpression((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            } else {
                mLeftExpr = new AST2PrimaryExpressionKeyword((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            }
        }
        
        return mLeftExpr;
    }

    /**
     * Returns the line number of the <code>'.'</code> character.
     * 
     * @return  The line number of the <code>'.'</code> character.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the primitive type if <code>this</code> represents a dot 
     * expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code>.
     * 
     * @see #getLeftExpression()
     * 
     * @return  The primitive type if <code>this</code> represents a dot
     *          expressions of type <code>PRIMITIVE_TYPE_DOT_CLASS</code> and 
     *          <code>null</code> otherwise.
     */
    public PrimitiveType getPrimitiveTypeFromLeft() {
        
        if (mDotExprType != DotExprType.PRIMITIVE_TYPE_DOT_CLASS) {
            return null; // Nothing to return if 'this' is not 'DOTEXPR_TYPE_2'
        }
        if (mPrimitiveType == null) {
            mPrimitiveType = new AST2PrimitiveType((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mPrimitiveType;
    }

    /**
     * Returns the expression from the dot's right side.
     *  
     * @return The expression from the dot's right side.
     */
    public PrimaryExpression getRightExpression() {
        
        if (mRightExpr == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(1);
            if (   mDotExprType == DotExprType.DOTEXPR_TYPE_1_VARIANTS
                && tree.Type != JavaTreeParser.CLASS) {
                mRightExpr = AST2Expression.resolvePrimaryExpression(
                        tree, getTokenRewriteStream());
            } else {
                mRightExpr = new AST2PrimaryExpressionKeyword(
                        tree, getTokenRewriteStream());
            }
        }
        
        return mRightExpr;
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
            if (mDotExprType != DotExprType.PRIMITIVE_TYPE_DOT_CLASS) {
                getLeftExpression().traverseAll(pAction);
            } else {
                getPrimitiveTypeFromLeft().traverseAll(pAction);
            }
            getRightExpression().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}