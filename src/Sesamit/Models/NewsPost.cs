using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sesamit.Models
{
    public class NewsPost
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Titel")]
        public string Title { get; set; }
        [Display(Name = "Text")]
        public string Text { get; set; }
        public string Author { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Bild")]
        public byte[] Picture { get; set; }

    }
}
