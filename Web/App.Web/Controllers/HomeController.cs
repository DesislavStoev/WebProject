using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.Data;
using App.Models;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Recipe> _recipeRepository;

        public HomeController(IRepository<Recipe> recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }
        public IActionResult Index()
        {
           ViewData["Message"] ="Count: " + _recipeRepository.All().Count();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
