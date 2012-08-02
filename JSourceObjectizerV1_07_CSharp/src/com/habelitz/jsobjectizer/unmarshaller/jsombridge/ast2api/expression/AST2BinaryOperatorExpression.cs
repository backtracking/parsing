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
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using Operator = com.habelitz.jsobjectizer.jsom.api.expression.BinaryOperator;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>Expression</code> type represents all kinds of binary operator
 * expressions.
 * <p>
 * The kind of the used binary operator can be found out by calling the method 
 * <code>getOperatorType()</code>.
 * <p>
 * Note that this class doesn't deal with the <code>instanceof</code> operator. 
 * 
 * @see InstanceOfExpression
 * 
 * @author Dieter Habelitz
 */
public class AST2BinaryOperatorExpression: AST2Expression , BinaryOperatorExpression {

    private Operator? mOperatorType;
    
    private Expression mLeftOperand;
    private Expression mRightOperand;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing the binary operator expression.
     * @param pOperatorType  One of the 'Operator.???' constants defined by the 
     *                       interface '.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    private AST2BinaryOperatorExpression(
            AST2JSOMTree pTree, Operator? pOperatorType, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.BINARY_OPERATOR_EXPRESSION, pTokenRewriteStream)
    {

        mOperatorType = pOperatorType;
    }

    /**
     * Factory method.
     * 
     * @param pTree  The tree node representing the binary operator expression.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.
     *                             
     * @return  A new instance of this class or <code>null</code> if the given
     *          tree doesn't represent a binary operator expression.                                        
     */
    public static AST2BinaryOperatorExpression createNewInstance(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {
        
        Operator? oper = null;
        switch (pTree.Type) {
        case JavaTreeParser.ASSIGN:
            oper = Operator.ASSIGN;
            break;
        case JavaTreeParser.PLUS_ASSIGN:
            oper = Operator.ADD_ASSIGN;
            break;
        case JavaTreeParser.MINUS_ASSIGN:
            oper = Operator.SUB_ASSIGN;
            break;
        case JavaTreeParser.STAR_ASSIGN:
            oper = Operator.MUL_ASSIGN;
            break;
        case JavaTreeParser.DIV_ASSIGN:
            oper = Operator.DIV_ASSIGN;
            break;
        case JavaTreeParser.AND_ASSIGN:
            oper = Operator.BITWISE_AND_ASSIGN;
            break;
        case JavaTreeParser.OR_ASSIGN:
            oper = Operator.BITWISE_OR_ASSIGN;
            break;
        case JavaTreeParser.XOR_ASSIGN:
            oper = Operator.BITWISE_XOR_ASSIGN;
            break;
        case JavaTreeParser.MOD_ASSIGN:
            oper = Operator.MOD_ASSIGN;
            break;
        case JavaTreeParser.BIT_SHIFT_RIGHT_ASSIGN:
            oper = Operator.BIT_SHIFT_RIGHT_ASSIGN;
            break;
        case JavaTreeParser.SHIFT_RIGHT_ASSIGN:
            oper = Operator.SHIFT_RIGHT_ASSIGN;
            break;
        case JavaTreeParser.SHIFT_LEFT_ASSIGN:
            oper = Operator.SHIFT_LEFT_ASSIGN;
            break;
        case JavaTreeParser.LOGICAL_OR:
            oper = Operator.LOGICAL_OR;
            break;
        case JavaTreeParser.LOGICAL_AND:
            oper = Operator.LOGICAL_AND;
            break;
        case JavaTreeParser.OR:
            oper = Operator.BITWISE_OR;
            break;
        case JavaTreeParser.XOR:
            oper = Operator.BITWISE_XOR;
            break;
        case JavaTreeParser.AND:
            oper = Operator.BITWISE_AND;
            break;
        case JavaTreeParser.EQUAL:
            oper = Operator.EQUAL;
            break;
        case JavaTreeParser.NOT_EQUAL:
            oper = Operator.NOT_EQUAL;
            break;
        case JavaTreeParser.LESS_OR_EQUAL:
            oper = Operator.LESS_OR_EQUAL;
            break;
        case JavaTreeParser.GREATER_OR_EQUAL:
            oper = Operator.GREATER_OR_EQUAL;
            break;
        case JavaTreeParser.BIT_SHIFT_RIGHT:
            oper = Operator.BIT_SHIFT_RIGHT;
            break;
        case JavaTreeParser.SHIFT_RIGHT:
            oper = Operator.SHIFT_RIGHT;
            break;
        case JavaTreeParser.GREATER_THAN:
            oper = Operator.GREATER_THAN;
            break;
        case JavaTreeParser.SHIFT_LEFT:
            oper = Operator.SHIFT_LEFT;
            break;
        case JavaTreeParser.LESS_THAN:
            oper = Operator.LESS_THAN;
            break;
        case JavaTreeParser.PLUS:
            oper = Operator.ADD;
            break;
        case JavaTreeParser.MINUS:
            oper = Operator.SUB;
            break;
        case JavaTreeParser.STAR:
            oper = Operator.MUL;
            break;
        case JavaTreeParser.DIV:
            oper = Operator.DIV;
            break;
        case JavaTreeParser.MOD:
            oper = Operator.MOD;
            break;
        default:
            return null;
        }
        
        return new AST2BinaryOperatorExpression(
                pTree, oper, pTokenRewriteStream);
    }

    /**
     * Returns the <i>character in line</i> position of the binary operator.
     * 
     * @return  The <i>character in line</i> position of the binary operator.
     */
    public override int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the operand from the operator's left side.
     * <p>
     * For assignment expressions the left operand corresponds to the lValue.
     * 
     * @return  The operand from the operator's left side.
     */
    public Expression getLeftOperand() {
        
        if (mLeftOperand == null) {
            mLeftOperand = AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mLeftOperand;
    }
    
    /**
     * Returns the line number of the binary operator.
     * 
     * @return  The line number of the binary operator.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the kind of the binary operator.
     * 
     * @return  One of the <code>BinaryOperatorExpression.Operator.???</code> 
     *          constants.
     */
    public BinaryOperator? getOperatorType() {

        return mOperatorType;
    }
    
    /**
     * Returns the operand from the operator's right side.
     * <p>
     * For assignment expressions the right operand corresponds to the rValue.
     * 
     * @return  The operand from the operator's right side.
     */
    public Expression getRightOperand() {
        
        if (mRightOperand == null) {
            mRightOperand = AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(1), getTokenRewriteStream());
        }
        
        return mRightOperand;
    }

    
    /**
     * Tells if the operator of <code>this/code> is an assignment operator.
     * <p>
     * For cases where it is of interest to know if an operator is an assignment
     * operator but where it is not of interest to know what assignment
     * assignment operator it actually is (the standard assignment operator
     * <code>'='</code> or one of the compound assignment operators like <code>
     * '+='</code>, <code>'-='</code>, <code>'<<='</code> and so on) this method
     * can be used to get the answer without the need of a load of <i>ORed</i>
     * conditions. 
     * 
     * @return  <code>true</code> if the operator of <code>this/code> is an 
     *          assignment operator. 
     */
    public bool isAssignmentOperator() {

        return mOperatorType.isAssignmentOperator();
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
            getLeftOperand().traverseAll(pAction);
            getRightOperand().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}