using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BirthdayCardGen.Models
{
    public class GuestResponse
    {

        [Required(ErrorMessage = "Please enter the From field")]
        public string From { get; set; }

        [Required(ErrorMessage = "Please enter the To field")]
        public string To { get; set; }

        [Required(ErrorMessage = "Please enter a message")]
        public string Message { get; set; }
        }

    
}
