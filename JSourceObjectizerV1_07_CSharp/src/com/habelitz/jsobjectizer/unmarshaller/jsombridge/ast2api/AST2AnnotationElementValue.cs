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
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;
using com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api.expression;
using Expression = com.habelitz.jsobjectizer.jsom.api.expression.Expression;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api
{
/** 
 * This <code>JSOM</code> type represents an annotation initialization value.
 * <p>
 * There are three variants of how annotation initialization values can occur:
 *  <ol>
 *      <li>
 *          a list of annotation element values (for initializing an
 *          annotation array element) 
 *      </li>
 *      <li>
 *          an annotation
 *      </li>
 *      <li>
 *          an expression
 *      </li>
 *  </ol>
 * <p>
 * The interface <code>AnnotationElementValue</code> defines constants for each 
 * of these variants. Furthermore there are appropriate getter methods for each 
 * variant.
 * 
 * @author Dieter Habelitz
 */
public class AST2AnnotationElementValue : AST2JSOM, AnnotationElementValue {
    
    /*
     * One of the 'AnnotationElementValue.RValueType.???' constants.
     */
    private RValueType mRValueType;
    /*
     * The list of annotation element values for the cases where
     * 'mRValueType == RValueType.ANNOTATION_ELEMENT_VALUES'. 
     */
    private List<AnnotationElementValue> mAnnotationElemArray;
    /*
     * The list of annotation element values for the cases where
     * 'mRValueType == RValueType.ANNOTATION'. 
     */
    private Annotation mAnnotation;
    /*
     * The list of annotation element values for the cases where
     * 'mRValueType == RValueType.EXPRESSION'. 
     */
    private Expression mExpression;
        
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing an annotation element value.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2AnnotationElementValue(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.ANNOTATION_ELEMENT_VALUE, pTokenRewriteStream)
    {
        if (pTree.Type == JavaTreeParser.ANNOTATION_INIT_ARRAY_ELEMENT) {
            mRValueType = RValueType.ANNOTATION_ELEMENT_VALUES;
        } else if (pTree.Type == JavaTreeParser.AT) {
            mRValueType = RValueType.ANNOTATION;
        } else if (pTree.Type == JavaTreeParser.EXPR) {
            mRValueType = RValueType.EXPRESSION;
        } else  {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
    }
    
    /**
     * Returns the annotation for the cases where <code>
     * getAnnotationRValueType() == RValueType.ANNOTATION</code>.
     * 
     * @return  The annotation  or <code>null</code> if <code>
     *          getAnnotationRValueType() != RValueType.ANNOTATION</code>.
     */
    public Annotation getAnnotation() {
        
        if (mRValueType != RValueType.ANNOTATION) {
            return null;
        }
        if (mAnnotation == null) {
            mAnnotation =
                    new AST2Annotation((AST2JSOMTree)getTreeNode(), getTokenRewriteStream());
        }
        
        return mAnnotation;
    }

    /**
     * Returns a list of the annotation element values for the cases where 
     * <code>getAnnotationRValueType() == 
     * RValueType.ANNOTATION_ELEMENT_VALUES</code>.
     * <p>
     * Calling this method equals an <code>getAnnotationElementValues(null)
     * </code> call.
     * 
     * @see #getAnnotationElementValues(List)
     *  
     * @return  A list of the annotation element values. If <code>
     *          getAnnotationRValueType() != 
     *          RValueType.ANNOTATION_ELEMENT_VALUES</code> <code>null</code> 
     *          will be returned.
     */
    public List<AnnotationElementValue> getAnnotationElementValues() {
        
        return getAnnotationElementValues(null);
    }

    /**
     * Returns a list of the annotation element values for the cases where 
     * <code>getAnnotationRValueType() == 
     * RValueType.ANNOTATION_ELEMENT_VALUES</code>.
     * 
     * @param  pList  If this argument isn't <code>null</code> the annotation
     *                element values will be added to this list and this list
     *                object will be returned. Otherwise a new list will be 
     *                created for the result.
     *  
     * @return  A list of the annotation element values. If <code>
     *          getAnnotationRValueType() != 
     *          RValueType.ANNOTATION_ELEMENT_VALUES</code> <code>null</code> 
     *          will be returned, even if the argument <code>pList</code> isn't 
     *          <code>null</code>.
     */
    public List<AnnotationElementValue> getAnnotationElementValues(
                                        List<AnnotationElementValue> pList) {
        
        if (mRValueType != RValueType.ANNOTATION_ELEMENT_VALUES) {
            return null;
        }
        if (mAnnotationElemArray == null) {
            resolveAnnotationElementValues();
        }
        List<AnnotationElementValue> result = pList;
        if (result == null) {
            result = new List<AnnotationElementValue>(
                                                mAnnotationElemArray.Count);
        }
        result.AddRange(mAnnotationElemArray);
        
        return result;
    }
    
    /**
     * Returns the constant for the annotation element value variant represented
     * by <code>this</code>.
     * 
     * @return  One of the <code>AnnotationElementValue.RValueType.???</code> 
     *          constants.
     */
    public RValueType getAnnotationRValueType() {
        
        return mRValueType;
    }

    /**
     * Returns the <i>character in line</i> position where the annotation 
     * element value starts.
     * 
     * @return  The <i>character in line</i> position where the annotation 
     *          element value starts.
     */
    public int getCharPositionInLine() {
        
        if (mRValueType == RValueType.EXPRESSION) {
            // Get the character position from the JSOM expression.
            return getExpression().getCharPositionInLine();
        }

        // Get the character position from the '{' or '@' character.
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * Returns the expression for the cases where <code>
     * getAnnotationRValueType() == RValueType.EXPRESSION</code>.
     * 
     * @return  The expression or <code>null</code> if <code>
     *          getAnnotationRValueType() != RValueType.EXPRESSION</code>.
     */
    public Expression getExpression() {
        
        if (mRValueType != RValueType.EXPRESSION) {
            return null;
        }
        if (mExpression == null) {
            mExpression = AST2Expression.resolveExpression((AST2JSOMTree)
                                        getTreeNode(), getTokenRewriteStream());
        }
        
        return mExpression;
    }

    /**
     * Returns the line number of the annotation element value.
     * 
     * @return  The line number of the annotation element value.
     */
    public int getLineNumber() {
        
        if (mRValueType == RValueType.EXPRESSION) {
            // Get the line number from the JSOM expression.
            return getExpression().getLineNumber();
        }
        
        // Get the line number from the '{' or '@' character.
        return getTreeNode().Line;
    }

    /**
     * Resolves the annotation element values.
     * <p>
     * Note that it's up to the caller to ensure that the rValue is of type
     * <code>RValueType.ANNOTATION_ELEMENT_VALUES</code>.
     */
    private void resolveAnnotationElementValues() {
        
        int size = getTreeNode().ChildCount;
        mAnnotationElemArray = new List<AnnotationElementValue>(size);
        for (int offset = 0; offset < size; offset++) {
            mAnnotationElemArray.Add(new AST2AnnotationElementValue((AST2JSOMTree)
                    getTreeNode().GetChild(offset), getTokenRewriteStream()));
        }
    }

    /**
     * Calls the methods <code>pAction.performAction(...)</code> and <code>
     * pAction.actionPerformed(...)</code> with <code>this</code> as argument.
     * <P>
     * Furthermore, if <code>pAction.isMemberTraversionEnabled() == true</code>
     * all <code>JSOM</code> members that belong to <code>this
     * </code> will be traversed by calling the <code>traverseAll(...)</code> 
     * method on these members with <code>pAction</code> as argument. This will
     * be done after the <code>pAction.performAction(...)</code> call but before
     * the <code>pAction.actionPerformed(...)</code> call.
     * 
     * @see  JSOM#traverseAll(TraverseAction)
     * 
     * @param pAction  User define traverse actions. 
     * 
     * @throws  NullPointerException if <code>pAction</code> is <code>
     *          null</code>.
     */
    public void traverseAll(TraverseAction pAction) {
        
        pAction.performAction(this);
        if (pAction.isMemberTraversingEnabled()) {
            // Traverse the members.
            if (mRValueType == RValueType.ANNOTATION_ELEMENT_VALUES) {
                if (mAnnotationElemArray == null) {
                    resolveAnnotationElementValues();
                }
                foreach (AnnotationElementValue value in mAnnotationElemArray) {
                    value.traverseAll(pAction);
                }
            } else if (mRValueType == RValueType.ANNOTATION) {
                getAnnotation().traverseAll(pAction);
            } else if (mRValueType == RValueType.EXPRESSION) {
                getExpression().traverseAll(pAction);
            }
        }
        pAction.actionPerformed(this);
    }
}
}