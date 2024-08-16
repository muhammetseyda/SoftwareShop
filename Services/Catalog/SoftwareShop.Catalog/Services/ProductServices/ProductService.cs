using SoftwareShop.Catalog.Dtos.ProductDtos;
using SoftwareShop.Catalog.Entities;
using SoftwareShop.Catalog.Repositories;

namespace SoftwareShop.Catalog.Services.ProductServices
{
    public class ProductService:IProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task CreateProduct(CreateProductDto dto)
        {
            Product Product = new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                ListPrice = dto.ListPrice,
                SalePrice = dto.SalePrice,
                Url = dto.Url,
                UserId = dto.UserId,
            };
            await _repository.CreateAsync(Product);
        }

        public async Task DeleteProduct(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(value);

        }

        public async Task<List<ResultProductDto>> GetAllProducts()
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                CategoryId = x.CategoryId,
                Name = x.Name,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                ListPrice = x.ListPrice,
                SalePrice = x.SalePrice,
                Url = x.Url,
                UserId = x.UserId,
            }).ToList();
        }

        public async Task<GetByIdProductDto> GetByIdProduct(int id)
        {
            var value = await _repository.GetByIdAsync(id);
            return new GetByIdProductDto
            {
                ProductId = value.ProductId,
                CategoryId = value.CategoryId,
                Name = value.Name,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                ListPrice = value.ListPrice,
                SalePrice = value.SalePrice,
                Url = value.Url,
                UserId = value.UserId,
            };
        }

        public async Task UpdateProduct(UpdateProductDto dto)
        {
            var value = await _repository.GetByIdAsync(dto.ProductId);
            value.Description = dto.Description;
            value.ImageUrl = dto.ImageUrl;  
            value.ListPrice = dto.ListPrice;
            value.SalePrice = dto.SalePrice;
            dto.Url = dto.Url;
            dto.UserId = dto.UserId;
            dto.CategoryId = dto.CategoryId;
            dto.Name = dto.Name;

            await _repository.UpdateAsync(value);
        }
    }
}
