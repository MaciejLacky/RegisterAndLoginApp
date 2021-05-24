using Bogus;
using Microsoft.AspNetCore.Mvc;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ProductControllerAPI : ControllerBase
    {

        [HttpPut("ProcessEdit")]
        public ActionResult <ProductModel> ProcessEdit(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            products.Update(product);
            return products.GetProductById(product.Id);
        }
        [HttpGet]
        public ActionResult <IEnumerable<ProductModel>> Index()
        {
            ProductsDAO products = new ProductsDAO();

            return products.GetAllProduct();
        }
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return  productList;
        }
        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult <ProductModel> ShowOneProduct(int id)
        {
            ProductsDAO products = new ProductsDAO();
            return products.GetProductById(id);
        }
        [HttpPost("insertOne")]
        public ActionResult <int> ProcessInsert(ProductModel product)
        {
            ProductsDAO products = new ProductsDAO();
            int newId = products.Insert(product);
            return  newId;
        }
        [HttpDelete("DeleteOne/{Id}")]
        public ActionResult <int> DeleteOne(int Id)
        {
            ProductsDAO products = new ProductsDAO();
            ProductModel product = products.GetProductById(Id);
            int success = products.Delete(product);
            return success;
        }


    }
}
