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
using com.habelitz.jsobjectizer;
using com.habelitz.jsobjectizer.jsom;

namespace com.habelitz.jsobjectizer.jsom.api
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
    /**
     * Defines constants for each modifier type.
     * 
     * @author Dieter Habelitz
     */
    class ModifierAttr : Attribute
    {
        private string mModifierAsString;

        internal ModifierAttr(string modifierAsString)
        {
            mModifierAsString = modifierAsString;
        }
        public string getModifierAsString()
        {
            return mModifierAsString;
        }
    }

    public static class Modifiers
    {
        public static string getModifierAsString(this Modifier p)
        {
            ModifierAttr attr = GetAttr(p);
            return attr.getModifierAsString();
        }

        private static ModifierAttr GetAttr(Modifier p)
        {
            return (ModifierAttr)Attribute.GetCustomAttribute(ForValue(p), typeof(ModifierAttr));
        }

        private static MemberInfo ForValue(Modifier p)
        {
            return typeof(Modifier).GetField(Enum.GetName(typeof(Modifier), p));
        }
    }

    public enum Modifier
    {

        /**
        * This constant represents the modifier keyword <code>abstract</code>. 
        */
        [ModifierAttr("abstract")]
        ABSTRACT,

        /**
        * This special constant signals the existence of an annotation within 
        * the modifier list. 
        */
        [ModifierAttr("")]
        ANNOTATION,

        /**
         * This constant represents the modifier keyword <code>final</code>. 
         */
        [ModifierAttr("final")]
        FINAL,

        /**
         * This constant represents the modifier keyword <code>native</code>. 
         */
        [ModifierAttr("native")]
        NATIVE,

        /**
         * This constant represents the modifier keyword <code>private</code>. 
         */
        [ModifierAttr("private")]
        PRIVATE,

        /**
         * This constant represents the modifier keyword <code>protected</code>. 
         */
        [ModifierAttr("protected")]
        PROTECTED,

        /**
         * This constant represents the modifier keyword <code>public</code>. 
         */
        [ModifierAttr("public")]
        PUBLIC,

        /**
         * This constant represents the modifier keyword <code>static</code>. 
         */
        [ModifierAttr("static")]
        STATIC,

        /**
         * This constant represents the modifier keyword <code>strictfp</code>. 
         */
        [ModifierAttr("strictfp")]
        STRICTFP,

        /**
         * This constant represents the modifier keyword <code>
         * synchronized</code>. 
         */
        [ModifierAttr("synchronized")]
        SYNCHRONIZED,

        /**
         * This constant represents the modifier keyword <code>transient</code>. 
         */
        [ModifierAttr("transient")]
        TRANSIENT,

        /**
         * This constant represents the modifier keyword <code>volatile</code>. 
         */
        [ModifierAttr("volatile")]
        VOLATILE,

        /**
         * This constant represents the modifier keyword <code>volatile</code>. 
         */
        [ModifierAttr(null)]
        NOT_SUPPORTED,
    }
    public interface ModifierList : JSOM
    {



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
        /*public*/ List<Annotation> getAnnotations();

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
        /*public*/ List<Annotation> getAnnotations(List<Annotation> pList);

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
        /*public*/ List<Modifier> getModifiers();

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
        /*public*/ List<Modifier> getModifiers(List<Modifier> pList);

        /**
         * Tells if the modifier list contains at least one annotation.
         * 
         * @return  <code>true</code> if the modifier list contains at least one 
         *          annotation.
         */
        /*public*/ bool hasAnnotation();

        /**
         * Tells if the modifier list contains at least one modifier.
         * <p>
         * Note that annotations don't count.
         * 
         * @return  <code>true</code> if the modifier list contains at least one
         *          modifier.
         */
        /*public*/ bool hasModifier();

        /**
         * Tells if the modifier list contains the modifier <code>abstract</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>abstract</code>.
         */
        /*public*/ bool isAbstract();

        /**
         * Tells if the modifier list contains the modifier <code>final</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>final</code>.
         */
        /*public*/ bool isFinal();

        /**
         * Equals an {@link #isLocalModifierList()} call.
         * 
         * @return  <code>true</code> if <code>this</code> represents a local
         *          modifier list.
         *          
         * @deprecated  Use the method {@link #isLocalModifierList()} instead.
         */
        [Obsolete]
        /*public*/ bool isLocalModifier();

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
        /*public*/ bool isLocalModifierList();

        /**
         * Tells if the modifier list contains the modifier <code>native</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>native</code>.
         */
        /*public*/ bool isNative();

        /**
         * Tells if the modifier list contains the modifier <code>private</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>private</code>.
         */
        /*public*/ bool isPrivate();

        /**
         * Tells if the modifier list contains the modifier <code>protected</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>protected</code>.
         */
        /*public*/ bool isProtected();

        /**
         * Tells if the modifier list contains the modifier <code>public</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>public</code>.
         */
        /*public*/ bool isPublic();

        /**
         * Tells if the modifier list contains the modifier <code>static</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>static</code>.
         */
        /*public*/ bool isStatic();

        /**
         * Tells if the modifier list contains the modifier <code>strictfp</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>strictfp</code>.
         */
        /*public*/ bool isStrictfp();

        /**
         * Tells if the modifier list contains the modifier <code>synchronized
         * </code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>synchronized</code>.
         */
        /*public*/ bool isSynchronized();

        /**
         * Tells if the modifier list contains the modifier <code>transient</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>transient</code>.
         */
        /*public*/ bool isTransient();

        /**
         * Tells if the modifier list contains the modifier <code>volatile</code>.
         * 
         * @return  <code>true</code> if the modifier list contains the modifier 
         *          <code>volatile</code>.
         */
        /*public*/ bool isVolatile();

        /**
         * Removes a stated annotation from <code>this</code>.
         * 
         * @param pAnnotation  The annotation that should be removed. The object 
         *                     passed to this method remains unchanged.
         * 
         * @  if the annotation passed to this 
         *                                     method doesn't belong to <code>
         *                                     this</code>.
         */
        /*public*/ void removeAnnotation(Annotation pAnnotation);
    }
}