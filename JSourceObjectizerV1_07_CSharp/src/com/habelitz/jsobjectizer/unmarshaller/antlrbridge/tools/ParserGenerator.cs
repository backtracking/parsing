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

package com.habelitz.jsobjectizer.unmarshaller.antlrbridge.tools;

import java.io.*;
import java.util.*;

import org.antlr.Tool;

import com.habelitz.core.resource.resbundle.CommonErrorMessages;
import com.habelitz.core.resource.resbundle.CommonStrings;
import com.habelitz.core.resource.resbundle.CommonStrings.STRING;
import com.habelitz.jsobjectizer.resource.resbundle.ParserGeneratorMessages;

/**
 * Generates an ANTLR parser.
 *   
 * @author Dieter Habelitz
 */
public final class ParserGenerator {

    /**
     * Standard constructor.
     */
    public ParserGenerator() {
        // Nothing to do.
    }
    
    /**
     * Generates the parsers from stated ANTLR grammars.
     * 
     * @param pOutputPath  The path the generated parsers (and lexer) should be
     *                     written to. If this argument is <code>null</code> the
     *                     current path will be used as output path. Otherwise
     *                     it's up to the caller to ensure that the path exists. 
     *                     Note that the generated files containing token 
     *                     mappings will be written to this directory, too. They 
     *                     may be removed if they are not needed.
     * @param pGrammarFiles  The ANTLR grammar(s). At least one ANTLR grammar 
     *                       must be stated and it's up to the caller to ensure 
     *                       that the file(s) exist(s).
     */
    public static void generateParser(
            String pOutputPath, String ... pGrammarFiles) {
        if (pGrammarFiles == null) {
            throw new IllegalArgumentException(
                CommonErrorMessages.getArgumentIsNullMessage("pGrammarFiles"));
        }
        if (pGrammarFiles.length == 0) {
            throw new IllegalArgumentException(
                    CommonErrorMessages.getArgumentIsEmptyMessage(
                        "pGrammarFiles", CommonStrings.getString(STRING.FILE)));
        }
        for (String fileName : pGrammarFiles) {
            if (fileName == null) {
                throw new IllegalArgumentException(
                        CommonErrorMessages
                            .getArgumentContainsNullMessage("pGrammarFiles"));
            }
            if (fileName.length() == 0) {
                throw new IllegalArgumentException(
                        CommonErrorMessages
                            .getArgumentContainsEmptyStringMessage(
                                    "pGrammarFiles"));
            }
        }
        System.out.println(
                ParserGeneratorMessages.getParserGenerationStartMessage());
        String[] args = null;
        int currentOffset = 0;
        if (pOutputPath != null) {
            args = new String[pGrammarFiles.length + 4];
            args[currentOffset++] = "-fo";
            args[currentOffset++] = pOutputPath;
            args[currentOffset++] = "-lib";
            args[currentOffset++] = pOutputPath;
        } else {
            args = new String[pGrammarFiles.length];
        }
        System.arraycopy(
                pGrammarFiles, 0, args, currentOffset, pGrammarFiles.length);
        try {
            Tool tool = new Tool(args);
            tool.process();
        } catch (Exception e) {
            e.printStackTrace();
        }
        System.out.println(
                    ParserGeneratorMessages.getParserGenerationEndMessage());
    }
    
    /**
     * Generates the parsers from stated ANTLR grammars.
     * <p>
     * The following two arguments must be passed to the main method:
     * <p>
     *  <table border=1>
     *      <tr>
     *          <td nowrap>
     *              -o
     *          </td>
     *          <td>
     *              This argument must be followed by a path the generated 
     *              parser sources should be written to. If there are more than 
     *              one of this argument always the last one will be used. This 
     *              may be useful if a certain path should be used temporarily 
     *              without the need to remove the standard path from the 
     *              argument list.
     *              <p>
     *              Note that the generated files containing token mappings will
     *              be written to this directory, too. They may be removed if 
     *              they are not needed. 
     *          </td>
     *      </tr>
     *      <tr>
     *          <td nowrap>
     *              -p
     *          </td>
     *          <td>
     *              This argument must be followed by one or more grammar file
     *              names (including the appropriate paths if necessary).
     *          </td>
     *      </tr>
     *  </table>
     * 
     * @param args  See above.
     */
    public static void main(String[] args) {
        String outputPath = null;
        List<String> grammarFiles = new ArrayList<String>();
        boolean hasGArg = false;
        for (int offset = 0; offset < args.length; offset++) {
            String arg = args[offset];
            if ("-h".equalsIgnoreCase(arg) || "-help".equalsIgnoreCase(arg)) {
                printUsage(null, null);
                System.exit(0);
            } else if ("-o".equalsIgnoreCase(arg)) {
                offset++;
                // Reset 'outputPath' for the case that there are more then one
                // '-o' arguments.
                outputPath = null;
                if (offset < args.length) {
                    arg = args[offset];
                    if (arg.length() > 0) {
                        if (arg.charAt(0) == '-') {
                            // It's the next argument, so 'push back' and
                            // continue.
                            offset--;
                            continue;
                        }
                        File file = null;
                        try {
                            file = new File(arg).getCanonicalFile();
                        } catch (IOException e) {
                            file = null;
                        }
                        if (file != null) {
                            if (file.isFile()) {
                                printUsage(
                                        args,
                                        ParserGeneratorMessages
                                            .getOArgumentIsFileMessage(
                                                                file.toString()));
                                System.exit(0);
                            }
                            outputPath = file.getPath();
                        } else {
                            printUsage(
                                    args, 
                                    ParserGeneratorMessages
                                        .getOArgumentPathNotFoundMessage(arg));
                            System.exit(0);
                        }
                    }
                }
            } else if ("-g".equalsIgnoreCase(arg)) {
                hasGArg = true;
                while (true) {
                    offset++;
                    if (offset == args.length) {
                        break;
                    }
                    arg = args[offset];
                    if (arg.length() > 0) {
                        if (arg.charAt(0) == '-') {
                            // It's the next argument, so 'push back' and
                            // continue with the outer loop.
                            offset--;
                            break;
                        }
                    }
                    File file = new File(arg);
                    if (!file.exists()) {
                        printUsage(
                                args,
                                ParserGeneratorMessages
                                    .getGArgumentFileNotFoundMessage(
                                                            file.toString()));
                        System.exit(0);
                    } else if (file.isDirectory()) {
                        printUsage(
                                args,
                                ParserGeneratorMessages
                                .getGArgumentIsDirectoryMessage(
                                                            file.toString()));
                        System.exit(0);
                    }
                    grammarFiles.add(arg);
                }
            }
        }
        if (!hasGArg) {
            printUsage(
                    args, ParserGeneratorMessages.getGArgumentMissingMessage());
            System.exit(0);
        }
        if (grammarFiles.size() == 0) {
            printUsage(
                    args, 
                    ParserGeneratorMessages.getGArgumentFileMissingMessage());
            System.exit(0);
        }
        
        generateParser(
                outputPath,
                grammarFiles.toArray(new String[grammarFiles.size()]));
    }
    
    /**
     * Prints the usage of the <code>ParserGenerator</code> main method.
     * 
     * If at least one of the arguments is not <code>null</code> the usage 
     * information will be written to <code>System.err</code> but to <code>
     * System.out</code> otherwise.
     * 
     * @param args  If the usage should be printed because of an invalid
     *              argument line the array of the arguments as passed to the
     *              main method can be passed forward to this method, too. This
     *              method will then print the wrong argument line to <code>
     *              System.err</code>, prefixed by the resource bundle string
     *              <code>INVALID_ARG_LINE</code>. If this argument is an empty
     *              array an appropriate <i>empty argument list</i> message will
     *              be written to <code>System.err</code>. If the argument line
     *              is okay this argument must be <code>null</code>, of 
     *              course.
     * @param errorMsg  An optional error message that should be written to
     *                  <code>System.err</code> or <code>null</code>. If the
     *                  this argument is not <code>null</code> indicating an
     *                  invalid argument line this argument line will be printed
     *                  out first. 
     */
    private static void printUsage(String[] args, String errorMsg) {
        boolean printUsageToSystemErrEnabled = false;
        if (args != null) {
            StringBuilder sbArgs = new StringBuilder(
                    ParserGeneratorMessages.getInvalidArgumentLineMessage());
            final int INIT_LEN = sbArgs.length();
            if (args.length > 0) {
                for (String arg : args) {
                    if (arg.length() == 0) {
                        continue;
                    }
                    if (sbArgs.length() > INIT_LEN) {
                        sbArgs.append(' ');
                    }
                    sbArgs.append(arg);
                }
            }
            if (sbArgs.length() == INIT_LEN) {
                sbArgs.append(
                        ParserGeneratorMessages.getEmptyArgumentLineMessage());
            }
            System.err.println(sbArgs);
            printUsageToSystemErrEnabled = true;
        }
        if (errorMsg != null) {
            System.err.println("" + errorMsg);
            printUsageToSystemErrEnabled = true;
        }
        PrintStream out = null;
        if (printUsageToSystemErrEnabled) {
            out = System.err;
        } else {
            out = System.out;
        }
        out.println(ParserGeneratorMessages.getUsageMessage());
    }
}

