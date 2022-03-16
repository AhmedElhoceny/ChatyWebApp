using Chaty.Models;
using Chaty.Repo;
using Chaty.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientRepo clientFuns;
        private readonly MessageRepo messagesFuns;
        private readonly OfferRepo offerFuns;
        private readonly AdminRepo adminFuns;

        public ClientController(ClientRepo ClientFuns , MessageRepo MessagesFuns , OfferRepo OfferFuns , AdminRepo AdminFuns)
        {
            clientFuns = ClientFuns;
            messagesFuns = MessagesFuns;
            offerFuns = OfferFuns;
            adminFuns = AdminFuns;
        }
        public IActionResult ShowMessages(string Name)
        {
            MessagesViewModel ClientMessages = new MessagesViewModel()
            {
                Client = clientFuns.SearchedByClientName(Name),
                Messages = messagesFuns.GetClientMessages(Name)
            };
            return View("ShowMessage" , ClientMessages);
        }
        public IActionResult ShowMessages_Arabic(string Name)
        {
            MessagesViewModel ClientMessages = new MessagesViewModel()
            {
                Client = clientFuns.SearchedByClientName(Name),
                Messages = messagesFuns.GetClientMessages(Name)
            };
            return View( ClientMessages);
        }
        public IActionResult EditData(String Name)
        {
            var SearchedClient = clientFuns.SearchedByClientName(Name);
            return View(SearchedClient);
        }
        public IActionResult EditData_Arabic(String Name)
        {
            var SearchedClient = clientFuns.SearchedByClientName(Name);
            return View(SearchedClient);
        }
        public IActionResult EditDataPost(string EditName , string EditEmail , string EditNumber , string EditPassWord , string EditConfirmPassWord , IFormFile file , int ItemId)
        {
            var SearchedClient = clientFuns.SearchedById(ItemId);
            if (EditPassWord == EditConfirmPassWord && EditName != null && EditEmail != null && EditNumber != null && EditPassWord != null && EditConfirmPassWord != null)
            {
                if (file != null)
                {
                    var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    clientFuns.EditItem(new Clients()
                    {
                        Email = EditEmail,
                        Imgae = file.FileName,
                        Name = EditName,
                        PassWord = EditPassWord,
                        PhoneNumber = EditNumber,
                        UserCode = RandomCodeGenerator.RandomString(8)
                    } , ItemId);
                }
                else
                {
                    clientFuns.EditItem(new Clients()
                    {
                        Email = EditEmail,
                        Imgae = "None",
                        Name = EditName,
                        PassWord = EditPassWord,
                        PhoneNumber = EditNumber,
                        UserCode = RandomCodeGenerator.RandomString(8)
                    } , ItemId);
                }
                return RedirectToAction(nameof(ShowMessages) ,new { Name = EditName });
            }
            else
            {
                return RedirectToAction(nameof(EditData) , new { Name = SearchedClient.Name });
            }
        }
        public IActionResult EditDataPost_Arabic(string EditName, string EditEmail, string EditNumber, string EditPassWord, string EditConfirmPassWord, IFormFile file, int ItemId)
        {
            var SearchedClient = clientFuns.SearchedById(ItemId);
            if (EditPassWord == EditConfirmPassWord && EditName != null && EditEmail != null && EditNumber != null && EditPassWord != null && EditConfirmPassWord != null)
            {
                if (file != null)
                {
                    var path = Path.Combine(
                      Directory.GetCurrentDirectory(), "wwwroot",
                      file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    clientFuns.EditItem(new Clients()
                    {
                        Email = EditEmail,
                        Imgae = file.FileName,
                        Name = EditName,
                        PassWord = EditPassWord,
                        PhoneNumber = EditNumber,
                        UserCode = RandomCodeGenerator.RandomString(8)
                    }, ItemId);
                }
                else
                {
                    clientFuns.EditItem(new Clients()
                    {
                        Email = EditEmail,
                        Imgae = "None",
                        Name = EditName,
                        PassWord = EditPassWord,
                        PhoneNumber = EditNumber,
                        UserCode = RandomCodeGenerator.RandomString(8)
                    }, ItemId);
                }
                return RedirectToAction(nameof(ShowMessages_Arabic), new { Name = EditName });
            }
            else
            {
                return RedirectToAction(nameof(EditData_Arabic), new { Name = SearchedClient.Name });
            }
        }
        public IActionResult ShowOffers(String Name)
        {
            var SearchedClient = clientFuns.SearchedByClientName(Name);
            ViewBag.ClientName = SearchedClient.Name;
            List<Offer> OurOffers = offerFuns.GetAllData();
            ViewBag.PayPalClientId = adminFuns.GetAdminData().PayPalClientId;
            return View(OurOffers);
        }
        public string GetOffer(string Name , int Offer)
        { 
            try
            {
                var SearchedClient = clientFuns.SearchedByClientName(Name);
                offerFuns.DeleteAllClientOffer(SearchedClient.UserCode);
                var SearchedOffer = offerFuns.SearchOfferByPrice(Offer);
                clientFuns.AddClientToOffer(SearchedClient.UserCode, SearchedOffer.OfferTitle);
                SearchedClient.MessagesNumber = SearchedOffer.MessagesNumber;
                offerFuns.SendProcessingRequest(SearchedClient.Id, SearchedOffer.id);
                return "Done";
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
        public IActionResult SendTextMessageWhatsApp(string To, string Message, string UserCode , string Image , string Link)
        {
            var SearchedClient = clientFuns.SearchedByCode(UserCode);
            try
            {
                if (SearchedClient == null)
                {
                    return RedirectToAction(nameof(Failed));
                }
                string SendMessage = "This Message From " + SearchedClient.Name + " : -----> " + Message;
                /*
                if (SearchedClient.Activated == false)
                {
                    return RedirectToAction(nameof(Failed));
                }
                var SearchClientOffer = offerFuns.SearchOfferByClientCode(UserCode);
                if (SearchClientOffer.OfferEndTime < DateTime.Now)
                {
                    SearchedClient.Activated = false;
                    clientFuns.EditItem(SearchedClient, SearchedClient.Id);
                    AccessDB.AccessChangesDB();
                    return RedirectToAction(nameof(Failed));
                } 
                */
                var Phones = To.Split(',');
                foreach (var PhoneItem in Phones)
                {
                    var MobilePhone = PhoneItem.Trim();
                    if (Message != null)
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/chat");
                        HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + MobilePhone + "&body=" + Message + "&priority=" + 10).Result;
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    }
                    if (Image != null)
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/image");
                        HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + MobilePhone + "&image=" + Image + "&caption=" + "").Result;
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    }
                    if (Link != null)
                    {
                        HttpClient client = new HttpClient();
                        client.BaseAddress = new Uri("https://api.ultramsg.com/instance3119/messages/link");
                        HttpResponseMessage response = client.GetAsync("?token=" + "xk2ro0hh14bhbkiq&to=" + MobilePhone + "&link=" + Link).Result;
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    }
                    messagesFuns.AddNewItem(new Models.Message()
                    {
                        ClientId = SearchedClient.Id,
                        MessageContent = Message,
                        MessageTime = DateTime.Now,
                        State = "Done",
                        ToPhoneNumber = To,
                        ImageURL = Image,
                        Link = Link
                    });
                    AccessDB.AccessChangesDB();
                }
                
                return RedirectToAction(nameof(Done));
            }
            catch (Exception)
            {
                messagesFuns.AddNewItem(new Models.Message()
                {
                    ClientId = SearchedClient.Id,
                    MessageContent = Message,
                    MessageTime = DateTime.Now,
                    State = "Failed",
                    ToPhoneNumber = To,
                    ImageURL = Image,
                    Link = Link
                });
                AccessDB.AccessChangesDB();
                return RedirectToAction(nameof(Failed));
            }

        }
       
        public IActionResult Done()
        {
            return View();
        }

        public IActionResult Failed()
        {
            return View();
        }
    }

}
