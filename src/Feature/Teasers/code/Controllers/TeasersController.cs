using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Sitecore.Mvc.Controllers;
using Sitecore.Mvc.Presentation;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Hackathon.Feature.Teasers.Models;
using Sitecore.Data.Fields;
using Sitecore.Resources.Media;
using Sitecore.Data.Items;

namespace Hackathon.Feature.Teasers.Controllers
{
    public class TeasersController : SitecoreController
    {
        public ActionResult Slider()
        {
            try
            {
                var dataSourceId = RenderingContext.CurrentOrNull.Rendering.DataSource;
                if (string.IsNullOrEmpty(dataSourceId))
                    return PartialView();


                var dataSource = Sitecore.Context.Database.GetItem(dataSourceId);
                if (dataSource == null || dataSource.Children.Count == 0)
                    return PartialView();

                if (!dataSource.IsDerived(Templates.SliderFolder.ID))
                    return PartialView();

                List<ISliderItem> Items = new List<ISliderItem>();
                foreach (var slide in dataSource.Children.ToList())
                {
                    if (slide.IsDerived(Templates.ImageSlider.ID))
                    {
                        ImageSlider _imageSlider = new ImageSlider();
                        _imageSlider.Title = slide.Fields[Templates.ImageSlider.Fields.Title].Value;
                        _imageSlider.Description = slide.Fields[Templates.ImageSlider.Fields.Description].Value;

                        ImageField _image = (ImageField)slide.Fields[Templates.ImageSlider.Fields.Image];
                        if (_image != null && _image.MediaItem != null)
                        {
                            _imageSlider.ImageUrl = MediaManager.GetMediaUrl(_image.MediaItem);
                        }

                        LinkField _Link = (LinkField)slide.Fields[Templates.ImageSlider.Fields.Link];
                        if (_Link != null)
                        {
                            _imageSlider.LinkUrl =_Link.GetFriendlyUrl();
                            _imageSlider.LinkTarget = _Link.Target;
                            _imageSlider.LinkText = _Link.Text;
                        }

                        Items.Add(_imageSlider);
                    }
                    else if (slide.IsDerived(Templates.VideoSlider.ID))
                    {
                        VideoSlider _videoSlider = new VideoSlider();
                        _videoSlider.Title = slide.Fields[Templates.VideoSlider.Fields.Title].Value;
                        _videoSlider.Description = slide.Fields[Templates.VideoSlider.Fields.Description].Value;

                        LinkField _videoLink = (LinkField)slide.Fields[Templates.VideoSlider.Fields.Video];
                        if (_videoLink != null)
                        {
                            MediaItem video = Sitecore.Context.Database.GetItem(_videoLink.TargetID);

                            string src = Sitecore.Resources.Media.MediaManager.GetMediaUrl(video);
                            _videoSlider.VideoUrl = src.Split('.')[0];
                        }

                        LinkField _Link = (LinkField)slide.Fields[Templates.VideoSlider.Fields.Link];
                        if (_Link != null)
                        {
                            _videoSlider.LinkUrl = _Link.GetFriendlyUrl();
                            _videoSlider.LinkTarget = _Link.Target;
                            _videoSlider.LinkText = _Link.Text;
                        }

                        Items.Add(_videoSlider);
                    }
                }
                return PartialView(Items);
            }
            catch(Exception ex)
            {

            }

            return PartialView();
        }
    }
}