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

import java.util.*;
import java.io.*;
import org.antlr.runtime.tree.Tree;
import com.habelitz.jsobjectizer.unmarshaller.*;
import com.habelitz.jsobjectizer.unmarshaller.antlrbridge.*;

/**
 * Writes out formated Java class structures.
 * 
 * This class may be helpful for debug purposes. It can be used to parse a Java
 * file and then create a structured text representation of the parser result,
 * i.e. of the node tree.
 *  
 * @author Habelitz
 */
public final class TreeStructureBuilder extends JSOParser {

    private static final String NL = System.getProperty("line.separator");
    private static final String INDENTATION_STEP = "|---";
    private final StringBuilder mCurrentIndentation = new StringBuilder();
    private final List<String> mErrorMessages = new ArrayList<String>();
    
    /**
     * Standard constructor.
     */
    public TreeStructureBuilder() {
        super();
    }

    /**
     * Writes the Java class structure into the given <code>Writer</code>
     * object.
     * 
     * @param pJavaSourceFile  A Java source file.
     * @param pDest  The destination the generated textual tree structure should
     *               be written to.
     */
    public final void writeTreeStructure(
                            final File pJavaSourceFile, final Writer pDest) {
        
        ParserResult parserResult = null;
        try {
            System.out.println("parse: " + pJavaSourceFile.getPath());
            parserResult = parse(pJavaSourceFile, mErrorMessages);
        } catch (JSourceUnmarshallerException jsue) {
            jsue.printStackTrace();
        }
        if (mErrorMessages.size() > 0) {
            StringBuilder sbMsg = new StringBuilder("Recognition error: ");
            final int START_LEN = sbMsg.length();
            for (String errorMessage : mErrorMessages) {
                sbMsg.replace(START_LEN, sbMsg.length(), errorMessage);
                System.err.println(sbMsg);
            }
            mErrorMessages.clear();
        }
        if (parserResult == null) {
            throw new RuntimeException("No parser result available.");
        }
        writeTreeStructure(pDest, parserResult.mTree);
    }
    
    /**
     * Variant of the method that allows recursive calls.
     * 
     * @param pDest  The destination the generated textual tree structure should
     *               be written to.
     * @param pRootNode  The (current) root node.
     */
    private final void writeTreeStructure(
            final Writer pDest, final Tree pRootNode) {
        
        try {
            pDest.write(mCurrentIndentation.toString());
            pDest.write(Integer.toString(pRootNode.getType()));
            pDest.write(':');
            pDest.write(pRootNode.getText());
            pDest.write(NL);
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }
        int noOfChildren = pRootNode.getChildCount();
        mCurrentIndentation.append(INDENTATION_STEP);
        for (int offset = 0; offset < noOfChildren; offset++) {
            Tree childNode = pRootNode.getChild(offset);
            if (childNode != null) {
                writeTreeStructure(pDest, childNode);
            }
        }
        mCurrentIndentation.delete(
                mCurrentIndentation.length() - INDENTATION_STEP.length(), 
                mCurrentIndentation.length());
    }
    
    /**
     * Parses Java source files, creates appropriate formated textual tree
     * structures and writes them into a file.
     * 
     * @param args  Argument line: -s {list of java source files} -o {output 
     *              path for the tree structures}
     */
    public static void main (String[] args) {
        
        if (args.length < 4) {
            printUsage(true);
            System.exit(0);
        }
        File outputDir = null;
        List<File> javaFiles = new ArrayList<File>();
        boolean sArgEnabled = false;
        boolean oArgEnabled = false;
        for (String arg : args) {
            if ("-h".equals(arg) || "-help".equals(arg)) {
                printUsage(false);
                System.exit(0);
            }
            if ("-s".equals(arg)) { 
                oArgEnabled = false;
                sArgEnabled = true;
                continue;
            }
            if ("-o".equals(arg)) {
                sArgEnabled = false;
                oArgEnabled = true;
                continue;
            }
            if (arg.length() > 0) {
                if (sArgEnabled) {
                    File file = new File(arg);
                    if (!file.exists() || !file.isFile()) {
                        System.err.print("invalid file name '" + arg + "'.");
                        printUsage(true);
                        System.exit(0);
                    }
                    javaFiles.add(file);
                } else if (oArgEnabled) {
                    outputDir = new File(arg);
                    if (!outputDir.exists() || !outputDir.isDirectory()) {
                        System.err.print(
                                      "invalid directory name '" + arg + "'.");
                        printUsage(true);
                        System.exit(0);
                    }
                    oArgEnabled = false;
                }
            }
        }
        TreeStructureBuilder treeStructureBuilder = new TreeStructureBuilder();
        try {
            StringBuilder sbTypeIdent = new StringBuilder();
            for (File file : javaFiles) {
                sbTypeIdent.replace(0, sbTypeIdent.length(), file.getName());
                int offset = sbTypeIdent.lastIndexOf(".java");
                sbTypeIdent.replace(offset, sbTypeIdent.length(), ".txt");
                BufferedWriter writer = new BufferedWriter(
                        new FileWriter(new File(
                                        outputDir, sbTypeIdent.toString())));
                treeStructureBuilder.writeTreeStructure(file, writer);
                writer.close();
            }
        } catch (IOException ioe) {
            ioe.printStackTrace();
        }
    }
    
    /**
     * Prints out the usage of the main method.
     * 
     * @param toSystemErr  <code>true</code> if the usage should be written to
     *                     <code>System.err</code> instead to <code>
     *                     System.out</code>.
     */
    private static void printUsage(boolean toSystemErr) {
        
        PrintStream out = null;
        if (toSystemErr) {
            out = System.err;
        } else {
            out = System.out;
        }
        out.println("usage:");
        out.println("java [anyJavaArgs] TreeStructureBuilder -s <list of java "
                    + "source files> -o <output path for the tree structures>");
    }
}

