using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProject.Models
{
    public class User:IdentityUser
    {
        public User()
        {
            Recipes = new HashSet<Recipe>();
        }

        public string FullName { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
