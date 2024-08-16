using SoftwareShop.Catalog.Dtos.CategoryDtos;
using SoftwareShop.Catalog.Entities;
using SoftwareShop.Catalog.Repositories;

namespace SoftwareShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task CreateCategory(CreateCategoryDto dto)
        {
            Category Category = new Category
            {
               CategoryName = dto.CategoryName,
            };
            await _repository.CreateAsync(Category);
        }

        public async Task DeleteCategory(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);

        }

        public async Task<List<ResultCategoryDto>> GetAllCategorys()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new ResultCategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();
        }

        public async Task<GetByIdCategoryDto> GetByIdCategory(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdCategoryDto
            {
                CategoryId = value.CategoryId,
                CategoryName = value.CategoryName,
            };
        }

        public async Task UpdateCategory(UpdateCategoryDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.CategoryId);
            value.CategoryName = dto.CategoryName;
            await _repository.UpdateAsync(value);
        }
    }
}
