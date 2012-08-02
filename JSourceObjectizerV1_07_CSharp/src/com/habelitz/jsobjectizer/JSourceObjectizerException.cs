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

namespace com.habelitz.jsobjectizer
{
    /**
     * The base exception type for all JSourceObjectizer exceptions.
     * 
     * @author Dieter Habelitz
     */
    public class JSourceObjectizerException : Exception
    {

        /** Generated serial version UID */
        private static long serialVersionUID = 6506501732949581256L;

        /**
         * Constructor.
         * 
         * @param pMessage  An error message.
         */
        public JSourceObjectizerException(String pMessage)
        {

        }

        /**
     * Constructor.
     * 
     * @param pCause  An exception that caused <code>this</code>.
     */
        public JSourceObjectizerException(Exception pCause) 
            : base("", pCause)
        {
        }

        /**
         * Constructor.
         * 
         * @param pMessage  An error message.
         * @param pCause  An exception that caused <code>this</code>.
         */
        public JSourceObjectizerException(String pMessage, Exception pCause)
            : base(pMessage, pCause)
        {

        }
    }
}