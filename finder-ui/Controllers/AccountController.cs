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
            bool UsernameExist = true;
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {
                using (var validation = new UserLoginServiceReference.LoginServiceClient())
                {
                    UsernameExist = validation.UsernameExist(vm.username);
                }
                if (!UsernameExist)
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
                

                if (Session["AuthorizedAsUser"] == "true")
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
                    ViewBag.Message= "Användarnamnet finns redan";
                    return View("Index");
                }

            }
          
        }

        //inloggnings saker
        [HttpGet]
        public ActionResult Login()
        {
            var controller = TempData["ReturnToController"].ToString();
            var action = TempData["ReturnToAction"].ToString();

            var viewModel = new LoginViewModel
            {
                Controller = controller,
                Action = action,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            // TODO: Här st man egentligen anropa inloggningstjänsten
            Session["AuthorizedAsUser"] = "true";
            return RedirectToAction(viewModel.Action, viewModel.Controller);
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
            using (var client = new UserProfileServiceReference.UserProfileServiceClient())
            {

                
                int.TryParse(Session["UserId"].ToString(), out int userid);

                var Userinfo = client.GetUserByUserId(userid);
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

                var user = client.UpdateUser(updateUser);

            }

            using (var client = new UserLoginServiceReference.LoginServiceClient())
            {
                if (client.UsernameExist(vm.username))
                {
                    ViewBag.Message = "Det valda Användarnamnet finns redan";
                }
                else
                {
                    return RedirectToAction("Index", "UserProfile");
                }
            }
            return View();

        }

    }
}