using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.habelitz.core
{
    public abstract class ListResourceBundle : ResourceBundle {
    
    public ListResourceBundle() {
    }

    // Implements java.util.ResourceBundle.handleGetObject; inherits javadoc specification.
    public Object handleGetObject(String key)
    {
        // lazily load the lookup hashtable.
        if (lookup == null)
        {
            loadLookup();
        }
        if (key == null)
        {
            throw new NullReferenceException();
        }
        return lookup[key]; // this class ignores locales
    }

    /**
     * Returns an <code>Enumeration</code> of the keys contained in
     * this <code>ResourceBundle</code> and its parent bundles.
     *
     * @return an <code>Enumeration</code> of the keys contained in
     *         this <code>ResourceBundle</code> and its parent bundles.
     * @see #keySet()
     */
    //public Enumeration<String> getKeys()
    //{
    //    // lazily load the lookup hashtable.
    //    if (lookup == null)
    //    {
    //        loadLookup();
    //    }

    //    ResourceBundle parent = this.parent;
    //    return new ResourceBundleEnumeration(lookup.keySet(),
    //            (parent != null) ? parent.getKeys() : null);
    //}

    /**
     * Returns a <code>Set</code> of the keys contained
     * <em>only</em> in this <code>ResourceBundle</code>.
     *
     * @return a <code>Set</code> of the keys contained only in this
     *         <code>ResourceBundle</code>
     * @since 1.6
     * @see #keySet()
     */
    protected List<String> handleKeySet()
    {
        if (lookup == null)
        {
            loadLookup();
        }
        return new List<string>(this.lookup.Keys);
    }

    /**
     * Returns an array in which each item is a pair of objects in an
     * <code>Object</code> array. The first element of each pair is
     * the key, which must be a <code>String</code>, and the second
     * element is the value associated with that key.  See the class
     * description for details.
     *
     * @return an array of an <code>Object</code> array representing a
     * key-value pair.
     */
    abstract protected Object[][] getContents();

    // ==================privates====================

    /**
     * We lazily load the lookup hashtable.  This function does the
     * loading.
     */

    private void loadLookup()
    {
        if (lookup != null)
            return;

        Object[][] contents = getContents();
        Dictionary<String, Object> temp = new Dictionary<String, Object>(contents.Length);
        for (int i = 0; i < contents.Length; ++i)
        {
            // key must be non-null String, value must be non-null
            String key = (String)contents[i][0];
            Object value = contents[i][1];
            if (key == null || value == null)
            {
                throw new NullReferenceException();
            }
            temp[key] = value;
        }
        lookup = temp;
    }

    private Dictionary<String, Object> lookup = null;
}
}
