using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Teams.Models
{
    public class TeamMember
    {
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string LinkedInUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string Country { get; set; }
    }
}