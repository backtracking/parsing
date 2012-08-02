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
using com.habelitz.core;

namespace com.habelitz.jsobjectizer.resource.resbundle {
/**
 * This <code>StringResourceBundle</code> defines strings and messages that may 
 * (and should) be used by the implementations of the <code>JSOM</code> types.
 * 
 * @author Dieter Habelitz
 */
public sealed class CommonJSOMMessages : StringResourceBundle {
    
    /**
     * Public access to this <code>StringResourceBundle</code>'s resources.
     * 
     * Actually only one instance of this class is needed.
     */
    private static readonly StringResourceBundle COMMON_JSOM_MESSAGES =
        (StringResourceBundle) ResourceBundle.getBundle(
                "com.habelitz.jsobjectizer.resource.resbundle."
                + "CommonJSOMMessages");

    /**
     * The key to content mapping.
     * 
     * <b>CONVENTION: THE KEYS MUST BE ORDERED ALPHABETICALLY!</b>
     */
    private static readonly String[][] contents = new String[][] {

        new String[] {   "CHILD_TREE_NODE_NOT_FOUND",
            "The tree node ''{0}'' is not a child of the tree node ''{1}''."},
        
        new String[] {   "METHOD_NOT_SUPPORTED",
             "The method ''{0}'' is not supported."},
             
        new String[] {   "OFFSET_OUT_OF_BOUNDS",
            "Invalid offset ''{0}''; the actual range is ''{1}''..''{2}''."},
            
        new String[] {   "STATEMENT_BLOCK_ELEMENT_DOES_NOT_EXIST",
            "The statement block element ''{0}'' does not exist within the " +
            "statement block scope starting at position ''{1}''."},
             
        new String[] {   "TYPE_MEMBER_DECLARATION_DOES_NOT_EXIST",
            "The type member declaration ''{0}'' does not exist within the " +
            "type top level scope starting at position ''{1}''."},
                 
        new String[] {   "VARIABLE_DECLARATOR_DOES_NOT_EXIST",
            "The variable declarator ''{0}'' does not exist within the " +
            "variable declaration at position ''{1}''."}
    };

    /**
     *  Get the currently used ListResourceBundle key/object list.
     *
     *  @return  the ListResourceBundle key/object list.
     */
    protected override Object[][] getContents() {
        
	   return contents;
    }

    /**
     * Returns a message for the cases where a certain child tree node is
     * searched within a (parent) tree node but it couldn't be found.
     * 
     * @param pChildNode  The searched child node.
     * @param pParentNode  The parent node.
     * 
     * @return  A message for the cases where a certain child tree node is
     *          searched within a (parent) tree node but it couldn't be found.
     */
    public static String getChildTreeNodeNotFoundMessage(
            String pChildNode, String pParentNode) {
        
        return COMMON_JSOM_MESSAGES.getResource(
                "CHILD_TREE_NODE_NOT_FOUND", 
                new String[] {pChildNode, pParentNode});
    }

    /**
     * Returns a message for the cases where an unsupported method has been
     * called.
     * 
     * @param pUnsupportedMethodId  The identifier of the unsupported method.
     * 
     * @return  A message for the cases where an unsupported method has been
     *          called.
     */
    public static String getMethodNotSupportedMessage(
            String pUnsupportedMethodId) {
        
        return COMMON_JSOM_MESSAGES.getResource(
                "METHOD_NOT_SUPPORTED", new String[] {pUnsupportedMethodId});
    }

    /**
     * Returns a message for the cases where a certain statement block element
     * hasn't been found within a certain statement block scope.
     * 
     * @param pStatementBlockElement  Description of the statement block element
     *                                (name, position, etc).
     * @param pStatementBlockScopePosition  The position of the statement block 
     *                                      scope.
     * 
     * @return  A message for the cases where a certain statement block element
     *          hasn't been found within a certain statement block scope.
     */
    public static String getStatementBlockElementDoesNotExistMessage(
            String pStatementBlockElement, 
            String pStatementBlockScopePosition) {
        
        return COMMON_JSOM_MESSAGES.getResource(
            "STATEMENT_BLOCK_ELEMENT_DOES_NOT_EXIST", 
            new String[] {
                    pStatementBlockElement, pStatementBlockScopePosition});
    }

    /**
     * Returns a message for the cases where a certain type member declaration
     * hasn't been found within a certain type declaration.
     * 
     * @param pTypeMemberDeclaration  Description of the type member declaration
     *                                (name, position, etc).
     * @param pCommonTypeTopLevelScope  The position of the type declaration top 
     *                                  level scope.
     * 
     * @return  A message for the cases where a certain statement block element
     *          hasn't been found within a certain statement block scope.
     */
    public static String getTypeMemberDeclarationDoesNotExistMessage(
            String pTypeMemberDeclaration, 
            String pCommonTypeTopLevelScope) {
        
        return COMMON_JSOM_MESSAGES.getResource(
            "TYPE_MEMBER_DECLARATION_DOES_NOT_EXIST", 
            new String[] {
                    pTypeMemberDeclaration, pCommonTypeTopLevelScope});
    }

    /**
     * Returns a message for the cases where a certain variable declarator 
     * hasn't been found within a certain variable declaration.
     * 
     * @param pVariableDeclaratorId  The identifier of the variable declarator.
     * @param pVariableDeclarationPosition  The position of the variable 
     *                                      declaration.
     * 
     * @return  A message for the cases where a certain variable declarator 
     *          hasn't been found within a certain variable declaration.
     */
    public static String getVariableDeclaratorDoesNotExistMessage(
            String pVariableDeclaratorId, 
            String pVariableDeclarationPosition) {
        
        return COMMON_JSOM_MESSAGES.getResource(
            "VARIABLE_DECLARATOR_DOES_NOT_EXIST", 
            new String[] {pVariableDeclaratorId, pVariableDeclarationPosition});
    }
}
}