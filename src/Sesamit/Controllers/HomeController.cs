using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Sesamit.Data;
using Sesamit.Models;
using Sesamit.Models.HomeViewModels;

namespace Sesamit.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Intro()
        {
            return View();
        }

        public IActionResult Foretag()
        {
            return View();
        }

        public IActionResult VadArSesam()
        {
            return View();
        }

        public async Task<IActionResult> NyheterBlogg()
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
                        TimePast = DateTime.Today - DateTime.Parse(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
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

            var newsPosts = _context.NewsPosts.OrderByDescending(x => x.Date);
            model.NewsPosts = newsPosts.ToList();

            
            return View(model);
        }

        public IActionResult Bryggan()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        //private List<NewsPost> FixBytePictures(List<NewsPost> newsPosts)
        //{
        //    var fixedPosts = new List<NewsPost>();
        //    foreach (var newsPost in newsPosts)
        //    {
        //        fixedPosts.Add(newsPost);
        //        if (newsPost.Picture != null)
        //        {
        //            fixedPosts[newsPosts.IndexOf(newsPost)].Picture = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(newsPost.Picture));
        //        }
        //    }
        //    return null;
        //}
    }
}
