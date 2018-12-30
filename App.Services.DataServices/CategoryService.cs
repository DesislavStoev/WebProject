using App.Data;
using App.Models;
using App.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace App.Services.DataServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }


        public IEnumerable<IdAndNameViewModel> GetAllCategories()
        {
            var categories = _repository.All().OrderBy(x => x.Name).Select(x => new IdAndNameViewModel { Id = x.Id, Name = x.Name}).ToList();

            return categories;
        }

        public bool IsCategoryIdValid(int categoryId)
        {
            return _repository.All().Any(x => x.Id == categoryId);
        }
    }
}
