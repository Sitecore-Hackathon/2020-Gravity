namespace Sitecore.Foundation.Accounts.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Sitecore.Data;
    using Sitecore.Data.Items;
    using Sitecore.Foundation.Accounts.Models;
    using Sitecore.Foundation.Accounts.Services;
    using Sitecore.Foundation.Dictionary.Repositories;
    using Sitecore.Security;
    using Sitecore.Security.Accounts;
    using Sitecore.SecurityModel;

    public class UserProfileService : IUserProfileService
    {
        private readonly IProfileSettingsService profileSettingsService;
 

      

        public UserProfileService(IProfileSettingsService profileSettingsService)
        {
            this.profileSettingsService = profileSettingsService;
    
        }

        public virtual string GetUserDefaultProfileId()
        {
            return this.profileSettingsService.GetUserDefaultProfile()?.ID?.ToString();
        }
      
    }
}