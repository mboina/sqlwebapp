using sqlwebapp.Models;

namespace sqlwebapp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}