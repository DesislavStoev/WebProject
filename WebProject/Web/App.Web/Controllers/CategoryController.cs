using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.DataServices;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IRecipeService _recipeService;

        public CategoryController(ICategoryService categoryService, IRecipeService recipeService)
        {
            _categoryService = categoryService;
            _recipeService = recipeService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategoryWithCount().ToList();
            return View(categories);
        }

        public IActionResult Details(int id)
        {
            var recipiesInCategory = _recipeService.GetAllRecipiesByCategory(id);

            return View(recipiesInCategory);
        }
    }
}