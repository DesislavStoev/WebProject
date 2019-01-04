using App.Services.Models.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Web.Controllers
{
    
    public class CommentController : Controller
    {
        [Authorize]
        public IActionResult Create(int id)
        {
            ViewData["recipeId"] = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCommentViewModel createComment)
        {
            if (!ModelState.IsValid)
            {
                return View(createComment);
            } 

            //TODO Add to database 

            return RedirectToAction("Details", "Recipe", new { id = createComment.RecipeId });
        }
    }
}