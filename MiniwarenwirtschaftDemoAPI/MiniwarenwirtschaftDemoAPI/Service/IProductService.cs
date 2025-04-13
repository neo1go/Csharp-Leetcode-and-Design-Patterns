
using MiniwarenwirtschaftDemoAPI.Model;
using MiniwarenwirtschaftDemoAPI.DTO;
using Swashbuckle.AspNetCore.Swagger;



namespace MiniwarenwirtschaftDemoAPI.Service
{
    // --- Service ---

    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(ProductDto dto);
        Task UpdateAsync(int id, ProductDto dto);
        Task DeleteAsync(int id);
    }
}
