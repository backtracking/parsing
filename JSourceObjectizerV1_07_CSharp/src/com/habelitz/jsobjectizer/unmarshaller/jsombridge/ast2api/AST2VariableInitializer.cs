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
using com.habelitz.jsobjectizer.jsom.api;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/**
 * This <code>JSOM</code> type represents a variable initializer.
 * <p>
 * A variable initializer can exist in two different incarnations. The first
 * variant is a more or less simple expression that can be most trivially any 
 * literal or even a fairly complex expression. The second variant are array
 * initializers like the following formal example
 * <pre>
 *     {   {"11", "12", "13"},
 *         {"21", "22", "23"},
 *         {"31", "32", "33"},
 *     }
 * </pre>
 * The first variant can be resolved simply by calling the method <code>
 * getExpression()</code> that returns the initializer expression. Resolving an
 * array initializer is a little bit more complex and it starts with calling the
 * method <code>getArrayInitializers()</code> which returns a list of <code>
 * VariableInitializer</code> objects that can represent expressions or further 
 * array initializers.
 * <p>
 * Taking the array initializer example above the first call of <code>
 * getArrayInitializers()</code> would return a list containing three <code>
 * VariableInitializer</code> objects representing array initializers again. 
 * Repeating the <code>getArrayInitializers()</code> call on each of these three 
 * objects will result in getting three further lists of three <code>
 * VariableInitializer</code> objects each, which now represent variable 
 * initializer expressions. Finally the method <code>getExpression()</code> can 
 * be called on each of these nine objects.
 * 
 * @author Dieter Habelitz
 */
public class AST2VariableInitializer : AST2JSOM, VariableInitializer {
    
    // 'true' if 'this' represents an array initializer.
    private bool mIsArrayInitializer = false;
     // The initializers for the cases where 'this' is an array initializer.
    private List<VariableInitializer> mArrayInitializers;
    // The initializer for the cases where 'this' isn't an array initializer.
    private Expression mExpression;
    
     // The initializer; must remain null for empty array initializers.
    private AST2JSOMTree mInitializerTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a variable initializer, i.e.
     *               an expression or an array initializer.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2VariableInitializer(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.VARIABLE_INITIALIZER, pTokenRewriteStream)
    {
        
        if (pTree.Type == JavaTreeParser.ARRAY_INITIALIZER) {
            mIsArrayInitializer = true;
            if (pTree.ChildCount > 0) {
                mInitializerTree = pTree;
            }
        } else if (pTree.Type == JavaTreeParser.EXPR) {
            mInitializerTree = pTree;
        } else {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }

    /**
     * If <code>this</code> represents an array initializer this method returns 
     * a list of the array initializers (see the documentation of this class 
     * above).
     * <p>
     * Calling this method equals an <code>getArrayInitializers(null)</code>
     * call.
     * 
     * @see #getArrayInitializers(List)
     *  
     * @return  A list of the array initializers. If <code>this</code> doesn't 
     *          represent an array initializer or if <code>this</code> 
     *          represents an empty array initializer (i.e. <code>
     *          isArrayInitializer()</code> will return <code>false</code> for 
     *          the first case but <code>true</code> for the second case) <code>
     *          null</code> will be returned.
     */
    public List<VariableInitializer> getArrayInitializers() {
        
        return getArrayInitializers(null);
    }

    /**
     * If <code>this</code> represents an array initializer this method returns 
     * a list of the array initializers (see the documentation of this class 
     * above).
     * 
     * @param  pList  If this argument isn't <code>null</code> the array
     *                initializers will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of the array initializers. If <code>this</code> doesn't 
     *          represent an array initializer or if <code>this</code> 
     *          represents an empty array initializer (i.e. <code>
     *          isArrayInitializer()</code> will return <code>false</code> for 
     *          the first case but <code>true</code> for the second case) <code>
     *          null</code> will be returned, even if the argument <code>pList
     *          </code> isn't <code>null</code>.
     */
    public List<VariableInitializer> getArrayInitializers(
            List<VariableInitializer> pList) {
        
        if (mInitializerTree == null || !mIsArrayInitializer) {
            // It's an empty array initializer or not an array initializer at
            // all.
            return null;
        }
        if (mArrayInitializers == null) {
            resolveArrayInitializers();
        }
        
        List<VariableInitializer> result = pList;
        if (result == null) {
            result = new List<VariableInitializer>(
                    mArrayInitializers.Count);
        }
        result.AddRange(mArrayInitializers);
        
        return result;
    }

    /**
     * Returns the <i>character in line</i> position where the variable
     * initializer starts.
     * 
     * @return  The <i>character in line</i> position where the variable
     *          initializer starts.
     */
    public int getCharPositionInLine() {
        
        if (mIsArrayInitializer) {
            return getTreeNode().CharPositionInLine;
        }
        // If still here return the character position of the expression.
        if (mExpression == null) {
            // Force resolving the expression.
            getExpression();
        }

        return mExpression.getCharPositionInLine();
    }
    
    /**
     * Returns the initializer expression.
     * 
     * @return  The initializer expression or <code>null<code> if <code>this
     *          </code> represents an array initializer.
     */
    public Expression getExpression() {
        
        if (mIsArrayInitializer) {
            return null;
        }
        if (mExpression == null) {
            mExpression = AST2Expression.resolveExpression(
                    mInitializerTree, getTokenRewriteStream());
        }
        
        return mExpression;
    }

    /**
     * Returns the line number of the variable initializer.
     * 
     * @return  The line number of the variable initializer.
     */
    public int getLineNumber() {
        
        if (mIsArrayInitializer) {
            return getTreeNode().Line;
        }
        // If still here return the character position of the expression.
        if (mExpression == null) {
            // Force resolving the expression.
            getExpression();
        }
        
        return mExpression.getLineNumber();
    }

    /**
     * Returns <code>true</code> if <code>this</code> represents an array 
     * initializer.
     * 
     * @return  <code>true</code> if <code>this</code> represents an array 
     *          initializer.
     */
    public bool isArrayInitializer() {
        
        return mIsArrayInitializer;
    }

    /**
     * Resolves the array initializers.
     * <p>
     * Note that it's up to the caller to ensure that <code>this</code> is an
     * array initializer and that there're initializers.
     */
    private void resolveArrayInitializers() {
        
        int size = mInitializerTree.ChildCount;
        mArrayInitializers = new List<VariableInitializer>(size);
        for (int offset = 0; offset < size; offset++) {
            mArrayInitializers.Add(new AST2VariableInitializer((AST2JSOMTree)
                    mInitializerTree.GetChild(offset), 
                    getTokenRewriteStream()));
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
            if (!mIsArrayInitializer) {
                getExpression().traverseAll(pAction);
            } else if (mInitializerTree != null) {
                if (mArrayInitializers == null) {
                    resolveArrayInitializers();
                }
                foreach (VariableInitializer initializer in mArrayInitializers) {
                    initializer.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}