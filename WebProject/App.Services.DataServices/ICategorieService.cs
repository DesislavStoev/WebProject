using System;
using System.Collections.Generic;
using System.Text;

namespace App.Services.DataServices
{
    public interface ICategorieService
    {
        IEnumerable<CategoryIdAndViewModel> GetAllCategories();
    }
}
