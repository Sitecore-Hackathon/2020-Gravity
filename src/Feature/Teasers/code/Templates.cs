using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data;

namespace Hackathon.Feature.Teasers
{
    public class Templates
    {
        public struct ImageSlider
        {
            public static readonly ID ID = new ID("{8160CBF6-C465-43A5-B1A6-02FA26823632}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{145CD81C-5B2B-4390-82AB-40994AFA5679}");
                public const string Title_FieldName = "Title";

                public static readonly ID Description = new ID("{4AB195B3-4069-4D78-A28C-2359F4EBBC8A}");
                public const string Description_FieldName = "Description";

                public static readonly ID Image = new ID("{7456B7B8-7F1E-4F90-BD0B-7637B7D273EF}");
                public const string Image_FieldName = "Image";

                public static readonly ID Link = new ID("{37AA9CCD-0866-46D5-85C3-E095C3204357}");
                public const string Link_FieldName = "Link";
            }
        }

        public struct VideoSlider
        {
            public static readonly ID ID = new ID("{1C4DD92C-5B30-4438-A055-47CAD4C2ABEA}");

            public struct Fields
            {
                public static readonly ID Title = new ID("{25C0232A-811B-4413-B0FE-6B14F37379D7}");
                public const string Title_FieldName = "Title";

                public static readonly ID Description = new ID("{81855AF7-7EF6-4844-8A8D-F70C9730E161}");
                public const string Description_FieldName = "Description";

                public static readonly ID Video = new ID("{A0EE8F88-8039-4227-B19B-F0AF86952D4C}");
                public const string Video_FieldName = "Image";

                public static readonly ID Link = new ID("{63655337-E37D-4639-9141-AB90917C16F1}");
                public const string Link_FieldName = "Link";
            }
        }

        public struct SliderFolder
        {
            public static readonly ID ID = new ID("{B2CFC44B-65ED-4E37-9104-2CDE925D300C}");
        }
    }
}