using App.Data;
using App.Models;
using App.Services.Models.Home;
using App.Services.Models.Recipe;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.DataServices
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<Recipe> _repositoryRecipe;
        private readonly IRepository<Category> _repositoryCategory;
        private readonly IRepository<Directions> _repositoryDirections;
        private readonly IRepository<Ingredient> _repositoryIngredient;
        private readonly IRepository<Nutrition> _repositoryNutrition;

        public RecipeService(IRepository<Recipe> repositoryRecipe, 
                             IRepository<Category> repositoryCategory, 
                             IRepository<Directions> repositoryDirections, 
                             IRepository<Ingredient> repositoryIngredient,
                             IRepository<Nutrition> repositoryNutrition)
        {
            _repositoryRecipe = repositoryRecipe;
            _repositoryCategory = repositoryCategory;
            _repositoryDirections = repositoryDirections;
            _repositoryIngredient = repositoryIngredient;
            _repositoryNutrition = repositoryNutrition;
        }

        public List<IndexRecipeViewModel> GetRandomRecipes(int count)
        {
            var recipes = _repositoryRecipe
                .All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .Select(x => new IndexRecipeViewModel { Name = x.Name, Url = x.SmallPictureUrl })
                .ToList();

            return recipes;
        }

        public bool IsCategoryExist(int categoryId)
        {
            return _repositoryCategory.All().Any(c => c.Id == categoryId);
        }

        public async Task<int> Create(CreateRecipeInputModel input, IFormCollection fc)
        {
            var names = fc["ingredientName"].ToList();
            var quantities = fc["ingredientQuantity"].ToList();
            var ingredients = new List<Ingredient>();

            for (int i = 0; i < names.Count(); i++)
            {
                var ingredient = new Ingredient
                {
                    Name = names[i],
                    Quantity = quantities[i]
                };
                ingredients.Add(ingredient);
            }

            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                Category = new Category
                {
                    Name = _repositoryCategory.All().FirstOrDefault(c => c.Id == input.CategoryId).Name
                },
                Author = input.Author,
                SmallPictureUrl = input.ImageUrl,
                MenuType = input.MenuType,
                Name = input.Name,
                Ingredients = ingredients,
                Directions = new Directions
                {
                    Method = input.Method,
                    CookSkill = input.CookSkill,
                    Serves = input.Serves,
                    CookTime = input.CookTime,
                    PrepTime = input.PrepTime,
                },
                Nutrition = new Nutrition
                {
                    Carbs = input.Carbs,
                    Fat = input.Fat,
                    Fibre = input.Fibre,
                    Kcal = input.Kcal,
                    Protein = input.Protein,
                    Salt = input.Salt,
                    Saturates = input.Saturates,
                    ServiceSize = input.ServiceSize,
                    Sugars = input.Sugars
                },
            };

            await _repositoryRecipe.AddAsync(recipe);
            await _repositoryRecipe.SafeChangesAsync();

            return recipe.Id;
        }

        public DetailsRecipeViewModel GetRecipeById(int id)
        {
            var recipe = _repositoryRecipe.All().FirstOrDefault(r => r.Id == id);
            var category = _repositoryCategory.All().FirstOrDefault(c => c.Id == recipe.CategoryId);
            var directions = _repositoryDirections.All().FirstOrDefault(d => d.Id == recipe.DirectionsId);
            var ingredients = _repositoryIngredient.All().Where(i => i.Recipe.Id == id);
            var nutrition = _repositoryNutrition.All().Where(n => n.Recipe.Id == id);

            DetailsRecipeViewModel details = new DetailsRecipeViewModel();

            if (recipe != null)
            {
                details.Author = recipe.Author;
                details.CategoryName = category.Name;
                details.Directions = recipe.Directions;
                details.Ingredients = recipe.Ingredients;
                details.MenuType = recipe.MenuType;
                details.Name = recipe.Name;
                details.Nutrition = recipe.Nutrition;
                details.SmallPictureUrl = recipe.SmallPictureUrl;
            }

            return details;
        }
    }
}
