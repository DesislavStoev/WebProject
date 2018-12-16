using App.Models.Enums;
using System;

namespace App.Models
{
    public class Directions:BaseModel<int>
    {
        public int Serves { get; set; }

        public CookSkill MyProperty { get; set; }

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string Method { get; set; }
    }
}
