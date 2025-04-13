
using MiniwarenwirtschaftDemoAPI.Repository;
using MiniwarenwirtschaftDemoAPI.Model;
using MiniwarenwirtschaftDemoAPI.DTO;
using Swashbuckle.AspNetCore.Swagger;

namespace MiniwarenwirtschaftDemoAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;
        public ProductService(IProductRepository repo) => _repo = repo;

        public async Task<List<Product>> GetAllAsync() => await _repo.GetAllAsync();

        public async Task<Product> GetByIdAsync(int id) => await _repo.GetByIdAsync(id);

        public async Task AddAsync(ProductDto dto)
        {
            var product = new Product { Name = dto.Name, Price = dto.Price, Stock = dto.Stock };
            await _repo.AddAsync(product);
        }

        public async Task UpdateAsync(int id, ProductDto dto)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) throw new Exception("Produkt nicht gefunden");

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await _repo.UpdateAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product != null)
                await _repo.DeleteAsync(product);
        }
    }
}
