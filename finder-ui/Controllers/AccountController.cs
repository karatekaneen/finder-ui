using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;
using finder_ui.SessionHandler;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    public class AccountController : Controller
    {
        // GET: CreateAccount
        public ActionResult Index()
        {
            var CreateAccount = new CreateAccountViewModel();
            return View(CreateAccount);
        }

        public ActionResult UpdateProfile(UpdateProfileViewModel vm)
        {
            var UpdateProfile = new UpdateProfileViewModel();
            return View(UpdateProfile);
        }


        public ActionResult CreateAccount(CreateAccountViewModel vm)
        {
            bool usernameExist = true;
            bool emailExist = true;
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                using (var validation = new UserLoginServiceReference.LoginServiceClient())
                {
                    usernameExist = validation.UsernameExist(vm.username);
                    if (usernameExist)
                    {
                        ModelState.AddModelError("username", "Det angivna användarnamnet är tyvärr upptaget");
                    }
                    emailExist = validation.EmailExist(vm.email);
                    if (emailExist)
                    {
                        ModelState.AddModelError("email", "Den angivna eposten är tyvärr upptagen");
                    }
                }
                if (!usernameExist && !emailExist)
                {
                    var newUser = new UserProfileServiceReference.NewUser()
                    {
                        Email = vm.email,
                        FirstName = vm.firstname,
                        Surname = vm.surname,
                        Password = vm.password,
                        Username = vm.username,
                    };
                    var user = client.CreateUser(newUser);

                    if (user != null)
                    {
                        Session["AuthorizedAsUser"] = "true";
                        Session["UserId"] = client.GetUserByUserNameOrEmail(vm.username).Id;
                    }
                    else
                    {
                        return View("Index");
                    }


                    if (Session["AuthorizedAsUser"].ToString() == "true")
                    {
                        return View("UpdateUserProfile");
                    }
                    else
                    {
                        return View("Index");
                    }
                }
                else
                {
                    return View("Index");
                }

            }

        }

        //inloggnings saker
        [CustomAuthorization]
        public ActionResult LogIn()
        {
            return RedirectToAction("MyServices", "Service");
        }


        [HttpGet]
        public ActionResult LogOut()
        {
            Session["AuthorizedAsUser"] = null;
            Session["UserId"] = null;
            return RedirectToAction("Index", "Home");
        }

        [CustomAuthorization]
        [HttpGet]
        public ActionResult UpdateUserProfile()
        {
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                int.TryParse(Session["UserId"].ToString(), out int userid);
                var Userinfo = client.GetUserByUserId(userid);

                var viewModel = new UpdateProfileViewModel()
                {
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
        [HttpPost]
        public ActionResult UpdateUserProfile(UpdateProfileViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            using (var client = new UserLoginServiceReference.LoginServiceClient())
            {
                if (client.UsernameExist(vm.username))
                {
                    ViewBag.Message = "Det valda Användarnamnet finns redan";
                }
                else if (client.EmailExist(vm.email))
                {
                    ViewBag.Message = "Den angiva epost adressen finns redan";
                }
                else
                {
                    using (var profileClient = new UserProfileServiceReference.UserProfileServiceClient())
                    {


                        int.TryParse(Session["UserId"].ToString(), out int userid);

                        var Userinfo = profileClient.GetUserByUserId(userid);
                        var updateUser = new UserProfileServiceReference.User()
                        {
                            Address = vm.userAddress,
                            City = vm.userCity,
                            PersonalCodeNumber = vm.personalnumber,
                            Phonenumber = vm.userPhoneNumber,
                            Picture = vm.userProfilePicture,
                            ZipCode = vm.userZipCode,
                            Id = userid,
                            Email = Userinfo.Email,
                            Name = Userinfo.Name,
                            Surname = Userinfo.Surname,
                            Username = Userinfo.Username,
                        };

                        var user = profileClient.UpdateUser(updateUser);


                    }
                    return RedirectToAction("Index", "UserProfile");
                }

            }

            return View();
        }

    }
}