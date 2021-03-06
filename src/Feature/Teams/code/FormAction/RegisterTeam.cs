﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using Hackathon.Feature.Teams.Models;
using Hackathon.Feature.Teams.Repositories;
using Hackathon.Foundation.Email.Models;
using Hackathon.Foundation.Settings.Repository;
using Sitecore.Data;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;

namespace Hackathon.Feature.Teams.FormAction
{
    public class RegisterTeam : SubmitActionBase<string>
    {
        private ITeamRepository TeamRepository { get; set; }

        //Initializes a new instance of the EmailMe class.
        //submitActionData => The submit action data
        public RegisterTeam(ISubmitActionData submitActionData) : base(submitActionData)
        {
        }


        //Executes the action with the specified <paramref name="data" />.
        //<param name="data">The data.</param>
        //<param name="formSubmitContext">The form submit context.</param>
        //returns <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            try
            {
                TeamRepository = new TeamRepository();

                Team _team = new Team();
                _team.TeamName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Name"));
                _team.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Email Address"));
                _team.LoginName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Login Name"));
                _team.Password = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Password"));

                ID _teamId = null;
                if (TeamRepository.ValidateTeam(_team))
                {
                    _teamId = TeamRepository.CreateTeamSitecoreItem(_team);
                }

                if (_teamId is null)
                    return false;

                TeamMember _member1 = new TeamMember();
                _member1.FullName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 1 Full Name"));
                _member1.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 1 Email Address"));
                _member1.LinkedInUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 1 LinkedIn Url"));
                _member1.TwitterUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 1 Twitter Url"));
                _member1.Country = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 1 Country"));

                if (TeamRepository.ValidateTeamMembers(_member1))
                {
                    TeamRepository.CreateTeamMemberSitecoreItem(_teamId, _member1);
                }

                TeamMember _member2 = new TeamMember();
                _member2.FullName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 2 Full Name"));
                _member2.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 2 Email Address"));
                _member2.LinkedInUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 2 LinkedIn Url"));
                _member2.TwitterUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 2 Twitter Url"));
                _member2.Country = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 2 Country"));

                if (TeamRepository.ValidateTeamMembers(_member2))
                {
                    TeamRepository.CreateTeamMemberSitecoreItem(_teamId, _member2);
                }

                TeamMember _member3 = new TeamMember();
                _member3.FullName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 3 Full Name"));
                _member3.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 3 Email Address"));
                _member3.LinkedInUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 3 LinkedIn Url"));
                _member3.TwitterUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 3 Twitter Url"));
                _member3.Country = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team member 3 Country"));

                if (TeamRepository.ValidateTeamMembers(_member3))
                {
                    TeamRepository.CreateTeamMemberSitecoreItem(_teamId, _member3);
                }


                // All good...Send confirmation email
                var _siteSetting = SiteSettings.localSettings;
                if (_siteSetting != null)
                {
                    var _emailTemplate = _siteSetting.Fields[Hackathon.Foundation.Settings.Templates.Settings.Fields.RegisterTeamConfirmationEmail].Value;
                    if (!string.IsNullOrEmpty(_emailTemplate))
                    {
                        var _emailTemplateItem = Sitecore.Context.Database.GetItem(_emailTemplate);
                        if (_emailTemplateItem != null)
                        {
                            Mail _Mail = new Mail();
                            _Mail.ToAddress = _team.EmailAddress;
                            _Mail.Subject = _emailTemplateItem.Fields[Hackathon.Foundation.Email.Templates.EmailTemplate.Fields.Subject].Value;
                            _Mail.Body = _emailTemplateItem.Fields[Hackathon.Foundation.Email.Templates.EmailTemplate.Fields.Body].Value;
                            _Mail.FromAddress = _emailTemplateItem.Fields[Hackathon.Foundation.Email.Templates.EmailTemplate.Fields.FromAddress].Value;

                            Hackathon.Foundation.Email.EmailUtil.SendEmail(_Mail);
                        }
                    }
                }


                return true;
            }
            catch(Exception ex)
            {
                Sitecore.Diagnostics.Log.Error(ex.Message, ex, this);
                return false;
            }
        }
        private static string GetValue(object field)
        {
            return field?.GetType().GetProperty("Value")?.GetValue(field, null)?.ToString() ?? string.Empty;
        }
        //Tries to convert the specified <paramref name="value" /> to an instance of the  specified target type.
        //<param name="value">The value.</param>
        //<param name="target">The target object.</param>
        //returns true if <paramref name="value" /> was converted successfully; otherwise, false.    
        protected override bool TryParse(string value, out string target)
        {
            target = string.Empty;
            return true;
        }
    }
}