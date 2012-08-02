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
using Variant = com.habelitz.jsobjectizer.jsom.api.Variant;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
    /**
     * This <code>JSOM</code> type represents a generic type argument.
     * <p>
     * There are four variants of how generic type argument can be stated:
     *  <ol>
     *      <li><code>&lt;AnyType&gt;</code></li>
     *      <li><code>&lt;?&gt;</code></li>
     *      <li><code>&lt;? : AnyType&gt;</code></li>
     *      <li><code>&lt;? super AnyType&gt;</code></li>
     *  </ol>
     * This class supports the representation of all these variants.
     * <p>
     * Note that there's no public constructor to crate instances of this class.
     * Instead, the static method 
     * {@link #resolveGenericTypeArgumentList(AST2JSOMTree, TokenRewriteStream)} 
     * must be used that resolves a generic type argument list and that returns
     * instances of this class representing the generic type arguments stated within
     * a certain generic type argument list.
     * 
     * @author Dieter Habelitz
     */
    public class AST2GenericTypeArgument : AST2JSOM, GenericTypeArgument
    {

        /*
         * One of the 'VARIANT_???' constant defined by 'GenericTypeArgument'.
         */
        private Variant mVariant;
        /*
         * The type of the generic type argument or an ':' or 'super' bound
         * type (depends on the variant).
         */
        private com.habelitz.jsobjectizer.jsom.api.Type mType;

        /**
         * Constructor.
         * 
         * @param pTree  One of the two possible generic type argument root nodes.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        private AST2GenericTypeArgument(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.GENERIC_TYPE_ARGUMENT, pTokenRewriteStream)
        {
            switch (pTree.Type)
            {
                case JavaTreeParser.TYPE:
                    mVariant = Variant.NOT_WILDCARDED;
                    break;
                case JavaTreeParser.QUESTION:
                    if (pTree.ChildCount == 0)
                    {
                        mVariant = Variant.WILDCARDED_NOT_BOUND;
                    }
                    else
                    {
                        ITree child = pTree.GetChild(0);
                        if (child.Type == JavaTreeParser.EXTENDS)
                        {
                            mVariant = Variant.WILDCARDED_EXTENDS_BOUND;
                        }
                        else
                        {
                            mVariant = Variant.WILDCARDED_SUPER_BOUND;
                        }
                    }
                    break;
                default:
                    throw new ArgumentException(
                            CommonErrorMessages.getInvalidArgumentValueMessage(
                                    "pTree.Type == " + pTree.Type, "pTree"));
            }
        }

        /**
         * Returns the <i>character in line</i> position where the generic type 
         * argument starts.
         * 
         * @return  The <i>character in line</i> position where the generic type 
         *          argument starts.
         */
        public int getCharPositionInLine()
        {

            if (mVariant == Variant.NOT_WILDCARDED)
            {
                // Return the character position of the type.
                return getType().getCharPositionInLine();
            }

            // Return the character position of the '?' character.
            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns the line number of the generic type argument.
         * 
         * @return  The line number of the generic type argument.
         */
        public int getLineNumber()
        {

            if (mVariant == Variant.NOT_WILDCARDED)
            {
                // Return the line number of the type.
                return getType().getLineNumber();
            }

            // Return the line number of the '?' character.
            return getTreeNode().Line;
        }

        /**
         * Returns the type stated by the generic type argument.
         * <p>
         * For the generic type variant <code>Variant.NOT_WILDCARDED</code> the
         * result of the method is the generic type itself but for the variants
         * <code>Variant.WILDCARDED_EXTENDS_BOUND</code> and <code>
         * Variant.WILDCARDED_SUPER_BOUND</code> the returned type corresponds to
         * the bound type (i.e. the type following the <code>:</code> or
         * <code>super</code> keyword).
         * 
         * @return  The type stated by the generic type argument or <code>null
         *          </code> if <code>this</code> represents a <code>
         *          Variant.WILDCARDED_NOT_BOUND</code> generic type argument.
         */
        public com.habelitz.jsobjectizer.jsom.api.Type getType()
        {

            if (mVariant == Variant.WILDCARDED_NOT_BOUND)
            {
                return null;
            }
            if (mType == null)
            {
                AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
                if (mVariant != Variant.NOT_WILDCARDED)
                {
                    // Must be an ':' or 'super' bound wildcard.
                    tree = (AST2JSOMTree)tree.GetChild(0).GetChild(0);
                }
                mType = new AST2Type(tree, getTokenRewriteStream());
            }

            return mType;
        }

        /**
         * Returns the variant of the generic type argument represented by <code>
         * this</code>.
         * 
         * @return  One of the <code>GenericTypeArgument.Variant.???</code> 
         *          constants.
         */
        public Variant getVariant()
        {

            return mVariant;
        }

        /**
         * Resolves a generic type argument list.
         * 
         * @param pTree  The generic type argument list's root node.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         * 
         * @return  A list containing the generic type arguments.
         */
        public static List<AST2GenericTypeArgument>
        resolveGenericTypeArgumentList(
                AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.GENERIC_TYPE_ARG_LIST)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            int size = pTree.ChildCount;
            List<AST2GenericTypeArgument> result =
                new List<AST2GenericTypeArgument>(size);
            for (int offset = 0; offset < size; offset++)
            {
                result.Add(new AST2GenericTypeArgument((AST2JSOMTree)
                        pTree.GetChild(offset), pTokenRewriteStream));
            }

            return result;
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
        public void traverseAll(TraverseAction pAction)
        {

            pAction.performAction(this);
            if (pAction.isMemberTraversingEnabled())
            {
                // Traverse the members.
                if (mVariant != Variant.WILDCARDED_NOT_BOUND)
                {
                    getType().traverseAll(pAction);
                }
            }
            pAction.actionPerformed(this);
        }
    }
}