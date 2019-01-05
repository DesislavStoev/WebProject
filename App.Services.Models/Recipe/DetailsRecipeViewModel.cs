using App.Models;
using System.Collections.Generic;

namespace App.Services.Models.Recipe
{
    public class DetailsRecipeViewModel
    {
        public int RecipeId { get; set; }

        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public string CategoryName { get; set; }

        public virtual Directions Directions { get; set; }
        
        public string Author { get; set; }

        public virtual Nutrition Nutrition { get; set; }
        
        public string SmallPictureUrl { get; set; }

        public ICollection<App.Models.Comment> Comments { get; set; }
    }
}
