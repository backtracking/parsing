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

using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
{
    /**
     * This <code>JSOM</code> type represents a generic type argument.
     * <p>
     * There are four variants of how generic type argument can be stated:
     *  <ol>
     *      <li><code>&lt;AnyType&gt;</code></li>
     *      <li><code>&lt;?&gt;</code></li>
     *      <li><code>&lt;? : AnyType&gt;</code></li>
     *      <li><code>&lt;? super AnyType&gt;</code></li>
     *  </ol>
     * This class supports the representation of all these variants.
     * 
     * @author Dieter Habelitz
     */
    /**
     * Defines constants for the various generic type argument variants.
     * 
     * @author Dieter Habelitz
     */
    public enum Variant
    {

        /**
         * Constant for the generic type argument variant <code>&lt;AnyType&gt;
         * </code>.
         */
        NOT_WILDCARDED,
        /**
         * Constant for the generic type argument variant <code>&lt;?&gt;</code>.
         */
        WILDCARDED_NOT_BOUND,
        /**
         * Constant for the generic type argument variant <code>&lt;? : 
         * AnyType&gt;</code>.
         */
        WILDCARDED_EXTENDS_BOUND,
        /**
         * Constant for the generic type argument variant <code>&lt;? super 
         * AnyType&gt;</code>.
         */
        WILDCARDED_SUPER_BOUND
    }

    public interface GenericTypeArgument : JSOM
    {



        /**
         * Returns the type stated by the generic type argument.
         * <p>
         * For the generic type variant <code>Variant.NOT_WILDCARDED</code> the
         * result of the method is the generic type itself but for the variants
         * <code>Variant.WILDCARDED_EXTENDS_BOUND</code> and <code>
         * Variant.WILDCARDED_SUPER_BOUND</code> the returned type corresponds to
         * the bound type (i.e. the type following the <code>:</code> or
         * <code>super</code> keyword).
         * 
         * @return  The type stated by the generic type argument or <code>null
         *          </code> if <code>this</code> represents a <code>
         *          Variant.WILDCARDED_NOT_BOUND</code> generic type argument.
         */
        /*public*/ Type getType();

        /**
         * Returns the variant of the generic type argument represented by <code>
         * this</code>.
         * 
         * @return  One of the <code>GenericTypeArgument.Variant.???</code> 
         *          constants.
         */
        /*public*/ Variant getVariant();
    }
}