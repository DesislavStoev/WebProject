using System.ComponentModel.DataAnnotations;

namespace App.Services.Models.Recipe
{
    public class IngredientVewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}
