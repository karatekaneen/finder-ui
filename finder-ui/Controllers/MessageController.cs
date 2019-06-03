using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using finder_ui.Models;
using static finder_ui.SessionHandler.CustomAuthorization;

namespace finder_ui.Controllers
{
    //[Authorize]
    [CustomAuthorization]
    public class MessageController : Controller

    {
        MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
        Group3ServiceReference.Service1Client adClient = new Group3ServiceReference.Service1Client();
        //UserProfileServiceReference.UserProfileServiceClient userName = new UserProfileServiceReference.UserProfileServiceClient();
        UserLoginServiceReference.LoginServiceClient getUsers = new UserLoginServiceReference.LoginServiceClient();

        public ActionResult Index()
        {
            int sessId = Convert.ToInt32(Session["UserId"]); //parsar sessionId till int
            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();


            ViewBag.userMedd = messageClient.GetUserMessage(sessId)/*.Select(x=>x.RecievingUserId)*/; //hämtar ens egna meddelanden
            ViewBag.Lista = messageList.Where(x => x.SendingUserId == sessId);// visar lista på endast egna meddelanden



            //ViewBag.annonsClient = adClient.AdvancedSearch(sessId); //funkar inte att skicka in id, måste skicka in 10 parametrar???

            //Group3ServiceReference.Service svar = adClient.GetServiceById(7); Jan olof  försök
            ViewBag.annonsMessage = adClient.GetServiceById(7); //hämtar service 7
            ViewBag.getUsers = getUsers.GetActiveUsers().ToList();
            ViewBag.getUser = getUsers.GetActiveUsers();

            ViewBag.test = getUsers.GetActiveUsers().Where(x => x.ID == sessId); // test ger info om specifik active user


            return View();
        }

        //[HttpPost]
        //public ActionResult Index(MessageServiceReference.AddMessage newMessage)
        //{
        //    MessageServiceReference.Service1Client messageClient = new MessageServiceReference.Service1Client();
        //    int sessId = Convert.ToInt32(Session["UserId"]);

        //    IEnumerable<MessageServiceReference.Messageinfo> messagelist = messageClient.GetMessages().ToList();
        //    ViewBag.Lista = messagelist;
        //    return RedirectToAction("index","message");
        //}


        // TODO: Gammal metod som anropas om man öppnar en annons och klickar länken "Kontakta annonsör"
        [HttpGet]
        public ActionResult MessageIndex(int id) //id = serviceID
        {
            return RedirectToAction("Message", new { servId = id });
        }

        //ny vy med alla recievingUserId av ett slag, inparameter måste skapas i index vy
        [HttpGet]
        public ActionResult Message(int servId)
        {
            int sessId = Convert.ToInt32(Session["UserId"]); //parsar sessionId till int
            IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetUserMessage(servId);


            //ViewBag.recUserMedd = messageClient.GetUserMessage(servId); //hämtar recieverId optimering
            ViewBag.Lista = messageList.Where(x=>x.ServiceId == servId);// visar lista på endast egna meddelanden

            MessageServiceReference.AddMessage nyttMsg = new MessageServiceReference.AddMessage();
            nyttMsg.ServiceId = servId;
            return View(nyttMsg);
        }
        [HttpPost]
        public ActionResult Message(MessageServiceReference.AddMessage nyttMsg/*int id, int servId, string titel*/)
        {
            Group3ServiceReference.Service1Client client = new Group3ServiceReference.Service1Client();
            var serv = client.GetServiceById(nyttMsg.ServiceId);
            //titel = "hej";
           int sessId = Convert.ToInt32(Session["UserId"]); //parsar sessionId till int
            nyttMsg.SendingUserId = sessId;
            nyttMsg.RecievingUserId = 5 /*serv.CreatorID*/;
            nyttMsg.ServiceTitle = "hej"/*serv.Title*/;
            ////IEnumerable<MessageServiceReference.Messageinfo> messageList = messageClient.GetMessages().ToList();
           messageClient.AddMessage(nyttMsg);

            ////ViewBag.userMedd = messageClient.GetUserMessage(sessId); //hämtar ens egna meddelanden
          //ViewBag.Lista = messageList.Where(x => x.SendingUserId == sessId && x.RecievingUserId == id);// visar lista på endast egna meddelanden

            return RedirectToAction("Message", "Message");//servid 
        }


        public ActionResult Searching()
        {
            Group3ServiceReference.Service1Client search = new Group3ServiceReference.Service1Client();
            List<Group3ServiceReference.Service> hitta = search.Search("hund").ToList();
            ViewBag.search = search.Search("katt").ToList();
            return View();
        }
        //[HttpPost]
        //public ActionResult Search(string a)
        //{
        //    Group3ServiceReference.Service1Client search = new Group3ServiceReference.Service1Client();
        //    ViewBag.search = search.Search(a).ToList();




        //    return View();
        //}

        public ActionResult Kontrakt(int serviceId, int counterpartId, int serviceOwnerId, int contractCreatorId)
        {

            Group3ServiceReference.Service1Client skapaKontrakt = new Group3ServiceReference.Service1Client();
            //ViewBag.skapaKontrakt = skapaKontrakt.CreateContract(serviceId, counterpartId, serviceOwnerId, contractCreatorId);
            skapaKontrakt.CreateContract(serviceId, counterpartId, serviceOwnerId, contractCreatorId);
            return RedirectToAction("Index", "Message");
        }



    }
}