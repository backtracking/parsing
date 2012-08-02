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
using System.Reflection;
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

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>PrimaryExpression</code> type represents the access to a static
 * array's element like <code>
 * 'anyPrimaryExpression.arrayIdentifier[anyOffsetExpression]'</code>, where 
 * <code>'anyPrimaryExpression'</code> is an optional qualifier and <code>
 * 'arrayIdentifier'</code> the identifier of the static array.
 * 
 * @author Dieter Habelitz
 */
public class AST2ArrayElementAccess : AST2PrimaryExpression, ArrayElementAccess {

    /*
     * The array's identifier.
     */
    private AST2PrimaryExpression mArrayAccess;
    /*
     * The array offset.
     */
    private AST2Expression mOffset;
    
    private AST2JSOMTree mIdentifierNode;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an array element access.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ArrayElementAccess(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.ARRAY_ELEMENT_ACCESS, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.ARRAY_ELEMENT_ACCESS) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        mArrayAccess = AST2Expression.resolvePrimaryExpression((AST2JSOMTree)
                getTreeNode().GetChild(0), getTokenRewriteStream());
        mOffset = AST2Expression.resolveExpression((AST2JSOMTree)
                getTreeNode().GetChild(1), getTokenRewriteStream());
        // Resolve the identifier of the array if the array is accessed via its
        // identifier at all.
        if (mArrayAccess.isExpressionType(ExpressionType.IDENTIFIER)) {
            mIdentifierNode = (AST2JSOMTree)mArrayAccess.getTreeNode();
        } else if (mArrayAccess.isExpressionType(
                ExpressionType.DOT_EXPRESSION)) {
                    AST2PrimaryExpression rightExpression = (AST2PrimaryExpression)
                ((AST2DotExpression) mArrayAccess).getRightExpression();
            if (rightExpression.isExpressionType(ExpressionType.IDENTIFIER)) {
                mIdentifierNode = (AST2JSOMTree)rightExpression.getTreeNode();
            }
        }
    }

    /**
     * Returns the access to the array.
     * <p>
     * An array access is a more or less complicated primary expression ending
     * with the array's identifier. A formal example could look like: 
     * <pre>
     *     anyMethodCall(anyArgs).arrayIdentifier[anyOffsetExpression]
     * </pre>. 
     * Calling this method for the example above the primary expression
     * representing <code>'anyMethodCall(anyArgs).anyArrayIdentifier'</code> 
     * would be returned.
     * <p>
     * The most trivial primary expression would be the array's identifier, of
     * course.
     * <p>
     * Note that for multidimensional arrays this method returns <code>
     * ArrayElementAccess</code> objects until the least dimension has been
     * reached.
     * 
     * @see #getIdentifier()
     * 
     * @return  The array's accessor.
     */
    public PrimaryExpression getArrayAccess() {
        
        return mArrayAccess;
    }

    /**
     * Returns the <i>character in line</i> of the array access.
     * 
     * @return  The <i>character in line</i> of the array access.
     */
    public int getCharPositionInLine() {
        
        if (mArrayAccess.isExpressionType(ExpressionType.DOT_EXPRESSION)) {
            return ((DotExpression) mArrayAccess)
                .getRightExpression().getCharPositionInLine();
        }

        return mArrayAccess.getCharPositionInLine();
    }
    
    /**
     * Returns the array's identifier.
     * <p>
     * This method extracts the array's identifier from the primary expression
     * that represents the array access.
     * 
     * @see #getArrayAccess()
     * 
     * @return  The array's identifier or <code>null</code> if the array isn't 
     *          accessed by an identifier, i.e. if the accessor is a method call
     *          (something like <code>anyMethodCall()[]</code> or an <code>
     *          ArrayElementAccess</code> again (multidimensional arrays). Or to
     *          say it in other words: This method only returns an identifier
     *          if <code>getArrayAccess()</code> returns a <code>JSOM</code>
     *          object of type <code>Identifier</code> or of type <code>
     *          DotExpression</code> with a right expression representing an
     *          identifier.
     */
    public String getIdentifier() {
        
        if (mIdentifierNode != null) {
            return mIdentifierNode.Text;
        }
        
        return null;
    }
    
    /**
     * Returns the line number of the array element access.
     * 
     * @return  The line number of the array element access.
     */
    public int getLineNumber() {
        
        return mArrayAccess.getLineNumber();
    }

    /**
     * Returns the array offset.
     * <p>
     * This method extracts offset expression from the primary expression that
     * represents the array access. 
     * 
     * @see #getArrayAccess()
     * 
     * @return  The array offset.
     */
    public Expression getOffset() {
        
        return mOffset;
    }

    /**
     * Tells if the array is accessed via an array identifier.
     * 
     * @return  <code>true</code> if the array is accessed via an identifier but
     *          <code>false</code> otherwise, i.e. if the accessor is a method 
     *          call (something like <code>anyMethodCall()[]</code> or an <code>
     *          ArrayElementAccess</code> again (multidimensional arrays). Or to
     *          say it in other words: This method only returns an identifier
     *          if <code>getArrayAccess()</code> returns a <code>JSOM</code>
     *          object of type <code>Identifier</code> or of type <code>
     *          DotExpression</code> with a right expression representing an
     *          identifier.
     */
    public bool hasIdentifier() {
    
        return mIdentifierNode != null;
    }
    
    /**
     * Replaces the identifier of the array element access.
     * <p>
     * If the array access represented by <code>this</code> isn't accessed via
     * an identifier, i.e. if the accessor is a method call (something like 
     * <code>anyMethodCall()[]</code> or an <code>ArrayElementAccess</code> 
     * again (multidimensional arrays), this method does nothing but return
     * <code>null</code>.
     * 
     * @param pNewIdentifier  The new array identifier.
     * 
     * @return  The old identifier or <code>null</code> if isn't accessed via an
     *          identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        if (mIdentifierNode != null) {
            String oldId = mIdentifierNode.Text;
            mIdentifierNode.Token.Text = pNewIdentifier;
            return oldId;
        }
        
        return null;
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
            mArrayAccess.traverseAll(pAction);
            mOffset.traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}