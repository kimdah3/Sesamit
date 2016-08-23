using System;
using System.ComponentModel.DataAnnotations;

namespace Sesamit.Models
{
    public class Sponsor
    {
        public int Id { get; set; }

        [Display(Name = "Företagsnamn")]
        [Required(ErrorMessage = "Ange företagsnamn.")]
        public string Name { get; set; }

        [Display(Name = "Logga")]
        public byte[] Picture { get; set; }

        [Display(Name = "Startdatum")]
        [Required(ErrorMessage = "Ange datum.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Slutdatum")]
        [Required(ErrorMessage = "Ange datum.")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
