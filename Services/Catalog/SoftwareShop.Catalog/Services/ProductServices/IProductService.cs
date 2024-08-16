using SoftwareShop.Catalog.Dtos.ProductDtos;

namespace SoftwareShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProducts();
        Task<GetByIdProductDto> GetByIdProduct(int id);
        Task CreateProduct(CreateProductDto dto);
        Task UpdateProduct(UpdateProductDto dto);
        Task DeleteProduct(int id);
    }
}
