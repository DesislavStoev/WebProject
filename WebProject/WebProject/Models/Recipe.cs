using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class Recipe
    {
        public Recipe()
        {
            //Users = new HashSet<User>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public string Author { get; set; }

        public CuisineStyle  CuisineStyle { get; set; }

        public CuisineType  CuisineType { get; set; }

       // public virtual ICollection<User> Users { get; set; }
    }
}
