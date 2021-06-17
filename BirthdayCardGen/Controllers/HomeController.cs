using BirthdayCardGen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BirthdayCardGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View(new GuestResponse());
        }
        [HttpPost]
        public IActionResult RsvpForm(Models.GuestResponse guestResponse)

        {
            if (ModelState.IsValid)
            {
                return View("NewCard", guestResponse);
            }
            else
            {
                return View(guestResponse);
            }
            //{
            //    return View("NewCard", guestResponse);
            //}
        }
    }
}
