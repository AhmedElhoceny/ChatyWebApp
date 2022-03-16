using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chaty.Controllers
{
    public class APIsDocumentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SendLink()
        {
            return View();
        }
        public IActionResult SendImage()
        {
            return View();
        }
        public IActionResult SendFile()
        {
            return View();
        }
        public IActionResult BuildChatBot()
        {
            return View();
        }
    }
}
