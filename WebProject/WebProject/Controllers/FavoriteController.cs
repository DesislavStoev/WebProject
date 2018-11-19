using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Favorite()
        {
            return View();
        }
    }
}