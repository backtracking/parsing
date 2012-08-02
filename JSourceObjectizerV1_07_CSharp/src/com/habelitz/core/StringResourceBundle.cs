using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.habelitz.core
{
    public abstract class StringResourceBundle : ListResourceBundle
    {
        public String getResource(String key, String[] args, bool isNullResultEnabled)
        {
            String resource = base.getString(key);
            if (resource != null)
            {
                if (args != null)
                    resource = String.Format(resource, args);
            }
            else if (!isNullResultEnabled)
            {
                resource = "INVALID_KEY: + key";
            }

            return resource;
        }

        public String getResource(String key, String[] args)
        {
            return getResource(key, args, false);
        }

        public String getResource(String key, bool isNullResultEnabled)
        {
            return getResource(key, null, isNullResultEnabled);
        }

        public String getResource(String key)
        {
            return getResource(key, null, false);
        }
    }
}