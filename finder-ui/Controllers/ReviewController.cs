using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.SessionHandler;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    public class ReviewController : Controller
    {
        ReviewServiceReference.Service1Client client = new ReviewServiceReference.Service1Client();

        [HttpGet]
        public ActionResult ShowReviewsByServiceId(int id)
        {
            ViewBag.serviceid = id;

            List<ReviewServiceReference.ReviewData> reviewList = client.GetReviewsByServiceId(id).ToList();

            return View(reviewList);
        }

        [HttpGet]
        public ActionResult ShowReviewsByUserId(int id)
        {
            ViewBag.byuser = id;

            List<ReviewServiceReference.ReviewData> reviewList = client.GetReviewsByUserId(id).ToList();

            return View(reviewList);
        }

        [HttpGet]
        public ActionResult ShowReviewsAboutUserId(int id)
        {
            ViewBag.aboutuser = id;

            List<ReviewServiceReference.ReviewData> reviewList = client.GetReviewsByAboutUserId(id).ToList();

            return View(reviewList);
        }

        [CustomAuthorization]
        [HttpGet]
        public ActionResult ReviewService(int id)
        {
            ViewBag.serId = id;
            var userID = Session["UserId"];
            ViewBag.usId = userID;


            return View();
        }

        [CustomAuthorization]
        [HttpGet]
        public ActionResult ReviewUser(int id)
        {
            ViewBag.aboutUser = id;
            var userID = Session["UserId"];
            ViewBag.usId = userID;

            return View();
        }

        [HttpPost]
        public ActionResult SaveReview(ReviewServiceReference.Reviews recension)
        {
            client.SaveReview(recension);
            return RedirectToAction("Index", "Home");
        }
    }
}