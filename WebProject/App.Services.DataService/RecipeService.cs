using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.DataService
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public List<Recipe> TakeTenRandomRecipes()
        {
            var recipes = _repository.All().OrderBy(x => Guid.NewGuid()).Take(10).ToList();

            return recipes;
        }
    }
}
