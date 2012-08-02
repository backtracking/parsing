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
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;
using com.habelitz.jsobjectizer.jsom.api.statement;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;
using ForInitType = com.habelitz.jsobjectizer.jsom.api.statement.ForInitType;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {

/**
 * This <code>Statement</code> type represents a <code>for</code> statement.
 * <p>
 * The JSOM abstraction of <code>for</code> statements looks like
 * <pre>
 *     for(initializer; condition; updater) statement
 * </pre>
 * and matches the following rules:
 *  <ul>
 *      <li>
 *          there're two variants for the <i>initializer</i>
 *          <ul>
 *              <li>
 *                  zero or one local variable declaration
 *              </li>
 *              <li>
 *                  zero or more expressions
 *              </li>
 *          </ul>
 *      </li>
 *      <li>
 *          the <i>condition</i> can be stated by zero or one expression and
 *      </li>  
 *      <li>
 *          the <i>updater</i> can be stated by zero or more expressions.
 *      </li>  
 *  </ul>
 * The method <code>getForInitType()</code> can be used to find out of what
 * variant the <i>initializer</i> is.
 * 
 * @see ForEachStatement
 * 
 * @author Dieter Habelitz
 */
public class AST2ForStatement : AST2Statement, ForStatement {

    // One of the 'ForStatement.ForInitType.???' constants.
    private ForInitType mForInitType;
    // The initializer variable declaration if 
    // 'mForInitType == FOR_INIT_TYPE_VAR_DECL'.
    private LocalVariableDeclaration mInitVarDecl;
    // The initializer expressions if 
    // 'mForInitType == FOR_INIT_TYPE_EXPRESSION'.
    private List<Expression> mInitExpressions;
    // The condition expression.
    private Expression mConditionExpression;
    // The updater expressions.
    private List<Expression> mUpdaterExpressions;
    // The 'for' statement's statements.
    private Statement mStatement;

    // The 'for' statement's children.
    private bool mHasForCondition = true;
    private bool mHasForUpdater = true;

    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a <code>for</code> statement.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ForStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) :  
        base (pTree, ElementType.FOR_STATEMENT,pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.FOR) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        ITree child = pTree.GetChild(0);
        if (child.ChildCount == 0) {
            mForInitType = ForInitType.NONE;
        } else if (   child.GetChild(0).Type 
                   == JavaTreeParser.VAR_DECLARATION) {
            mForInitType = ForInitType.VAR_DECL;
        } else {
            mForInitType = ForInitType.EXPRESSION;
        }
        if (pTree.GetChild(1).ChildCount == 0) {
            mHasForCondition = false;
        }
        child = pTree.GetChild(2);
        if (pTree.GetChild(2).ChildCount == 0) {
            mHasForUpdater = false;
        }
    }
    
    /**
     * Returns the <code>for</code> statement's condition expression.
     * 
     * @return  The <code>for</code> statement's condition expression or <code>
     *          null</code> if no condition expression has been stated.
     */
    public Expression getForCondition() {
        
        if (!mHasForCondition) {
            return null; // There's no condition expression.
        }
        if (mConditionExpression == null) {
            mConditionExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(1).GetChild(0),
                    getTokenRewriteStream());
        }
        
        return mConditionExpression;
    }
    
    /**
     * Returns the type of the <code>for</code> statement's initializer variant.
     * 
     * @return  One of the <code>ForStatement.ForInitType</code> constants.
     */
    public ForInitType getForInitType() {
        
        return mForInitType;
    }
    
    /**
     * Returns a list of the <code>for</code> statement's updater expressions.
     * <p>
     * Calling this method equals an <code>getForUpdaters(null)</code>
     * call.
     * 
     * @see #getForUpdaters(List)
     *                
     * @return  A list of the <code>for</code> statement's updater expressions.
     *          If no updaters have been stated <code>null</code> will be 
     *          returned.
     */
    public List<Expression> getForUpdaters() {
        
        return getForUpdaters(null);
    }
    
    /**
     * Returns a list of the <code>for</code> statement's updater expressions.
     * 
     * @param  pList  If this argument isn't <code>null</code> the expressions
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *                
     * @return  A list of the <code>for</code> statement's updater expressions.
     *          If no updaters have been stated <code>null</code> will be 
     *          returned, even if the argument <code>pList</code> isn't <code>
     *          null</code>.
     */
    public List<Expression> getForUpdaters(List<Expression> pList) {
        
        if (!mHasForUpdater) {
            return null; // No updaters available.
        }
        if (mUpdaterExpressions == null) {
            resolveForUpdaters();
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mUpdaterExpressions.Count);
        }
        result.AddRange(mUpdaterExpressions);
        
        return result;
    }
    
    /**
     * Returns a list of the expressions stated within the <code>for</code> 
     * statement's initializer.
     * <p>
     * Calling this method equals an <code>getInitializerExpressions(null)
     * </code> call.
     * 
     * @see #getInitializerExpressions(List)
     *                
     * @return  A list of the <code>for</code> statement's initializer 
     *          expressions. If <code>
     *          'getForInitType() != ForInitType.EXPRESSION</code> <code>null
     *          </code> will be returned.
     */
    public List<Expression> getInitializerExpressions() {
        
        return getInitializerExpressions(null);
    }
    
    /**
     * Returns a list of the expressions stated within the <code>for</code> 
     * statement's initializer.
     * 
     * @param  pList  If this argument isn't <code>null</code> the expressions
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *                
     * @return  A list of the <code>for</code> statement's initializer 
     *          expressions. If <code>
     *          'getForInitType() != ForInitType.EXPRESSION</code> <code>null
     *          </code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    public List<Expression> getInitializerExpressions(List<Expression> pList) {
        
        if (mForInitType != ForInitType.EXPRESSION) {
            return null;
        }
        if (mInitExpressions == null) {
            resolveInitializerExpressions();
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mInitExpressions.Count);
        }
        result.AddRange(mInitExpressions);
        
        return result;
    }
    
    /**
     * Returns the local variable declaration stated within the <code>for</code> 
     * statement's initializer.
     * 
     * @return  The <code>for</code> statement's initializer variable 
     *          declaration or <code>null</code> if <code>getForInitType() != 
     *          ForInitType.VAR_DECL</code>.
     */
    public LocalVariableDeclaration getInitializerVarDecl() {
        
        if (mForInitType != ForInitType.VAR_DECL) {
            return null;
        }
        if (mInitVarDecl == null) {
            mInitVarDecl = new AST2LocalVariableDeclaration((AST2JSOMTree)
                    getTreeNode().GetChild(0).GetChild(0), 
                    getTokenRewriteStream());
        }
        
        return mInitVarDecl;
    }
    
    
    /**
     * Returns the statement that should be executed by the <code>for</code> 
     * loop.
     * 
     * @return  The statement that should be executed by the <code>for</code> 
     *          loop.
     */
    public Statement getStatement() {
        
        if (mStatement == null) {
            mStatement = AST2Statement.resolveStatement((AST2JSOMTree)
                    getTreeNode().GetChild(3), getTokenRewriteStream());
        }
        
        return mStatement;
    }
    
    /**
     * Tells if the <code>for</code> statement has a condition expression.
     * 
     * @return  <code>true</code> if the <code>for</code> statement has a 
     *          condition expression.
     */
    public bool hasForCondition() {
        
        return mHasForCondition;
    }
    
    /**
     * Tells if the <code>for</code> statement has at least one updater
     * expression.
     * 
     * @return  <code>true</code> if the <code>for</code> statement has at least 
     *          one updater expression.
     */
    public bool hasForUpdater() {
        
        return mHasForUpdater;
    }

    /**
     * Resolves the <code>for</code> statement's updater expressions.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * updater expression.
     */
    private void resolveForUpdaters() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(2);
        int size = tree.ChildCount;
        mUpdaterExpressions = new List<Expression>(size);
        for (int offset = 0; offset < size; offset++) {
            mUpdaterExpressions.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                            tree.GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Resolves the expression of the <code>for</code> initializer.
     * <p>
     * Note that it's up to the caller to ensure that <code>this</code>
     * represents a <code>for</code> statement of the <code>ForInitType</code>
     * <code>EXPRESSION</code>.
     */
    private void resolveInitializerExpressions() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode().GetChild(0); 
        int size = tree.ChildCount;
        mInitExpressions = new List<Expression>(size);
        for (int offset = 0; offset < size; offset++) {
            mInitExpressions.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                            tree.GetChild(offset), getTokenRewriteStream()));
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
    public void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            if (mForInitType == ForInitType.VAR_DECL) {
                getInitializerVarDecl().traverseAll(pAction);
            } else if (mForInitType == ForInitType.EXPRESSION) {
                if (mInitExpressions == null) {
                    resolveInitializerExpressions();
                }
                foreach (Expression expression in mInitExpressions) {
                    expression.traverseAll(pAction);
                }
            }
            Expression condition = getForCondition();
            if (condition != null) {
                condition.traverseAll(pAction);
            }
            if (mHasForUpdater) {
                if (mUpdaterExpressions == null) {
                    resolveForUpdaters();
                }
                foreach (Expression expression in mUpdaterExpressions) {
                    expression.traverseAll(pAction);
                }
            }
            getStatement().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}