using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Foundation.Email
{
    public class Templates
    {
        public struct EmailTemplate
        {
            public static readonly ID ID = new ID("{E447F2B5-9942-4819-8D86-A8EA0B856FC7}");

            public struct Fields
            {
                public static readonly ID FromAddress = new ID("{5CF2E728-309C-4482-AC0E-86A5BF2978F0}");
                public const string FromAddress_FieldName = "From Address";

                public static readonly ID ToAddress = new ID("{0F6ED83F-D7F5-4620-8CC1-934102D98C31}");
                public const string ToAddress_FieldName = "To Address";

                public static readonly ID Subject = new ID("{3A624D6E-A8E0-438C-8BF1-C87671EC889D}");
                public const string Subject_FieldName = "Subject";

                public static readonly ID Body = new ID("{1436AD6B-4B48-4EA5-94FF-CE87BF9CBE9B}");
                public const string Body_FieldName = "Body";
            }
        }
    }
}