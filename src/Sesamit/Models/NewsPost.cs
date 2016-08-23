using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sesamit.Models
{
    public class NewsPost
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public string Author { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
