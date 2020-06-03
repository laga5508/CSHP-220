using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BDayCardGenerator.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Please enter Name")]
        public string From { get; set; }
        [Required(ErrorMessage = " Please enter Name")]
        public string To { get; set; }
        public bool? WillAttend { get; set; }
    }
}
