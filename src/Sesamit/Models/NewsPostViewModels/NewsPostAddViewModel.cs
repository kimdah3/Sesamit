using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sesamit.Models.NewsPostViewModels
{
    public class NewsPostAddViewModel
    {
        public NewsPost NewsPost { get; set; }
        public IFormFile FilePicture { get; set; }

    }
}
