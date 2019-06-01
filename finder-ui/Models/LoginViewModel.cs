using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Du måste fylla i ett användarnamn / epost")]
        public string username { get; set; }
        [Required(ErrorMessage="Du måste fylla i ett lösenord")]
        public string userPassword { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
    }
}