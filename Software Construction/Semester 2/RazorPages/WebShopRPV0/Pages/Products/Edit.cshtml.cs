using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebShopRPV0.Services;
using WebShopRPV0.Models;

namespace WebShopRPV0.Pages.Products
{
    public class EditModel : PageModel
    {
        IProductDataService _productDataService;

        [BindProperty]
        public Product Data { get; set; }

        public EditModel(IProductDataService productDataService)
        {
            _productDataService = productDataService;
        }

        public virtual IActionResult OnGet(int id)
        {
            Product? data = _productDataService.Read(id);

            if (data == null)
            {
                return RedirectToPage("/Error");
            }

            Data = data;
            return Page();
        }

        public virtual IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productDataService.Update(Data.Id, Data);
            return RedirectToPage("All");
        }
    }
}
