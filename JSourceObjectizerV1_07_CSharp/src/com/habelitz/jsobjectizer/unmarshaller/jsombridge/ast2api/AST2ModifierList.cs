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
using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;

using CommonErrorMessages = com.habelitz.core.resource.resbundle.CommonErrorMessages;
using JSourceObjectizerException = com.habelitz.jsobjectizer.JSourceObjectizerException;
using JSOM = com.habelitz.jsobjectizer.jsom.JSOM;
using JSOMType = com.habelitz.jsobjectizer.jsom.JSOMType;
using com.habelitz.jsobjectizer.jsom.api;
using Modifier = com.habelitz.jsobjectizer.jsom.api.Modifier;
using TraverseAction = com.habelitz.jsobjectizer.jsom.util.TraverseAction;
using AST2JSOMTree = com.habelitz.jsobjectizer.unmarshaller.antlrbridge.AST2JSOMTree;
using com.habelitz.jsobjectizer.unmarshaller.antlrbridge.generated;
using AST2JSOM = com.habelitz.jsobjectizer.unmarshaller.jsombridge.AST2JSOM;


namespace com.habelitz.jsobjectizer.unmarshaller.jsombridge.ast2api 
{
/**
 * This <code>JSOM</code> represents a list of modifiers including annotations.
 * <p>
 * The modifiers themselves are represented by constants defined by this class.
 * A specialty here are annotations. Annotations may occur everywhere modifiers
 * can occur. For the cases were a modifier list contains annotations (as a 
 * matter of fact a modifier list can simply contain one annotation but nothing 
 * else) the list contains a special modifier constant for each annotation. This
 * means from the point of view of a modifier list an annotation is nothing else
 * then a certain modifier.
 * 
 * However, because annotations are a little bit more complex than modifiers
 * (which are simply keywords) there are also some methods to receive the 
 * appropriate <code>Annotation</code> objects.
 * 
 * @author Dieter Habelitz
 */
public class AST2ModifierList : AST2JSOM, ModifierList {
    
    private List<Modifier> mModifierTypes;
    private List<AST2Annotation> mAnnotations;
    private bool mIsLocalModifier;
    private bool mHasModifiers = false;
    
    private List<AST2JSOMTree> mAnnotationTrees;
    
    /**
     * Constructor.
     * 
     * @param pTree  The tree node representing a modifier list.
     * @param pTokenRewriteStream  The token stream the token of the stated
     *                             tree node belongs to.            
     */
    public AST2ModifierList(AST2JSOMTree pTree, TokenRewriteStream pTokenRewriteStream) 
        : base(pTree, JSOMType.MODIFIER_LIST, pTokenRewriteStream)
    
    {
        if (pTree.Type == JavaTreeParser.MODIFIER_LIST) {
            mIsLocalModifier = false;
        } else if (pTree.Type == JavaTreeParser.LOCAL_MODIFIER_LIST) {
            mIsLocalModifier = true;
        } else {
            throw new ArgumentException(
                    CommonErrorMessages.getInvalidArgumentValueMessage(
                            "pTree.Type == " + pTree.Type, "pTree"));
        }
        resolveModifierList(pTree);
    }
    
    /**
     * If the modifier list is not empty this method returns the <i>character in 
     * line</i> position of the first list entry. Otherwise 0 will be returned.
     * 
     * @return  The <i>character in line</i> position where the first list entry
     *          starts or 0 if the modifier list is empty.
     */
    public int getCharPositionInLine() {
        
        return getTreeNode().CharPositionInLine;
    }
    
    /**
     * If the modifier list is not empty this method returns the line number of
     * the first list entry. Otherwise 0 will be returned.
     * 
     * @return  The line number of the first list entry or 0 if the modifier
     *          list is empty.
     */
    public int getLineNumber() {
        
        return getTreeNode().Line;
    }

    /**
     * Returns a list of all <code>Annotation</code> objects that exist within
     * the modifier list.
     * <p>
     * Calling this method equals an <code>getAnnotations(null)</code>
     * call.
     * 
     * @see #getAnnotations(List)
     *  
     * @return  A list of all <code>Annotation</code> objects. If there are no
     *          annotations <code>null</code> will be returned.
     */
    public List<Annotation> getAnnotations() {
        
        return getAnnotations(null);
    }
    
    /**
     * Returns a list of all <code>Annotation</code> objects that exist within
     * the modifier list.
     * 
     * @param  pList  If this argument isn't <code>null</code> the <code>
     *                Annotation</code> objects will be added to this list and 
     *                this list object will be returned. Otherwise a new list 
     *                will be created for the result.
     *  
     * @return  A list of all <code>Annotation</code> objects. If there are no
     *          annotations <code>null</code> will be returned, even if the 
     *          argument <code>pList</code> isn't <code>null</code>.
     */
    public List<Annotation> getAnnotations(List<Annotation> pList) {
        
        if (mAnnotationTrees == null) {
            return null; // There're no annotations.
        }
        if (mAnnotations == null) {
            resolveAnnotations();
        }
        List<Annotation> result = pList;
        if (result == null) {
            result = new List<Annotation>(mAnnotations.Count);
        }
        result.AddRange(mAnnotations);
        
        return result;
    }
    
    /**
     * Returns a list of the modifiers, represented by appropriate <code>
     * ModifierList.Modifier</code> constants, that belong to the modifier list.
     * <p>
     * Calling this method equals an <code>getModifiers(null)</code> call.
     * 
     * @see #getModifiers(List)
     *  
     * @return  A list of the modifiers that belong to the modifier list. If the
     *          modifier list is empty, i.e. if there is neither a modifier nor 
     *          an annotation, <code>null</code> will be returned.
     */
    public List<Modifier> getModifiers() {
        
        return getModifiers(null);
    }
    
    /**
     * Returns a list of the modifiers, represented by appropriate <code>
     * ModifierList.Modifier</code> constants, that belong to the modifier list.
     * 
     * @param  pList  If this argument isn't <code>null</code> the modifier
     *                constants will be added to this list and this list object
     *                will be returned. Otherwise a new list will be created for
     *                the result.
     *  
     * @return  A list of the modifiers that belong to the modifier list. If the
     *          modifier list is empty, i.e. if there is neither a modifier nor 
     *          an annotation, <code>null</code> will be returned, even if the
     *          argument <code>pList</code> isn't <code>null</code>.
     */
    public List<Modifier> getModifiers(List<Modifier> pList) {
        
        if (mModifierTypes == null) {
            return null;
        }
        List<Modifier> result = pList;
        if (result == null) {
            result = new List<Modifier>(mModifierTypes.Count);
        }
        result.AddRange(mModifierTypes);
        
        return result;
    }
    
    /**
     * Tells if the modifier list contains at least one annotation.
     * 
     * @return  <code>true</code> if the modifier list contains at least one 
     *          annotation.
     */
    public bool hasAnnotation() {
        
        return mAnnotationTrees != null;
    }

    /**
     * Tells if the modifier list contains at least one modifier.
     * <p>
     * Note that annotations don't count.
     * 
     * @return  <code>true</code> if the modifier list contains at least one
     *          modifier.
     */
    public bool hasModifier() {
        
        return mHasModifiers;
    }

    /**
     * Tells if the modifier list contains the modifier <code>abstract</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>abstract</code>.
     */
    public bool isAbstract() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.ABSTRACT);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>final</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>final</code>.
     */
    public bool isFinal() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.FINAL);
        }
        
        return false;
    }
    
    /**
     * Equals an {@link #isLocalModifierList()} call.
     * 
     * @return  <code>true</code> if <code>this</code> represents a local
     *          modifier list.
     *          
     * @deprecated  Use the method {@link #isLocalModifierList()} instead.
     */
    [Obsolete]  
    public bool isLocalModifier() {
        
        return mIsLocalModifier;
    }

    /**
     * Tells if <code>this</code> represents a local modifier list, i.e. the
     * modifier list of a local variable, of a parameter from a formal parameter
     * list, etc.
     * <p>
     * Local modifier lists can only contain the modifier <code>final</code> and
     * annotations whereby annotations my occur before and/or after the <code>
     * final</code> keyword.
     * 
     * @return  <code>true</code> if <code>this</code> represents a local
     *          modifier list.
     */
    public bool isLocalModifierList() {
        
        return mIsLocalModifier;
    }

    /**
     * Tells if the modifier list contains the modifier <code>native</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>native</code>.
     */
    public bool isNative() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.NATIVE);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>private</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>private</code>.
     */
    public bool isPrivate() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.PRIVATE);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>protected</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>protected</code>.
     */
    public bool isProtected() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.PROTECTED);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>public</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>public</code>.
     */
    public bool isPublic() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.PUBLIC);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>static</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>static</code>.
     */
    public bool isStatic() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.STATIC);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>strictfp</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>strictfp</code>.
     */
    public bool isStrictfp() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.STRICTFP);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>synchronized
     * </code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>synchronized</code>.
     */
    public bool isSynchronized() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.SYNCHRONIZED);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>transient</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>transient</code>.
     */
    public bool isTransient() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.TRANSIENT);
        }
        
        return false;
    }
    
    /**
     * Tells if the modifier list contains the modifier <code>volatile</code>.
     * 
     * @return  <code>true</code> if the modifier list contains the modifier 
     *          <code>volatile</code>.
     */
    public bool isVolatile() {
        
        if (mModifierTypes != null) {
            return mModifierTypes.Contains(Modifier.VOLATILE);
        }
        
        return false;
    }

    /**
     * Removes a stated annotation from <code>this</code>.
     * 
     * @param pAnnotation  The annotation that should be removed. The object 
     *                     passed to this method remains unchanged.
     * 
     * @  if the annotation passed to this 
     *                                     method doesn't belong to <code>
     *                                     this</code>.
     * 
     * __TEST__                                         
     */
    public void removeAnnotation(Annotation pAnnotation) {
        
        // If the passed annotation belongs to 'this' the annotation list must 
        // be resolved.
        int offset = -1;
        if (mAnnotations != null) {
            offset = mAnnotations.IndexOf((AST2Annotation)pAnnotation);
        }
        if (offset == -1) {
            // TODO  After implementation of changing JSOMs:
            //       Replace message by an internationalized message.
            throw new JSourceObjectizerException(
                    "The annotation " + pAnnotation.getIdentifier().ToString() +
                    "' (from position " + pAnnotation.getLineNumber() + ':' + 
                    pAnnotation.getCharPositionInLine() + 
                    ") doesn't belong to the modifier list at " +
                    getLineNumber() + ':' + getCharPositionInLine() + '.');
        }
        // Just remove the token from the token stream and resolve the modifier
        // list again.
        removeTreeNode(
                (AST2JSOMBase)mAnnotations[offset], null, 
                ChangeTokenBorder.NEXT_NON_HIDDEN_TOKEN_EXCLUDING);
        mModifierTypes = null;
        mAnnotations = null;
        mHasModifiers = false;
        mAnnotationTrees = null;
        resolveModifierList((AST2JSOMTree)getTreeNode());
    }

    /**
     * Resolves the annotations.
     * <p>
     * Note that it's up to the caller to ensure that there's at least once
     * annotation.
     */
    private void resolveAnnotations() {
        
        int size = mAnnotationTrees.Count;
        mAnnotations = new List<AST2Annotation>(size);
        TokenRewriteStream stream = getTokenRewriteStream();
        foreach (AST2JSOMTree tree in mAnnotationTrees) {
            mAnnotations.Add(new AST2Annotation(tree, stream));
        }
    }

    /**
     * Resolves the content of the modifier list.
     * 
     * @param pTree  The tree node representing a modifier list.
     */
    private void resolveModifierList(AST2JSOMTree pTree) {
        
        int numberOfChildren = pTree.ChildCount;
        if (numberOfChildren > 0) {
            mModifierTypes = new List<Modifier>(numberOfChildren);
            int numberOfAnnotations = 0;
            for (int offset = 0; offset < numberOfChildren; offset++) {
                if (pTree.GetChild(offset).Type == JavaTreeParser.AT) {
                    numberOfAnnotations++;
                }
            }
            if (numberOfAnnotations > 0) {
                mAnnotationTrees = 
                    new List<AST2JSOMTree>(numberOfAnnotations);
            }
            if (numberOfChildren > numberOfAnnotations) {
                mHasModifiers = true;
            }
            for (int offset = 0; offset < numberOfChildren; offset++) {
                AST2JSOMTree child = (AST2JSOMTree)pTree.GetChild(offset);
                switch (child.Type) {
                // Handle annotations and the modifier 'final' at first
                // because the rest is irrelevant for local modifiers.
                case JavaTreeParser.AT:
                    mAnnotationTrees.Add(child);
                    mModifierTypes.Add(Modifier.ANNOTATION);
                    break;
                case JavaTreeParser.FINAL:
                    mModifierTypes.Add(Modifier.FINAL);
                    break;
                case JavaTreeParser.PUBLIC:
                    mModifierTypes.Add(Modifier.PUBLIC);
                    break;
                case JavaTreeParser.PROTECTED:
                    mModifierTypes.Add(Modifier.PROTECTED);
                    break;
                case JavaTreeParser.PRIVATE:
                    mModifierTypes.Add(Modifier.PRIVATE);
                    break;
                case JavaTreeParser.STATIC:
                    mModifierTypes.Add(Modifier.STATIC);
                    break;
                case JavaTreeParser.ABSTRACT:
                    mModifierTypes.Add(Modifier.ABSTRACT);
                    break;
                case JavaTreeParser.NATIVE:
                    mModifierTypes.Add(Modifier.NATIVE);
                    break;
                case JavaTreeParser.SYNCHRONIZED:
                    mModifierTypes.Add(Modifier.SYNCHRONIZED);
                    break;
                case JavaTreeParser.TRANSIENT:
                    mModifierTypes.Add(Modifier.TRANSIENT);
                    break;
                case JavaTreeParser.VOLATILE:
                    mModifierTypes.Add(Modifier.VOLATILE);
                    break;
                case JavaTreeParser.STRICTFP:
                    mModifierTypes.Add(Modifier.STRICTFP);
                    break;
                default:
                    mModifierTypes.Add(Modifier.NOT_SUPPORTED);
                    break;
                }
            }
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
            if (mAnnotationTrees != null) {
                if (mAnnotations == null) {
                    resolveAnnotations();
                }
                foreach (Annotation annotation in mAnnotations) {
                    annotation.traverseAll(pAction);
                }
            }
        }
        pAction.actionPerformed(this);
    }
}
}