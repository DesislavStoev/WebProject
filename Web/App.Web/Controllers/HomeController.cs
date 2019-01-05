using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Web.Models;
using App.Services.DataServices;
using App.Services.Models.Home;

namespace App.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IRecipeService recipeService;

        public HomeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }
        public IActionResult Index()
        {
            var recipes = recipeService.GetRandomRecipes(12);
            IndexViewModel indexViewModel = new IndexViewModel { Recipes = recipes };
            return View(indexViewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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
    }
}
