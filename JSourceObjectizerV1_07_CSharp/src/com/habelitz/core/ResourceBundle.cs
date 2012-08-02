using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.habelitz.core
{
    public abstract class ResourceBundle
    {
        protected ResourceBundle parent = null;


        public static ResourceBundle getBundle(String baseName)
        {
            return null;
        }

        public String getString(String key) 
        {
            return null;
        }
    }
}
