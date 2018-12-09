using App.Models.Enums;
using System;

namespace App.Models
{
    public class Directions:BaseModel<int>
    {
        public int Serves { get; set; }

        public CookSkill MyProperty { get; set; }

        public DateTime PrepTime { get; set; }

        public DateTime CookTime { get; set; }

        public string Method { get; set; }
    }
}
