using Chaty.Models;
using Chaty.Repo;
using Chaty.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClientRepo clientFuns;
        private readonly MessageRepo messageFuns;
        private readonly OfferRepo offerFuns;
        private readonly AdminMessageRepo adminMessageFuns;
        private readonly AdminRepo adminDataFuns;

        public HomeController(ClientRepo ClientFuns , MessageRepo MessageFuns , OfferRepo OfferFuns , AdminMessageRepo AdminMessageFuns , AdminRepo AdminDataFuns)
        {
            clientFuns = ClientFuns;
            messageFuns = MessageFuns;
            offerFuns = OfferFuns;
            adminMessageFuns = AdminMessageFuns;
            adminDataFuns = AdminDataFuns;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Arabic()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult About_Us()
        {
            return View();
        }
        public IActionResult About_Us_Arabic()
        {
            return View();
        }
        public IActionResult AddAdminMessage(string Name , string Email , string Phone , string Message)
        {
            try
            {
                adminMessageFuns.AddNewItem(new AdminMessage()
                {
                    Email = Email,
                    Message = Message,
                    Name = Name,
                    Phone = Phone
                });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        public IActionResult LogIn()
        {
            var AdminData = adminDataFuns.GetAllData();
            if (AdminData.Count == 0)
            {
                adminDataFuns.AddNewItem(new AdminData()
                {
                    UserName = "Admin",
                    PassWord = "Admin",
                    PayPalClientId = ""
                });
            }
            return View();
        }
        public IActionResult LogIn_Arabic()
        {
            return View();
        }
        public IActionResult SignUp_Arabic()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public string LogInPost(string UserName, string PassWord)
        {
            var AdminData = adminDataFuns.GetAdminData();
            if (UserName == AdminData.UserName && PassWord == AdminData.PassWord)
            {
                return "Admin";
            }
            var Response = clientFuns.IsClientExist(UserName, PassWord);
            return Response.Name;
        }
        [HttpPost]
        public string SignUpPost(string UserName , string Email , string PassWord , string ConfirmPassWord , string Mobile)
        {
                var ClientExistCheck = clientFuns.IsClientExist(UserName, PassWord);
                if (PassWord == ConfirmPassWord && ClientExistCheck.Name == "No_One" && UserName != null && Email != null && Mobile != null)
                {
                    var NewClient = new Clients()
                    {
                        Email = Email,
                        Imgae = "None",
                        Name = UserName,
                        PassWord = PassWord,
                        PhoneNumber = Mobile,
                        UserCode = RandomCodeGenerator.RandomString(8),
                        Activated = false
                    };
                    clientFuns.AddNewItem(NewClient);
                    AccessDB.AccessChangesDB();
                return "Done";
                }
                else
                {
                    return "Failed";
                }
        }
    }
}
