using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Homes365.Models
{
    public class Housing
    {
        public int Id { get; set; }

        [Display(Name = "Housing Details")]
        public string HousingDetails { get; set; }
        public decimal? Price { get; set; }

        public bool Availability { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

    }
}
