using MyApiApp.Interfaces;
using MyApiApp.Models;

namespace MyApiApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new();

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await Task.FromResult(_products);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
            return await Task.FromResult(product);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var existing = _products.FirstOrDefault(p => p.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
            }
            return await Task.FromResult(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}