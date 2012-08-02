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
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {
/**
 * This <code>Statement</code> type represents either a <code>while</code> or a
 *  <code>do...while</code> statement.
 * 
 * @author Dieter Habelitz
 */
public class AST2WhileAndDoStatements 
    : AST2Statement , WhileAndDoStatements {

    // The 'while' condition.
    private Expression mCondition;
    // The statement that should be executed while the condition is 'true'
    private Statement mStatement;
    // 'true' if 'this' represents a 'while' (i.e. not a 'do...while')
    // statement.
    private bool mIsWhileStatement = false;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a </code>while</code> or <code>
     *               do...while</code> statement.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2WhileAndDoStatements(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ElementType.DO_OR_WHILE_STATEMENT,pTokenRewriteStream)
    {
        
        if (pTree.Type == JavaTreeParser.WHILE) {
            mIsWhileStatement = true;
        } else if (pTree.Type != JavaTreeParser.DO) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Returns the </code>while</code> or <code>do...while</code> statement's 
     * condition expression.
     * 
     * @return  The </code>while</code> or <code>do...while</code> statement's 
     *          condition expression.
     */
    public Expression getCondition() {
        
        if (mCondition == null) {
            AST2JSOMTree tree = null;
            if (mIsWhileStatement) {
                tree = (AST2JSOMTree)getTreeNode().GetChild(0).GetChild(0);
            } else {
                tree = (AST2JSOMTree)getTreeNode().GetChild(1).GetChild(0);
            }
            mCondition = AST2Expression.resolveExpression(
                    tree, getTokenRewriteStream());
        }
        
        return mCondition;
    }
    
    /**
     * Returns the statement that should be executed while the condition is
     * <code>true</code>.
     * 
     * @return  The statement that should be executed while the condition is
     *          <code>true</code>.
     */
    public Statement getStatement() {
        
        if (mStatement == null) {
            AST2JSOMTree tree = null;
            if (mIsWhileStatement) {
                tree = (AST2JSOMTree)getTreeNode().GetChild(1);
            } else {
                tree = (AST2JSOMTree)getTreeNode().GetChild(0);
            }
            mStatement = AST2Statement.resolveStatement(
                    tree, getTokenRewriteStream());
        }
        
        return mStatement;
    }
    
    /**
     * Tells if <code>this</code> represents a <code>do...while</code>
     * statement.
     * 
     * @return  <code>true</code> if <code>this</code> represents a <code>
     *          do...while</code> statement.
     */
    public bool isDoWileStatement() {
        
        return !mIsWhileStatement;
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
            if (mIsWhileStatement) {
                getCondition().traverseAll(pAction);
                getStatement().traverseAll(pAction);
            } else {
                getStatement().traverseAll(pAction);
                getCondition().traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}