using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class DailyOffersController : Controller
    {
        public IActionResult DailyOffers()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();

            }
            else
            {
                return View();
            }
        }

    }
}