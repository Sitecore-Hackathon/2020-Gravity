using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Identity.Repositories
{
        public static class IdentityRepository
        {
            public static Item Get(Item contextItem)
            {
                if (contextItem == null)
                    throw new ArgumentNullException(nameof(contextItem));

                return contextItem.GetAncestorOrSelfOfTemplate(Templates.Identity.ID) ?? Context.Site.GetContextItem(Templates.Identity.ID);
            }
        }
}