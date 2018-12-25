using App.Services.Models.Recipe;
using App.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
    public class RecipeController : BaseController
    {
        [Authorize]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeInputModel input)
        {

            return RedirectToAction("View", new { id = 0 });
        }

        public IActionResult Details(int id)
        {
            return this.View();
        }
    }
}   
