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

using com.habelitz.jsobjectizer.jsom.api;
using com.habelitz.jsobjectizer.jsom.api.expression;

namespace com.habelitz.jsobjectizer.jsom.api.statement
{
/**
 * This <code>Statement</code> type represents an <code>for</code> statement
 * that matches the <i>forEach</i> syntax.
 * <p>
 * The JSOM abstraction of <i>forEach</i> statements looks like
 *  <pre>
 *      for (localModifierList type identifier : expression) 
 *          statement
 *  </pre>
 * 
 * @see ForStatement
 * 
 * @author Dieter Habelitz
 */
public interface ForEachStatement : Statement {

    /**
     * Returns the expression from the <i>forEach</i> statement's initializer.
     * 
     * @return  The expression from the <i>forEach</i> statement's initializer.
     */
    Expression getExpression();
    
    /**
     * Returns the identifier from the <i>forEach</i> statement's initializer.
     * 
     * @return  The identifier from the <i>forEach</i> statement's initializer.
     */
    String getIdentifier();
    
    /**
     * Returns the local modifier list from the <i>forEach</i> statement's 
     * initializer.
     * <p>
     * Note that the modifier list may also include annotations.
     * 
     * @return  The local modifier list from the <i>forEach</i> statement's 
     *          initializer or <code>null</code> if there are no modifiers.
     */
    ModifierList getLocalModifiers();
    
    /**
     * Returns the statement that should be executed by the <i>forEach</i> loop.
     * 
     * @return  The statement that should be executed by the <i>forEach</i> 
     *          loop.
     */
    Statement getStatement();
    
    /**
     * Returns the type from the <i>forEach</i> statement's initializer.
     * 
     * @return  The type from the <i>forEach</i> statement's initializer.
     */
    Type getType();
    
    /**
     * Tells if the <i>forEach</i> statement's initializer has at least one
     * modifier (which can only be the <code>final</code> modifier here, of
     * course) or annotation.
     * 
     * @return  <code>true</code> if the <i>forEach</i> statement's initializer
     *          has at least one modifier or annotation.
     */
    bool hasModifier();
    
    /**
     * Replaces the identifier of <code>this</code>.
     * 
     * @param pNewIdentifier  The new identifier of the <i>forEach</i> 
     *                        statement's variable.
     * 
     * @return  The old identifier.
     */
    String setIdentifier(String pNewIdentifier);
}
}