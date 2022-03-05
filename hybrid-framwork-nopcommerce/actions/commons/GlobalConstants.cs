using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hybrid_framwork_nopcommerce.actions.commons
{
    public class GlobalConstants
    {
        public static readonly String USER_URL = "https://demo.nopcommerce.com/";
        public static readonly String ADMIN_URL = "https://admin-demo.nopcommerce.com/";

        public static readonly int SHORT_TIMEOUT = 5;
        public static readonly int LONG_TIMEOUT = 30;

        // This will get the current WORKING directory (i.e. \bin\Debug)
        public static readonly string WORKING_DIR = Environment.CurrentDirectory;

        // This will get the current PROJECT directory
        public static readonly string PROJECT_DIR = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
    }
}
