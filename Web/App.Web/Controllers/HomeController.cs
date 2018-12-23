using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.Data;
using App.Models;
using App.Web.Models.Home;
using App.Web.Services;

namespace App.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly RecipeService recipeService;

        public HomeController(RecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult Index()
        {
            var recipes = recipeService.TakeTenRandomRecipes().Select(x => new IndexRecipeViewModel { Name = x.Name, Url = x.SmallPictureUrl });
            IndexViewModel indexViewModel = new IndexViewModel { Recipes = recipes };
            return View(indexViewModel);
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
