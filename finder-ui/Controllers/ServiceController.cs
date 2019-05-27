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

        // GET: Service
        public ActionResult Index()
        {
            var indexService = client.GetAllServiceData();
           // int.TryParse(Session["UserId"].ToString(), out int userid);
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

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                client.CreateService(
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

                return RedirectToAction("Index");
            }
            catch
            {
              return RedirectToAction("Error");
            }
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

                if (service.CreatorID == userid)
                {
                    return View(service);
                }
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
