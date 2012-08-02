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
using ModifierList = com.habelitz.jsobjectizer.jsom.api.ModifierList;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {
/**
 * This <code>Statement</code> type represents an <code>for</code> statement
 * that matches the <i>forEach</i> syntax.
 * <p>
 * The JSOM abstraction of <i>forEach</i> statements looks like
 *  <pre>
 *      for (localModifierList type identifier : expression) 
 *          statement
 *  </pre>
 * 
 * @see ForStatement
 * 
 * @author Dieter Habelitz
 */
public class AST2ForEachStatement : AST2Statement, ForEachStatement {

    // The optional modifier of the 'for' statement initializer's type. 
    private ModifierList mModifierList;
    // The 'for' statement initializer's type.
    private Type mType;
    // The 'for' statement initializer's expression.
    private Expression mExpression;
    // The 'for' statement's statements.
    private Statement mStatement;
    
    // The 'forEach' statement's children.
    private bool mHasModifier = false;
    
    private AST2JSOMTree mIdentifierTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a <code>forEach</code> 
     *               statement.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ForEachStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ElementType.FOR_EACH_STATEMENT,pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.FOR_EACH) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (pTree.GetChild(0).ChildCount > 0) {
            mHasModifier = true;
        }
        mIdentifierTree = (AST2JSOMTree)pTree.GetChild(2);
    }

    /**
     * Returns the expression from the <i>forEach</i> statement's initializer.
     * 
     * @return  The expression from the <i>forEach</i> statement's initializer.
     */
    public Expression getExpression() {
        
        if (mExpression == null) {
            mExpression = (Expression)AST2Expression.resolveExpression((AST2JSOMTree)
                    getTreeNode().GetChild(3), getTokenRewriteStream());
        }
        
        return mExpression;
    }
    
    /**
     * Returns the identifier from the <i>forEach</i> statement's initializer.
     * 
     * @return  The identifier from the <i>forEach</i> statement's initializer.
     */
    public String getIdentifier() {
        
        return mIdentifierTree.Text;
    }
    
    /**
     * Returns the local modifier list from the <i>forEach</i> statement's 
     * initializer.
     * <p>
     * Note that the modifier list may also include annotations.
     * 
     * @return  The local modifier list from the <i>forEach</i> statement's 
     *          initializer or <code>null</code> if there are no modifiers.
     */
    public ModifierList getLocalModifiers() {
        
        if (!mHasModifier) {
            return null;
        }
        if (mModifierList == null) {
            mModifierList = new AST2ModifierList((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }

        return mModifierList;
    }
    
    /**
     * Returns the statement that should be executed by the <i>forEach</i> loop.
     * 
     * @return  The statement that should be executed by the <i>forEach</i> 
     *          loop.
     */
    public Statement getStatement() {
        
        if (mStatement == null) {
            mStatement = AST2Statement.resolveStatement((AST2JSOMTree)
                    getTreeNode().GetChild(4), getTokenRewriteStream());
        }
        
        return mStatement;
    }
    
    /**
     * Returns the type from the <i>forEach</i> statement's initializer.
     * 
     * @return  The type from the <i>forEach</i> statement's initializer.
     */
    public Type getType() {
        
        if (mType == null) {
            mType = new AST2Type((AST2JSOMTree)
                    getTreeNode().GetChild(1), getTokenRewriteStream());
        }
        
        return mType;
    }
    
    /**
     * Tells if the <i>forEach</i> statement's initializer has at least one
     * modifier (which can only be the <code>final</code> modifier here, of
     * course) or annotation.
     * 
     * @return  <code>true</code> if the <i>forEach</i> statement's initializer
     *          has at least one modifier or annotation.
     */
    public bool hasModifier() {
        
        return mHasModifier;
    }

    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new identifier of the <i>forEach</i> 
     *                        statement's variable.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        String oldId = mIdentifierTree.Text;
        mIdentifierTree.Token.Text = pNewIdentifier;
        
        return oldId;
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
            ModifierList modifiers = getLocalModifiers();
            if (modifiers != null) {
                modifiers.traverseAll(pAction);
            }
            getType().traverseAll(pAction);
            getExpression().traverseAll(pAction);
            getStatement().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}