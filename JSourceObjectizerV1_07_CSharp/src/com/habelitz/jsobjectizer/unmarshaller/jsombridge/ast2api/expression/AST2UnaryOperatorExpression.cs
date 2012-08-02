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
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using Operator = com.habelitz.jsobjectizer.jsom.api.expression.Operator;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>Expression</code> type represents all kinds of unary operator
 * expressions.
 * <p>
 * The kind of the used unary operator can be found out by calling the method 
 * <code>getOperatorType()</code>.
 * 
 * @author Dieter Habelitz
 */
public class AST2UnaryOperatorExpression 
    : AST2Expression , UnaryOperatorExpression {

    private Operator? mOperatorType;
    
    private Expression mOperand;
    
    /**
     * Constructor.
     * <p>
     * This constructor may be used if the operator type has already been
     * resolved for the given tree.
     * 
     * @param pTree  The tree node representing the binary operator expression.
     * @param pOperatorType  One of the 'OP_???' constants defined by the 
     *                       interface '. Note that 
     *                       it's up to the caller to ensure that the operator 
     *                       type matches the token type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    private AST2UnaryOperatorExpression(
            AST2JSOMTree pTree, Operator? pOperatorType, 
            TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.UNARY_OPERATOR_EXPRESSION, pTokenRewriteStream)
    {
        
        mOperatorType = pOperatorType;
    }

    /**
     * Factory method.
     * 
     * @param pTree  The tree node representing the unary operator expression.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     * 
     * @return  A new instance of this class or <code>null</code> if the given
     *          tree doesn't represent an unary operator expression.                                        
     */
    public static AST2UnaryOperatorExpression createNewInstance(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) {
        
        Operator? oper = null;
        switch (pTree.Type) {
        case JavaTreeParser.UNARY_PLUS:
            oper = Operator.UNARY_PLUS;
            break;
        case JavaTreeParser.UNARY_MINUS:
            oper = Operator.UNARY_MINUS;
            break;
        case JavaTreeParser.PRE_INC:
            oper = Operator.PRE_INCREMENT;
            break;
        case JavaTreeParser.PRE_DEC:
            oper = Operator.PRE_DECREMENT;
            break;
        case JavaTreeParser.POST_INC:
            oper = Operator.POST_INCREMENT;
            break;
        case JavaTreeParser.POST_DEC:
            oper = Operator.POST_DECREMENT;
            break;
        case JavaTreeParser.NOT:
            oper = Operator.BITWISE_NOT;
            break;
        case JavaTreeParser.LOGICAL_NOT:
            oper = Operator.LOGICAL_NOT;
            break;
        default:
            return null;
        }
        
        return new AST2UnaryOperatorExpression(
                pTree, oper, pTokenRewriteStream);
    }

    /**
     * Returns the <i>character in line</i> position of the unary operator.
     * 
     * @return  The <i>character in line</i> position of the unary operator.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the line number of the unary operator.
     * 
     * @return  The line number of the unary operator.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the operand.
     * 
     * @return  The operand.
     */
    public Expression getOperand() {
        
        if (mOperand == null) {
            mOperand = AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mOperand;
    }

    /**
     * Returns the kind of the unary operator.
     * 
     * @return  One of the <code>UnaryOperatorExpression.Operator.???</code> 
     *          constants.
     */
    public Operator? getOperatorType() {
        
        return mOperatorType;
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
            getOperand().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}