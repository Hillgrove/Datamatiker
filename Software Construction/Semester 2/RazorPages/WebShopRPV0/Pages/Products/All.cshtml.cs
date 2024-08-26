using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopRPV0.Models;
using WebShopRPV0.Services;

namespace WebShopRPV0.Pages.Products
{
    public class AllModel : PageModel
    {
        private IProductDataService _productDataService;
        public List<Product> Data { get; private set; }
        
        public AllModel(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public void OnGet()
        {
            Data = _productDataService.GetAll();
        }
    }
}
