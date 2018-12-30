using App.Models;
using App.Models.Enums;
using System.Collections.Generic;

namespace App.Services.Models.Recipe
{
    public class DetailsRecipeViewModel
    {
        public string Name { get; set; }

        public MenuType MenuType { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

        public string CategoryName { get; set; }

        public virtual Directions Directions { get; set; }

        //public int Serves { get; set; }

        //public CookSkill CookSkill { get; set; }

        //public string PrepTime { get; set; }

        //public string CookTime { get; set; }

        //public string Method { get; set; }

        public string Author { get; set; }

        public virtual Nutrition Nutrition { get; set; }


        //public string ServiceSize { get; set; }

        //public decimal Kcal { get; set; }

        //public decimal Fat { get; set; }

        //public decimal Saturates { get; set; }

        //public decimal Carbs { get; set; }

        //public decimal Sugars { get; set; }

        //public decimal Fibre { get; set; }

        //public decimal Protein { get; set; }

        //public decimal Salt { get; set; }

        public string SmallPictureUrl { get; set; }
    }
}
