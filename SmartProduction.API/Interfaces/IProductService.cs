using SmartProduction.API.DTOs;

namespace SmartProduction.API.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync();
        Task<ProductResponseDto> CreateProductAsync(ProductCreateDto dto);
    }
}
