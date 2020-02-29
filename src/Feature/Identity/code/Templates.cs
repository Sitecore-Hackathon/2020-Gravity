using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Identity
{
    public struct Templates
    {
        public struct Identity
        {
            public static readonly ID ID = new ID("{124AED8A-D1B7-488C-8950-1C19AB85428D}");

            public struct Fields
            {
                public static readonly ID Logo = new ID("{5209330C-345D-4D66-BFC3-0E10A6A85A70}");
                public static readonly ID Copyright = new ID("{CEEFD27A-AB4F-47BB-9FF5-DB76F7CE2D97}");
            }
        }
    }
}