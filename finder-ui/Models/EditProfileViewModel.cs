using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace finder_ui.Models
{
    public class EditProfileViewModel
    {
        public int UserId { get; set; }
        public string UserCity { get; set; }
        public string UserAddress { get; set; }
        [RegularExpression ("[0-9]{5}", ErrorMessage ="Du måste fylla i ett giltigt postnummer")]
        public int? UserZipCode { get; set; }
        [RegularExpression ("[0-9]{9,12}", ErrorMessage = "Du måste fylla i ett giltigt telefonnummer")]
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public string UserProfilePicture { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserSurname { get; set; }
        public int? PersonalCodeNumber { get; set; }
    }
}