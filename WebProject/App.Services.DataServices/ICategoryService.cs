using App.Services.Models;
using App.Services.Models.Category;
using System.Collections.Generic;

namespace App.Services.DataServices
{
    public interface ICategoryService
    {
        IEnumerable<IdAndNameViewModel> GetAllCategories();

        bool IsCategoryIdValid(int categoryId);

        IEnumerable<CategoryViewModel> GetAllCategoryWithCount();
    }
}
