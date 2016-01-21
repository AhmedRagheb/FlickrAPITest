using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FlickrAPITest.Helper
{
    public static class Configurations
    {
        public static string GetRepository()
        {
            var str = ConfigurationManager.AppSettings["Repository"];
            if (string.IsNullOrEmpty(str))
                return "FlickrRepository";

            return str;
        }
    }
}