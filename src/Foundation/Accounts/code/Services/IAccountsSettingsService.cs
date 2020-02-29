namespace Sitecore.Foundation.Accounts.Services
{
    using System;
    using System.Net.Mail;
  using Sitecore.Data;
  using Sitecore.Data.Items;

  public interface IAccountsSettingsService
  {
    string GetPageLink(Item contextItem, ID fieldID);
    string GetPageLinkOrDefault(Item contextItem, ID field, Item defaultItem = null);

  }
}