using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Nutrition : BaseModel<int>
    {
        public int Kcal { get; set; }

        public int Fat { get; set; }

        public int Saturates { get; set; }

        public int Carbs { get; set; }

        public int Sugars { get; set; }

        public int Fibre { get; set; }

        public int Protein { get; set; }

        public int Salt { get; set; }
    }
}
