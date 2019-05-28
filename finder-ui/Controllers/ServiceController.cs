using finder_ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.SessionHandler;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    public class ServiceController : Controller
    {
        Group3ServiceReference.Service1Client client = new Group3ServiceReference.Service1Client();
        UserProfileServiceReference.UserProfileServiceClient userClient = new UserProfileServiceReference.UserProfileServiceClient();
        ReviewServiceReference.Service1Client reviewClient = new ReviewServiceReference.Service1Client();

        // GET: Service
        public ActionResult Index()
        {
            var indexService = client.GetAllServiceData();
           // int.TryParse(Session["UserId"].ToString(), out int userid);
            List<UserServiceObject> serviceList = new List<UserServiceObject>();

            

            foreach (var item in indexService)
            {
                List<ReviewServiceReference.ReviewData> reviews = new List<ReviewServiceReference.ReviewData>();

                var temp = reviewClient.GetReviewsByServiceId(item.Id).ToList();
                if (temp.Count > 0)
                {
                    reviews = temp;
                }
                UserServiceObject activeService = new UserServiceObject();
                activeService.IncomingService = item;
                activeService.IncomingUser = userClient.GetUserByUserId(activeService.IncomingService.CreatorID);
                activeService.IncomingReview = reviews;
                serviceList.Add(activeService);
                
            }
            
            return View(serviceList);
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {

            var service = client.GetServiceById(id);
            var user = userClient.GetUserByUserId(service.CreatorID);

            List<ReviewServiceObject> review = new List<ReviewServiceObject>();
            List<ReviewServiceReference.ReviewData> tempReviews = reviewClient.GetReviewsByServiceId(service.Id).ToList();
            if (tempReviews.Count > 0)
            {
                foreach (var item in tempReviews)
                {
                    var reviewWriter = userClient.GetUserByUserId(item.ByUserId);
                    ReviewServiceObject reviewServiceObject = new ReviewServiceObject();
                    reviewServiceObject.IncomingReview = item;
                    reviewServiceObject.IncomingReviewUser = reviewWriter;

                    review.Add(reviewServiceObject);
                }
            }


            

            UserServiceObject detailedService = new UserServiceObject();
            detailedService.IncomingService = service;
            detailedService.IncomingUser = user;
            detailedService.IncomingReviewWithUser = review;
            return View(detailedService);
        }

        // GET: Service/Create
        public ActionResult Create()
        { 
            List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
            List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
            List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();
            List<Group3ServiceReference.Category> categories = client.GetCategories().ToList();

            CreateServiceObject createServiceObject = new CreateServiceObject(statuses, subCategories, serviceTypes, categories);
            return View(createServiceObject);
        }

        // POST: Service/Create
        [HttpPost]
        public ActionResult Create(
            int type,
            int serviceStatusId,
            string picture,
            string title,
            string description,
            double price,
            DateTime? startDate,
            DateTime? endDate,
            bool timeNeeded,
            int subCategoryId)
        {
            try
            {
                List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
                List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
                List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();
                List<Group3ServiceReference.Category> categories = client.GetCategories().ToList();

                int.TryParse(Session["UserId"].ToString(), out int userid);
 
                if (picture == "")
                {
                    picture = "http://hdimages.org/wp-content/uploads/2017/03/placeholder-image10.jpg";
                }
                    
                
                CreateServiceObject createServiceObject = new CreateServiceObject(
                    type,
                    userid,
                    serviceStatusId,
                    picture,
                    title,
                    description,
                    price,
                    startDate,
                    endDate,
                    timeNeeded,
                    subCategoryId);

                createServiceObject.ServiceStatusId = 2;

                bool test = client.CreateService(
                    createServiceObject.Type,
                    createServiceObject.CreatorId,
                    createServiceObject.ServiceStatusId,
                    createServiceObject.Picture,
                    createServiceObject.Title,
                    createServiceObject.Description,
                    createServiceObject.Price,
                    createServiceObject.StartDate,
                    createServiceObject.EndDate,
                    createServiceObject.TimeNeeded,
                    createServiceObject.SubCategoryId);

                if (test)
                {
                    test = false;
                }
                else
                {
                    test = true;
                }
                
          
                return RedirectToAction("Index");
            }
            catch
            {
              return RedirectToAction("Error");
            }
        }

        [CustomAuthorization]
        public ActionResult MyServices()
        {
            int.TryParse(Session["UserId"].ToString(), out int userid);

            var indexService = client.AdvancedSearch(
                new Group3ServiceReference.DateRange(),
                new Group3ServiceReference.DateRange(),
                new Group3ServiceReference.DateRange(),
                userid,
                null, // Titel
                null,
                new Group3ServiceReference.PriceRange(),
                0,  // <--- Det här är status
                new List<int>().ToArray(),
                new List<int>().ToArray());
            List<UserServiceObject> serviceList = new List<UserServiceObject>();
            foreach (var item in indexService)
            {
                UserServiceObject activeService = new UserServiceObject();
                activeService.IncomingService = item;
                activeService.IncomingUser = userClient.GetUserByUserId(activeService.IncomingService.CreatorID);
                serviceList.Add(activeService);
            }

            return View(serviceList);
        }

        // GET: Service/Edit/5
        [CustomAuthorization]
        public ActionResult Edit(int id)
        {
            Group3ServiceReference.Service service = client.GetServiceById(id);
            List<Group3ServiceReference.ServiceStatusType> statuses = client.GetServiceStatusTypes().ToList();
            List<Group3ServiceReference.SubCategory> subCategories = client.GetSubCategories().ToList();
            List<Group3ServiceReference.ServiceType> serviceTypes = client.GetTypes().ToList();
            List<Group3ServiceReference.Category> categories = client.GetCategories().ToList();

            EditServiceObject editService = new EditServiceObject(
                service.Id,
                service.ServiceType.Id,
                service.ServiceStatus.Id,
                service.Picture,
                service.Title,
                service.Description,
                service.Price,
                service.StartDate,
                service.EndDate,
                service.TimeNeeded,
                service.SubCategory.Id,
                statuses,
                subCategories,
                categories,
                serviceTypes
                );

            return View(editService);
        }

        // POST: Service/Edit/5
        [HttpPost]
        public ActionResult Edit(
            int id, 
            int type,
            int serviceStatusId,
            string picture,
            string title,
            string description,
            double price,
            DateTime? startDate,
            DateTime? endDate,
            bool timeNeeded,
            int subCategoryId)
        {
            try
            {
                var x = subCategoryId;
                bool editOk = 
                client.EditService(
                    id,
                    type,
                    serviceStatusId,
                    picture,
                    title,
                    description,
                    price,
                    startDate,
                    endDate,
                    timeNeeded,
                    subCategoryId); 

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                int.TryParse(Session["UserId"].ToString(), out int userid);
                var service = client.GetServiceById(id);
                var user = userClient.GetUserByUserId(service.CreatorID);

                UserServiceObject deleteService = new UserServiceObject();
                deleteService.IncomingService = service;
                deleteService.IncomingUser = user;

                if (deleteService.IncomingService.CreatorID == userid)
                {
                    return View(deleteService);
                }

                // TODO:
                //else if (inloggad som admin){
                //return View(service)
                //}

                else
                {
                    return RedirectToAction("Error");
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Ej inloggad" + e);
                return RedirectToAction("Error");
            }
        
        }

        // POST: Service/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                client.DeleteService(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error");
            }
        }
        
        public ActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var services = client.Search(searchString);
            List<UserServiceObject> serviceList = new List<UserServiceObject>();
            foreach (var item in services)
            {
                UserServiceObject activeService = new UserServiceObject();
                activeService.IncomingService = item;
                activeService.IncomingUser = userClient.GetUserByUserId(activeService.IncomingService.CreatorID);
                serviceList.Add(activeService);
            }
            return View(serviceList);
        }



    }
}
