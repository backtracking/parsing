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
using PrimitiveType = com.habelitz.jsobjectizer.jsom.api.PrimitiveType;
using Type = com.habelitz.jsobjectizer.jsom.api.Type;
using ComplexTypeIdentifier = com.habelitz.jsobjectizer.jsom.api.ComplexTypeIdentifier;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using JavaTreeParser = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated.JavaTreeParser;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/**
 * This <code>JSOM</code> represents a type identifier for both primitive and
 * complex types.
 * 
 * @author Dieter Habelitz
 */
public class AST2Type : AST2JSOM, Type {
    
    /*
     * 'true' if 'this' is a complex type and 'false' if 'this' is a primitive
     * 'type'.
     */
    private bool mIsComplexType = false;
    /*
     * The qualified type identifier if 'this' is a complex type but 'null'
     * otherwise.
     */
    private List<AST2ComplexTypeIdentifier> mQualifiedTypeIdentifier;
    /*
     * The primitive type represented by 'this' or 'null' if 'this' represents
     * a complex type.
     */
    private PrimitiveType mPrimitiveType;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a type.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2Type(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
    : base(pTree, JSOMType.TYPE, pTokenRewriteStream)
    {
        if (pTree.Type != JavaTreeParser.TYPE) {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        if (   pTree.GetChild(0).Type 
            == JavaTreeParser.QUALIFIED_TYPE_IDENT) {
            mIsComplexType = true;
        }
    }

    /**
     * Returns the <i>character in line</i> position where the type identifier 
     * or the primitive type keyword starts.
     * 
     * @return  The <i>character in line</i> position where the type identifier 
     *          or the primitive type keyword starts.
     */
    public int getCharPositionInLine() {
        
        if (mIsComplexType) {
            if (mQualifiedTypeIdentifier == null) {
                mQualifiedTypeIdentifier =
                    AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier((AST2JSOMTree)
                            getTreeNode().GetChild(0), getTokenRewriteStream());
            }
            return mQualifiedTypeIdentifier[0].getCharPositionInLine();
        }
        // If still here 'this' must represent a primitive type.
        return getPrimitiveType().getCharPositionInLine();
    }
    
    /**
     * Returns the line number of the type identifier or the primitive type
     * keyword.
     * 
     * @return  The line number of the type identifier the primitive type 
     *          keyword.
     */
    public int getLineNumber() {
        
        if (mIsComplexType) {
            if (mQualifiedTypeIdentifier == null) {
                mQualifiedTypeIdentifier =
                    AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier((AST2JSOMTree)
                            getTreeNode().GetChild(0), getTokenRewriteStream());
            }
            return mQualifiedTypeIdentifier[0].getLineNumber();
        }
        // If still here 'this' must represent a primitive type.
        return getPrimitiveType().getLineNumber();
    }

    /**
     * Returns the number of array declarators, i.e. the number of <code>[]
     * </code> character sequences that have been stated with the type.
     * <p>
     * If <code>this</code> doesn't represent a static array type <code>0</code>
     * will be returned.
     *
     * @return  The number of array declarators.
     */
    public int getNumberOfArrayDeclarators() {
        
        if (!isStaticArrayType()) {
            return 0;
        }
        
        return getTreeNode().GetChild(1).ChildCount;
    }

    /**
     * Returns a list of the identifiers of the qualified type identifier.
     * <p>
     * Calling this method equals an <code>getQualifiedTypeIdentifier(null)
     * </code> call.
     * 
     * @see #getQualifiedTypeIdentifier(List)
     *  
     * @return  A list of the identifiers of the qualified type identifier. The
     *          first entry corresponds to the most left identifier. If <code>
     *          this</code> doesn't represent a complex type (i.e. <code>
     *          isComplexType() == false</code> <code>null</code> will be 
     *          returned.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier() {
        
        return getQualifiedTypeIdentifier(null);
    }

    /**
     * Returns a list of the identifiers of the qualified type identifier.
     * 
     * @param  pList  If this argument isn't <code>null</code> the identifiers
     *                will be added to this list and this list object will be 
     *                returned. Otherwise a new list will be created for the 
     *                result.
     *  
     * @return  A list of the identifiers of the qualified type identifier. The
     *          first entry corresponds to the most left identifier. If <code>
     *          this</code> doesn't represent a complex type (i.e. <code>
     *          isComplexType() == false</code> <code>null</code> will be 
     *          returned, even if the argument <code>pList</code> isn't <code>
     *          null</code>.
     */
    public List<ComplexTypeIdentifier> getQualifiedTypeIdentifier(
            List<ComplexTypeIdentifier> pList) {
        
        if (!mIsComplexType) {
            return null;
        }
        if (mQualifiedTypeIdentifier == null) {
            mQualifiedTypeIdentifier =
                AST2ComplexTypeIdentifier.resolveQualifiedTypeIdentifier((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
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
     * If <code>this</code> represents a primitive type this method returns the
     * appropriate <code>PrimitiveType</code> object, Otherwise, i.e. if <code>
     * isComplexType()</code> returns <code>true</code>, <code>null</code> will 
     * be returned.
     * 
     * @return  A <code>PrimitiveType</code> object or <code>null</code> if 
     *          <code>this</code> represents a complex type.
     */
    public PrimitiveType getPrimitiveType() {
        
        if (mIsComplexType) {
            return null;
        }
        if (mPrimitiveType == null) {
            mPrimitiveType = new AST2PrimitiveType((AST2JSOMTree)
                    getTreeNode().GetChild(0), getTokenRewriteStream());
        }
        
        return mPrimitiveType;
    }
    
    /**
     * Tells if <code>this</code> represents a complex type.
     * 
     * @return  <code>true</code> if <code>this</code> represents a complex 
     *          type.
     */
    public bool isComplexType() {
        
        return mIsComplexType;
    }

    /**
     * Tells if <code>this</code> represents a static array type.
     * 
     * @return  <code>true</code> if <code>this</code> represents a static array 
     *          type.
     */
    public bool isStaticArrayType() {
        
        return getTreeNode().ChildCount == 2;
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
            if (!mIsComplexType) {
                getPrimitiveType().traverseAll(pAction);
            } else {
                if (mQualifiedTypeIdentifier == null) {
                    mQualifiedTypeIdentifier = AST2ComplexTypeIdentifier
                        .resolveQualifiedTypeIdentifier((AST2JSOMTree)
                                getTreeNode().GetChild(0), 
                                getTokenRewriteStream());
                }
                foreach (ComplexTypeIdentifier id in mQualifiedTypeIdentifier) {
                    id.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}