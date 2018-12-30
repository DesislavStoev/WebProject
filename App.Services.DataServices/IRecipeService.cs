using App.Services.Models.Home;
using App.Services.Models.Recipe;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.DataServices
{
    public interface IRecipeService
    {
        List<IndexRecipeViewModel> GetRandomRecipes(int count);

        Task<int> Create(CreateRecipeInputModel input, IFormCollection fc);

        DetailsRecipeViewModel GetRecipeById(int id);

        bool IsCategoryExist(int categoryId);
    }
}
