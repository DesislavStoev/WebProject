using App.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Recipe : BaseModel<int>
    {
        public string Name { get; set; }

        public MenuType MenuType { get; set; }

        public virtual List<Ingredient> Ingredients { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int DirectionsId { get; set; }

        public virtual Directions Directions { get; set; }

        public string Author { get; set; }

        public int NutritionId { get; set; }

        public virtual Nutrition Nutrition { get; set; }


    }
}
