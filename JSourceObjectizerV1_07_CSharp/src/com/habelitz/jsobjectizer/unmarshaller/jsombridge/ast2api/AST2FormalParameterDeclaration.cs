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
using Type = com.habelitz.jsobjectizer.jsom.api.Type;

namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{


    /** 
     * This <code>JSOM</code> type represents a formal parameter declaration
     * including <i>vararg</i> parameter declarations, i.e. a parameter declarations 
     * of a variable number of arguments like <code>anyType ... typeId</code>.
     * 
     * @author Dieter Habelitz
     */
    public class AST2FormalParameterDeclaration : AST2JSOM, FormalParameterDeclaration
    {

        // The parameters modifiers.
        private ModifierList mModifierList;
        // The parameter type.
        private Type mType;
        // The parameter identifier.
        private VariableDeclaratorIdentifier mVarDeclIdentifier;
        private bool mIsVarArgParam = false;
        private bool mHasModifier;

        /**
         * Constructor.
         * 
         * @param pTree  The tree node representing a formal parameter declaration.
         * @param pTokenRewriteStream  The token stream the token of the stated
         *                             tree node belongs to.            
         * 
         */
        public AST2FormalParameterDeclaration(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream)
            : base(pTree, JSOMType.FORMAL_PARAMETER_DECLARATION, pTokenRewriteStream)
        {
            if (pTree.Type == JavaTreeParser.FORMAL_PARAM_VARARG_DECL)
            {
                mIsVarArgParam = true;
            }
            else if (pTree.Type != JavaTreeParser.FORMAL_PARAM_STD_DECL)
            {
                throw new ArgumentException(
                        CommonErrorMessages.getInvalidArgumentValueMessage(
                                "pTree.Type == " + pTree.Type, "pTree"));
            }
            mHasModifier = pTree.GetChild(0).ChildCount > 0;
        }

        /**
         * Adds a stated (simple) annotation to <code>this</code>.
         * 
         * @param pAnnotationIdentifier  The annotation's identifier. Note that this 
         *                               identifier must not start with the character 
         *                               <code>@</code> because is will be added by 
         *                               this method automatically.
         * 
         * @  if parsing fails.
         * 
         * @deprecated  JSourceObjectizer 2.xx feature; should be seen as 
         *              experimental.
         * 
         * __TEST__                                         
         */
        [Obsolete]
        public void addAnnotation(Char[] pAnnotationIdentifier)
        {

            StringBuilder sbModifierList =
                            new StringBuilder('@').Append(pAnnotationIdentifier);
            ModifierList oldModifierList = getModifiers();
            if (oldModifierList != null)
            {
                sbModifierList.Append(' ')
                              .Append(oldModifierList.getMarshaller().ToString());
            }
            List<String> errorMessages = new List<String>();
            try
            {
                AST2ModifierList modifierList =
                    getUnmarshaller().unmarshalAST2ModifierList(
                            sbModifierList.ToString(), errorMessages);
                if (modifierList != null)
                {
                    // TODO  After implementation of adding JSOMs to JSOMs:
                    //       Check if error messages have been emitted by the parser.
                    ITree modifierListTree = modifierList.getTreeNode();
                    mModifierList = modifierList;
                    getTreeNode().SetChild(0, modifierListTree);
                }
            }
            catch (JSourceUnmarshallerException jsue)
            {
                // TODO  After implementation of adding JSOMs to JSOMs:
                //       Replace message by an internationalized message.
                throw new JSourceObjectizerException(
                        "Parsing the modifier list '" + pAnnotationIdentifier +
                        "' failed.", jsue);
            }
            // Update the token stream.
            // TODO  After implementation of adding JSOMs to JSOMs:
            //       Move this stuff to 'AST2JSOM'.
            TokenRewriteStream stream = getTokenRewriteStream();
            sbModifierList.Remove(0, sbModifierList.Length);
            sbModifierList.Append('@').Append(pAnnotationIdentifier)
                          .Append(' ');
            stream.InsertBefore(
                    getTreeNode().TokenStartIndex, sbModifierList.ToString());
        }

        /**
         * Returns the <i>character in line</i> position where the parameter
         * identifier starts.
         * 
         * @return  The <i>character in line</i> position where the parameter
         *          identifier starts.
         */
        public int getCharPositionInLine()
        {

            return getIdentifier().getCharPositionInLine();
        }

        /**
         * Returns the line number of the parameter's identifier.
         * 
         * @return  The line number of the parameter's identifier.
         */
        public int getLineNumber()
        {

            return getIdentifier().getLineNumber();
        }

        /**
         * Returns the formal parameter declaration's modifiers including
         * annotations. 
         * 
         * @return  The modifiers of the formal parameter declaration or <code>null
         *          </code> if no modifiers have been stated.
         *          
         * @deprecated  Use {@link #getModifierList()} instead.
         */
        [Obsolete]
        public ModifierList getModifiers()
        {

            if (!mHasModifier)
            {
                return null;
            }
            if (mModifierList == null)
            {
                mModifierList = new AST2ModifierList((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            }

            return mModifierList;
        }

        /**
         * Returns the formal parameter declaration's modifiers including
         * annotations. 
         * 
         * @return  A list of type modifiers which is empty if the parameter 
         *          declaration has no modifiers.
         */
        public ModifierList getModifierList()
        {

            if (mModifierList == null)
            {
                mModifierList = new AST2ModifierList((AST2JSOMTree)
                        getTreeNode().GetChild(0), getTokenRewriteStream());
            }

            return mModifierList;
        }


        /**
         * Returns the identifier of the formal parameter. 
         * 
         * @return  The the identifier of the formal parameter.
         */
        public VariableDeclaratorIdentifier getIdentifier()
        {

            if (mVarDeclIdentifier == null)
            {
                mVarDeclIdentifier = new AST2VariableDeclaratorIdentifier((AST2JSOMTree)
                        getTreeNode().GetChild(2), getTokenRewriteStream());
            }

            return mVarDeclIdentifier;
        }

        /**
         * Returns the type of the formal parameter. 
         * 
         * @return  The the type of the formal parameter.
         */
        public Type getType()
        {

            if (mType == null)
            {
                mType = new AST2Type((AST2JSOMTree)
                        getTreeNode().GetChild(1), getTokenRewriteStream());
            }

            return mType;
        }

        /**
         * Tells if <code>this</code> represents a <i>vararg</i> parameter 
         * declaration.
         * 
         * @return  <code>true</code> if <code>this</code> represents a <i>vararg
         *          </i>parameter declaration.  
         */
        public bool isVarargParameterDeclaration()
        {

            return mIsVarArgParam;
        }

        /**
         * Tells if the formal parameter declaration has at least one modifier or
         * annotation.
         * 
         * @return  <code>true</code> if the formal parameter declaration has at 
         *          least one modifier or annotation.
         */
        public bool hasModifier()
        {

            return mHasModifier;
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
                getModifierList().traverseAll(pAction);
                getType().traverseAll(pAction);
                getIdentifier().traverseAll(pAction);
            }
            pAction.actionPerformed(this);
        }
    }
}