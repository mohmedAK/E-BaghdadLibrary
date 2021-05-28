using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ELibrary.Factory
{
    public class database
    {
        public static string conVal()
        {
            return ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        }
    }
}