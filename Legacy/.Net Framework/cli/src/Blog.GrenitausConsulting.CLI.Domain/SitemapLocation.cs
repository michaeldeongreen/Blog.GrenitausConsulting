﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blog.GrenitausConsulting.CLI.Domain
{
    public class SitemapLocation
    {
        public SitemapLocation()
        {
            Images = new List<SitemapImage>();
        }
        public enum eChangeFrequency
        {
            always,
            hourly,
            daily,
            weekly,
            monthly,
            yearly,
            never
        }

        [XmlElement("loc")]
        public string Url { get; set; }

        [XmlElement("changefreq")]
        public eChangeFrequency? ChangeFrequency { get; set; }
        public bool ShouldSerializeChangeFrequency() { return ChangeFrequency.HasValue; }

        [XmlElement("lastmod")]
        public DateTime? LastModified { get; set; }
        public bool ShouldSerializeLastModified() { return LastModified.HasValue; }

        [XmlElement("priority")]
        public double? Priority { get; set; }
        public bool ShouldSerializePriority() { return Priority.HasValue; }

        [XmlElement("image", Namespace = "http://www.google.com/schemas/sitemap-image/1.1")]
        public List<SitemapImage> Images { get; set; }
        public bool ShouldSerializeImages() { return Images != null && Images.Count > 0; }
    }
}
