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

        public Category Category { get; set; }

        public Directions Directions { get; set; }

        public string Author { get; set; }

        public Nutrition Nutrition { get; set; }


    }
}
