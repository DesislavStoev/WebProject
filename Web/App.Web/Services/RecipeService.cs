using App.Data;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Web.Services
{
    public class RecipeService :IAppService
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
