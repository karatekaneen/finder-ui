using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    [CustomAuthorization]
    public class MessageController : Controller
    {
        MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
        Group3ServiceReference.Service1Client adClient = new Group3ServiceReference.Service1Client();
        UserProfileServiceReference.UserProfileServiceClient userClient = new UserProfileServiceReference.UserProfileServiceClient();

        //GET: Message

        [HttpGet]
        public ActionResult MessageIndex(int id) //id = serviceID
        {
            var serv = adClient.GetServiceById(id); //hämtar serviceobjekt via serviceID
            var creatorId = serv.CreatorID;
            var servID = serv.Id;
            var sessId = Convert.ToInt32(Session["UserId"]);
            ViewBag.serviceId = servID;
            ViewBag.serviceOwner = creatorId;
            ViewBag.ServiceTitle = serv.Title;

            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages();// hämtar alla meddelanden om en service
           
            ViewBag.Lista = messageList.Where(x => x.SendingUserId == sessId && x.RecievingUserId == creatorId && x.ServiceId == servID);// visar lista på service du är mottagare eller sändare i.

            var namnServiceOwner = userClient.GetUserByUserId(creatorId);
            var namnInloggad = userClient.GetUserByUserId(sessId);
            ViewBag.namnServiceOwner = namnServiceOwner;
            ViewBag.namnInloggadUser = namnInloggad;

            MessageServiceReference.AddMessage nyttMsg = new MessageServiceReference.AddMessage();
            nyttMsg.ServiceId = id;
            return View(nyttMsg);
        }
        [HttpPost]
        public ActionResult MessageIndex(MessageServiceReference.AddMessage nyttMsg/*int id, int servId, string titel*/)
        {
            
            var serv = adClient.GetServiceById(nyttMsg.ServiceId); //hämtar serviceobjekt via serviceID
            var creatorId = serv.CreatorID;
            var servID = serv.Id;
            
            var sessId = Convert.ToInt32(Session["UserId"]); //parsar sessionId till int
            nyttMsg.SendingUserId = sessId;
            nyttMsg.RecievingUserId = serv.CreatorID;
            nyttMsg.ServiceTitle = serv.Title;

            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
            messageClient.AddMessage(nyttMsg);

            
            ViewBag.Lista = messageList.Where(x => x.SendingUserId == sessId && x.RecievingUserId == creatorId && x.ServiceId == servID);// visar lista på endast egna meddelanden

            return RedirectToAction("MessageIndex", "Message");
        }
        
        public ActionResult Kontrakt(int serviceId, int counterpartId, int serviceOwnerId, int contractCreatorId)
        {
            
            adClient.CreateContract(serviceId, counterpartId, serviceOwnerId, contractCreatorId); //Skapa kontrakt
            var kontraktinfo = adClient.GetContract(serviceId, counterpartId, serviceOwnerId);//Hämta kontraktet
            var serviceInfo = adClient.GetServiceById(serviceId);//Hämta serviceinfo

            //var serviceTitel = serviceInfo.Title;
            var sessId = Convert.ToInt32(Session["UserId"]);//hämta AktivAnvändare
            var serviceOwnerInfo = userClient.GetUserByUserId(serviceOwnerId);//hämta serviceägaren!
            ViewBag.serviceOwner = serviceOwnerInfo.Name; //Viewbag med serviceägarens NAMN
            var userInfo = userClient.GetUserByUserId(sessId);
            ViewBag.activeUser = userInfo.Name;//Viewbag med den inloggades NAMN

            
            

            return View(serviceInfo);
        }
    }
}