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
//using NL = com.habelitz.core.Constants.NL;
//import static com.habelitz.core.Constants.NL;

namespace com.habelitz.jsobjectizer.resource.resbundle {
/**
 * This <code>StringResourceBundle</code> defines all kind of strings and 
 * messages used by the <code>ParserGenerator</code>.
 * 
 * @author Dieter Habelitz
 */
public sealed class ParserGeneratorMessages : StringResourceBundle
{
    /**
     * Public access to this <code>StringResourceBundle</code>'s resources.
     * 
     * Actually only one instance of this class is needed.
     */
    private static readonly StringResourceBundle PARSER_GENERAOR_MESSAGES =
        (StringResourceBundle) ResourceBundle.getBundle(
                "com.habelitz.jsobjectizer.resource.resbundle."
                + "ParserGeneratorMessages");

    /**
     * The key to content mapping.
     * 
     * <b>CONVENTION: THE KEYS MUST BE ORDERED ALPHABETICALLY!</b>
     */
    private static readonly String[][] contents = new String[][] { 

        // Error message for the case where at least one of the '-g' parameters 
        // is a directory instead of a file.
        new String[] { "G_ARG_IS_DIR",
          "''{0}'' passed with the argument -g is a directory instead of a " +
          "file."},

        // Error message for the case where at least one of the '-g' parameters 
        // states a file that doesn't exist.
        new String[] { "G_ARG_FILE_NOT_FOUND",
          "The file ''{0}'' stated with the argument -g has not been found."},
                
        // Information string that signals that the parser generation starts.
        new String[] { "GEN_START", "Generate parser(s) ..." },

        // Information string that signals that the parser generation has been
        // finished.
        new String[] { "GEN_END", "... finished" },

        // May be used to prefix an invalid argument line.
        new String[] { "INVALID_ARG_LINE", "Invalid main program argument line:" },

        // States that no arguments have been passed.
        new String[] { "NO_ARGS", "Empty argument list." },

        // Error message if no '-g' argument has been stated.
        new String[] { "NO_G_ARG", "The argument -g is missing." },
        
        // Error message for the case where no file has been stated for the main 
        // program argument '-g'.
        new String[] { "NO_G_ARG_FILE",
           "The argument -g must be followed at least by one file name."},

        // Error message for the case where the '-o' parameter is a file instead
        // of a directory.
        new String[] { "O_ARG_IS_FILE",
          "''{0}'' passed with the argument -o is a file instead of a " +
          "directory."},

        // Error message for the case where the '-o' path doesn't exist.
        new String[] { "O_ARG_PATH_NOT_FOUND",
          "The path ''{0}'' stated with the argument -o has not been found."},

        // The 'Usage' message.
        new String[] { "USAGE",
          "Usage: " + Constants.NL + 
          "    java [any Java VM args] ParserGenerator [ParserGenerator args]" +
          "    arguments:" + Constants.NL +
          "        -o : the path the generated files should be written to" + 
          Constants.NL +
          "        -g : one or more grammar files (obligatory)" +
          Constants.NL +
          "        -h : this usage information" +
          Constants.NL +
          "    Note that the argument -g are obligatory unless the argument " +
          "-h has been stated. " +
          Constants.NL +
          "    If the option -o hasn't been stated the current dirrectory " +
          "will become the output directory."}
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
     * Returns a message telling that the argument list of the main program call
     * is empty.
     * 
     * @return  A message telling that the argument list of the main program 
     *          call is empty.
     */
    public static String getEmptyArgumentLineMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("NO_ARGS");
    }
    
    /**
     * Returns a message telling that the main program argument <i>-g</i> is 
     * missing.
     * 
     * @return  A message telling that the main program argument <i>-g</i> is 
     *          missing.
     */
    public static String getGArgumentMissingMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("NO_G_ARG");
    }
    
    /**
     * Returns a message telling that no file has been stated for the main
     * program argument <i>-g</p>.
     * 
     * @return  A message telling no file has been stated for the main program
     *          argument <i>-g</p>.
     */
    public static String getGArgumentFileMissingMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("NO_G_ARG_FILE");
    }
    
    /**
     * Returns a message telling that the <code>-g</code> parameter states a
     * directory instead of a file.
     * 
     * @param pPath  The path stated by the <code>-g</code> parameter.
     * 
     * @return  A message telling that the <code>-g</code> parameter states a
     *          directory instead of a file.
     */
    public static String getGArgumentIsDirectoryMessage(String pPath) {
        
        return PARSER_GENERAOR_MESSAGES.getResource(
                                        "G_ARG_IS_DIR", new String[] {pPath});
    }
    
    /**
     * Returns a message telling that at least one file stated by the <code>-g
     * </code> argument couldn't be found.
     * 
     * @param pFile  The file that have been stated by the <code>-g</code> 
     *               argument but that couldn't be found.
     * 
     * @return  A message telling that at least one file stated by the <code>-g
     *          </code> argument couldn't be found.
     */
    public static String getGArgumentFileNotFoundMessage(String pFile) {
        
        return PARSER_GENERAOR_MESSAGES.getResource(
                                "G_ARG_FILE_NOT_FOUND", new String[] {pFile});
    }
    
    /**
     * Returns a message an invalid argument line can be prefixed with.
     * 
     * @return  A message an invalid argument line can be prefixed with.
     */
    public static String getInvalidArgumentLineMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("INVALID_ARG_LINE");
    }
    
    /**
     * Returns a message telling that the <code>-o</code> parameter states a
     * file instead of a directory.
     * 
     * @param pFileNameAndPath  The path and file name of the file stated by the
     *                          <code>-o</code> parameter.
     * 
     * @return  A message telling that the <code>-o</code> parameter states a
     *          file instead of a directory.
     */
    public static String getOArgumentIsFileMessage(String pFileNameAndPath) {
        
        return PARSER_GENERAOR_MESSAGES.getResource(
                "O_ARG_IS_FILE", new String[] {pFileNameAndPath});
    }
    
    /**
     * Returns a message telling that the path stated by the <code>-o</code> 
     * argument couldn't be found.
     * 
     * @param pPath  The path stated by the <code>-o</code> parameter.
     * 
     * @return  A message telling that the path stated by the <code>-o</code> 
     *          argument couldn't be found.
     */
    public static String getOArgumentPathNotFoundMessage(String pPath) {
        
        return PARSER_GENERAOR_MESSAGES.getResource(
                    "O_ARG_PATH_NOT_FOUND", new String[] {pPath});
    }
    
    /**
     * Returns an information string that signals that the parser generation
     * has been finnished.
     * 
     * @return  The message string.
     */
    public static String getParserGenerationEndMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("GEN_END");
    }
    
    /**
     * Returns an information string that signals that the parser generation
     * starts.
     * 
     * @return  The message string.
     */
    public static String getParserGenerationStartMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("GEN_START");
    }
    
    /**
     * Returns the <i>usage</i> message regarding the main program call via the
     * command line.
     * 
     * @return  The <i>usage</i> message regarding the main program call via the
     *          command line.
     */
    public static String getUsageMessage() {
        
        return PARSER_GENERAOR_MESSAGES.getResource("USAGE");
    }
}
}