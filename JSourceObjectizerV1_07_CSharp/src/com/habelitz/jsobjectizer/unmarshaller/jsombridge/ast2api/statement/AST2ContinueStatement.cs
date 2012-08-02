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
using com.habelitz.jsobjectizer.jsom.api.statement;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.statement {
/**
 * This <code>Statement</code> type represents a <code>continue</code>
 * statement.
 * 
 * @author Dieter Habelitz
 */
public class AST2ContinueStatement : AST2Statement , ContinueStatement {

    private bool mHasLabelIdentifier = false;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a <code>continue</code> 
     *               statement.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ContinueStatement(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, ElementType.CONTINUE_STATEMENT,pTokenRewriteStream)
    {
       
        if (pTree.Type != JavaTreeParser.CONTINUE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (pTree.ChildCount == 1) {
            mHasLabelIdentifier = true;
        }
    }
    
    /**
     * Returns the label identifier that has been stated with the <code>continue
     * </code> statement.
     * 
     * @return  The label identifier that has been stated with the <code>
     *          continue</code> statement or <code>null</code> if no label
     *          identifier has been stated.
     */
    public String getLabelIdentifier() {
        
        if (!mHasLabelIdentifier) {
            return null; // No identifier available.
        }
        
        return getTreeNode().GetChild(0).Text;
    }

    /**
     * Tells if a label identifier has been stated for the <code>continue</code> 
     * statement.
     * 
     * @return  <code>true</code> if a label identifier has been stated for the
     *          <code>continue</code> statement.
     */
    public bool hasLabelIdentifier() {
        
        return mHasLabelIdentifier;
    }

    /**
     * Calls the methods <code>pAction.performAction(...)</code> and <code>
     * pAction.actionPerformed(...)</code> with <code>this</code> as argument.
     * <p>
     * Note that this <code>JSOM</code> type has no <code>JSOM</code> members to
     * traverse.
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
        // Nothing to traverse.
        pAction.actionPerformed(this);
    }
}
}