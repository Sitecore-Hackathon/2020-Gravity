using Hackathon.Feature.Judges.Models;
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

namespace Hackathon.Feature.Judges.Controllers
{
    public class JudgesController : Controller
    {

        public ActionResult JudgesListing()
        {
            JudgeViewModel lstJudges = new JudgeViewModel();

            try
            {
                Item datasource = RenderingContext.Current.Rendering.Item;

                if (datasource != null && datasource.IsDerived(Templates.JudgesListing.ID))
                {
                    lstJudges.Judges = new List<Judge>();

                    foreach (var judgItem in datasource.Children.Where(x => x.IsDerived(Templates.Judges.ID)))
                    {
                        lstJudges.Judges.Add(new Judge
                        {
                            item = judgItem
                        });
                    }
                }
                else
                {

                    ChildList Childs = Context.Item.Children;

                    if (Context.Item != null && Childs != null)
                    {
                        if (Childs.Any(x => x.IsDerived(Templates.Judges.ID)))
                        {
                            lstJudges.Judges = new List<Judge>();

                            foreach (var judgItem in Childs.Where(x => x.IsDerived(Templates.Judges.ID)))
                            {
                                lstJudges.Judges.Add(new Judge
                                {
                                    item = judgItem
                                });
                            }

                        }
                        else if (Childs.Any(x => x.IsDerived(Templates.JudgesListing.ID)))
                        {
                            lstJudges.Judges = new List<Judge>();

                            var judgeItem = Childs.Where(x => x.IsDerived(Templates.JudgesListing.ID)).FirstOrDefault();

                            foreach (var judgItem in judgeItem.Children.Where(x => x.IsDerived(Templates.Judges.ID)))
                            {
                                lstJudges.Judges.Add(new Judge
                                {
                                    item = judgItem
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
            return View(lstJudges);
        }
    }
}