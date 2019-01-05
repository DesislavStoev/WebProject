using App.Services.DataServices;
using App.Services.Models.Recipe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Controllers
{
    public class RecipeController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly ICategoryService _categorieService;

        public RecipeController(IRecipeService recipeService, ICategoryService categorieService)
        {
            _recipeService = recipeService;
            _categorieService = categorieService;
        }

        [Authorize]
        public IActionResult Create()
        {
            ViewData["Categories"] = _categorieService
                .GetAllCategories()
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input, IFormCollection fc)
        {
            if (!ModelState.IsValid || !_categorieService.IsCategoryIdValid(input.CategoryId))
            {
                return View(input);
            }
            
            var id = await _recipeService.Create(input, fc);
            return RedirectToAction("Details", new { id });
        }

        public IActionResult Details(int id)
        {
           var recipe = _recipeService.GetRecipeById(id);
            return this.View(recipe);
        }
    }
}
