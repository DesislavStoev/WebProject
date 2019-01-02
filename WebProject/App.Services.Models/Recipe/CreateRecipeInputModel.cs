using App.Models;
using App.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace App.Services.Models.Recipe
{
    public class CreateRecipeInputModel
    {
        [Required]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public IngredientVewModel Ingredient { get; set; }

        public string Author { get; set; }

        [Range(1, 10)]
        public int Serves { get; set; }

        public CookSkill CookSkill { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        [Required]
        public string Method { get; set; }

        public MenuType MenuType { get; set; }

        [Range(1, 1000)]
        public string ServiceSize { get; set; }

        [Range(1, 10000)]
        public decimal Kcal { get; set; }

        [Range(0.01, 10000.00)]
        public decimal Fat { get; set; }

        [Range(0.01, 10000)]
        public decimal Saturates { get; set; }

        [Range(0.01, 10000)]
        public decimal Carbs { get; set; }

        [Range(0.01, 10000)]
        public decimal Sugars { get; set; }

        [Range(0.01, 10000)]
        public decimal Fibre { get; set; }

        [Range(0.01, 10000)]
        public decimal Protein { get; set; }

        [Range(0.01, 10000)]
        public decimal Salt { get; set; }
    }

}
