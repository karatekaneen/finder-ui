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
        [Required(ErrorMessage = "Du måste fylla i en giltig Email!")]
        public string UserEmail { get; set; }
        public string UserProfilePicture { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett namn!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett namn!")]
        public string UserFirstName { get; set; }
        [Required(ErrorMessage = "Du måste fylla i ett namn!")]
        public string UserSurname { get; set; }
        [RegularExpression("[0-9]{8}", ErrorMessage = "Fyll i födelsedatum max 8 siffror!")]
        public int? PersonalCodeNumber { get; set; }

    }
}