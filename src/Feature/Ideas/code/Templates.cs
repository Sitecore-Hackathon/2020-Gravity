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
            public static readonly ID ID = new ID("{D0D502BB-A7B5-4983-A811-7BA4CB45678C}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{79FEB57C-A53A-45A6-BFFA-B8BAB0CFA8D1}");
                public static readonly ID Description = new ID("{B1E9C489-F0A4-4A51-9366-975A9499DCF4}");
            }
        }

        public struct IdeasListing
        {
            public static readonly ID ID = new ID("{FE15B22A-6B5E-4798-BB2B-4FB4609DCF5D}");

        }

    }
}