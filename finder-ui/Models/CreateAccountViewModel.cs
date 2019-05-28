using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class CreateAccountViewModel
    {
        [Required(ErrorMessage ="Du måste fylla i ett namn!")]
        public string firstname { get; set; }
        [Required(ErrorMessage ="Du måste fylla i ett namn!")]
        public string surname { get; set; }
        [Required(ErrorMessage ="Du måste fylla i en E-post adress!")]
        public string email { get; set; }
        [Required(ErrorMessage ="Du måste fylla i ett användarnamn!")]
        public string username { get; set; }
        [Required(ErrorMessage ="Du måste fylla i ett lösenord!")]
        public string password { get; set; }
        public int id { get; set; }
       
        
    }
}