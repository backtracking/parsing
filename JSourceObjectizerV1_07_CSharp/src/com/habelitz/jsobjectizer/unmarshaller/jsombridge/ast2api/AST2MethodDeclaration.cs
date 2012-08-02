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

using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using MethodDeclaration = com.habelitz.jsobjectizer.jsom.api.MethodDeclaration;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api 
{
/**
 * This <code>JSOM</code> type represents a method declarations.
 * 
 * @author Dieter Habelitz
 */
public class AST2MethodDeclaration : AST2CommonMethodOrConstructorDeclaration , MethodDeclaration {

    // The method's return type (if it's not a void method).
    private Type mReturnType;
    // The number of optional array declarators following the formal parameter
    // list.
    private int mNumberOfArrayDeclarators;
    
    // Some children from the method declaration tree.
    private AST2JSOMTree mReturnTypeTree;
    private AST2JSOMTree mIdentifierTree;
    
    /**
     * Constructor.
     * <p>
     * This constructor is used to create a <code>JSOM</code> object 
     * representing an abstract method, i.e. a method not having a statement
     * scope.
     * 
     * @param pTree  The tree node representing a method declaration.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2MethodDeclaration(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : this(pTree, JSOMType.METHOD_DECLARATION, pTokenRewriteStream)
    {
        
       
    }

    /**
     * Constructor.
     * <p>
     * This constructor is used to create a <code>JSOM</code> object 
     * representing a more or less detailed method declaration. An example would
     * be a method definition, i.e. a method signature followed by a statement
     * block scope.
     * 
     * @param pTree  The tree node representing a method declaration.
     * @param pJSOMType  One of the <code>JSOMType.???</code> constants defined
     *                   by the interface <code>JSOM</code>.              
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    protected AST2MethodDeclaration(
            AST2JSOMTree pTree, JSOMType pJSOMType, 
            TokenRewriteStream pTokenRewriteStream)
        : base(pTree, pJSOMType, pTokenRewriteStream)
    {
        if (pTree.Type == JavaTreeParser.FUNCTION_METHOD_DECL) {
            // Get the type child.
            int offset = 1;
            AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(offset);
            if (child.Type == JavaTreeParser.GENERIC_TYPE_PARAM_LIST) {
                offset++;
                child = (AST2JSOMTree)pTree.GetChild(offset);
            }
            mReturnTypeTree = child;
            // Get the identifier.
            offset++;
            mIdentifierTree = (AST2JSOMTree)pTree.GetChild(offset);
            // Is there an array declarator list behind the formal parameter
            // list?
            offset += 2;
            if (offset < pTree.ChildCount) {
                child = (AST2JSOMTree)pTree.GetChild(offset);
                if (child.Type == JavaTreeParser.ARRAY_DECLARATOR_LIST) {
                    mNumberOfArrayDeclarators = child.ChildCount;
                }
            }
        } else if (pTree.Type == JavaTreeParser.VOID_METHOD_DECL) {
            // For void method only the identifier must be fetched.
            AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(1);
            if (child.Type == JavaTreeParser.GENERIC_TYPE_PARAM_LIST) {
                child = (AST2JSOMTree)pTree.GetChild(2);
            }
            mIdentifierTree = child;
        } else {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
        
    /**
     * Returns the <i>character in line</i> position where the method identifier 
     * starts.
     * 
     * @return  The <i>character in line</i> position where the method
     *          identifier starts.
     */
    public int getCharPositionInLine() {
        
        return mIdentifierTree.CharPositionInLine;
    }
    
    /**
     * Returns the method's identifier.
     * 
     * @return  The method's identifier.
     */
    public String getIdentifier() {
        
        return mIdentifierTree.Text;
    }

    /**
     * Returns the line number of the method's identifier.
     * 
     * @return  The line number of the method's identifier.
     */
    public int getLineNumber() {
        
        return mIdentifierTree.Line;
    }

    /**
     * Returns the number of array declarators stated behind the formal
     * parameter list.
     * <p>
     * Methods like
     * <pre>
     *     AnyType[][] foo() {...}
     * </pre>
     * can also be declared like this:
     * <pre>
     *     AnyType foo() [][] {...}
     * </pre>
     * For the first (and most common) variant this method would return <code>0
     * </code> but <code>2</code> for the second variant. Furthermore for the 
     * first variant the array declarators are part of the type returned by the 
     * method <code>getReturnType()</code>.
     * 
     * @return  The number of array declarators stated behind the formal
     *          parameter list; for void method always 0 will be returned, of 
     *          course.
     */
    public int getNumberOfArrayDeclarators() {
        
        return mNumberOfArrayDeclarators;
    }
    
    /**
     * Returns the method's return type or <code>null</code> for <code>void
     * </code> methods.
     * 
     * @return  The method's return type or <code>null</code> for <code>void 
     *          </code> methods.
     */
    public Type getReturnType() {
        
        if (mReturnTypeTree == null) {
            return null;
        }
        if (mReturnType == null) {
            mReturnType = 
                new AST2Type(mReturnTypeTree, getTokenRewriteStream());
        }
        
        return mReturnType;
    }
    
    /**
     * Returns <code>true</code> if <code>this</code> represents a <code>void
     * </code> method.
     * 
     * @return  <code>true</code> if <code>this</code> represents a <code>void
     *          </code> method.
     */
    public bool isVoidMethod() {
        
        return mReturnTypeTree == null;
    }
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new method identifier.
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
    public override void traverseAll(TraverseAction pAction) {
        
        traverseAll(pAction, false);
    }
    
    /**
     * @see #traverseAll(TraverseAction)
     * 
     * @param pAction  A user define action.
     * @param pTraverseMembersOnly  If <code>true</code> the methods <code>
     *                              pAction.performAction()</code> and 
     *                              <code>pAction.actionPerformed</code> will 
     *                              not be called by this method.
     */
    protected void traverseAll(
            TraverseAction pAction, bool pTraverseMembersOnly) {
        
        if (!pTraverseMembersOnly) {
            pAction.performAction(this);
        }
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            Type returnType = getReturnType();
            if (returnType != null) {
                returnType.traverseAll(pAction);
            }
        }
        if (!pTraverseMembersOnly) {
            pAction.actionPerformed(this);
        }
    }
}
}