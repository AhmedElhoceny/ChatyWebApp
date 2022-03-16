using Chaty.Models;
using Chaty.Repo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class AdminController : Controller
    {
        private readonly ClientRepo clientFuns;
        private readonly AdminMessageRepo adminMessageFuns;
        private readonly OfferRepo offerFuns;
        private readonly AdminRepo adminFuns;

        public AdminController(ClientRepo ClientFuns , AdminMessageRepo adminMessageFuns , OfferRepo OfferFuns , AdminRepo AdminFuns)
        {
            clientFuns = ClientFuns;
            this.adminMessageFuns = adminMessageFuns;
            offerFuns = OfferFuns;
            adminFuns = AdminFuns;
        }
        public IActionResult Index()
        {
            List<Clients> AllClients = clientFuns.GetAllData();
            return View(AllClients);
        }
        public IActionResult Index_Arabic()
        {
            List<Clients> AllClients = clientFuns.GetAllData();
            return View(AllClients);
        }
        public IActionResult ShowClientContacts()
        {
            return View(adminMessageFuns.GetAllData());
        }
        public IActionResult RemoveComment(int Id)
        {
            adminMessageFuns.DeleteItem(Id);
            return RedirectToAction(nameof(ShowClientContacts));
        }
        public IActionResult ActivateClient(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            SearchedClient.Activated = true;
            clientFuns.EditItem(SearchedClient, SearchedClient.Id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ShowProcessingRequest()
        {
            return View(offerFuns.GetAllProcessingRequests());
        }
        public IActionResult AcceptProcessingRequest(int Id)
        {
            var SearchedClient = clientFuns.SearchedById(Id);
            offerFuns.AcceptProcessingRequest(SearchedClient.Id);
            return RedirectToAction(nameof(ShowProcessingRequest));
        }
        public IActionResult RejectProcessingRequest(int Id)
        {
            var SearchedClient = clientFuns.SearchedById(Id);
            var SearchedRequest = offerFuns.SearchProcessingRequest(SearchedClient.Id);
            offerFuns.RejectProcessingRequest(SearchedClient.Id , SearchedRequest.Id);
            return RedirectToAction(nameof(ShowProcessingRequest));
        }
        public IActionResult DeactivateClient(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            SearchedClient.Activated = false;
            clientFuns.EditItem(SearchedClient, SearchedClient.Id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveClient(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            clientFuns.DeleteItem(SearchedClient.Id);
            AccessDB.AccessChangesDB();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ActivateClient_Arabic(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            SearchedClient.Activated = true;
            clientFuns.EditItem(SearchedClient, SearchedClient.Id);
            return RedirectToAction(nameof(Index_Arabic));
        }
        public IActionResult DeactivateClient_Arabic(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            SearchedClient.Activated = false;
            clientFuns.EditItem(SearchedClient, SearchedClient.Id);
            return RedirectToAction(nameof(Index_Arabic));
        }
        public IActionResult RemoveClient_Arabic(String Name)
        {
            Clients SearchedClient = clientFuns.SearchedByClientName(Name);
            clientFuns.DeleteItem(SearchedClient.Id);
            AccessDB.AccessChangesDB();
            return RedirectToAction(nameof(Index_Arabic));
        }
        public IActionResult AddNewOffer()
        {
            return View();
        }
        public IActionResult AddNewOfferPost(string OfferTitle, int MessagesNumber, int daysNumber, double Money)
        {
            offerFuns.AddNewItem(new Offer()
            {
                daysNumber = daysNumber,
                MessagesNumber = MessagesNumber,
                Money = Money,
                OfferTitle = OfferTitle
            });
            AccessDB.AccessChangesDB();
            return RedirectToAction(nameof(ShowOffers));
        }
        public IActionResult ShowOffers()
        {
            var Offers = offerFuns.GetAllData();
            return View(Offers);
        }
        public IActionResult DeleteOffer(int Id)
        {
            offerFuns.DeleteItem(Id);
            return RedirectToAction(nameof(ShowOffers));
        }
        public IActionResult AdminData()
        {
            var AdminData = adminFuns.GetAdminData();
            return View(AdminData);
        }
        public IActionResult UpdateAdminData(string AdminUserName , string PassWord , string PayPalClientId)
        {
            adminFuns.EditItem(new AdminData()
            {
                PassWord = PassWord,
                UserName = AdminUserName,
                PayPalClientId = PayPalClientId
            }, 1);
            return RedirectToAction(nameof(Index));
        }
    }
}
