using System.Collections.Generic;

namespace App.Services.Models.Home
{
    public class IndexViewModel
    {
        public IEnumerable<IndexRecipeViewModel> Recipes { get; set; }
    }
}
