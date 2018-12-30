using App.Services.Models;
using System.Collections.Generic;

namespace App.Services.DataServices
{
    public interface ICategoryService
    {
        IEnumerable<IdAndNameViewModel> GetAllCategories();

        bool IsCategoryIdValid(int categoryId);
    }
}
