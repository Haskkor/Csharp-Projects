using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _3NETMiniProjet1.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field required.")]
        public string Address { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public List<int> GuestsList { get; set; }

        public int EventStatusId { get; set; }

        public int EventTypeId { get; set; }

        public int CreatorId { get; set; }
    }
}