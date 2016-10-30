using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _3NETMiniProjet1.Models
{
    public class EventStatus
    {
        public int EventStatusId { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string Name { get; set; }
    }
}