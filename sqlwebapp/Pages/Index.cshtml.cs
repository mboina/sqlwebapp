using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlwebapp.Services;
using sqlwebapp.Models;

namespace sqlwebapp.Pages
{
    public class IndexModel : PageModel
    {

        public List<Product> Products;

        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {
            Products = _productService.GetProducts();
        }
    }
}