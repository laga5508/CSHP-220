using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BDayCardGenerator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateCardForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCardForm(Models.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("HappyBirthday", guestResponse);
            }
            else
            {
                return View("Index");
            }
            
        }

    }
}