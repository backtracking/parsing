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
using Antlr.Runtime;
using Antlr.Runtime.Tree;

namespace com.habelitz.jsobjectizer.unmarshaller.antlrbridge {
/**
 * Wrappes the type <code>org.antlr.runtime.tree.CommonErrorNode</code>.
 *
 * @author Dieter Habelitz
 */
public class AST2JSOMCommonErrorNode : AST2JSOMTree {
    
    private CommonErrorNode mCommonErrorNode;
    
    /**
     * Constructor.
     * 
     * @param pInput  Will be passed to the constructor of the wrapped object.
     * @param pStart  Will be passed to the constructor of the wrapped object.
     * @param pStop  Will be passed to the constructor of the wrapped object.
     * @param pException  Will be passed to the constructor of the wrapped 
     *                    object.
     *
     * __TEST__
     */
    public AST2JSOMCommonErrorNode(
            ITokenStream pInput, IToken pStart, IToken pStop, 
            RecognitionException pException) :base() {
        
        //base();
        mCommonErrorNode = 
            new CommonErrorNode(pInput, pStart, pStop, pException);
    }
    
    // Delegation calls to the wrapped tree node:
    
    /**
     * Calls the appropriate method of the wrapped object and returns the result
     * of this call.
     *
     * @return  The result returned from the wrapped object.
     * 
     * __TEST__
     */
    public override bool IsNil 
    { 
        get { return mCommonErrorNode.IsNil; } 
    }

    /**
     * Calls the appropriate method of the wrapped object and returns the result
     * of this call.
     *
     * @return  The result returned from the wrapped object.
     * 
     * __TEST__
     */
    public override int Type 
    { 
        get { return mCommonErrorNode.Type; } 
    }

    /**
     * Calls the appropriate method of the wrapped object and returns the result
     * of this call.
     *
     * @return  The result returned from the wrapped object.
     * 
     * __TEST__
     */

    public override string Text 
    { 
        get { return mCommonErrorNode.Text; } 
    }

    /**
     * Calls the appropriate method of the wrapped object and returns the result
     * of this call.
     *
     * @return  The result returned from the wrapped object.
     * 
     * __TEST__
     */
    public override String ToString() {
        
        return mCommonErrorNode.ToString();
    }
}
}