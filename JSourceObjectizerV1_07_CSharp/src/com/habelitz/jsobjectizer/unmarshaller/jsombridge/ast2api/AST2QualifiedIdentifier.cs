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
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using QualifiedIdentifier = com.habelitz.jsobjectizer.jsom.api.QualifiedIdentifier;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/** 
 * This <code>JSOM</code> type represents a qualified identifier.
 * <p>
 * <i>Qualified identifier</i> means that a certain identifier <b>may
 * </b> be a qualified identifier. It is not obligatory that the
 * identifier is actually a qualified identifier, i.e. it may also be
 * a single identifier. 
 * 
 * @author Dieter Habelitz
 */
public class AST2QualifiedIdentifier : AST2JSOM, QualifiedIdentifier {
    
    // A array containing the dot separated identifiers of the qualified
    // identifier starting with the first identifier from left.
    private AST2JSOMTree[] mIdentifiers;
    
    /**
     * Constructor.
     * 
     * @param pTree  The qualified identifier node.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2QualifiedIdentifier(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
    :base(pTree, JSOMType.QUALIFIED_IDENTIFIER, pTokenRewriteStream)
    {
        if (   pTree.Type != JavaTreeParser.IDENT
            && pTree.Type != JavaTreeParser.DOT) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        resolveIdentifiers();
    }

    /**
     * Returns the <i>character in line</i> position where the qualified
     * identifier starts.
     * 
     * @return  The <i>character in line</i> position where the the qualified
     * identifier starts.
     */
    public int getCharPositionInLine() {
        
        return mIdentifiers[0].CharPositionInLine;
    }
    
    /**
     * Returns a certain identifier of the qualifiedIdentifier.
     * 
     * @param pOffset  The offset of the identifier starting with 0 for the most
     *                 left identifier.
     *                 
     * @return  The identifier.
     *
     * @throws IndexOutOfRangeException  if the stated offset is lower than 0
     *                                    or higher than <i>identifier count - 
     *                                    1</i>.
     */
    public String getIdentifier(int pOffset) {
        
        if (pOffset < 0 && pOffset >= mIdentifiers.Length) {
            throw new IndexOutOfRangeException(
                    CommonErrorMessages.getOffsetOutOfBoundMessage(
                            pOffset, 0, mIdentifiers.Length - 1));
        }
        
        return mIdentifiers[pOffset].Text;
    }
    
    /**
     * Returns the number of identifiers the qualified identifier consists of.
     * 
     * @return  The number of identifiers.
     */
    public int getIdentifierCount() {
        
        return mIdentifiers.Length;
    }
    

    /**
     * Returns the line number of the qualified identifier.
     * 
     * @return  The line number of the qualified identifier.
     */
    public int getLineNumber() {
        
        return mIdentifiers[0].Line;
    }

    /**
     * Returns a list of the identifiers of the qualified identifier.
     * <p>
     * The returned list contains the dot separated identifiers (without any 
     * dots, of course), were the first list entry corresponds to the most left 
     * identifier. For the simplest case this list contains only one identifier.
     * <p>
     * Calling this method equals an <code>getQualifiedIdentifier(null)</code>
     * call.
     * 
     * @see #getQualifiedIdentifier(List)
     *  
     * @return  A list of the identifiers of the qualified identifier.
     */
    public List<String> getQualifiedIdentifier() {
        
        return getQualifiedIdentifier(null);
    }
    
    /**
     * Returns a list of the identifiers of the qualified identifier.
     * <p>
     * The returned list contains the dot separated identifiers (without any 
     * dots, of course), were the first list entry corresponds to the most left 
     * identifier. For the simplest case this list contains only one identifier.
     * 
     * @param  pList  If this argument isn't <code>null</code> the identifiers
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the identifiers of the qualified identifier.
     */
    public List<String> getQualifiedIdentifier(List<String> pList) {
        
        List<String> result = pList;
        if (result == null) {
            result = new List<String>(mIdentifiers.Length);
        }
        foreach (AST2JSOMTree tree in mIdentifiers) {
            result.Add(tree.Text);
        }
        
        return result;
    }
    
    /**
     * Resolves the qualified identifier.
     */
    private void resolveIdentifiers() {

        AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
        if (tree.Type == JavaTreeParser.IDENT) {
            // If there's just one identifier take the short way.
            mIdentifiers = new AST2JSOMTree[1];
            mIdentifiers[0] = tree;
        } else {
            List<AST2JSOMTree> ids = new List<AST2JSOMTree>();
            // Resolve the identifiers that come from right to left.
            while (tree.Type == JavaTreeParser.DOT) {
                // Add the current right identifier.
                ids.Insert(0, (AST2JSOMTree)tree.GetChild(1));
                // Continue with the current left node.
                tree = (AST2JSOMTree)tree.GetChild(0);
            }
            // Add the most left identifier
            ids.Insert(0, tree);
            //mIdentifiers = new AST2JSOMTree[ids.Count];
            mIdentifiers = ids.ToArray();
        }
    }

    /**
     * Replaces a certain identifier of the qualifiedIdentifier.
     * 
     * @param pOffset  The offset of the identifier starting with 0 for the most
     *                 left identifier.
     * @param pNewIdentifier  The new identifier.                 
     *                 
     * @return  The old identifier.
     *
     * @throws IndexOutOfRangeException  An implementation of this method is
     *                                    expected to throw an exception if the
     *                                    stated offset is lower than 0 or
     *                                    higher than <i>identifier count - 
     *                                    1</i>.
     */
    public String setIdentifier(int pOffset, String pNewIdentifier) {
        
        if (pOffset < 0 && pOffset >= mIdentifiers.Length) {
            throw new IndexOutOfRangeException(
                    CommonErrorMessages.getOffsetOutOfBoundMessage(
                            pOffset, 0, mIdentifiers.Length - 1));
        }
        String oldId = mIdentifiers[pOffset].Text;
        mIdentifiers[pOffset].Token.Text = pNewIdentifier;
        
        return oldId;
    }


    /**
     * Returns the qualified identifier as string.
     * <p>
     * The returned string will only contain the dot separated identifiers or a
     * single identifier for the most trivial case. For instance, whitespaces
     * stated within the qualified identifier in the Java source will not be
     * part of the returned string. To get also such hidden things the <code>
     * JSourceMarshaller should be used.
     * 
     * @see JSOM#getMarshaller()
     * 
     * @return  The qualified identifier as string.
     */
    public override String ToString() {
        
        // For most cases there's only one identifier.
        if (mIdentifiers.Length == 1) {
            return mIdentifiers[0].Text;
        }
        StringBuilder sbIdent = new StringBuilder(mIdentifiers[0].Text);
        int size = mIdentifiers.Length;
        for (int offset = 1; offset < size; offset++) {
            sbIdent.Append('.').Append(mIdentifiers[offset].Text);
        }

        return sbIdent.ToString();
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
        // No members to traverse.
        pAction.actionPerformed(this);
    }
}
}