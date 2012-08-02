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
using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using com.habelitz.core;
using com.habelitz.jsobjectizer.jsom;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using JSourceObjectizerInternalException = com.habelitz.jsobjectizer.JSourceObjectizerInternalException;
using ExpressionType =  com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using ElementType = com.habelitz.jsobjectizer.jsom.api.statement.ElementType;
using Owner = com.habelitz.jsobjectizer.jsom.api.statement.Owner;
using JSourceMarshaller = com.habelitz.jsobjectizer.marshaller.JSourceMarshaller;
using MarshallerException = com.habelitz.jsobjectizer.marshaller.MarshallerException;
using CommonJSOMMessages = com.habelitz.jsobjectizer.resource.resbundle.CommonJSOMMessages;
using MarshallerMessages = com.habelitz.jsobjectizer.resource.resbundle.MarshallerMessages;
using JSourceUnmarshallerException = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshallerException;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using JSOParser = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.JSOParser;
using JavaTreeParser = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated.JavaTreeParser;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2Annotation = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2Annotation;
using AST2AnnotationDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2AnnotationDeclaration;
using AST2ClassDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ClassDeclaration;
using AST2ClassExtendsClause = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ClassExtendsClause;
using AST2ComplexTypeIdentifier = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ComplexTypeIdentifier;
using AST2EnumConstant = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2EnumConstant;
using AST2EnumDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2EnumDeclaration;
using AST2FormalParameterList = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2FormalParameterList;
using AST2GenericTypeArgument = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2GenericTypeArgument;
using AST2GenericTypeParameter = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2GenericTypeParameter;
using AST2ImplementsClause = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ImplementsClause;
using AST2ImportDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ImportDeclaration;
using AST2InterfaceDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2InterfaceDeclaration;
using AST2InterfaceExtendsClause = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2InterfaceExtendsClause;
using AST2JavaSource = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2JavaSource;
using AST2ModifierList = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ModifierList;
using AST2PackageDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2PackageDeclaration;
using AST2PrimitiveType = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2PrimitiveType;
using AST2QualifiedIdentifier = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2QualifiedIdentifier;
using AST2ThrowsClause = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2ThrowsClause;
using AST2Type = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2Type;
using AST2VariableDeclaratorIdentifier = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2VariableDeclaratorIdentifier;
using AST2VariableInitializer = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.AST2VariableInitializer;
using AST2CommonTypeDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype.AST2CommonTypeDeclaration;
using AST2Expression = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression.AST2Expression;
using AST2AssertStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2AssertStatement;
using AST2BreakStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2BreakStatement;
using AST2ContinueStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ContinueStatement;
using AST2ExpressionStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ExpressionStatement;
using AST2ForEachStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ForEachStatement;
using AST2ForStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ForStatement;
using AST2IfStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2IfStatement;
using AST2LabeledStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2LabeledStatement;
using AST2LocalClassDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2LocalClassDeclaration;
using AST2LocalVariableDeclaration = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2LocalVariableDeclaration;
using AST2ReturnStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ReturnStatement;
using AST2Statement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2Statement;
using AST2StatementBlockElement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2StatementBlockElement;
using AST2StatementBlockScope = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2StatementBlockScope;
using AST2SwitchStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2SwitchStatement;
using AST2SynchronizedStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2SynchronizedStatement;
using AST2ThrowStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2ThrowStatement;
using AST2TryStatement = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2TryStatement;
using AST2WhileAndDoStatements = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2WhileAndDoStatements;
using AST2SwitchLabel = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2SwitchStatement.AST2SwitchLabel;



namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge
{
/**
 * This is the base type for all kinds of <code>JSOM</code> types.
 *   
 * @author Dieter Habelitz
 */
public abstract class AST2JSOM : AST2JSOMBase {
    
    /**
     * Defines constants for change actions.
     * <p>
     * When a <code>JSOM</code> objects gets changed and therefore the
     * appropriate tree node and token stream must get changed, too, it could be
     * sometimes necessary non only to consider the tokens representing the
     * <code>JSOM</code> object but also some surrounding tokens within the
     * hidden channel. These constants can be used to define the hidden tokens
     * that should be considered.
     * <p>
     * The javadoc comments for the constants below apply to the following 
     * formal example stream content:
     * 
     *  <code>
     *      NON_HIDDEN_TOKEN_LEFT
     *      HIDDEN_TOKEN_ANY(1)
     *      HIDDEN_TOKEN_NEWLINE(1)
     *      HIDDEN_TOKEN_ANY(2)
     *      HIDDEN_TOKEN_NEWLINE(2)
     *      HIDDEN_TOKEN_ANY(3)
     *      NON_HIDDEN_TOKEN_TO_CHANGE
     *      HIDDEN_TOKEN_ANY(4)
     *      HIDDEN_TOKEN_NEWLINE(3)
     *      HIDDEN_TOKEN_ANY(5)
     *      HIDDEN_TOKEN_NEWLINE(4)
     *      HIDDEN_TOKEN_ANY(6)
     *      NON_HIDDEN_TOKEN_RIGHT
     *  </code>
     *  
     * @author habelitz
     */
    protected enum ChangeTokenBorder {

        /**
         * Consider all hidden tokens from <code>HIDDEN_TOKEN_ANY(2)</code> to
         * <code>HIDDEN_TOKEN_ANY(3)</code> or from <code>HIDDEN_TOKEN_ANY(4)
         * </code> to <code>HIDDEN_TOKEN_ANY(5)</code>
         */
        FARTHEST_NEWLINE_EXCLUDING,

        /**
         * Consider all hidden tokens from <code>HIDDEN_TOKEN_NEWLINE(1)</code> 
         * to <code>HIDDEN_TOKEN_ANY(3)</code> or from <code>HIDDEN_TOKEN_ANY(4)
         * </code> to <code>HIDDEN_TOKEN_NEWLINE(4)</code>
         */
        FARTHEST_NEWLINE_INCLUDING,
        
        /**
         * Consider the hidden token <code>HIDDEN_TOKEN_ANY(3)</code> or <code>
         * HIDDEN_TOKEN_ANY(4)</code>
         */
        NEXT_NEWLINE_EXCLUDING,
        
        /**
         * Consider all hidden tokens from <code>HIDDEN_TOKEN_NEWLINE(2)</code> 
         * to <code>HIDDEN_TOKEN_ANY(3)</code> or from <code>HIDDEN_TOKEN_ANY(4)
         * </code> to <code>HIDDEN_TOKEN_NEWLINE(3)</code>
         */
        NEXT_NEWLINE_INCLUDING,
        
        /**
         * Consider all hidden tokens from <code>HIDDEN_TOKEN_ANY(1)</code> 
         * to <code>HIDDEN_TOKEN_ANY(3)</code> or from <code>HIDDEN_TOKEN_ANY(4)
         * </code> to <code>HIDDEN_TOKEN_ANY(6)</code>
         */
        NEXT_NON_HIDDEN_TOKEN_EXCLUDING
    }
    
    private static AST2JSOMUnmarshaller sUnmarshaller = null;
    
    // The Tree object represented by this object.
    private AST2JSOMTree mTree;
    // The token stream the token of 'mTree' belongs to.
    private TokenRewriteStream mTokenRewriteStream;
    // The JSOM type of 'this'
    private JSOMType? mJSOMType;
    
    /**
     * Constructor.
     * 
     * @param pTree  The ANTLR tree node wrapped by the new object.
     * @param pJSOMType  One of the <code>JSOMType.???</code> constants defined
     *                   by the interface <code>JSOM</code>.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2JSOM(
            AST2JSOMTree pTree, JSOMType? pJSOMType, 
            TokenRewriteStream pTokenRewriteStream) {
        
        mTree = pTree;
        mJSOMType = pJSOMType;
        mTokenRewriteStream = pTokenRewriteStream;
    }
    
    /**
     * Returns the <code>JSOMType</code> represented by <code>this</code>.
     * 
     * @return The <code>JSOMType</code> represented by <code>this</code>.
     */
    public JSOMType? getJSOMType() {
        
        return mJSOMType;
    }

    public virtual int getCharPositionInLine()
    {
        return -1;
    }

    public virtual int getLineNumber()
    {
        return -1;
    }

    public virtual void traverseAll(TraverseAction pAction)
    {

    }

    /**
     * Returns the token stream that contains the token represented by <code>
     * this</code>.
     * 
     * @return  The token stream that contains the token represented by <code>
     *          this</code>.
     */
    public TokenRewriteStream getTokenRewriteStream() {
        
        return mTokenRewriteStream;
    }
    
    /**
     * Returns the marshaller to rewrite the Java source represented by <code>
     * this</code>.
     * <p>
     * This method can be called for every <code>JSOM</code> type and the 
     * returned marshaller will only rewrite those Java sources represented by 
     * the appropriate <code>JSOM</code> type.
     * 
     * @return  A marshaller to rewrite the Java source represented by <code>
     *          this</code>.
     */
    public JSourceMarshaller getMarshaller() {
         
        return new JSOMMarshaller(this);
    }
    
    /** 
     * Returns the ANTLR tree node represented by <code>this</code>.
     * 
     * @return  The ANTLR tree node represented by <code>this</code>.
     */
    public ITree getTreeNode()
    {
        
        return mTree;
    }
    
    /**
     * Returns a global marshaller that can be used by sub classes of this class
     * to alter their content, i.e. to add Java source fragments, for instance.
     * 
     * @return  A global marshaller.
     */
    protected static AST2JSOMUnmarshaller getUnmarshaller() {
        
        if (sUnmarshaller == null) {
            sUnmarshaller = new AST2JSOMUnmarshaller();
        }
        
        return sUnmarshaller;
    }
    
    /** 
     * Tells if <code>this</code> represents an expression of the stated type.
     *
     * @param pType  One of the <code>ExpressionType.???</code> constants 
     *               defined by the interface <code>Expression</code>.   
     *
     * @return  This implementation always returns false. <code>JSOM</code>
     *          types that implement the representation of an expression must
     *          overwrite this method.
     */
    public bool isExpressionType(
            ExpressionType pType) {
        
        return false;
    }
    
    /** 
     * Tells if <code>this</code> is of the stated <code>JSOM</code> type.
     *
     * @param pType  One of the <code>JSOMType.???</code> constants defined by
     *               the interface <code>JSOM</code>.
     *
     * @return  <code>true</code> if <code>this</code> is of the stated <code>
     *          JSOM</code> type.
     */
    public bool isJSOMType(JSOMType pType) {
        
        return mJSOMType == pType;
    }
    
    /** 
     * Tells if <code>this</code> represents a statement block element of the 
     * stated type.
     *
     * @param pType  One of the <code>ElementType.???</code> constants defined 
     *               by the interface <code>StatementBlockElement</code>.   
     *
     * @return  This implementation always returns false. <code>JSOM</code>
     *          types that implement the representation of an expression must
     *          overwrite this method.
     */
    public virtual bool isStatementBlockElementType(
            ElementType pType) {
        
        return false;
    }
    
    /**
     * Removes the tree node that belongs to the stated <code>AST2JSOMBase
     * </code> from it's parent tree node. Furthermore the appropriate tokens
     * will be removed from the token stream.
     * 
     * @param pNodeToRemove  The owner of the tree node that should get removed.
     * 
     * @throws JSourceObjectizerInternalException  If the stated tree node is
     *                                             not a child of the stated
     *                                             parent node. I.e. it's up to
     *                                             the caller to ensure that the
     *                                             child exists.
     * 
     * __TEST__
     */
    protected static void removeTreeNode(AST2JSOMBase pNodeToRemove) {
        
        removeTreeNode(pNodeToRemove, (AST2JSOMBase) null, null);
    }
    
    /**
     * Removes the tree node that belongs to the stated <code>AST2JSOMBase
     * </code> from it's parent tree node. Furthermore the appropriate tokens
     * will be removed from the token stream.
     * 
     * @param pNodeToRemove  The owner of the tree node that should get removed.
     * @param pLeftChangeTokenBorder  See the comments for the enumeration 
     *                                declaration <code>
     *                                AST2JSOM.ChangeTokenBorder</code>. If this
     *                                argument is <code>null</code> removing 
     *                                will start with the left position of the
     *                                stated node. 
     * @param pRightChangeTokenBorder See the comments for the enumeration 
     *                                declaration <code>
     *                                AST2JSOM.ChangeTokenBorder</code>. If this
     *                                argument is <code>null</code> removing 
     *                                will end at the right position of the 
     *                                stated node. 
     * 
     * __TEST__
     */
    protected static void removeTreeNode(
            AST2JSOMBase pNodeToRemove,
            ChangeTokenBorder? pLeftChangeTokenBorder, 
            ChangeTokenBorder? pRightChangeTokenBorder) {
        
        ITree nodeToRemove = pNodeToRemove.getTreeNode();
        ITree parent = nodeToRemove.Parent;
        
        // Remove the tree node from it's parent
        int childCount = parent.ChildCount;
        int childOffset = 0;
        while (childOffset < childCount) {
            if (parent.GetChild(childOffset) == nodeToRemove) {
                break;
            }
            childOffset++;
        }
        if (childOffset == childCount) {
            // If still here no matching child has been found.
            throw new JSourceObjectizerInternalException(
                    CommonJSOMMessages.getChildTreeNodeNotFoundMessage(
                            nodeToRemove.ToString(), parent.ToString()));
        }
        parent.DeleteChild(childOffset);

        // Remove the tokens from the stream.
        
        TokenRewriteStream stream = pNodeToRemove.getTokenRewriteStream();
        int startIndex = nodeToRemove.TokenStartIndex;
        int stopIndex = nodeToRemove.TokenStopIndex;
        if (pLeftChangeTokenBorder != null) {
            startIndex--;
            if (      pLeftChangeTokenBorder 
                   == ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING
                ||    pLeftChangeTokenBorder 
                   == ChangeTokenBorder.FARTHEST_NEWLINE_INCLUDING
                ||    pLeftChangeTokenBorder 
                   == ChangeTokenBorder.NEXT_NON_HIDDEN_TOKEN_EXCLUDING) {
                // At first search the first non hidden token from left.
                while (startIndex >= 0) {                    
                    IToken token = stream.Get(startIndex);
                    if (token.Channel != TokenChannels.Hidden) {
                        break;
                    }
                    startIndex--;
                }
                startIndex++;
                // If the farthest newline is needed search it from the current
                // position to right.
                if (   pLeftChangeTokenBorder 
                    != ChangeTokenBorder.NEXT_NON_HIDDEN_TOKEN_EXCLUDING) {
                    while (true) {
                        IToken token = stream.Get(startIndex);
                        if (token.Channel != TokenChannels.Hidden) {
                            // The most left token of the node that should get 
                            // removed has been reached again.
                            startIndex = nodeToRemove.TokenStartIndex;
                            break;
                        } else if (Constants.NL.Equals(token.Text)) {
                            if (   pLeftChangeTokenBorder 
                                == ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING) {
                                startIndex++;
                            }
                            break;
                        }
                        startIndex++;
                    }
                }
            } else if (      pLeftChangeTokenBorder 
                          == ChangeTokenBorder.NEXT_NEWLINE_EXCLUDING
                       ||    pLeftChangeTokenBorder 
                          == ChangeTokenBorder.NEXT_NEWLINE_INCLUDING) {
                while (startIndex >= 0) {
                    IToken token = stream.Get(startIndex);
                    if (Constants.NL.Equals(token.Text)) {
                        if (   pLeftChangeTokenBorder 
                            == ChangeTokenBorder.NEXT_NEWLINE_EXCLUDING) {
                            startIndex++;
                        }
                        break;
                    } else if (token.Channel != TokenChannels.Hidden) {
                        // No new line found.
                        startIndex = nodeToRemove.TokenStartIndex;
                        break;
                    }
                    startIndex--;
                }
            } else {
                // TODO  Throw exception for unknown ChangeTokenBorder constant.
            }
        }
        if (pRightChangeTokenBorder != null) {
            stopIndex++;
            if (       pRightChangeTokenBorder 
                    == ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING
                 ||    pRightChangeTokenBorder 
                    == ChangeTokenBorder.FARTHEST_NEWLINE_INCLUDING
                 ||    pRightChangeTokenBorder 
                    == ChangeTokenBorder.NEXT_NON_HIDDEN_TOKEN_EXCLUDING) {
                // At first search the first non hidden token from right.
                while (true) {
                    IToken token = stream.Get(stopIndex);
                    if (   token.Channel != TokenChannels.Hidden
                        || token.Type == CharStreamConstants.EndOfFile)
                    {
                        break;
                    }
                    stopIndex++;
                }
                stopIndex--;
                // If the farthest newline is needed search it from the current
                // position to left.
                if (   pRightChangeTokenBorder 
                    != ChangeTokenBorder.NEXT_NON_HIDDEN_TOKEN_EXCLUDING) {
                    while (true) {
                        IToken token = stream.Get(stopIndex);
                        if (token.Channel != TokenChannels.Hidden) {
                            // The most right token of the node that should get 
                            //removed has been reached again.
                            stopIndex = nodeToRemove.TokenStopIndex;
                            break;
                        } else if (Constants.NL.Equals(token.Text)) {
                            if (   pRightChangeTokenBorder 
                                == ChangeTokenBorder.FARTHEST_NEWLINE_EXCLUDING) {
                                stopIndex--;
                            }
                            break;
                        }
                        stopIndex--;
                    }
                }
            } else if (      pRightChangeTokenBorder 
                          == ChangeTokenBorder.NEXT_NEWLINE_EXCLUDING
                       ||    pRightChangeTokenBorder 
                          == ChangeTokenBorder.NEXT_NEWLINE_INCLUDING) {
                while (true) {
                    IToken token = stream.Get(stopIndex);
                    if (Constants.NL.Equals(token.Text)) {
                        if (   pRightChangeTokenBorder 
                            == ChangeTokenBorder.NEXT_NEWLINE_EXCLUDING) {
                            stopIndex--;
                        }
                        break;
                    } else if (token.Channel != TokenChannels.Hidden) {
                        // No new line found.
                        stopIndex = nodeToRemove.TokenStopIndex;
                        break;
                    }
                    stopIndex++;
                }
            } else {
                // TODO  Throw exception for unknown ChangeTokenBorder constant.
            }
        }
        pNodeToRemove.getTokenRewriteStream().Delete(startIndex, stopIndex);
    }
    
    /**
     * Removes the tree node that belongs to the stated <code>AST2JSOMBase
     * </code> from it's parent tree node. Furthermore the appropriate tokens
     * will be removed from the token stream.
     * 
     * @param pNodeToRemove  The owner of the tree node that should get removed.
     * @param pFromNode If not <code>null</code> all tokens from the right of
     *                  this object up to the tokens that belong to <code>
     *                  pNodeToRemove</code> will be removed, too.
     * @param pToNode  If not <code>null</code> all tokens from the left of
     *                  this object up to the tokens that belong to <code>
     *                  pNodeToRemove</code> will be removed, too.                           
     * 
     * __TEST__
     */
    protected static void removeTreeNode(
            AST2JSOMBase pNodeToRemove, AST2JSOMBase pFromNode, 
            AST2JSOMBase pToNode) {
        
        ITree nodeToRemove = pNodeToRemove.getTreeNode();
        int startIndex = 0;
        int stopIndex = 0;
        if (pFromNode != null) {
            startIndex = pFromNode.getTreeNode().TokenStopIndex + 1;
        } else {
            startIndex = nodeToRemove.TokenStartIndex;
        }
        if (pToNode != null) {
            stopIndex = pToNode.getTreeNode().TokenStartIndex - 1;
        } else {
            stopIndex = nodeToRemove.TokenStopIndex;
        }
        pNodeToRemove.getTokenRewriteStream().Delete(startIndex, stopIndex);
        ITree parent = nodeToRemove.Parent;
        int childCount = parent.ChildCount;
        for (int offset = 0; offset < childCount; offset++) {
            if (parent.GetChild(offset) == nodeToRemove) {
                parent.DeleteChild(offset);
                return;
            }
        }
        // If still here no matching child has been found.
        throw new JSourceObjectizerInternalException(
                CommonJSOMMessages.getChildTreeNodeNotFoundMessage(
                        nodeToRemove.ToString(), parent.ToString()));
    }
    
    /**
     * The implementation of the JSourceObjectizer unmarshaller.
     * 
     * @author habelitz
     */
    protected class JSOMMarshaller : JSourceMarshaller {
        
        private AST2JSOM mJSOM;
        
        /**
         * Constructor.
         * 
         * @param pJSOM  The <code>JSOM</code> object that represents the Java
         *               source that should be rewritten.
         */
        public JSOMMarshaller(AST2JSOM pJSOM) {

            mJSOM = pJSOM;
        }

        /**
         * Returns the parsed Java source as a <code>String</code>.
         * <p>
         * The returned string equals the Java source that would be rewritten by 
         * the method <code>writeJSOM(...)</code>.
         * 
         * @return  The parsed Java source as a <code>String</code>.
         */
       
        public override String ToString() {

            ITree tree = mJSOM.getTreeNode();
            if (tree.Type == JavaTreeParser.JAVA_SOURCE) {
                return mJSOM.getTokenRewriteStream().ToString();
            }
            
            return mJSOM.getTokenRewriteStream().ToString(
                    tree.TokenStartIndex, tree.TokenStopIndex);
        }
    
        /**
         * Writes the parsed Java source to the stated <code>Writer</code> 
         * object.
         * 
         * @param pWriter  The writer the parsed Java source should be written 
         *                 to. 
         * 
         * @throws MarshallerException  if rewriting the Java source has been 
         *                              failed.
         */
        public void writeJSOM(TextWriter pWriter)
        {
            
            try {
                pWriter.Write(ToString());
            } catch (IOException ioe) {
                throw new MarshallerException(
                        MarshallerMessages.getRewritingFailedMessage(), ioe);
            }
        }
    }
    
    /**
     * The purpose of this class is to parse Java sources and transform the 
     * parser results into appropriate <code>AST2JSOM</code> objects.
     * <p>
     * This class is only visible to sub-types of the <code>AST2JSOM</code>
     * type. It's unmarshaller methods return <code>AST2JSOM</code> type 
     * objects. Unmarshaller methods within classes derived from this class
     * should only return <code>JSOM</code> types without the visibility of all
     * the <i>AST2</i> stuff.
     *  
     * __TEST__  Most unmarshalble code fragments still untested for 
     *           unmarshalling failure.
     * 
     * @author Dieter Habelitz
     */
    public /*static*/ class AST2JSOMUnmarshaller : JSOParser {
        
        /**
         * Standard constructor that has namespace scope only.
         */
        public AST2JSOMUnmarshaller() : base(){
            
        }
        
        /**
         * Unmarshals a complete Java source file.
         * 
         * @param pJavaSource  The Java source that should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          ASTJavaSource</code>. If marshalling the file has been
         *          failed but no exception has been thrown <code>null</code>
         *          will be returned and it's very likely that there's at least
         *          one message within the message list passed to this method
         *          (if a list has been passed at all, of course).
         * 
         * @ if marshalling the Java file 
         *                                       failed.
         */
        public AST2JavaSource unmarshalAST2JavaSource(
                JFile pJavaSource, List<String> pErrorMessages) 
        {

            ParserResult parserResult = parse(pJavaSource, pErrorMessages);
            if (parserResult != null) {
                String fileName = pJavaSource.getName();
                int offset = fileName.LastIndexOf(".java");
                if (offset != -1) {
                    fileName = fileName.Substring(0, offset);
                }
                return new AST2JavaSource(
                        parserResult.mTree, fileName, 
                        parserResult.mTokenRewriteStream,
                        parserResult.mLineCount);
            }

            return null;
        }
        
        /**
         * Unmarshals a complete Java source stated as string.
         * 
         * @param pJavaSource  The Java source that should get unmarshalled.
         * @param pJavaSourceIdentifier  The identifier of the Java source.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          ASTJavaSource</code>. If marshalling the file has been
         *          failed but no exception has been thrown <code>null</code>
         *          will be returned and it's very likely that there's at least
         *          one message within the message list passed to this method
         *          (if a list has been passed at all, of course).
         * 
         * @ if marshalling the Java file 
         *                                       failed.
         */
        public AST2JavaSource unmarshalAST2JavaSource(
                String pJavaSource, String pJavaSourceIdentifier,
                List<String> pErrorMessages) 
        {

            ParserResult parserResult = parse(
                    pJavaSource, CodeFragmentType.JAVA_SOURCE, pErrorMessages);
            if (parserResult != null) {
                return new AST2JavaSource(
                        parserResult.mTree, pJavaSourceIdentifier, 
                        parserResult.mTokenRewriteStream,
                        parserResult.mLineCount);
            }

            return null;
        }
        
        /**
         * Unmarshals an annotation stated by a string.
         * 
         * @param pAnnotation  The annotation that should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2Annotation</code>. If marshalling the code fragment has
         *          been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2Annotation unmarshalAST2Annotation(
                String pAnnotation, List<String> pErrorMessages) {
            
            ParserResult parserResult = parse(
                    pAnnotation, CodeFragmentType.ANNOTATION, pErrorMessages);
            if (parserResult != null) {
                return new AST2Annotation(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals an <code>assert</code> statement stated by a string.
         * 
         * @param pAssertStatement  The <code>assert</code> statement that 
         *                          should get unmarshalled. Note that the 
         *                          stated string must include the terminating 
         *                          semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2AssertStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2AssertStatement unmarshalAST2AssertStatement(
                String pAssertStatement, List<String> pErrorMessages) {
            
            ParserResult parserResult = parse(
                    pAssertStatement, CodeFragmentType.ASSERT_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2AssertStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>break</code> statement stated by a string.
         * 
         * @param pBreakStatement  The <code>break</code> statement that should 
         *                         get unmarshalled. Note that the stated string
         *                         must include the terminating semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2BreakStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2BreakStatement unmarshalAST2BreakStatement(
                String pBreakStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pBreakStatement, CodeFragmentType.BREAK_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2BreakStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a class <code>:</code> clause stated as string.
         * 
         * @param pExtendsClause  The class <code>:</code> clause that 
         *                        should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ClassExtendsClause</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ClassExtendsClause unmarshalAST2ClassExtendsClause(
                String pExtendsClause, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pExtendsClause, CodeFragmentType.CLASS_EXTENDS_CLAUSE, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ClassExtendsClause(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a complex type identifier stated as string.
         * 
         * @param pComplexTypeIdentifier  The complex type identifier that 
         *                                should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ComplexTypeIdentifier</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ComplexTypeIdentifier unmarshalAST2ComplexTypeIdentifier(
                String pComplexTypeIdentifier, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pComplexTypeIdentifier, 
                    CodeFragmentType.COMPLEX_TYPE_IDENTIFIER, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ComplexTypeIdentifier(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>continue</code> statement stated by a string.
         * 
         * @param pContinueStatement  The <code>continue</code> statement that
         *                            should get unmarshalled. Note that the
         *                            stated string must include the terminating
         *                            semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ContinueStatement</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ContinueStatement unmarshalAST2ContinueStatement(
                String pContinueStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pContinueStatement, CodeFragmentType.CONTINUE_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ContinueStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>do ... while</code> statement stated by a string.
         * 
         * @param pDoWhileStatement  The <code>do ... while</code> statement 
         *                           that should get unmarshalled. Note that the
         *                           stated string must contain the complete 
         *                           statement including the closing semicolon 
         *                           and the statement following the <code>do
         *                           </code> keyword.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2WhileAndDoStatements</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2WhileAndDoStatements unmarshalAST2DoWhileStatement(
                String pDoWhileStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pDoWhileStatement, CodeFragmentType.DO_WHILE_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2WhileAndDoStatements(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals an enumeration constant stated as string.
         * 
         * @param pEnumConstant  The enumeration constant that should get 
         *                       unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2EnumConstant</code>. 
         * 
         * @ if marshalling the code fragment 
         *                                       failed.
         */
        public AST2EnumConstant unmarshalAST2EnumConstant(
                String pEnumConstant, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pEnumConstant, CodeFragmentType.ENUM_CONSTANT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2EnumConstant(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals any kind of expressions stated by a string.
         * <p>
         * <b>Important note:</b> The given string must represent a complete 
         * expression in a semantical point of view, i.e. an assignment 
         * statement, a 'new' expression, a method call and so on. Unmarshalling
         * of a fraction of a complete expression <i><b>may</b></i> succeed but
         * this is not guaranteed. For instance, unmarshalling just a primary
         * expression representing an array type declaration (something like 
         * <code>anyType[]</code>) will always fail.
         * 
         * @param pExpression  The expression that should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2Expression</code>. 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2Expression unmarshalAST2Expression(
                String pExpression, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pExpression, CodeFragmentType.EXPRESSION, pErrorMessages);
            if (parserResult != null) {
                return AST2Expression.resolveExpression(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals an expression statement stated by a string.
         * <p>
         * An expression statement is a statement that could also be an
         * expression anywhere else. This could be an assignment expression or
         * a method call, for instance.
         * 
         * @param pExpressionStatement  The expression statement that should get
         *                              unmarshalled. Note that the stated 
         *                              string must include the terminating 
         *                              semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ExpressionStatement</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ExpressionStatement unmarshalAST2ExpressionStatement(
                String pExpressionStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pExpressionStatement, CodeFragmentType.EXPRESSION_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ExpressionStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a so called <code>forEach</code> statement stated by a 
         * string.
         * 
         * @param pForEachStatement  The <code>forEach</code> statement that 
         *                           should get unmarshalled. Note that the 
         *                           stated string must also contain the 
         *                           statement following the <code>forEach
         *                           </code> statement.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ForEachStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ForEachStatement unmarshalAST2ForEachStatement(
                String pForEachStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pForEachStatement, CodeFragmentType.FOREACH_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ForEachStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a formal parameter list stated by a string.
         * 
         * @param pFormalParameterList  The formal parameter list that should 
         *                              get unmarshalled. Note that this must be
         *                              a complete formal parameter list 
         *                              containing 0 or more formal parameter
         *                              declarations enclosed within
         *                              parentheses.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2FormalParameterList</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2FormalParameterList unmarshalAST2FormalParameterList(
                String pFormalParameterList, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pFormalParameterList, 
                    CodeFragmentType.FORMAL_PARAMETER_LIST, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2FormalParameterList(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>for</code> statement stated by a string.
         * <p>
         * This method can't be used to unmarshal a so called <code>
         * forEach</code> statement. For <code>forEach</code> statements use the
         * method {@link #unmarshalAST2ForEachStatement(String, List)}.
         * 
         * @param pForStatement  The <code>for</code> statement that should get
         *                       unmarshalled. Note that the stated string must 
         *                       also contain the statement following the <code>
         *                       for</code> statement.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2IfStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ForStatement unmarshalAST2ForStatement(
                String pForStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pForStatement, CodeFragmentType.FOR_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ForStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a generic type argument list stated as string.
         * <p>
         * Note that this method doesn't return an object representing a 
         * generic type argument list. Instead the generic type arguments will 
         * be resolved from the parsed generic type argument list and these 
         * resolved generic type arguments will be returned.
         * 
         * @param pGenericTypeArgumentList  The generic type argument list that 
         *                                  should get unmarshalled. Note that 
         *                                  this must be a complete generic type
         *                                  list including the angle brackets.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A list containing one or more <code>JSOM</code> objects of 
         *          type <code>AST2GenericTypeArgument</code> resolved from the 
         *          given generic type argument list. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public List<AST2GenericTypeArgument> 
        unmarshalAST2GenericTypeArgumentList(
                String pGenericTypeArgumentList, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pGenericTypeArgumentList, 
                    CodeFragmentType.GENERIC_TYPE_ARGUMENT_LIST,
                    pErrorMessages);
            if (parserResult != null) {
                return AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a generic type parameter list stated as string.
         * <p>
         * Note that this method doesn't return an object representing a generic
         * type parameter list. Instead the generic type parameters will be 
         * resolved from the parsed generic type parameter list and these 
         * resolved generic type parameters will be returned.
         * 
         * @param pGenericTypeParameterList  The generic type parameter list 
         *                                   that should get unmarshalled. Note
         *                                   that this must be a complete
         *                                   generic type parameter list
         *                                   including the angle brackets.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A list containing one or more <code>JSOM</code> objects of
         *          type <code>AST2GenericTypeParameter</code> resolved from the
         *          given generic type parameter list. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public List<AST2GenericTypeParameter> 
        unmarshalAST2GenericTypeParameterList(
                String pGenericTypeParameterList, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pGenericTypeParameterList, 
                    CodeFragmentType.GENERIC_TYPE_PARAMETER_LIST,
                    pErrorMessages);
            if (parserResult != null) {
                return AST2GenericTypeParameter.resolveGenericTypeParameterList(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals an <code>if</code> statement stated by a string.
         * 
         * @param pIfStatement  The <code>if</code> statement that should get
         *                      unmarshalled. Note that the stated string must 
         *                      also contain the statement following the <code>
         *                      if</code> statement.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2IfStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2IfStatement unmarshalAST2IfStatement(
                String pIfStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pIfStatement, CodeFragmentType.IF_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2IfStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals an <code>,</code> clause stated as string.
         * 
         * @param pImplementsClause  The <code>,</code> clause that 
         *                           should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ImplementsClause</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ImplementsClause unmarshalAST2ImplementsClause(
                String pImplementsClause, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pImplementsClause, CodeFragmentType.IMPLEMENTS_CLAUSE, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ImplementsClause(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        public AST2PackageDeclaration unmarshalAST2PackageDeclaration(
                String pPackageDeclaration, List<String> pErrorMessages)
        {

            ParserResult parserResult = parse(
                    pPackageDeclaration, CodeFragmentType.IMPORT_DECLARATION,
                    pErrorMessages);
            if (parserResult != null)
            {
                return new AST2PackageDeclaration(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }

            return null;
        }

        /**
         * Unmarshals an <code>import</code> declaration stated as string.
         * 
         * @param pImportDeclaration  The import declaration that should get 
         *                            unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ImportDeclaration</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ImportDeclaration unmarshalAST2ImportDeclaration(
                String pImportDeclaration, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pImportDeclaration, CodeFragmentType.IMPORT_DECLARATION, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ImportDeclaration(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals an interface <code>:</code> clause stated as string.
         * 
         * @param pExtendsClause  The interface <code>:</code> clause that 
         *                        should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2InterfaceExtendsClause</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2InterfaceExtendsClause unmarshalAST2InterfaceExtendsClause(
                String pExtendsClause, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pExtendsClause, CodeFragmentType.INTERFACE_EXTENDS_CLAUSE, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2InterfaceExtendsClause(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a labeled statement stated by a string.
         * 
         * @param pLabeledStatement  The labeled statement that should get 
         *                           unmarshalled. Note that the stated string
         *                           must include the colon following the label
         *                           identifier and the statement following the
         *                           colon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2LabeledStatement</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2LabeledStatement unmarshalAST2LabeledStatement(
                String pLabeledStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pLabeledStatement, CodeFragmentType.LABELED_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2LabeledStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a local class declaration stated as string.
         * 
         * @param pClassDeclaration  The local class declaration that should get 
         *                           unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2LocalClassDeclaration</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed or if the
         *                                       stated type declaration doesn't
         *                                       represent a class declaration.
         */
        public AST2LocalClassDeclaration unmarshalAST2LocalClassDeclaration(
                String pClassDeclaration, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pClassDeclaration, 
                    CodeFragmentType.TYPE_DECLARATION, pErrorMessages);
            if (parserResult != null) {
                if (parserResult.mTree.Type == JavaTreeParser.CLASS) {
                    return new AST2LocalClassDeclaration(
                            parserResult.mTree,
                            parserResult.mTokenRewriteStream);
                }
                // TODO  Internationalize the error message.
                throw new JSourceObjectizerInternalException(
                        "Unsupported type declaration type '" +
                        parserResult.mTree.Type + "'.");
            }
            
            return null;
        }
        
        /**
         * Unmarshals a local variable declaration, with or without an
         * initializer.
         * 
         * @param pVariableDeclaration  The local variable declaration that 
         *                              should get get unmarshalled. Note that
         *                              the given string must include the 
         *                              terminating semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2LocalVariableDeclaration</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2LocalVariableDeclaration 
        unmarshalAST2LocalVariableDeclaration(
                String pVariableDeclaration, List<String> pErrorMessages)
        {
            
            ParserResult parserResult = parse(
                    pVariableDeclaration, 
                    CodeFragmentType.LOCAL_VARIABLE_DECLARATION, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2LocalVariableDeclaration(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a modifier list stated by a string.
         * 
         * @param pModifierList  The modifier list that should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ModifierList</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ModifierList unmarshalAST2ModifierList(
                String pModifierList, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pModifierList, CodeFragmentType.MODIFIER_LIST, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ModifierList(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
         
        /**
         * Unmarshals a primitive type stated by a string.
         * 
         * @param pPrimitiveType  The primitive type that should get
         *                        unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2PrimitiveType</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2PrimitiveType unmarshalAST2PrimitiveType(
                String pPrimitiveType, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pPrimitiveType, CodeFragmentType.PRIMITIVE_TYPE, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2PrimitiveType(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
         
        /**
         * Unmarshals a simple qualified identifier, i.e. something that 
         * typically occurs for namespace and import declarations.
         * 
         * @param pQualifiedIdentifier  The qualified identifier that should get
         *                              unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2QualifiedIdentifier</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2QualifiedIdentifier unmarshalAST2QualifiedIdentifier(
                String pQualifiedIdentifier, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pQualifiedIdentifier, CodeFragmentType.QUALIFIED_IDENTIFIER, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2QualifiedIdentifier(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals a <code>return</code> statement stated by a string.
         * 
         * @param pReturnStatement  The <code>return</code> statement that 
         *                          should get unmarshalled. Note that the 
         *                          stated string must include the terminating 
         *                          semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ReturnStatement</code>. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ReturnStatement unmarshalAST2ReturnStatement(
                String pReturnStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pReturnStatement, CodeFragmentType.RETURN_STATEMENT, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ReturnStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a statement stated as string.
         * <p>
         * Note that this doesn't include any element that may occur within a
         * compound statement block, i.e. only real statements can get 
         * unmarshalled by this this method but no local variables or local 
         * class declarations.
         * 
         * @param pStatement  The statement that should get unmarshalled. Note
         *                    that the given string must include the terminating
         *                    semicolon.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2Statement</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2Statement unmarshalAST2Statement(
                String pStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pStatement, CodeFragmentType.STATEMENT, pErrorMessages);
            if (parserResult != null) {
                return AST2Statement.resolveStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a compound statement block.
         * <p>
         * Note that the owner of the returned object will be <code>
         * Owner.COMPOUND_STATEMENT</code>.
         * 
         * @param pCompoundStatement  The compound statement that should get
         *                            unmarshalled. Note that the given string 
         *                            must contain the opening and closing
         *                            curly brackets.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2Statement</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2StatementBlockScope unmarshalAST2StatementBlock(
                String pCompoundStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pCompoundStatement, 
                    CodeFragmentType.STATEMENT_BLOCK, pErrorMessages);
            if (parserResult != null) {
                return new AST2StatementBlockScope(
                        parserResult.mTree, Owner.COMPOUND_STATEMENT, 
                        parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals any kind of statement block elements stated by a string.
         * <p>
         * Note that it's up to the caller to find out if the returned object
         * represents a local variable declaration, a local class declaration or
         * a statement (if this is of interest at all).
         * 
         * @param pStatementBlockElement  The statement block element that 
         *                                should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2StatementBlockElement</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2StatementBlockElement unmarshalAST2StatementBlockElement(
                String pStatementBlockElement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pStatementBlockElement, 
                    CodeFragmentType.STATEMENT_BLOCK_ELEMENT, pErrorMessages);
            if (parserResult != null) {
                if (   parserResult.mTree.Type 
                    == JavaTreeParser.VAR_DECLARATION) {
                    return new AST2LocalVariableDeclaration(
                            parserResult.mTree, 
                            parserResult.mTokenRewriteStream);
                } else if (   parserResult.mTree.Type 
                           == JavaTreeParser.CLASS) {
                    return new AST2LocalClassDeclaration(
                            parserResult.mTree, 
                            parserResult.mTokenRewriteStream);
                } else {
                    return AST2Statement.resolveStatement(
                            parserResult.mTree, 
                            parserResult.mTokenRewriteStream);
                }
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>case</code> label of a <code>switch</code> 
         * statement stated by a string.
         * <p>
         * This includes the optional statement block elements that may follow
         * the <code>case</code> label.
         * 
         * @param pSwitchCaseLabel  The <code>case</code> label that should get
         *                          unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2SwitchStatement.SwitchLabelImpl</code> representing a
         *          <code>case</code> label. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2SwitchLabel unmarshalAST2SwitchStatementCaseLabel(
                String pSwitchCaseLabel, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pSwitchCaseLabel, CodeFragmentType.SWITCH_CASE_LABEL,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2SwitchStatement.AST2SwitchLabel(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>default</code> label of a <code>switch</code> 
         * statement stated by a string.
         * <p>
         * This includes the optional statement block elements that may follow
         * the <code>default</code> label.
         * 
         * @param pSwitchDefaultLabel  The <code>default</code> label that
         *                             should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2SwitchStatement.SwitchLabelImpl</code> representing a
         *          <code>default</code> label. If marshalling the code fragment
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2SwitchLabel unmarshalAST2SwitchStatementDefaultLabel(
                String pSwitchDefaultLabel, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pSwitchDefaultLabel, CodeFragmentType.SWITCH_DEFAULT_LABEL,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2SwitchStatement.AST2SwitchLabel(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>switch</code> statement stated by a string.
         * 
         * @param pSwitchStatement  The <code>switch</code> statement that
         *                          should get unmarshalled. Note that the 
         *                          stated string must contain the complete 
         *                          statement including the <code>switch</code>
         *                          expression and the <code>case</code> block
         *                          following - even then if the block should be
         *                          empty.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2SwitchStatement</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2SwitchStatement unmarshalAST2SwitchStatement(
                String pSwitchStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pSwitchStatement, CodeFragmentType.SWITCH_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2SwitchStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>synchronized</code> statement stated by a string.
         * 
         * @param pSynchronizedStatement  The <code>synchronized</code>
         *                                statement that should get 
         *                                unmarshalled. Note that the stated
         *                                string must contain the complete 
         *                                statement including the parenthesized
         *                                elements and the statement block to 
         *                                synchronize.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2SynchronizedStatement</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2SynchronizedStatement unmarshalAST2SynchronizedStatement(
                String pSynchronizedStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pSynchronizedStatement, 
                    CodeFragmentType.SYNCHRONIZED_STATEMENT, pErrorMessages);
            if (parserResult != null) {
                return new AST2SynchronizedStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals a <code>throw</code> statement stated by a string.
         * 
         * @param pThrowStatement  The <code>throw</code> statement that should
         *                         get unmarshalled. Note that the stated string
         *                         must contain the complete statement including
         *                         the closing semicolon and the expression
         *                         that states the object to throw.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ThrowStatement</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ThrowStatement unmarshalAST2ThrowStatement(
                String pThrowStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pThrowStatement, CodeFragmentType.THROW_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ThrowStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals a <code>throws</code> clause stated as string.
         * 
         * @param pThrowsClause  The <code>throws</code> clause that should get
         *                       unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2ThrowsClause</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2ThrowsClause unmarshalAST2ThrowsClause(
                String pThrowsClause, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pThrowsClause, CodeFragmentType.THROWS_CLAUSE, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2ThrowsClause(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals a <code>try</code> statement stated by a string.
         * 
         * @param pTryStatement  The <code>try</code> statement that should get
         *                       unmarshalled. Note that the stated string must
         *                       contain the complete statement including a
         *                       <code>catch</code> clause and/or a <code>
         *                       finally</code> clause and including the
         *                       statement blocks following the the <code>
         *                       try/catch/finally</code> keywords.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2TryStatement</code>. If marshalling the code fragment 
         *          has been failed but no exception has been thrown <code>null
         *          </code> will be returned and it's very likely that there's
         *          at least one message within the message list passed to this
         *          method (if a list has been passed at all, of course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2TryStatement unmarshalAST2TryStatement(
                String pTryStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pTryStatement, CodeFragmentType.TRY_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2TryStatement(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a <code>catch</code> clause of a <code>try</code>
         * statement stated by a string.
         * 
         * @param pCatchClause  The <code>catch</code> clause that should get
         *                      unmarshalled. Note that the stated string must
         *                      contain the complete <code>catch</code> clause
         *                      including the statement block scope.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2TryStatement.CatchImpl</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2TryStatement.AST2Catch unmarshalAST2TryStatementCatchClause(
                String pCatchClause, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pCatchClause, CodeFragmentType.TRY_STATEMENT_CATCH_CLAUSE,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2TryStatement.AST2Catch(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * Unmarshals a primitive or complex type including static arrays stated 
         * as string.
         * 
         * @param pType  The type that should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>AST2Type</code>.
         *          If marshalling the code fragment has been failed but no 
         *          exception has been thrown <code>null</code> will be returned
         *          and it's very likely that there's at least one message
         *          within the message list passed to this method (if a list has
         *          been passed at all, of course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2Type unmarshalAST2Type(
                String pType, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = 
                parse(pType, CodeFragmentType.TYPE, pErrorMessages);
            if (parserResult != null) {
                return new AST2Type(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals any kind of type declarations stated as string.
         * <p>
         * Note that this method shouldn't be used to create local class
         * declarations. Do do this the methods 
         * {@link #unmarshalAST2LocalClassDeclaration(String, List)} or even
         * {@link #unmarshalAST2StatementBlockElement(String, List)} should be
         * used instead.
         * 
         * @param pTypeDeclaration  The type declaration that should get 
         *                          unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2CommonTypeDeclaration</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of 
         *          course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2CommonTypeDeclaration unmarshalAST2TypeDeclaration(
                String pTypeDeclaration, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pTypeDeclaration, 
                    CodeFragmentType.TYPE_DECLARATION, pErrorMessages);
            if (parserResult != null) {
                if (parserResult.mTree.Type == JavaTreeParser.CLASS) {
                    return new AST2ClassDeclaration(
                            parserResult.mTree,
                            parserResult.mTokenRewriteStream);
                } else if (   parserResult.mTree.Type 
                           == JavaTreeParser.INTERFACE) {
                    return new AST2InterfaceDeclaration(
                            parserResult.mTree,
                            parserResult.mTokenRewriteStream);
                } else if (parserResult.mTree.Type == JavaTreeParser.ENUM) {
                    return new AST2EnumDeclaration(
                         parserResult.mTree,
                         parserResult.mTokenRewriteStream);
                } else if (parserResult.mTree.Type == JavaTreeParser.AT) {
                    return new AST2AnnotationDeclaration(
                         parserResult.mTree,
                         parserResult.mTokenRewriteStream);
                } else {
                    // TODO  Internationalize the error message.
                    throw new JSourceObjectizerInternalException(
                            "Unsupported type declaration type '" +
                            parserResult.mTree.Type + "'.");
                }
            }
            
            return null;
        }
        
        /**
         * Unmarshals a variable declarator identifier.
         * <p>
         * These are identifiers of type fields, local variables and formal 
         * parameters followed by 0 or more array declarators.
         * 
         * @param pVariableDeclaratorIdentifier  The variable identifier that 
         *                                       should get unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2VariableDeclaratorIdentifier</code>. If marshalling the
         *          code fragment has been failed but no exception has been 
         *          thrown <code>null</code> will be returned and it's very 
         *          likely that there's at least one message within the message
         *          list passed to this method (if a list has been passed at
         *          all, of course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2VariableDeclaratorIdentifier 
        unmarshalAST2VariableDeclaratorIdentifier(
                String pVariableDeclaratorIdentifier, 
                List<String> pErrorMessages)
        {
            
            ParserResult parserResult = parse(
                    pVariableDeclaratorIdentifier, 
                    CodeFragmentType.VARIABLE_DECLARATOR_IDENTIFIER, 
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2VariableDeclaratorIdentifier(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
        
        /**
         * 
         * Unmarshals a variable initializer.
         * 
         * @param pVariableInitializer  The variable initializer that should get 
         *                              unmarshalled.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and
         *                        each list entry will correspond to one error
         *                        line as reported by the parser.
         *                        
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2VariableInitializer</code>. If marshalling the code 
         *          fragment has been failed but no exception has been thrown 
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course). 
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2VariableInitializer unmarshalAST2VariableInitializer(
                String pVariableInitializer, List<String> pErrorMessages)
        {
            
            ParserResult parserResult = parse(
                    pVariableInitializer, 
                    CodeFragmentType.VARIABLE_INITIALIZER, pErrorMessages);
            if (parserResult != null) {
                return new AST2VariableInitializer(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }

        /**
         * Unmarshals a <code>while</code> statement stated by a string.
         * 
         * @param pWhileStatement  The <code>while</code> statement that should
         *                         get unmarshalled. Note that the stated string
         *                         must also contain the statement following the
         *                         <code>while</code> statement.
         * @param pErrorMessages  If the parser reports one or more errors it
         *                        depends on this argument what will happen. If 
         *                        this argument is <code>null</code> all the 
         *                        error messages will be written to <code>
         *                        System.err</code>. Otherwise the error 
         *                        messages will be added to the given list and 
         *                        each list entry will correspond to one error 
         *                        line as reported by the parser.
         * 
         * @return  A <code>JSOM</code> object of type <code>
         *          AST2WhileAndDoStatements</code>. If marshalling the code
         *          fragment has been failed but no exception has been thrown
         *          <code>null</code> will be returned and it's very likely that
         *          there's at least one message within the message list passed
         *          to this method (if a list has been passed at all, of
         *          course).
         * 
         * @ if marshalling the code 
         *                                       fragment failed.
         */
        public AST2WhileAndDoStatements unmarshalAST2WhileStatement(
                String pWhileStatement, List<String> pErrorMessages)
            {
            
            ParserResult parserResult = parse(
                    pWhileStatement, CodeFragmentType.WHILE_STATEMENT,
                    pErrorMessages);
            if (parserResult != null) {
                return new AST2WhileAndDoStatements(
                        parserResult.mTree, parserResult.mTokenRewriteStream);
            }
            
            return null;
        }
    }
}
}