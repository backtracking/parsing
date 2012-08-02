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
using MethodDefinition = com.habelitz.jsobjectizer.jsom.api.MethodDefinition;
using StatementBlockScope = com.habelitz.jsobjectizer.jsom.api.statement.StatementBlockScope;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using Owner = com.habelitz.jsobjectizer.jsom.api.statement.Owner;
using AST2StatementBlockScope = com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement.AST2StatementBlockScope;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api 
{
/**
 * This <code>JSOM</code> type represents a method definition.
 * 
 * This type corresponds to the type <code>MethodDeclaration</code> but has also 
 * have a declaration block. This means a <code>MethodDeclaration</code> object
 * may represent an abstract method but a <code>MethodDefinition</code> object 
 * never represents an abstract method.
 * 
 * @author Dieter Habelitz
 */
public class AST2MethodDefinition : AST2MethodDeclaration, MethodDefinition {

    // The method's implementation block.
    private StatementBlockScope mScope;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a method definition.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2MethodDefinition(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.METHOD_DEFINITION, pTokenRewriteStream)
    {
        if (   pTree.Type != JavaTreeParser.FUNCTION_METHOD_DECL
            && pTree.Type != JavaTreeParser.VOID_METHOD_DECL) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Returns the method's statement block scope, i.e. the content of the 
     * method body.
     * 
     * @return  The method's statement block scope.
     */
    public StatementBlockScope getStatementBlockScope() {
        
        if (mScope == null) {
            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            mScope = new AST2StatementBlockScope((AST2JSOMTree)
                                tree.GetChild(tree.ChildCount - 1), 
                                Owner.METHOD_DEFINITION,
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
            base.traverseAll(pAction, true);
            getStatementBlockScope().traverseAll(pAction);
        }
        pAction.actionPerformed(this);
    }
}
}