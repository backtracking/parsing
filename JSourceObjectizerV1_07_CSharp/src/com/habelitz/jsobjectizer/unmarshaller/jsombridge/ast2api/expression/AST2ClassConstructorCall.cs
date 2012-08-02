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
using com.habelitz.jsobjectizer.jsom.api.expression;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression {
/**
 * This <code>PrimaryExpression</code> type represents a <code>new</code>
 * expression via a class constructor invocation, i.e. something like <code>
 * 'new AnyClassType(constructorArgs)'</code>.
 * <p>      
 * This class also supports <i>inner new expressions</code> for creating
 * instances of an inner member class from outside the outer class.
 * <pre>
 *  OuterType outer = new OuterType();
 *  InnerType inner = outer.new InnerType(); // 'InnerType' is an inner member
 *                                           // class within 'OuterType'.
 * </pre>
 * The difference between the two constructor invocation variants is that
 *  <ul>
 *      <li>
 *          inner new expressions are preceded by a primary expression (which is
 *          not a member of this class!) and ...
 *      </li>
 *      <li>
 *          ... the constructor's name is never a qualified identifier, but 
 *          always just a simple identifier.
 *      </li>
 *  </ul> 
 * 
 * @see StaticArrayCreator  for <code>new</code> expressions that instantiate 
 *                          static arrays.
 *       
 * @author Dieter Habelitz
 */
public class AST2ClassConstructorCall : AST2PrimaryExpression , ClassConstructorCall {

    // The constructor call's optional arguments.
    private List<Expression> mArguments;
    // The optional generic type arguments.
    private List<AST2GenericTypeArgument> mGenericTypeArguments;
    // The type identifier for normal constructor calls.
    private List<AST2ComplexTypeIdentifier> mQualifiedTypeIdentifier;
    // The optional class top level scope for anonymous classes.
    private AST2ClassTopLevelScope mTopLevelScope;
    
    // Remember some child nodes from the 'CLASS_CONSTRUCTOR_CALL' node.
    
    private AST2JSOMTree mGenericTypeArgumentListTree;
    // Is expected to be 'null' for inner new expressions.
    private AST2JSOMTree mQualifiedTypeIdentTree;
    // is expected to be the type identifier the constructor is called for.
    private AST2JSOMTree mIdentifierTree;
    private AST2JSOMTree mArgumentListTree;
    private AST2JSOMTree mClassScopeDeclTree;
    
    /**
     * Constructor.
     * 
     * @param pTree  The root tree representing a class constructor call.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ClassConstructorCall(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ExpressionType.CLASS_CONSTRUCTOR_CALL,pTokenRewriteStream)
    {
        
        if (pTree.Type != JavaTreeParser.CLASS_CONSTRUCTOR_CALL) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        // Get the optional generic type argument list. If there is no such list
        // it's the identifier.
        int offset = 0;
        AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(offset);
        if (child.Type == JavaTreeParser.GENERIC_TYPE_ARG_LIST) {
            // Remember the generic type argument list.
            mGenericTypeArgumentListTree = child;
            // Switch forward to the identifier.
            offset++;
            child = (AST2JSOMTree)pTree.GetChild(offset);
        }
        if (child.Type != JavaTreeParser.IDENT) {
            // 'mIdentifierTree' must get resolved just in time.
            mQualifiedTypeIdentTree = child;
        } else {
            // 'mQualifiedTypeIdentTree' remains 'null' for inner new
            // expressions.
            mIdentifierTree = child;
        }
        // If there are arguments get and remember them.
        offset++;
        mArgumentListTree = (AST2JSOMTree)pTree.GetChild(offset);
        if (mArgumentListTree.ChildCount == 0) {
            mArgumentListTree = null;
        }
        // Get and remember optional class scope declarations.
        offset++;
        if (offset == pTree.ChildCount - 1) {
            mClassScopeDeclTree = (AST2JSOMTree)pTree.GetChild(offset);
        }
    }

    /**
     * Returns a list of the constructor call's arguments.
     * <p>
     * Calling this method equals an <code>getArguments(null)</code> call.
     * 
     * @see #getArguments(List)
     *  
     * @return  A list of the constructor call's arguments. If there are no
     *          arguments <code>null</code> will be returned. 
     */
    public List<Expression> getArguments() {
        
        return getArguments(null);
    }

    /**
     * Returns a list of the constructor call's arguments.
     * 
     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the constructor call's arguments. If there are no
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    public List<Expression> getArguments(List<Expression> pList) {

        if (mArgumentListTree == null) {
            return null; // There're no arguments.
        }
        if (mArguments == null) {
            resolveArguments();
        }
        List<Expression> result = pList;
        if (result == null) {
            result = new List<Expression>(mArguments.Count);
        }
        result.AddRange(mArguments);
        
        return result;
    }

    /**
     * Returns the <i>character in line</i> position where the type identifier 
     * starts.
     * 
     * @return  The <i>character in line</i> position where the type identifier 
     *          starts.
     */
    public int getCharPositionInLine() {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }

        return mIdentifierTree.CharPositionInLine;
    }
    
    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the constructor invocation.
     * <p>
     * Example: <code>new &lt;T1&gt; Foo&lt;T2&gt;(anyArgs)</code>
     * <p>
     * For the example above this method would return list that contains just 
     * one generic type parameter that represents the type <code>T1</code> 
     * stated by <code>&lt;T1&gt;</code>. The generic type argument <code>
     * &lt;T2&gt;</code> would be part of the qualified identifier.
     * <p>
     * Calling this method equals an <code>getGenericTypeArguments(null)</code>
     * call.
     * 
     * @see #getGenericTypeArguments(List)
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned. 
     */
    public List<GenericTypeArgument> getGenericTypeArguments() {
        
        return getGenericTypeArguments(null);
    }
    
    /**
     * Returns a list of generic type arguments that may have been stated with 
     * the constructor invocation.
     * <p>
     * Example: <code>new &lt;T1&gt; Foo&lt;T2&gt;(anyArgs)</code>
     * <p>
     * For the example above this method would return list that contains just 
     * one generic type parameter that represents the type <code>T1</code> 
     * stated by <code>&lt;T1&gt;</code>. The generic type argument <code>
     * &lt;T2&gt;</code> would be part of the qualified identifier.

     * @param  pList  If this argument isn't <code>null</code> the arguments
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of generic type arguments. If there are no generic type
     *          arguments <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>. 
     */
    public List<GenericTypeArgument> getGenericTypeArguments(
            List<GenericTypeArgument> pList) {
    
        if (mGenericTypeArgumentListTree == null) {
            return null; // There're no generic type arguments.
        }
        if (mGenericTypeArguments == null) {
            mGenericTypeArguments = 
                AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                        mGenericTypeArgumentListTree, getTokenRewriteStream());
        }
        List<GenericTypeArgument> result = pList;
        if (result == null) {
            result = new List<GenericTypeArgument>(
                    mGenericTypeArguments.Count);
        }
        result.AddRange(mGenericTypeArguments);
        
        return result;
    }
    
    /**
     * If <code>this</code> represents an <i>inner new expression</code>) this 
     * method returns the identifier of the constructor. Otherwise, i.e. for
     * normal constructor calls, the last identifier from the qualified
     * identifier will be returned.
     * 
     * @see  ClassConstructorCall#getGenericTypeArguments()
     * 
     * @return  The identifier of the constructor, i.e. the type of the new
     *          instance.
     */
    public String getIdentifier() {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }

        return mIdentifierTree.Text;
    }
    
    /**
     * Returns the line number of the type identifier.
     * 
     * @return  The line number of the type identifier.
     */
    public int getLineNumber() {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }

        return mIdentifierTree.Line;
    }

    /**
     * If <code>this</code> represents a standard constructor call (i.e. not the
     * constructor call of an <i>inner new expression</code>) this method
     * returns a list of identifiers representing a qualified identifier.
     * <p>
     * The first entry is the most left identifier and the last one is the type 
     * (i.e. the constructor) identifier. For the most trivial case only one
     * identifier, the type identifier, will be added to the list.
     * <p>
     * Calling this method equals an <code>getQualifiedTypeIdentifier(null)
     * </code> call.
     * 
     * @see #getQualifiedTypeIdentifier(List)
     * @see  ClassConstructorCall#getIdentifier()
     * 
     * @return  A list of identifiers representing a qualified identifier. If 
     *          'isInnerNewExpression() == true'</code> <code>null</code> will 
     *          be returned.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier() {
        
        return getQualifiedTypeIdentifier(null);
    }

    /**
     * If <code>this</code> represents a standard constructor call (i.e. not the
     * constructor call of an <i>inner new expression</code>) this method
     * returns a list of identifiers representing a qualified identifier.
     * <p>
     * The first entry is the most left identifier and the last one is the type 
     * (i.e. the constructor) identifier. For the most trivial case only one
     * identifier, the type identifier, will be added to the list.
     * 
     * @see  ClassConstructorCall#getIdentifier()
     * 
     * @param  pList  If this argument isn't <code>null</code> the identifiers
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *                
     * @return  A list of identifiers representing a qualified identifier. If 
     *          'isInnerNewExpression() == true'</code> <code>null</code> will 
     *          be returned, even if the argument <code>pList</code> isn't 
     *          <code>null</code>.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
            List<ComplexTypeIdentifier> pList) {

        if (mQualifiedTypeIdentTree == null) {
            return null;
        }
        if (mQualifiedTypeIdentifier == null) {
            resolveIdentifier();
        }
        List<ComplexTypeIdentifier> result = pList;
        if (result == null) {
            result = new List<ComplexTypeIdentifier>(
                    mQualifiedTypeIdentifier.Count);
        }
        result.AddRange(mQualifiedTypeIdentifier);
        
        return result;
    }

    /**
     * If an anonymous class declaration follows the constructor call this
     * method returns the appropriate <code>ClassTopLevelScope</code> object.
     * 
     * @return  A <code>ClassTopLevelScope</code> object if an anonymous class 
     *          declaration follows the constructor call but <code>null</code>
     *          otherwise.
     */
    public ClassTopLevelScope getTopLevelScope()
    {
        
        if (mClassScopeDeclTree == null) {
            return null; // There's no class scope.
        }
        if (mTopLevelScope == null) {
            mTopLevelScope = new AST2ClassTopLevelScope(
                    mClassScopeDeclTree, this, getTokenRewriteStream());
        }
        
        return mTopLevelScope;
    }

    /**
     * Tells if the constructor call has at least one argument.
     * 
     * @return  <code>true</code> if the constructor call has at least one 
     *          argument.
     */
    public bool hasArgument() {
        
        return mArgumentListTree != null;
    }
    
    /**
     * Tells if <code>this</code> has at least one generic type argument.
     * 
     * @return  <code>true</code> if <code>this</code> has at least one generic
     *          type argument.
     */
    public bool hasGenericTypeArgument() {
        
        return mGenericTypeArgumentListTree != null;
    }

    /**
     * Tells if the class constructor call is followed by an anonymous class
     * definition.
     * 
     * @return  <code>true</code> if the class constructor call is followed by
     *          an anonymous class definition.
     */
    public bool isAnonymousClassCreator() {
        
        return mClassScopeDeclTree != null;
    }
    
    /**
     * Tells if <code>this</code> represents an <i>inner new expression</i> or
     * not.
     * 
     * @return  <code>true</code> if <code>this</code> represents an <i>inner 
     *          new expression</i>.
     */
    public bool isInnerNewExpression() {
        
        return mQualifiedTypeIdentTree == null;
    }

    /**
     * Resolves the arguments.
     * <p>
     * Note that it's up to the caller to ensure that there's at least one
     * argument.
     */
    private void resolveArguments() {
        
        int numberOfArgs = mArgumentListTree.ChildCount;
        mArguments = new List<Expression>(numberOfArgs);
        for (int offset = 0; offset < numberOfArgs; offset++) {
            mArguments.Add(AST2Expression.resolveExpression((AST2JSOMTree)
                    mArgumentListTree.GetChild(offset), 
                    getTokenRewriteStream()));
        }
    }

    /**
     * Resolves the identifier of the called method.
     */
    private void resolveIdentifier() {
        
        if (mIdentifierTree == null) {
            if (mQualifiedTypeIdentifier == null) {
                mQualifiedTypeIdentifier = 
                    AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier(
                            mQualifiedTypeIdentTree, getTokenRewriteStream());
            }
            mIdentifierTree = (AST2JSOMTree)mQualifiedTypeIdentifier[mQualifiedTypeIdentifier.Count - 1]
                .getTreeNode();
        }
    }
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new identifier of the constructor call.
     * 
     * @return  The old identifier.
     */
    public String setIdentifier(String pNewIdentifier) {
        
        if (mIdentifierTree == null) {
            resolveIdentifier();
        }
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
            if (mGenericTypeArgumentListTree != null) {
                if (mGenericTypeArguments == null) {
                    mGenericTypeArguments = 
                        AST2GenericTypeArgument.resolveGenericTypeArgumentList(
                                mGenericTypeArgumentListTree, 
                                getTokenRewriteStream());
                }
                foreach (GenericTypeArgument arg in mGenericTypeArguments) {
                    arg.traverseAll(pAction);
                }
            }
            if (!isInnerNewExpression()) {
                foreach (ComplexTypeIdentifier id in getQualifiedTypeIdentifier()) {
                    id.traverseAll(pAction);
                }
            }
            if (mArgumentListTree != null) {
                if (mArguments == null) {
                    resolveArguments();
                }
                foreach (Expression expression in mArguments) {
                    expression.traverseAll(pAction);
                }
            }
            ClassTopLevelScope scope = getTopLevelScope();
            if (scope != null) {
                scope.traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}