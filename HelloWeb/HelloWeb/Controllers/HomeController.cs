using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(Models.GuestResponse guestResponse)
        {
            return View("Thanks", guestResponse);
        }
    }
}