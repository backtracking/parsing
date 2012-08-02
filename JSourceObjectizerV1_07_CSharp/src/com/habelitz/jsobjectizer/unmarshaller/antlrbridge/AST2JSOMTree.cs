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
 * The main purpose if this class is to avoid a lot of casts from the ANTLR
 * runtime base <code>Tree</code> types to more specialized tree types. 
 *
 * @author Dieter Habelitz
 */
public class AST2JSOMTree : CommonTree {
    
    /**
     * Standard constructor.
     *
     * __TEST__
     */
    protected AST2JSOMTree() :base() {
        
        //base();
    }
    
    /**
     * Constructor.
     * 
     * @param pToken  The payload of the new tree object. 
     *
     * __TEST__
     */
    public AST2JSOMTree(IToken pToken):base(pToken) {
        
        //base(pToken);
    }

    /**
     * Copy constructor.
     * 
     * @param pTree  The object that should be cloned.
     *
     * __TEST__
     */
    public AST2JSOMTree(AST2JSOMTree pTree) : base(pTree) {
        
        //base(pTree);
    }
    
    /**
     * @see org.antlr.runtime.tree.BaseTree#getChild(int)
     *
     * __TEST__
     */
    public override ITree GetChild(int pOffset)
    {
        return base.GetChild(pOffset);
    }
    
    
    /**
     * @see org.antlr.runtime.tree.CommonTree#dupNode()
     *
     * __TEST__
     */

    public override ITree DupNode() {
        return new AST2JSOMTree(this);
    }
}
}