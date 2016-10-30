using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _3NETMiniProjet1.Models
{
    public class Contribution
    {
        public int ContributionId { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field required.")]
        public int Quantity { get; set; }

        public int ContributionTypeId { get; set; }

        public int EventId { get; set; }
    }
}