using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace finder_ui.Models
{
    public class UpdateProfileViewModel
    {
        public int id { get; set; }
        [Range(0, 99999999, ErrorMessage = "Fyll i korrekt födelsedatum (ÅÅÅÅMMDD)")]
        public int? personalnumber { get; set; }
        public string userCity { get; set; }
        public string userAddress { get; set; }
        public int? userZipCode { get; set; }
        public string userPhoneNumber { get; set; }
        public string userProfilePicture { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string username { get; set; }
    }
}