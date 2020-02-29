using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hackathon.Feature.Teams.Models;
using Hackathon.Feature.Teams.Repositories;
using Sitecore.Data;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;

namespace Hackathon.Feature.Teams.FormAction
{
    public class RegisterTeam : SubmitActionBase<string>
    {
        private ITeamRepository TeamRepository { get; }

        //Initializes a new instance of the EmailMe class.
        //submitActionData => The submit action data
        public RegisterTeam(ISubmitActionData submitActionData, ITeamRepository ITeamRepository) : base(submitActionData)
        {
            TeamRepository = ITeamRepository;
        }


        //Executes the action with the specified <paramref name="data" />.
        //<param name="data">The data.</param>
        //<param name="formSubmitContext">The form submit context.</param>
        //returns <c>true</c> if the action is executed correctly; otherwise <c>false</c>
        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
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
            _member2.FullName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 2 Full Name"));
            _member2.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 2 Email Address"));
            _member2.LinkedInUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 2 LinkedIn Url"));
            _member2.TwitterUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 2 Twitter Url"));
            _member2.Country = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 2 Country"));

            if (TeamRepository.ValidateTeamMembers(_member2))
            {
                TeamRepository.CreateTeamMemberSitecoreItem(_teamId, _member2);
            }

            TeamMember _member3 = new TeamMember();
            _member3.FullName = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 3 Full Name"));
            _member3.EmailAddress = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 3 Email Address"));
            _member3.LinkedInUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 3 LinkedIn Url"));
            _member3.TwitterUrl = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 3 Twitter Url"));
            _member3.Country = GetValue(formSubmitContext.Fields.FirstOrDefault(f => f.Name == "Team Member 3 Country"));

            if (TeamRepository.ValidateTeamMembers(_member3))
            {
                TeamRepository.CreateTeamMemberSitecoreItem(_teamId, _member3);
            }
            return true;
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