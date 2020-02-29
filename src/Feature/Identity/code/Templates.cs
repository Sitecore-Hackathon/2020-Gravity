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
                public static readonly ID Logo = new ID("{51B46D28-C694-4DA7-855B-5BAAC06208E6}");
                public static readonly ID Copyright = new ID("{73CB7306-F324-4714-8D7A-D3A179B8B0E0}");
                public static readonly ID About = new ID("{79038483-B32A-4985-B961-4E243831C76A}");
                public static readonly ID Address = new ID("{50885A2E-AA98-4560-AD3F-DAB802E05DFB}");
                public static readonly ID Email = new ID("{F826B99B-CF43-4A34-A8B6-3E46B0AF9428}");
                public static readonly ID Phone = new ID("{C0AB8F05-41EA-466A-9122-3EAFDA16B1E0}");
            }
        }
    }
}