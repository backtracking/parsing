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
using StringResourceBundle = com.habelitz.core.StringResourceBundle;
using ExpressionType = com.habelitz.jsobjectizer.jsom.api.expression.ExpressionType;
using CodeFragmentType = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.JSOParser.CodeFragmentType;
using com.habelitz.core;

namespace com.habelitz.jsobjectizer.resource.resbundle
{
/**
 * This <code>StringResourceBundle</code> defines all kind of strings and 
 * messages used by the JSourceObjectizer's unmarshaller.
 * 
 * @author Dieter Habelitz
 */
public sealed class UnmarshallerMessages : StringResourceBundle {
    
    /**
     * Public access to this <code>StringResourceBundle</code>'s resources.
     * 
     * Actually only one instance of this class is needed.
     */
    private static StringResourceBundle UNMARSHALLER_MESSAGES =
        (StringResourceBundle) ResourceBundle.getBundle(
                "com.habelitz.jsobjectizer.resource.resbundle."
                + "UnmarshallerMessages");

    /**
     * The key to content mapping.
     * 
     * <b>CONVENTION: THE KEYS MUST BE ORDERED ALPHABETICALLY!</b>
     */
    private static readonly String[][] contents = new String[][] { 

        new String[] {   "JAVA_CODE_FRAGMENT_PARSING_FAILED",
            "Parsing the Java code fragment ''{0}'' failed (code fragment " +
            "type ''{1}'')."},
      
        new String[] {   "JAVA_FILE_PARSING_FAILED",
             "Parsing the Java file ''{0}'' failed."},
           
        new String[] {   "LEXER_MESSAGE",
             "Lexer message: "},
              
        new String[] {   "PARSER_MESSAGE",
             "Parser message: "},
              
        new String[] {   "PARSER_MESSAGES_EMITED_FOR_CODE_FRAGMENT",
            "Parser messages emited for the code fragment: ''{0}'' (code " +
            "fragment type ''{1}'')."},
              
        new String[] {   "PARSER_MESSAGES_EMITED_FOR_FILE",
            "Parser messages emited for the file: ''{0}''."},
             
        new String[] {   "TREE_PARSER_MESSAGE",
            "Tree parser message: "},
             
        new String[] {   "UNSUPPORTED_CODE_FRAGMENT_TYPE",
            "Unsupported code fragment type: ''{0}''."},

        new String[] {   "UNSUPPORTED_EXPRESSION_TYPE",
            "Unsupported expression type: ''{0}''."}
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
     * Returns a message for the cases where parsing a Java code fragment has 
     * been failed.
     * 
     * @param pJavaCodeFragment  The code fragment.
     * @param pCodeFragmentType  The code framgment type.
     * 
     * @return  A message for the cases where parsing a Java code fragment has 
     *          beenfailed.
     */
    public static String getJavaCodeFragmentParsingFailedMessage(
            String pJavaCodeFragment, CodeFragmentType pCodeFragmentType) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "JAVA_CODE_FRAGMENT_PARSING_FAILED", 
                new String[] {pJavaCodeFragment, pCodeFragmentType.ToString()});
    }
    
    /**
     * Returns a message for the cases where parsing a Java file has been
     * failed.
     * 
     * @param pJavaFileNameAndPath  The path and file name of the Java file.
     * 
     * @return  A message for the cases where parsing a Java file has been
     *          failed.
     */
    public static String getJavaFileParsingFailedMessage(
            String pJavaFileNameAndPath) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "JAVA_FILE_PARSING_FAILED", 
                new String[] {pJavaFileNameAndPath});
    }
    
    /**
     * Returns a message lexer messages can be prefixed with.
     * 
     * @return  A message lexer messages can be prefixed with.
     */
    public static String getLexerMessageMessage() {
        
        return UNMARSHALLER_MESSAGES.getResource("LEXER_MESSAGE");
    }

    /**
     * Returns a message header for the cases where the parser emited at least 
     * one message while parsing a Java code fragment.
     * 
     * @param pJavaCodeFragment  The code fragment.
     * @param pCodeFragmentType  The code framgment type.
     * 
     * @return  A message header for the cases where the parser emited at least 
     *          one message while parsing a Java code fragment.
     */
    public static String getParserMessagesEmitedForCodeFragmentMessage(
                String pJavaCodeFragment, CodeFragmentType pCodeFragmentType) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "PARSER_MESSAGES_EMITED_FOR_CODE_FRAGMENT", 
                new String[] {pJavaCodeFragment, pCodeFragmentType.ToString()});
    }

    /**
     * Returns a message header for the cases where the parser emited at least 
     * one message while parsing a Java file.
     * 
     * @param pJavaFileNameAndPath  The path and file name of the Java file.
     * 
     * @return  A message header for the cases where the parser emited at least 
     *          one message while parsing a Java file.
     */
    public static String getParserMessagesEmitedForFileMessage(
            String pJavaFileNameAndPath) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "PARSER_MESSAGES_EMITED_FOR_FILE", 
                new String[] {pJavaFileNameAndPath});
    }

    /**
     * Returns a message parser messages can be prefixed with.
     * 
     * @return  A message parser messages can be prefixed with.
     */
    public static String getParserMessageMessage() {
        
        return UNMARSHALLER_MESSAGES.getResource("PARSER_MESSAGE");
    }

    /**
     * Returns a message tree parser messages can be prefixed with.
     * 
     * @return  A message tree parser messages can be prefixed with.
     */
    public static String getTreeParserMessageMessage() {
        
        return UNMARSHALLER_MESSAGES.getResource("TREE_PARSER_MESSAGE");
    }

    /**
     * Returns a message for the cases where an unsupported <code>
     * JSOParser.CodeFragmentType</code> constant should get handled.
     * 
     * @param pCodeFragmentType  The unsupported <code>
     *                           JSOParser.CodeFragmentType</code> constant.
     * 
     * @return  A message for the cases where an unsupported <code>
     *          JSOParser.CodeFragmentType</code> constant should get handled.
     */
    public static String getUnsupportedCodeFragmentTypeMessage(
                                        CodeFragmentType pCodeFragmentType) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "UNSUPPORTED_CODE_FRAGMENT_TYPE", 
                new String[] {pCodeFragmentType.ToString()});
    }

    /**
     * Returns a message for the cases where an <code>Expression</code> remains
     * unhandled because the expression type is not supported.
     * 
     * @param pExpressionType  The unsupported expression type.
     * 
     * @return  A message that stated the unsupported expression.
     */
    public static String getUnsupportedExpressionTypeMessage(
                                            ExpressionType pExpressionType) {
        
        return UNMARSHALLER_MESSAGES.getResource(
                "UNSUPPORTED_EXPRESSION_TYPE", 
                new String[] {pExpressionType.ToString()});
    }
}
}