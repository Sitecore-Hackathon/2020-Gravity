using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Navigation
{
    public class Templates
    {
        public struct NavigationFolder
        {
            public static readonly ID ID = new ID("{DACAF3C7-3F30-4178-8642-6F977CCE0EBD}");
        }

        public struct NavigationLink
        {
            public static readonly ID ID = new ID("{F23427ED-C4DE-44F1-B214-B52E2C842E64}");

            public struct Fields
            {
                public static readonly ID Link = new ID("{4EC37222-CD9E-41BA-B1EB-8D88A64B444C}");
            }
        }

        public struct NavigationCssClass
        {
            public static readonly ID ID = new ID("{61EE950D-D91C-4970-82CF-32C466B01F71}");

            public struct Fields
            {
                public static readonly ID CssClass = new ID("{9AC8C79B-72F0-4819-A180-EB5180F9A617}");
            }
        }
    }
}