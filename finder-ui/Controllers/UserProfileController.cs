using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        [CustomAuthorization]
        [HttpGet]
        public ActionResult Index()
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                int.TryParse(Session["UserId"].ToString(), out int userid);
                var Userinfo = client.GetUserByUserId(userid);

                var viewModel = new UpdateProfileViewModel()
                {
                    firstname = Userinfo.Name,
                    surname = Userinfo.Surname,
                    username = Userinfo.Username,
                    email = Userinfo.Email,
                    personalnumber = Userinfo.PersonalCodeNumber,
                    userPhoneNumber = Userinfo.Phonenumber,
                    userCity = Userinfo.City,
                    userAddress = Userinfo.Address,
                    userZipCode = Userinfo.ZipCode,
                    userProfilePicture = Userinfo.Picture,
                };
                return View(viewModel);
            }
        }
        
        [CustomAuthorization]
        [HttpGet]
        public ActionResult EditProfile()
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                int.TryParse(Session["UserId"].ToString(), out int userid);
                var Userinfo = client.GetUserByUserId(userid);

                var viewModel = new EditProfileViewModel()
                {
                    PersonalCodeNumber = Userinfo.PersonalCodeNumber,
                    UserEmail = Userinfo.Email,
                    UserPhoneNumber = Userinfo.Phonenumber,
                    UserCity = Userinfo.City,
                    UserAddress = Userinfo.Address,
                    UserZipCode = Userinfo.ZipCode,
                    UserProfilePicture = Userinfo.Picture,
                };
                return View(viewModel);
            }
        }

        [CustomAuthorization]
        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel vm)
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                int.TryParse(Session["UserId"].ToString(), out int userid);
                var Userinfo = client.GetUserByUserId(userid);

                var updateUser = new UserProfileServiceReference.User()
                {
                    PersonalCodeNumber = vm.PersonalCodeNumber,
                    Address = vm.UserAddress,
                    City = vm.UserCity,
                    Phonenumber = vm.UserPhoneNumber,
                    Picture = vm.UserProfilePicture,
                    ZipCode = vm.UserZipCode,
                    Id = userid,
                    Email = Userinfo.Email,
                    Name = Userinfo.Name,
                    Surname = Userinfo.Surname,
                    Username = Userinfo.Username,
                };

                var user = client.UpdateUser(updateUser);

            }
            
            if(!ModelState.IsValid){
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

        }


        public ActionResult UpdateAccountInformation(EditProfileViewModel vm)
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                var updateUser = new UserProfileServiceReference.User()
                {
                    Address = vm.UserAddress,
                    City = vm.UserCity,
                    Email = vm.UserEmail,
                    Phonenumber = vm.UserPhoneNumber,
                    Picture = vm.UserProfilePicture,
                    ZipCode = vm.UserZipCode,
                    Id = vm.UserId,

                };

                var user = client.UpdateUser(updateUser);
            }

            return View();

        }
    }
}