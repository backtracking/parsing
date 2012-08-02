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
 * LIMITED TO, PROCUREMEN T OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
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

using com.habelitz.jsobjectizer.unmarshaller;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using com.habelitz.jsobjectizer.resource.resbundle;
using com.habelitz.core;

namespace com.habelitz.jsobjectizer.unmarshaller.antlrbridge
{


/**
 * This is the core class of the JSourceObjectizer to parse Java sources.
 * <p>
 * Note that this class just parses a Java source. It does not transform the
 * parser results into any <code>JSOM</code> type.
 * 
 * @see JSourceUnmarshaller 
 *
 * @author Dieter Habelitz
 */
public class JSOParser {
    
    /**
     * Defines constants for the various Java code fragment types that can be
     * parsed by the <code>JSOParser</code>.
     * 
     * @author habelitz
     */
    public enum CodeFragmentType {
        
        /**
         * Constant for code fragments representing an annotation.
         */
        ANNOTATION,
        
        /**
         * Constant for code fragments representing an <code>assert</code>
         * statement.
         */
        ASSERT_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>break</code>
         * statement.
         */
        BREAK_STATEMENT,
        
        /**
         * Constant for code fragments representing a class <code>:</code>
         * clause.
         */
        CLASS_EXTENDS_CLAUSE,
        
        /**
         * Constant for code fragments representing a complex type identifier.
         */
        COMPLEX_TYPE_IDENTIFIER,
        
        /**
         * Constant for code fragments representing a <code>continue</code>
         * statement.
         */
        CONTINUE_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>do ... while</code>
         * statement.
         */
        DO_WHILE_STATEMENT,
        
        /**
         * Constant for code fragments representing an enumeration constant.
         */
        ENUM_CONSTANT,
        
        /**
         * Constant for code fragments representing any kind of expressions.
         */
        EXPRESSION,
        
        /**
         * Constant for code fragments representing a expression statement.
         * <p>
         * An expression statement is a statement that could also be an
         * expression anywhere else. This could be an assignment expression or
         * a method call, for instance.
         */
        EXPRESSION_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>for</code>
         * statement.
         */
        FOR_STATEMENT,
        
        /**
         * Constant for code fragments representing a so called <code>forEach
         * </code> statement.
         */
        FOREACH_STATEMENT,
        
        /**
         * Constant for code fragments representing a formal parameter list.
         */
        FORMAL_PARAMETER_LIST,
        
        /**
         * Constant for code fragments representing a generic type argument
         * list.
         */
        GENERIC_TYPE_ARGUMENT_LIST,
        
        /**
         * Constant for code fragments representing a generic type parameter
         * list.
         */
        GENERIC_TYPE_PARAMETER_LIST,
        
        /**
         * Constant for code fragments representing an <code>if</code>
         * statement.
         */
        IF_STATEMENT,
        
        /**
         * Constant for code fragments representing an <code>,</code>
         * clause.
         */
        IMPLEMENTS_CLAUSE,
        
        /**
         * Constant for code fragments representing an <code>import</code>
         * declaration.
         */
        IMPORT_DECLARATION,
        
        /**
         * Constant for code fragments representing a interface <code>:
         * </code> clause.
         */
        INTERFACE_EXTENDS_CLAUSE,
        
        /**
         * Constant for the complete content of a Java source file.
         */
        JAVA_SOURCE,
        
        /**
         * Constant for code fragments representing a expression statement, i.e.
         * a label identifier followed by a colon and this followed by a further
         * statement.
         */
        LABELED_STATEMENT,
        
        /**
         * Constant for code fragments representing a modifier list (i.e. a list
         * of modifiers and/or annotations).
         */
        MODIFIER_LIST,

        /**
         * Constant for code fragments representing a <code>package</code>
         * declaration.
         */
        PACKAGE_DECLARATION,

        /**
         * Constant for code fragments representing a primitive type.
         */
        PRIMITIVE_TYPE,
        
        /**
         * Constant for code fragments representing a simple qualified
         * identifier, i.e. something that typically occurs for namespace and
         * import declarations.
         */
        QUALIFIED_IDENTIFIER,
        
        /**
         * Constant for code fragments representing a <code>return</code>
         * statement.
         */
        RETURN_STATEMENT,
        
        /**
         * Constant for code fragments representing any statement type.
         * <p>
         * Note that this doesn't include any element that may occur within a
         * compound statement block, i.e. this constant can't be used to parse
         * local variables or local class declarations.
         */
        STATEMENT,

        /**
         * Constant for code fragments representing compound statement block.
         */
        STATEMENT_BLOCK,
        
        /**
         * Constant for code fragments representing any kind of statement block
         * elements, i.e. that can be a content element of a compound statement
         * block.
         */
        STATEMENT_BLOCK_ELEMENT,

        /**
         * Constant for code fragments representing a <code>case</code> label of
         * a <code>switch</code> statement including the optional statement
         * block elements that may follow the <code>case</code> label.
         */
        SWITCH_CASE_LABEL,
        
        /**
         * Constant for code fragments representing a <code>default</code> label
         * of a <code>switch</code> statement including the optional statement
         * block elements that may follow the <code>default</code> label.
         */
        SWITCH_DEFAULT_LABEL,
        
        /**
         * Constant for code fragments representing a <code>switch</code>
         * statement.
         */
        SWITCH_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>synchronized</code>
         * statement.
         */
        SYNCHRONIZED_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>throw</code>
         * statement.
         */
        THROW_STATEMENT,
        
        /**
         * Constant for code fragments representing an <code>throws</code>
         * clause.
         */
        THROWS_CLAUSE,
        
        /**
         * Constant for code fragments representing a <code>try</code>
         * statement.
         */
        TRY_STATEMENT,
        
        /**
         * Constant for code fragments representing a <code>catch</code> clause
         * for a <code>try</code> statement.
         */
        TRY_STATEMENT_CATCH_CLAUSE,
        
        /**
         * Constant for code fragments representing a primitive or complex type
         * including static arrays of primitive or complex types.
         */
        TYPE,
        
        /**
         * Constant for code fragments representing a type declaration.
         */
        TYPE_DECLARATION,
        
        /**
         * Constant for code fragments representing a local variable
         * declaration.
         * <p>
         * <i>Local variable</i> in this context means variable declarations
         * with or without an initializer and with an optional modifier list
         * limited to annotations and the modifier <code>final</code>.
         */
        LOCAL_VARIABLE_DECLARATION,

        /**
         * Constant for code fragments representing a variable declarator
         * identifier , i.e. an identifier of a type field, a local variable or
         * a formal parameter followed by 0 or more array declarators.
         */
        VARIABLE_DECLARATOR_IDENTIFIER,

        /**
         * Constant for code fragments representing a variable initializer.
         */
        VARIABLE_INITIALIZER,
        
        /**
         * Constant for code fragments representing a <code>while</code>
         * statement.
         */
        WHILE_STATEMENT
    }
    
    private JavaLexer mLexer = new JavaLexer();
    private JavaParser mParser;
    private JavaTreeParser mTreeParser; 
    private AST2JSOMTreeAdaptor mAST2JSOMTreeAdaptor =
        new AST2JSOMTreeAdaptor();
    
    /**
     * Standard constructor.
     */
    protected JSOParser() {
        
        mLexer.mPreserveBlockComments = true;
        mLexer.mPreserveJavaDocComments = true;
        mLexer.mPreserveLineComments = true;
        mLexer.mPreserveWhitespaces = true;
        mLexer.mPreserveNewlineCharacters = true;
    }
    
    /**
     * Parses a Java file.
     * 
     * @param pJavaFile  The Java file that should get parsed. Note that it's up
     *                   to the caller to ensure that the file exists, i.e. this
     *                   will not be checked by this method.
     * @param pErrorMessages  If this argument is not <code>null</code> error
     *                        messages emited by the parser will be added to
     *                        this list. Otherwise these error messages will be
     *                        written to <code>System.err</code>.
     *                        
     * @return  An object of type <code>JSOParser.ParserResult</code>
     *          containing the root node representing a Java file and the token
     *          stream containing the tokens of the parsed source. If parsing
     *          the file has been failed but no exception has been thrown <code>
     *          null</code> will be returned and it's very likely that there's
     *          at least one message within the message list passed to this 
     *          method (if a list has been passed at all, of course).
     * 
     * @  if parsing the Java file failed.
     */
    protected ParserResult parse(JFile pJavaFile, List<String> pErrorMessages)
    {

        ParserResult result = null;
        try {
            
            result = parse(
                    new ANTLRFileStream(pJavaFile.getPath()), 
                    CodeFragmentType.JAVA_SOURCE, pErrorMessages);
        } catch (RecognitionException re) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                        .getJavaFileParsingFailedMessage(pJavaFile.ToString()), 
                    re);
        } catch (FileNotFoundException fnfe) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                    .getJavaFileParsingFailedMessage(pJavaFile.ToString()), 
                    fnfe);
        } catch (IOException ioe) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                        .getJavaFileParsingFailedMessage(pJavaFile.ToString()), 
                    ioe);
        } catch (JSourceUnmarshallerException jsue) {
            // Just catch 'JSourceUnmarshallerException' exceptions in order to
            // avoid jumping into the following 'catch' block.
            throw jsue;
        } catch (Exception e) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                        .getJavaFileParsingFailedMessage(pJavaFile.ToString()), 
                    e);
        } finally {
            if (pErrorMessages != null) {
                List<String> parserMessages;
                bool isMessageHeaderEnabled = true;
                parserMessages = mLexer.GetMessages();
                if (parserMessages.Count > 0) {
                    pErrorMessages.Add(
                            UnmarshallerMessages
                                .getParserMessagesEmitedForFileMessage(
                                        pJavaFile.getAbsolutePath()));
                    isMessageHeaderEnabled = false;
                    foreach (String message in parserMessages) {
                        pErrorMessages.Add(
                                UnmarshallerMessages
                                    .getLexerMessageMessage() + message);
                    }
                }
                if (mParser != null) {
                    parserMessages = mParser.GetMessages();
                    if (parserMessages.Count > 0) {
                        if (isMessageHeaderEnabled) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                        .getParserMessagesEmitedForFileMessage(
                                                pJavaFile.getAbsolutePath()));
                        }
                        isMessageHeaderEnabled = false;
                        foreach (String message in parserMessages) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                        .getParserMessageMessage() + message);
                        }
                    }
                }
                if (mTreeParser != null) {
                    parserMessages = mTreeParser.GetMessages();
                    if (parserMessages.Count > 0) {
                        if (isMessageHeaderEnabled) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                        .getParserMessagesEmitedForFileMessage(
                                               pJavaFile.getAbsolutePath()));
                        }
                        String TEST_STR = "JavaTreeParser.g: ";
                        foreach (String message in parserMessages) {
                            int offset = message.IndexOf(TEST_STR); 
                            if (offset != -1) {
                                pErrorMessages.Add(
                                        UnmarshallerMessages
                                            .getTreeParserMessageMessage() + 
                                        message.Substring(
                                                offset + TEST_STR.Length));
                            } else {
                                pErrorMessages.Add(
                                        UnmarshallerMessages
                                            .getTreeParserMessageMessage() + 
                                        message);
                            }
                        }
                    }
                }
            }
        }
        if (result.mTree != null) {
            return result;
        }

        return null;
    }
    
    /**
     * Parses a piece of Java code that matches a certain grammar rule.
     * 
     * @param pCodeFragment  The Java code fragment that should get parsed.
     * @param pCodeFragmentType  The code fragment type defining the grammar
     *                           rule that should be used to parse the code
     *                           fragment.
     * @param pErrorMessages  If this argument is not <code>null</code> error
     *                        messages emited by the parser will be added to
     *                        this list. Otherwise these error messages will be
     *                        written to <code>System.err</code>.
     *                        
     * @return  An object of type <code>JSOParser.ParserResult</code>
     *          containing the root node representing a Java code fragment and 
     *          the token stream containing the tokens of the parsed source. If 
     *          parsing the code fragment has been failed but no exception 
     *          has been thrown <code>null</code> will be returned and it's 
     *          very likely that there's at least one message within the message 
     *          list passed to this method (if a list has been passed at all, of
     *          course).
     * 
     * @  if parsing the code fragment 
     *                                       failed.
     */
    protected ParserResult parse(
            String pCodeFragment, CodeFragmentType pCodeFragmentType,
            List<String> pErrorMessages) {

        ParserResult result = new ParserResult();
        try {
            result = parse(
                    new ANTLRStringStream(pCodeFragment), pCodeFragmentType, 
                    pErrorMessages);
        } catch (RecognitionException re) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                    .getJavaCodeFragmentParsingFailedMessage(
                            pCodeFragment, pCodeFragmentType), re);
        } catch (JSourceUnmarshallerException jsue) {
            // Just catch 'JSourceUnmarshallerException' exceptions in order to
            // avoid jumping into the following 'catch' block.
            throw jsue;
        } catch (Exception e) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                    .getJavaCodeFragmentParsingFailedMessage(
                            pCodeFragment, pCodeFragmentType), e);
        } finally {
            if (pErrorMessages != null) {
                List<String> parserMessages;
                bool isMessageHeaderEnabled = true;
                parserMessages = mLexer.GetMessages();
                if (parserMessages.Count > 0) {
                    pErrorMessages.Add(
                            UnmarshallerMessages
                                .getParserMessagesEmitedForCodeFragmentMessage(
                                        pCodeFragment, pCodeFragmentType));
                    isMessageHeaderEnabled = false;
                    foreach (String message in parserMessages) {
                        pErrorMessages.Add(
                                UnmarshallerMessages
                                    .getLexerMessageMessage() + message);
                    }
                }
                if (mParser != null) {
                    parserMessages = mParser.GetMessages();
                    if (parserMessages.Count > 0) {
                        if (isMessageHeaderEnabled) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                        .getParserMessagesEmitedForCodeFragmentMessage(
                                                pCodeFragment, 
                                                pCodeFragmentType));
                        }
                        isMessageHeaderEnabled = false;
                        foreach (String message in parserMessages) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                        .getParserMessageMessage() + message);
                        }
                    }
                }
                if (mTreeParser != null) {
                    parserMessages = mTreeParser.GetMessages();
                    if (parserMessages.Count > 0) {
                        if (isMessageHeaderEnabled) {
                            pErrorMessages.Add(
                                    UnmarshallerMessages
                                    .getParserMessagesEmitedForCodeFragmentMessage(
                                            pCodeFragment, pCodeFragmentType));
                        }
                        foreach (String message in parserMessages) {
                            String TEST_STR = "JavaTreeParser.g: ";
                            int offset = message.IndexOf(TEST_STR); 
                            if (offset != -1) {
                                pErrorMessages.Add(
                                        UnmarshallerMessages
                                            .getTreeParserMessageMessage() + 
                                        message.Substring(
                                                offset + TEST_STR.Length));
                            } else {
                                pErrorMessages.Add(
                                        UnmarshallerMessages
                                            .getTreeParserMessageMessage() + 
                                        message);
                            }
                        }
                    }
                }
            }
        }
        if (result.mTree != null) {
            return result;
        }

        return null;
    }

    /**
     * Parses a piece of Java code that matches a certain grammar rule.
     * 
     * @param pSource  The Java source that should get parsed.
     * @param pCodeFragmentType  The code fragment type defining the grammar
     *                           rule that should be used to parse the code
     *                           fragment.
     * @param pErrorMessages  If this argument is not <code>null</code> error
     *                        messages emited by the parser will be added to
     *                        this list. Otherwise these error messages will be
     *                        written to <code>System.err</code>.
     *                        
     * @return  An object of type <code>JSOParser.ParserResult</code>
     *          containing the root node representing a Java code fragment and 
     *          the token stream containing the tokens of the parsed source.
     * 
     * @
     *         if parsing the code fragment or creating the AST failes.
     * @throws RecognitionException 
     * 
     * __TEST__  All parsable code fragments still untested for parser failure.
     */
    private ParserResult parse(
            ANTLRStringStream pSource, CodeFragmentType pCodeFragmentType,
            List<String> pErrorMessages)
    {

        ParserResult result = new ParserResult();
        bool isMessageCollectingEnabled = pErrorMessages != null;
        mLexer.CharStream = pSource;
        mLexer.EnableErrorMessageCollection(isMessageCollectingEnabled);
        TokenRewriteStream tokenRewriteStream = 
            new TokenRewriteStream(mLexer);
        if (mParser != null) {
            mParser.TokenStream = tokenRewriteStream;
        } else {
            mParser = new JavaParser(tokenRewriteStream);
            mParser.TreeAdaptor = mAST2JSOMTreeAdaptor;
        }
        mParser.EnableErrorMessageCollection(isMessageCollectingEnabled);
        AST2JSOMTree tree = null;
        if (pCodeFragmentType == CodeFragmentType.ANNOTATION) {
            tree = (AST2JSOMTree) mParser.annotation().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.ASSERT_STATEMENT) {
            tree = (AST2JSOMTree) mParser.assertStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.BREAK_STATEMENT) {
            tree = (AST2JSOMTree) mParser.breakStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.CLASS_EXTENDS_CLAUSE) {
            tree = (AST2JSOMTree) mParser.classExtendsClause().Tree;
        } else if (   pCodeFragmentType 
                   == CodeFragmentType.COMPLEX_TYPE_IDENTIFIER) {
            tree = (AST2JSOMTree) mParser.typeIdent().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.CONTINUE_STATEMENT) {
            tree = (AST2JSOMTree) mParser.continueStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.DO_WHILE_STATEMENT) {
            tree = (AST2JSOMTree) mParser.doWhileStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.ENUM_CONSTANT) {
            tree = (AST2JSOMTree) mParser.enumConstant().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.EXPRESSION) {
            tree = (AST2JSOMTree) mParser.expression().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.EXPRESSION_STATEMENT) {
            tree = (AST2JSOMTree) mParser.expressionStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.FOR_STATEMENT) {
            tree = (AST2JSOMTree) mParser.forStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.FOREACH_STATEMENT) {
            tree = (AST2JSOMTree) mParser.forEachStatement().Tree;
        } else if (   pCodeFragmentType 
                   == CodeFragmentType.FORMAL_PARAMETER_LIST) {
            tree = (AST2JSOMTree) mParser.formalParameterList().Tree;
        } else if (   pCodeFragmentType 
                   == CodeFragmentType.GENERIC_TYPE_ARGUMENT_LIST) {
            tree = (AST2JSOMTree) mParser.genericTypeArgumentList().Tree;
        } else if (   pCodeFragmentType 
                == CodeFragmentType.GENERIC_TYPE_PARAMETER_LIST) {
         tree = (AST2JSOMTree) mParser.genericTypeParameterList().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.IF_STATEMENT) {
            tree = (AST2JSOMTree) mParser.ifStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.IMPLEMENTS_CLAUSE) {
            tree = (AST2JSOMTree) mParser.implementsClause().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.IMPORT_DECLARATION) {
            tree = (AST2JSOMTree) mParser.importDeclaration().Tree;
        } else if (   pCodeFragmentType 
                   == CodeFragmentType.INTERFACE_EXTENDS_CLAUSE) {
            tree = (AST2JSOMTree) mParser.interfaceExtendsClause().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.JAVA_SOURCE) {
            tree = (AST2JSOMTree) mParser.javaSource().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.LABELED_STATEMENT) {
            tree = (AST2JSOMTree) mParser.labeledStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.LOCAL_VARIABLE_DECLARATION) {
            tree = (AST2JSOMTree) mParser.localVariableDeclaration().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.MODIFIER_LIST) {
            tree = (AST2JSOMTree) mParser.modifierList().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.PRIMITIVE_TYPE) {
            tree = (AST2JSOMTree) mParser.primitiveType().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.QUALIFIED_IDENTIFIER) {
            tree = (AST2JSOMTree) mParser.qualifiedIdentifier().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.RETURN_STATEMENT) {
            tree = (AST2JSOMTree) mParser.returnStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.STATEMENT) {
            tree = (AST2JSOMTree) mParser.statement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.STATEMENT_BLOCK) {
            tree = (AST2JSOMTree) mParser.block().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.STATEMENT_BLOCK_ELEMENT) {
            tree = (AST2JSOMTree) mParser.blockStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.SWITCH_CASE_LABEL) {
            tree = (AST2JSOMTree) mParser.switchCaseLabel().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.SWITCH_DEFAULT_LABEL) {
            tree = (AST2JSOMTree) mParser.switchDefaultLabel().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.SWITCH_STATEMENT) {
            tree = (AST2JSOMTree) mParser.switchStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.SYNCHRONIZED_STATEMENT) {
            tree = (AST2JSOMTree) mParser.synchronizedStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.THROW_STATEMENT) {
            tree = (AST2JSOMTree) mParser.throwStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.THROWS_CLAUSE) {
            tree = (AST2JSOMTree) mParser.throwsClause().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.TRY_STATEMENT) {
            tree = (AST2JSOMTree) mParser.tryStatement().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.TRY_STATEMENT_CATCH_CLAUSE) {
            tree = (AST2JSOMTree) mParser.catchClause().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.TYPE) {
            tree = (AST2JSOMTree) mParser.type().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.TYPE_DECLARATION) {
            tree = (AST2JSOMTree) mParser.typeDeclaration().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.VARIABLE_DECLARATOR_IDENTIFIER) {
            // Simply use the grammar rule for local variables.
            tree = (AST2JSOMTree) mParser.variableDeclaratorId().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.VARIABLE_INITIALIZER) {
            tree = (AST2JSOMTree) mParser.variableInitializer().Tree;
        } else if (pCodeFragmentType == CodeFragmentType.WHILE_STATEMENT) {
            tree = (AST2JSOMTree) mParser.whileStatement().Tree;
        } else if (pCodeFragmentType != null) {
            throw new JSourceUnmarshallerException(
                    UnmarshallerMessages
                        .getUnsupportedCodeFragmentTypeMessage(
                                                    pCodeFragmentType));
        } else {
            // TODO  Internationalize the message.
            throw new JSourceUnmarshallerException(
                    "The argument stating the code fragment type mustn't be " +
                    "'null'");
        }
        // On parser errors the generated parser may return something 
        // undefined rather than 'null'.
        if (!mParser.HasErrors()) {
            // TODO  It seems that the JSourceObjectizer uses the parser result
            //       instead of the tree parser result. CHECK THIS!
            CommonTreeNodeStream treeNodes = 
                new CommonTreeNodeStream(mAST2JSOMTreeAdaptor, tree);
            treeNodes.TokenStream = tokenRewriteStream;
            if (mTreeParser != null) {
                mTreeParser.Reset();
                mTreeParser.SetTreeNodeStream(treeNodes);
            } else {
                mTreeParser = new JavaTreeParser(treeNodes);
            }
            mTreeParser.EnableErrorMessageCollection(
                    isMessageCollectingEnabled);
            if (pCodeFragmentType == CodeFragmentType.ANNOTATION) {
                mTreeParser.annotation();
            } else if (   pCodeFragmentType 
                       == CodeFragmentType.COMPLEX_TYPE_IDENTIFIER) {
                mTreeParser.typeIdent();
            } else if (pCodeFragmentType == CodeFragmentType.ENUM_CONSTANT) {
                mTreeParser.enumConstant();
            } else if (pCodeFragmentType == CodeFragmentType.EXPRESSION) {
                mTreeParser.expression();
            } else if (      pCodeFragmentType 
                          == CodeFragmentType.CLASS_EXTENDS_CLAUSE
                       ||    pCodeFragmentType 
                          == CodeFragmentType.INTERFACE_EXTENDS_CLAUSE) {
                mTreeParser.extendsClause();
            } else if (   pCodeFragmentType 
                       == CodeFragmentType.FORMAL_PARAMETER_LIST) {
                mTreeParser.formalParameterList();
            } else if (   pCodeFragmentType 
                       == CodeFragmentType.GENERIC_TYPE_ARGUMENT_LIST) {
                mTreeParser.genericTypeArgumentList();
            } else if (   pCodeFragmentType 
                    == CodeFragmentType.GENERIC_TYPE_PARAMETER_LIST) {
                mTreeParser.genericTypeParameterList();
            } else if (   pCodeFragmentType 
                    == CodeFragmentType.IMPLEMENTS_CLAUSE) {
                mTreeParser.implementsClause();
            } else if (   pCodeFragmentType 
                       == CodeFragmentType.IMPORT_DECLARATION) {
                mTreeParser.importDeclaration();
            } else if (pCodeFragmentType == CodeFragmentType.JAVA_SOURCE) {
                mTreeParser.javaSource();
            } else if (pCodeFragmentType == CodeFragmentType.LOCAL_VARIABLE_DECLARATION) {
                mTreeParser.localVariableDeclaration();
            } else if (pCodeFragmentType == CodeFragmentType.MODIFIER_LIST) {
                mTreeParser.modifierList();
            } else if (pCodeFragmentType == CodeFragmentType.PRIMITIVE_TYPE) {
                mTreeParser.primitiveType();
            } else if (   pCodeFragmentType 
                       == CodeFragmentType.QUALIFIED_IDENTIFIER) {
                mTreeParser.qualifiedIdentifier();
            } else if (   pCodeFragmentType == CodeFragmentType.STATEMENT
                       || pCodeFragmentType == CodeFragmentType.ASSERT_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.BREAK_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.CONTINUE_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.DO_WHILE_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.EXPRESSION_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.FOR_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.FOREACH_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.IF_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.LABELED_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.RETURN_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.SWITCH_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.SYNCHRONIZED_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.THROW_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.TRY_STATEMENT
                       || pCodeFragmentType == CodeFragmentType.WHILE_STATEMENT) {
                mTreeParser.statement();    
            } else if (pCodeFragmentType == CodeFragmentType.SWITCH_CASE_LABEL) {
                mTreeParser.switchCaseLabel();
            } else if (pCodeFragmentType == CodeFragmentType.SWITCH_DEFAULT_LABEL) {
                mTreeParser.switchDefaultLabel();
            } else if (pCodeFragmentType == CodeFragmentType.STATEMENT_BLOCK) {
                mTreeParser.block();
            } else if (pCodeFragmentType == CodeFragmentType.STATEMENT_BLOCK_ELEMENT) {
                mTreeParser.blockStatement();
            } else if (pCodeFragmentType == CodeFragmentType.THROWS_CLAUSE) {
                mTreeParser.throwsClause();
            } else if (pCodeFragmentType == CodeFragmentType.TRY_STATEMENT_CATCH_CLAUSE) {
                mTreeParser.catchClause();
            } else if (pCodeFragmentType == CodeFragmentType.TYPE) {
                mTreeParser.type();
            } else if (pCodeFragmentType == CodeFragmentType.TYPE_DECLARATION) {
                mTreeParser.typeDeclaration();
            } else if (pCodeFragmentType == CodeFragmentType.VARIABLE_DECLARATOR_IDENTIFIER) {
                mTreeParser.variableDeclaratorId();
            } else if (pCodeFragmentType == CodeFragmentType.VARIABLE_INITIALIZER) {
                mTreeParser.variableInitializer();
            } else if (pCodeFragmentType != null) {
                throw new JSourceUnmarshallerException(
                        UnmarshallerMessages
                            .getUnsupportedCodeFragmentTypeMessage(
                                                        pCodeFragmentType));
            } else {
                // TODO  Internationalize the message.
                throw new JSourceUnmarshallerException(
                        "The argument stating the code fragment type mustn't be " +
                        "'null'");
            }

            result.mLineCount = mLexer.Line;
            result.mTokenRewriteStream = tokenRewriteStream;
            result.mTree = tree;
        }
    
        return result;
    }

    /**
     * Objects of this class will be returned by the method <code>
     * JSOParser.parse()</code>.
     * 
     * @author habelitz
     */
    protected class ParserResult {

        /**
         * Public access to the stream containing the tokens of a parsed Java
         * source.
         */
        public TokenRewriteStream mTokenRewriteStream;
        
        /**
         * Public access to the root tree of the parsed Java source.
         */
        public AST2JSOMTree mTree;

        /**
         * Public access to the line count of the parsed Java source.
         */
        public int mLineCount;

        /**
         * Standard constructor.
         */
       public ParserResult() {

            // Nothing to do.
        }
    }
}
}