using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Feature.Teasers.Models
{
    public class ImageSlider : ISliderItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlt { get; set; }
        public string LinkUrl { get; set; }
        public string LinkTarget { get; set; }
    }
}