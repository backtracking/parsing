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
using ConstructorDefinition = com.habelitz.jsobjectizer.jsom.api.ConstructorDefinition;
using StatementBlockScope = com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockScope;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.abstracttype;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement;
using com.habelitz.jsobjectizer.jsom.api.statement;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api {
/**
 * This <code>JSOM</code> type represents a constructor definition.
 * 
 * @author Dieter Habelitz
 */
public class AST2ConstructorDefinition 
    : AST2CommonMethodOrConstructorDeclaration 
    , ConstructorDefinition {

    // The constructor's implementation block.
    private StatementBlockScope mScope;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a constructor definition.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ConstructorDefinition(
            AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        :  base(pTree, JSOMType.CONSTRUCTOR_DEFINITION, pTokenRewriteStream)
    {

        if (pTree.Type != JavaTreeParser.CONSTRUCTOR_DECL) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }

    /**
     * Returns the <i>character in line</i> position where the constructor's 
     * (i.e. the type) identifier starts.
     * 
     * @return  The <i>character in line</i> position where the constructor's 
     * (i.e. the type) identifier starts.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the line number of the constructor's (i.e. the type) identifier.
     * 
     * @return  The line number of the type constructor's (i.e. the type) 
     *          identifier.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns the constructors's statement block scope, i.e. the content of the 
     * constructor body.
     * 
     * @return  The method's statement scope.
     */
    public StatementBlockScope getStatementBlockScope() {
        
        if (mScope == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            mScope = new AST2StatementBlockScope((AST2JSOMTree)
                    tree.GetChild(tree.ChildCount - 1),
                    Owner.CONSTRUCTOR,
                    getTokenRewriteStream());
        }
        
        return mScope;
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
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            base.traverseAll(pAction);
            getStatementBlockScope().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}