using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sesamit.Models.HomeViewModels
{
    public class BloggPostModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PubDate { get; set; }
        public TimeSpan TimePast { get; set; }
        public Uri Link { get; set; }
        public Uri ImageLink { get; set; }
}
}
