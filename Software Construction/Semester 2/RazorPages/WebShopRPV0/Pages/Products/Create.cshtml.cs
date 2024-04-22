using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopRPV0.Services;
using WebShopRPV0.Models;

namespace WebShopRPV0.Pages.Products
{
    public class CreateModel : PageModel
    {
        private IProductDataService _productDataService;

        [BindProperty]
        public Product Data { get; set; }

        public CreateModel(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public IActionResult OnPost()
        {
            // Check if input is valid
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Send data to dataservice
            _productDataService.Create(Data);

            return RedirectToPage("All");
        }
    }
}
