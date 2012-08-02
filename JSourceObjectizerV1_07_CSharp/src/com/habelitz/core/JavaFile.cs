using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace com.habelitz.core
{
    public class JFile
    {
        private String mPathName = string.Empty;

        public JFile(String pathname)
        {
            mPathName = pathname;
        }

        public String getPath()
        {
            return mPathName;
        }

        public String getName()
        {
            return Path.GetFileName(mPathName);
        }

        public String getAbsolutePath()
        {
            return Path.GetFullPath(mPathName);
        }

    }
}
