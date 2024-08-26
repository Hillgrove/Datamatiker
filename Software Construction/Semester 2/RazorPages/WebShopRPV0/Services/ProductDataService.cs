using WebShopRPV0.Models;

namespace WebShopRPV0.Services
{
    public class ProductDataService : IProductDataService
    {
        private Dictionary<int, Product> _products;

        public ProductDataService()
        {
            _products = new Dictionary<int, Product>();

            Create(new Product("PC", 6999));
            Create(new Product("Monitor", 2299));
            Create(new Product("Mouse", 449));
            Create(new Product("Keyboard", 599));
        }

        public int Create(Product product)
        {
            product.Id = NextId();
            _products[product.Id] = product;

            return product.Id;
        }

        public List<Product> GetAll()
        {
            return _products.Values.ToList();
        }

        private int NextId() => _products.Keys.DefaultIfEmpty(0).Max() + 1;
    }
}
