﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace SajaProjectV2.Factory
{
    public class Database
    {
        public static string conVal(string conStr)
        {
            return ConfigurationManager.ConnectionStrings[conStr].ConnectionString;
        }
    }
}
