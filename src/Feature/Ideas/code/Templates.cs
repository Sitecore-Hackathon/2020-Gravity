using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Ideas
{
    public class Templates
    {
        public struct Ideas
        {
            public static readonly ID ID = new ID("{0462E357-4A58-4CDC-BBE5-1684BA0B00D6}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{79FEB57C-A53A-45A6-BFFA-B8BAB0CFA8D1}");
                public static readonly ID Description = new ID("{B1E9C489-F0A4-4A51-9366-975A9499DCF4}");
  
            }
        }
    }
}