﻿namespace App.Models
{
    public class Directions:BaseModel<int>
    {
        public int Serves { get; set; }

        public int CookSkill { get; set; }  

        public string PrepTime { get; set; }

        public string CookTime { get; set; }

        public string Method { get; set; }
    }
}
