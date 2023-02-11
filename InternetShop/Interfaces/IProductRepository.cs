using InternetShop.Models;

namespace InternetShop.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetByIdAsync(int id);
        Task<Product> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Product>> GetProductByName(string name);

        bool Add(Product product);
        bool Update(Product product);   
        bool Delete(Product product);
        bool Save();
    }
}
