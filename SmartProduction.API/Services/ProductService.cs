using SmartProduction.API.DTOs;
using SmartProduction.API.Entities;
using SmartProduction.API.Interfaces;

namespace SmartProduction.API.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
         public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(p => new ProductResponseDto
            {
               Id = p.Id,
               Name = p.Name,
                SKU = p.SKU,
                Description = p.Description,
                CreatedDate = p.CreatedDate
            });
        }
        public async Task<ProductResponseDto> CreateProductAsync(ProductCreateDto dto) {
            var entity = new Product
            {
                Name = dto.Name,
                SKU = dto.SKU,
                Description = dto.Description,
            };
            var createdProduct = await _repository.CreateAsync(entity);
            return new ProductResponseDto
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                SKU = createdProduct.SKU,
                Description = createdProduct.Description,
                CreatedDate = createdProduct.CreatedDate
            };
        }
    }
}
