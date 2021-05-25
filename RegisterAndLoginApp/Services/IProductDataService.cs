using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public interface IProductDataService
    {
        List<ProductModel> GetAllProduct();
        List<ProductModel> SearchProducts(string searchTerm);
        ProductModel GetProductById(int Id);
        int Insert(ProductModel product);
        int Delete(ProductModel product);
        int Update(ProductModel product);


    }
}
