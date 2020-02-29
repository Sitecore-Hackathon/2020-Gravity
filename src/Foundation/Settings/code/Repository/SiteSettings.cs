using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;

namespace Hackathon.Foundation.Settings.Repository
{
    public class SiteSettings
    {
        public static Item localSettings
        {
            get
            {
                if (Sitecore.Context.Site == null)
                {
                    return null;
                }
                Item siteSettingsPath = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath + "/Settings"); return siteSettingsPath;
            }
        }
    }
}