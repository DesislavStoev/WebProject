using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Category : BaseModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
