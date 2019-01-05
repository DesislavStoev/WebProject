using App.Services.DataServices;
using App.Services.Models.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace App.Web.Controllers
{

    public class CommentController : Controller
    {
        private readonly IRecipeService _recipeService;

        public CommentController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["recipeId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCommentViewModel createComment)
        {
            ViewData["recipeId"] = createComment.RecipeId;
            if (!ModelState.IsValid)
            {
                return View(createComment);
            }

            _recipeService.AddComment(createComment);

            return RedirectToAction("Details", "Recipe", new { id = createComment.RecipeId });
        }
    }
}