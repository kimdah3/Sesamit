using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Sesamit.Models.HomeViewModels;

namespace Sesamit.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult Samarbetspartners()
        {
            return View();
        }

        public IActionResult Jobbmojligheter()
        {
            return View();
        }

        public IActionResult VadArSesam()
        {
            return View();
        }

        public async Task<IActionResult> BloggNyheter()
        {
            const string url = "http://sesamnu.blogg.se/index.rss";
            var model = new NyheterBloggViewModel();
            var bloggPosts = new List<BloggPostModel>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                var responseMessage = await client.GetAsync(url);
                var responseString = await responseMessage.Content.ReadAsStringAsync();

                //extract feed items
                var doc = XDocument.Parse(responseString);
                foreach (var item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item"))
                {
                    var post = new BloggPostModel()
                    {
                        Title = item.Elements().First(i => i.Name.LocalName == "title").Value,

                        Description = item.Elements().First(i => i.Name.LocalName == "description").Value.Substring(0, item.Elements().First(i => i.Name.LocalName == "description").Value.IndexOf('-')),
                        Link = new Uri(item.Elements().First(i => i.Name.LocalName == "link").Value),
                        PubDate = DateTime.Parse(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                        TimePast = DateTime.Now - DateTime.Parse(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                        ImageLink = null
                    };
                    if (item.Elements().Count() == 8)
                    {
                        post.ImageLink = new Uri(item.Elements().First(i => i.Name.LocalName == "enclosure").FirstAttribute.Value);
                    }
                    bloggPosts.Add(post);
                }
            }

            model.BloggPosts = bloggPosts;

            return View(model);
        }

        public IActionResult Bryggan()
        {
            return View();
        }

        public IActionResult Sesamvagen()
        {
            return View();
        }

        public IActionResult MEGAN()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }

}
