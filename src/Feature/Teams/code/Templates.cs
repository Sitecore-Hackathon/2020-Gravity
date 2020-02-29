using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data;

namespace Hackathon.Feature.Teams
{
    public class Templates
    {
        public struct Team
        {
            public static readonly ID ID = new ID("{58E2534F-2FA3-4287-9DF9-69268E2F094F}");

            public struct Fields
            {
                public static readonly ID Name = new ID("{00FB8CD9-291D-4E59-AD4E-45EAFCA2F1AE}");
                public const string Name_FieldName = "Name";

                public static readonly ID EmailAddress = new ID("{297AD2AE-7957-4EBE-B120-FF5D2BA9B33D}");
                public const string EmailAddress_FieldName = "Email Address";
            }
        }

        public struct TeamMember
        {
            public static readonly ID ID = new ID("{2827C8BE-7D7C-4FB7-8182-EB103927C033}");

            public struct Fields
            {
                public static readonly ID FullName = new ID("{158FC578-B759-4052-BC1B-668560F4A6C8}");
                public const string FullName_FieldName = "Full Name";

                public static readonly ID EmailAddress = new ID("{C24C272D-BFAD-4BCA-AB37-56C3D1E14761}");
                public const string EmailAddress_FieldName = "Email Address";

                public static readonly ID LinkedInUrl = new ID("{7E68F776-57F6-419C-8016-D1BFAE363C07}");
                public const string LinkedInUrl_FieldName = "LinkedIn Url";

                public static readonly ID TwitterUrl = new ID("{2D37ABE0-84D4-4161-AB24-85E6F6380CAB}");
                public const string TwitterUrl_FieldName = "Twitter Url";
            }
        }
    }
}