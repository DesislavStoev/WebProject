using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Nutrition : BaseModel<int>
    {
        public string ServiceSize { get; set; }

        public decimal Kcal { get; set; }

        public decimal Fat { get; set; }

        public decimal Saturates { get; set; }

        public decimal Carbs { get; set; }

        public decimal Sugars { get; set; }

        public decimal Fibre { get; set; }

        public decimal Protein { get; set; }

        public decimal Salt { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
