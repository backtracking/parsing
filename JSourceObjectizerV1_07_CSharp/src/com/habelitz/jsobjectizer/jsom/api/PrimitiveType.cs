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
using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
{
    /**
     * Defines constants for each primitive type.
     * 
     * @author Dieter Habelitz
     */
    class TypeKeywordAttr : Attribute
    {
        private string mModifierAsString;

        internal TypeKeywordAttr(string modifierAsString)
        {
            mModifierAsString = modifierAsString;
        }
        public string getTypeAsString()
        {
            return mModifierAsString;
        }
    }

    public static class TypeKeywords
    {
        public static string getTypeAsString(this TypeKeyword p)
        {
            TypeKeywordAttr attr = GetAttr(p);
            return attr.getTypeAsString();
        }

        private static TypeKeywordAttr GetAttr(TypeKeyword p)
        {
            return (TypeKeywordAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(TypeKeywordAttr));
        }

        private static MemberInfo ForValue(TypeKeyword p)
        {
            return typeof(TypeKeyword).GetField(Enum.GetName(typeof(TypeKeyword), p));
        }
    }

    public enum TypeKeyword
    {

        /**
         * This constant represents the primitive type <code>bool</code>. 
         */
        [TypeKeywordAttr("bool")]
        BOOLEAN,

        /**
        * This constant represents the primitive type <code>bool</code>. 
        */
        [TypeKeywordAttr("char")]
        CHAR,

        /**
         * This constant represents the primitive type <code>byte</code>. 
         */
        [TypeKeywordAttr("byte")]
        BYTE,

        /**
         * This constant represents the primitive type <code>short</code>. 
         */
        [TypeKeywordAttr("short")]
        SHORT,

        /**
         * This constant represents the primitive type <code>int</code>. 
         */
        [TypeKeywordAttr("int")]
        INT,

        /**
         * This constant represents the primitive type <code>long</code>. 
         */
        [TypeKeywordAttr("long")]
        LONG,

        /**
         * This constant represents the primitive type <code>float</code>. 
         */
        [TypeKeywordAttr("float")]
        FLOAT,

        /**
         * This constant represents the primitive type <code>double</code>. 
         */
        [TypeKeywordAttr("double")]
        DOUBLE
    }
/**
 * This <code>JSOM</code> represents a primitive type.
 * 
 * @author Dieter Habelitz
 */
public interface PrimitiveType : JSOM {
    
    

    /**
     * Returns the type constant for the type represented by <code>this</code>.
     * 
     * @return  One of the <code>PrimitiveType.TypeKeyword</code> constants.
     */
    /*public*/ TypeKeyword getTypeKeyword();

    /**
     * Returns the type constant for the type represented by <code>this</code>.
     * 
     * @return  One of the <code>PrimitiveType.TypeKeyword</code> constants.
     * 
     * @deprecated  Replaced by {@link #getTypeKeyword()}
     */
    [Obsolete]
    /*public*/ TypeKeyword getTypeKeywort();
}
}