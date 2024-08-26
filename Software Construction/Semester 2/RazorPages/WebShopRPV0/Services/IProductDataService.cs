using WebShopRPV0.Models;

namespace WebShopRPV0.Services
{
    public interface IProductDataService
    {
        int Create(Product product);
        List<Product> GetAll();
        Product? Read(int id);
        bool Delete(int id);
    }
}
