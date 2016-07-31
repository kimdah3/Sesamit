using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Sesamit.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Sesamit.Controllers
{
    public class BloggNyheterController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var url = "http://sesamnu.blogg.se/index.rss";
            var bloggModel = new BloggRssModel();

            using (var reader = XmlReader.Create(url))
            {
                var feed = SyndicationFeed.Load(reader);
                foreach (var item in feed.Items)
                {
                    var bloggPost = new BloggPost()
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text.Substring(0, item.Summary.Text.IndexOf('-')),
                        Link = item.Links[0].Uri,
                        PubDate = DateTime.Parse(item.PublishDate.ToString())
                    };
                    bloggModel.BloggPosts.Add(bloggPost);
                }
            }
            return View(bloggModel);
        }
    }

}
