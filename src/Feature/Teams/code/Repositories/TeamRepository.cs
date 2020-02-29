using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;

using Hackathon.Feature.Teams.Models;
using static Hackathon.Feature.Teams.Constants;
using Sitecore.Data;
using Sitecore.Foundation.DependencyInjection;
using Sitecore.Foundation.Accounts;
using Sitecore.Foundation.Accounts.Repositories;
using Sitecore.Foundation.SitecoreExtensions.Extensions;

namespace Hackathon.Feature.Teams.Repositories
{
    [Service(typeof(ITeamRepository))]
    public class TeamRepository : ITeamRepository
    {
        public void CreateTeamMemberSitecoreItem(ID TeamId, TeamMember TeamMember)
        {
            try
            {
                Sitecore.Data.Database masterDB = Sitecore.Configuration.Factory.GetDatabase(DBNames.Master);

                Item parentItem = masterDB.GetItem(TeamId);

                string name = ItemUtil.ProposeValidItemName(TeamMember.FullName);
                var teamTemplate = masterDB.GetTemplate(Templates.TeamMember.ID);

                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    Item newItem = parentItem.Add(name, teamTemplate);
                    try
                    {
                        if (newItem != null)
                        {
                            newItem.Editing.BeginEdit();
                            newItem[Templates.TeamMember.Fields.FullName] = TeamMember.FullName;
                            newItem[Templates.TeamMember.Fields.EmailAddress] = TeamMember.EmailAddress;
                            newItem[Templates.TeamMember.Fields.LinkedInUrl] = TeamMember.LinkedInUrl;
                            newItem[Templates.TeamMember.Fields.TwitterUrl] = TeamMember.TwitterUrl;
                            newItem[Templates.TeamMember.Fields.Country] = TeamMember.Country;
                            newItem.Editing.EndEdit();
                        }
                    }
                    catch
                    {
                        newItem.Editing.CancelEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }
        }

        public bool ValidateTeam(Team Team)
        {
            if (string.IsNullOrEmpty(Team.TeamName))
                return false;

            if (string.IsNullOrEmpty(Team.EmailAddress))
                return false;

            return true;
        }

        public bool ValidateTeamMembers(TeamMember TeamMember)
        {
            if (string.IsNullOrEmpty(TeamMember.FullName))
                return false;

            if (string.IsNullOrEmpty(TeamMember.EmailAddress))
                return false;

            if (string.IsNullOrEmpty(TeamMember.LinkedInUrl))
                return false;

            if (string.IsNullOrEmpty(TeamMember.TwitterUrl))
                return false;

            return true;
        }

        public ID CreateTeamSitecoreItem(Team Team)
        {
            try
            {
                Sitecore.Data.Database masterDB = Sitecore.Configuration.Factory.GetDatabase(DBNames.Master);

                Item _rootItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
                Item parentItem = _rootItem.Axes.GetDescendants().ToList().Where(p => p.IsDerived(Templates.TeamsListing.ID)).FirstOrDefault();

                string name = ItemUtil.ProposeValidItemName(Team.TeamName);
                var teamTemplate = masterDB.GetTemplate(Templates.Team.ID);

                using (new Sitecore.SecurityModel.SecurityDisabler())
                {
                    Item newItem = parentItem.Add(name, teamTemplate);
                    try
                    {
                        if (newItem != null)
                        {
                            newItem.Editing.BeginEdit();
                            newItem[Templates.Team.Fields.Name] = Team.TeamName;
                            newItem[Templates.Team.Fields.EmailAddress] = Team.EmailAddress;
                            newItem[Templates.Team.Fields.LoginName] = Team.LoginName;
                            newItem[Templates.Team.Fields.Password] = Team.Password;
                            newItem.Editing.EndEdit();
                        }
                    }
                    catch
                    {
                        newItem.Editing.CancelEdit();
                    }

                    RegisterTeam(Team.LoginName, Team.Password);
                    return newItem.ID;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }

            return null;
        }

        public void RegisterTeam(string Email, string Password)
        {
            IAccountRepository _accountRepository = new AccountRepository();
            _accountRepository.RegisterUser(Email, Password, Constants.Settings.TeamProfileId.ToString());
        }
    }
}