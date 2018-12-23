using App.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.DataService
{
    public interface IRecipeService
    {
        List<Recipe> GetRandomRecipes(int count);
    }
}
