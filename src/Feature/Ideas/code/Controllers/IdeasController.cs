using Hackathon.Feature.Ideas.Models;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Feature.Ideas.Controllers
{
    public class IdeasController : Controller
    {
        public ActionResult IdeasListing()
        {
            IdeaViewModel lstIdeas = new IdeaViewModel();

            try
            {
                Item datasource = RenderingContext.Current.Rendering.Item;

                if (datasource != null && datasource.IsDerived(Templates.IdeasListing.ID))
                {
                    lstIdeas.Ideas = new List<Idea>();

                    foreach (var idea in datasource.Children.Where(x => x.IsDerived(Templates.Ideas.ID)))
                    {
                        lstIdeas.Ideas.Add(new Idea
                        {
                            item = idea
                        });
                    }
                }
                else
                {
                    ChildList Childs = Context.Item.Children;

                    if (Context.Item != null && Childs != null)
                    {
                        if (Childs.Any(x => x.IsDerived(Templates.Ideas.ID)))
                        {
                            lstIdeas.Ideas = new List<Idea>();

                            foreach (var ideaItem in Childs.Where(x => x.IsDerived(Templates.Ideas.ID)))
                            {
                                lstIdeas.Ideas.Add(new Idea
                                {
                                    item = ideaItem
                                });
                            }

                        }
                        else if (Childs.Any(x => x.IsDerived(Templates.IdeasListing.ID)))
                        {
                            lstIdeas.Ideas = new List<Idea>();

                            var ideaItem = Childs.Where(x => x.IsDerived(Templates.IdeasListing.ID)).FirstOrDefault();

                            foreach (var idea in ideaItem.Children.Where(x => x.IsDerived(Templates.Ideas.ID)))
                            {
                                lstIdeas.Ideas.Add(new Idea
                                {
                                    item = idea
                                });
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex, this);
            }
            return View(lstIdeas);
        }
    }
}