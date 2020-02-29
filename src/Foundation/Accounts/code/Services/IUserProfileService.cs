namespace Sitecore.Foundation.Accounts.Services
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Sitecore.Foundation.Accounts.Models;
    using Sitecore.Security;
    using Sitecore.Security.Accounts;

    public interface IUserProfileService
    {
        string GetUserDefaultProfileId();
      
    }
}