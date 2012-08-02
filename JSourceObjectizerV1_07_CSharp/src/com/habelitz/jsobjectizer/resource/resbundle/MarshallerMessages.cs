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
 * This <code>StringResourceBundle</code> defines all kind of strings and 
 * messages used by the JSourceObjectizer's marshaller.
 * 
 * @author Dieter Habelitz
 */
public sealed class MarshallerMessages : StringResourceBundle
{
    /**
     * Public access to this <code>StringResourceBundle</code>'s resources.
     * 
     * Actually only one instance of this class is needed.
     */
    public static readonly StringResourceBundle MARSHALLER_MESSAGES =
        (StringResourceBundle) ResourceBundle.getBundle(
                "com.habelitz.jsobjectizer.resource.resbundle."
                + "MarshallerMessages");

    /**
     * The key to content mapping.
     * 
     * <b>CONVENTION: THE KEYS MUST BE ORDERED ALPHABETICALLY!</b>
     */
    private static readonly String[][] contents = new String[][] {

        new String[] {   "REWRITING_FAILED",
            "Rewriting of the Java source has been failed."}
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
     * Returns a message for the cases where rewriting of a Java source has been
     * failed.
     * 
     * @return  A message that stated the unsupported expression.
     */
    public static String getRewritingFailedMessage() {
        
        return MARSHALLER_MESSAGES.getResource("REWRITING_FAILED");
    }
}
}
