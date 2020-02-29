using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data.Items;

namespace Hackathon.Feature.Teams.Models
{
    public class Team
    {
        public string TeamName { get; set; }

        public string EmailAddress { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public Item item { get; set; }
        public List<TeamMember> Members { get; set; }
    }
}