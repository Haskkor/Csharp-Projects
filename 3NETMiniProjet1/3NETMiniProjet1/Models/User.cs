using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _3NETMiniProjet1.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters."), MinLength(4, ErrorMessage = "Min 4 caracters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Field required."), MaxLength(20, ErrorMessage = "Max 20 caracters.")]
        public string NickName { get; set; }

        public int RoleId { get; set; }

        public List<int> FriendsListId { get; set; }
    }
}