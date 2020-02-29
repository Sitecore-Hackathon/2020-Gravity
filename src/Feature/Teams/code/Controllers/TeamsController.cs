using Hackathon.Feature.Teams.Models;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sitecore.Data.Items;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Collections;
using Sitecore;
using Sitecore.Diagnostics;

namespace Hackathon.Feature.Teams.Controllers
{
    public class TeamsController : Controller
    {
        public ActionResult TeamsListing()
        {
            TeamsViewModel lstTeams = new TeamsViewModel();

            try
            {
                Item datasource = RenderingContext.Current.Rendering.Item;

                if (datasource != null && datasource.IsDerived(Templates.Team.ID))
                {
                    lstTeams.Teams = new List<Team>();

                    foreach (var teamItem in datasource.Children.Where(x => x.IsDerived(Templates.Team.ID)))
                    {
                        var team = new Team();

                        foreach (var member in teamItem.Children.Where(x => x.IsDerived(Templates.TeamMember.ID)))
                        {
                            team.Members.Add(new TeamMember { item = member });
                        }

                        lstTeams.Teams.Add(team);
                    }
                }
                else
                {

                    ChildList Childs = Context.Item.Children;

                    if (Context.Item != null && Childs != null)
                    {
                        if (Childs.Any(x => x.IsDerived(Templates.Team.ID)))
                        {
                            lstTeams.Teams = new List<Team>();

                            foreach (var teamItem in Childs.Where(x => x.IsDerived(Templates.Team.ID)))
                            {
                                var team = new Team();

                                foreach (var member in teamItem.Children.Where(x => x.IsDerived(Templates.TeamMember.ID)))
                                {
                                    team.Members.Add(new TeamMember { item = member });
                                }

                                lstTeams.Teams.Add(team);
                            }

                        }
                        else if (Childs.Any(x => x.IsDerived(Templates.TeamsListing.ID)))
                        {
                            lstTeams.Teams = new List<Team>();

                            var teamItem = Childs.Where(x => x.IsDerived(Templates.TeamsListing.ID)).FirstOrDefault();

                            foreach (var teamObj in teamItem.Children.Where(x => x.IsDerived(Templates.Team.ID)))
                            {
                                var team = new Team();

                                foreach (var member in teamObj.Children.Where(x => x.IsDerived(Templates.TeamMember.ID)))
                                {
                                    team.Members.Add(new TeamMember { item = member });
                                }

                                lstTeams.Teams.Add(team);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex, this);
            }
            return View(lstTeams);
        }
    }
}