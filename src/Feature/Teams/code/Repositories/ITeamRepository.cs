using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using static Hackathon.Feature.Teams.Constants;
using Hackathon.Feature.Teams.Models;
using Sitecore.Data;

namespace Hackathon.Feature.Teams.Repositories
{
    public interface ITeamRepository
    {
        ID CreateTeamSitecoreItem(Team Team);

        void CreateTeamMemberSitecoreItem(ID TeamId, TeamMember TeamMember);

        void RegisterTeam(string Email, string Password);

        bool ValidateTeam(Team Team);

        bool ValidateTeamMembers(TeamMember TeamMember);
    }
}