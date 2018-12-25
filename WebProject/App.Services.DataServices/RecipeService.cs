using App.Data;
using App.Models;
using App.Services.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Services.DataServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repository;

        public RecipeService(IRepository<Recipe> repository)
        {
            _repository = repository;
        }

        public List<IndexRecipeViewModel> GetRandomRecipes(int count)
        {
            var recipes = _repository
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .Select(x => new IndexRecipeViewModel { Name = x.Name, Url = x.SmallPictureUrl })
                .ToList();

            return recipes;
        }
    }
}
