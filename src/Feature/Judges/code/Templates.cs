using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Judges
{
    public class Templates
    {
        public struct Judges
        {
            public static readonly ID ID = new ID("{124AED8A-D1B7-488C-8950-1C19AB85428D}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{F6B51342-3C44-4072-9A69-E740048E6566}");
                public static readonly ID TwitterAccount = new ID("{FBD6AA8E-D63C-460F-93E4-DFC8FE4E21AA}");
                public static readonly ID LinkedInAccount = new ID("{127030DC-F814-456D-A09E-C8A7D92DCF56}");
                public static readonly ID Picture = new ID("{25C67C1C-1CB8-4FF1-AF2B-D87FFF256CFE}");
            }
        }

        public struct JudgesListing
        {
            public static readonly ID ID = new ID("{A070B30B-0C04-4C0E-932B-EDD0DB130CC4}");
        }


    }
}