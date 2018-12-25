using App.Services.Models.Home;
using System.Collections.Generic;

namespace App.Services.DataServices
{
    public interface IRecipeService
    {
        List<IndexRecipeViewModel> GetRandomRecipes(int count);
    }
}
