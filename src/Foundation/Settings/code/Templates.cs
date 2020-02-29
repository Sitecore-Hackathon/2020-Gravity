using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Hackathon.Foundation.Settings
{
    public class Templates
    {
        public struct Settings
        {
            public static readonly ID ID = new ID("{36C88705-4B82-430F-8F8A-D962DE5735E9}");

            public struct Fields
            {
                public static readonly ID RegisterTeamConfirmationEmail = new ID("{2EA49DC5-E143-4B8A-B417-DC11B8030B20}");
                public const string RegisterTeamConfirmationEmail_FieldName = "Register Team Confirmation Email";
            }
        }
    }
}