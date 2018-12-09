using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Ingredient : BaseModel<int>
    {
        public string Name { get; set; }

        public string Quantity { get; set; }

        public string Comment { get; set; }
    }
}
