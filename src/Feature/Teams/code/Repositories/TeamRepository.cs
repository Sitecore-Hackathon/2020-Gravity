using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Sitecore.Data.Items;

using Hackathon.Feature.Teams.Models;
using static Hackathon.Feature.Teams.Constants;
using Sitecore.Data;
using Sitecore.Foundation.DependencyInjection;

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

        public void CreateTeamMemberSitecoreItem(TeamMember TeamMember)
        {
            throw new NotImplementedException();
        }

        public void CreateTeamSitecoreItem(ID TeamId, Team Team)
        {
            throw new NotImplementedException();
        }

        public void SendTeamRegistrationLink(string email)
        {
           
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

                Item parentItem = Sitecore.Context.Item;

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
                            newItem.Editing.EndEdit();
                        }
                    }
                    catch
                    {
                        newItem.Editing.CancelEdit();
                    }

                    return newItem.ID;
                }
            }
            catch (Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
            }

            return null;
        }

        public void RegisterTeam(string Email, string Password, string ProfileId)
        {
            throw new NotImplementedException();
        }
    }
}