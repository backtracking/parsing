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
using System.Reflection;
using System.Text;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using JSourceUnmarshallerException = com.habelitz.jsobjectizer.unmarshaller.JSourceUnmarshallerException;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
    /** 
     * This <code>JSOM</code> type represents a formal parameter list.
     * 
     * @author Dieter Habelitz
     */
    public class AST2FormalParameterList : AST2JSOM, FormalParameterList
    {

        // The formal parameter declarations.
        private List<AST2FormalParameterDeclaration> mParams;

        private bool mIsEmptyFormalParameterList;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a formal parameter list.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         */
        public AST2FormalParameterList(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.FORMAL_PARAMETER_LIST, pTokenRewriteStream)
        {

            if (pTree.Type != JavaTreeParser.FORMAL_PARAM_LIST)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            mIsEmptyFormalParameterList = pTree.ChildCount == 0;
        }

        /**
         * Returns the <i>character in line</i> position of the opening parenthesis.
         * 
         * @return  The <i>character in line</i> position of the opening 
         *          parenthesis.
         */
        public int getCharPositionInLine()
        {

            return getTreeNode().CharPositionInLine;
        }

        /**
         * Returns a list of the formal parameter declarations.
         * <p>
         * The last <code>FormalParameterDeclaration</code> object (or the only one)
         * may be a <i>vararg</i> parameter declaration, i.e. a parameter 
         * declaration of a variable number of arguments like <code>public void 
         * foo(anyType ... typeId) {...}</code>. 
         * <p>
         * Calling this method equals an <code>getFormalParameterDeclarations(null)
         * </code> call.
         * 
         * @see #getFormalParameterDeclarations(List)
         * @see FormalParameterDeclaration#isVarargParameterDeclaration()
         * 
         * @return  A list of the formal parameter declarations. If <code>this
         *          </code> represents an empty formal parameter list <code>null
         *          </code> will be returned.
         */
        public List<FormalParameterDeclaration> getFormalParameterDeclarations()
        {

            return getFormalParameterDeclarations(null);
        }

        /**
         * Returns a list of the formal parameter declarations.
         * <p>
         * The last <code>FormalParameterDeclaration</code> object (or the only one)
         * may be a <i>vararg</i> parameter declaration, i.e. a parameter 
         * declaration of a variable number of arguments like <code>public void 
         * foo(anyType ... typeId) {...}</code>. 
         * 
         * @param  pList  If this argument isn't <code>null</code> the formal
         *                parameter declarations will be added to this list and this 
         *                list object will be returned. Otherwise a new list will be 
         *                created for the result.
         *  
         * @see FormalParameterDeclaration#isVarargParameterDeclaration()
         * 
         * @return  A list of the formal parameter declarations. If <code>this
         *          </code> represents an empty formal parameter list <code>null
         *          </code> will be returned, even if the argument <code>pList
         *          </code> isn't <code>null</code>.
         */
        public List<FormalParameterDeclaration> getFormalParameterDeclarations(
                List<FormalParameterDeclaration> pList)
        {

            if (mIsEmptyFormalParameterList)
            {
                return null; // No parameters available.
            }
            if (mParams == null)
            {
                resolveFormalParameterDeclarations();
            }
            List<FormalParameterDeclaration> result = pList;
            if (result == null)
            {
                result = new List<FormalParameterDeclaration>(mParams.Count);
            }
            result.AddRange(mParams);

            return result;
        }

        /**
         * Returns the line number of the opening parenthesis.
         * 
         * @return  The line number of the opening parenthesis.
         */
        public int getLineNumber()
        {

            return getTreeNode().Line;
        }

        /**
         * Tells if the formal parameter list is empty, i.e. if there are no
         * formal parameter declarations.
         * 
         * @return  <code>true</code> if the formal parameter list is empty.
         */
        public bool isEmptyFormalParameterList()
        {

            return mIsEmptyFormalParameterList;
        }


        /**
         * Replaces a certain parameter declaration by a new one stated as string.
         * 
         * @param pOldParameterDeclaration  The parameter declaration that should be
         *                                  replaced.
         * @param pNewParameterDeclaration  The new parameter declaration.
         *
         * @  if the stated old parameter doesn't
         *                                     exist or if parsing the new parameter
         *                                     declaration fails.
         * __TEST__
         */
        public void replaceFormalParameter(
            FormalParameterDeclaration pOldParameterDeclaration,
            String pNewParameterDeclaration)
        {

            // Because it's not clear if the stated new formal parameter states a
            // standard parameter or a VarArg parameter simulate a parameter list
            // containing just one parameter.
            StringBuilder sb = new StringBuilder();
            sb.Append('(').Append(pNewParameterDeclaration).Append(')');
            List<String> errorMessages = new List<String>();
            AST2FormalParameterDeclaration newParamDecl = null;
            try
            {
                AST2FormalParameterList paramList =
                    getUnmarshaller().unmarshalAST2FormalParameterList(
                            sb.ToString(), errorMessages);
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Check if error messages have been emitted by the parser.
                if (paramList != null)
                {
                    paramList.resolveFormalParameterDeclarations();
                    if (paramList.mParams != null
                        && paramList.mParams.Count == 1)
                    {
                        newParamDecl = paramList.mParams[0];
                    }
                }
            }
            catch (JSourceUnmarshallerException jsue)
            {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Replace message by an internationalized message.
                throw new JSourceObjectizerException(
                        "Parsing the formal parameter '" +
                        pNewParameterDeclaration + "' failed.", jsue);
            }
            if (newParamDecl != null)
            {
                List<FormalParameterDeclaration> formalParamDecls =
                    getFormalParameterDeclarations();
                int offset = -1;
                if (formalParamDecls != null)
                {
                    offset = mParams.IndexOf((AST2FormalParameterDeclaration)pOldParameterDeclaration);
                }
                if (offset >= 0)
                {
                    AST2FormalParameterDeclaration oldParamDecl = mParams[offset];
                    mParams[offset] = newParamDecl;
                    getTreeNode().SetChild(offset, newParamDecl.getTreeNode());
                    ITree oldParamDeclTree = oldParamDecl.getTreeNode();
                    getTokenRewriteStream().Replace(
                            oldParamDeclTree.TokenStartIndex,
                            oldParamDeclTree.TokenStopIndex,
                            pNewParameterDeclaration);

                }
                else
                {
                    // TODO  After implementation of adding JSOMs to JSOMs:
                    //       Replace message by an internationalized message.
                    throw new JSourceObjectizerException(
                            "The old parameter '" +
                            pOldParameterDeclaration.getMarshaller().ToString() +
                            "' passed as argument doesn't belong to the " +
                            "parameter list.");
                }
            }
            else
            {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Replace message by an internationalized message.
                throw new JSourceObjectizerException(
                        "Unmarshalling the new formal parameter '" +
                        pNewParameterDeclaration + "' failed.");
            }
        }

        /**
         * Resolves the optional formal parameter declarations.
         * <p>
         * Note that it's up to the caller to ensure that there's at least one
         * formal parameter declaration.
         */
        private void resolveFormalParameterDeclarations()
        {

            AST2JSOMTree tree = (AST2JSOMTree)getTreeNode();
            int size = tree.ChildCount;
            mParams = new List<AST2FormalParameterDeclaration>(size);
            for (int offset = 0; offset < size; offset++)
            {
                mParams.Add(new AST2FormalParameterDeclaration((AST2JSOMTree)
                        tree.GetChild(offset), getTokenRewriteStream()));
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
        public void traverseAll(TraverseAction pAction)
        {

            pAction.performAction(this);
            if (pAction.isMemberTraversingEnabled())
            {
                // Traverse the members.
                if (!mIsEmptyFormalParameterList)
                {
                    if (mParams == null)
                    {
                        resolveFormalParameterDeclarations();
                    }
                    foreach (FormalParameterDeclaration declaration in mParams)
                    {
                        declaration.traverseAll(pAction);
                    }
                }
            }
            pAction.actionPerformed(this);
        }
    }
}
