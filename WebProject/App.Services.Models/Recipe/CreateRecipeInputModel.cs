using App.Models;
using App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.Models.Recipe
{
    public class CreateRecipeInputModel
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }

        public string Author { get; set; }

        public int Serves { get; set; }

        public CookSkill CookSkill { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string Method { get; set; }

        public MenuType MenuType { get; set; }

        public string ServiceSize { get; set; }

        public decimal Kcal { get; set; }

        public decimal Fat { get; set; }

        public decimal Saturates { get; set; }

        public decimal Carbs { get; set; }

        public decimal Sugars { get; set; }

        public decimal Fibre { get; set; }

        public decimal Protein { get; set; }

        public decimal Salt { get; set; }
    }
}
