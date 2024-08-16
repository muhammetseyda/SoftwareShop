using SoftwareShop.Catalog.Dtos.CategoryDtos;

namespace SoftwareShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategorys();
        Task<GetByIdCategoryDto> GetByIdCategory(int id);
        Task CreateCategory(CreateCategoryDto dto);
        Task UpdateCategory(UpdateCategoryDto dto);
        Task DeleteCategory(int id);
    }
}
