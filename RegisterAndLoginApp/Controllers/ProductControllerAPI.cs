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
        //dto model
        [HttpGet]
        public ActionResult <IEnumerable<ProductModelDTO>> Index()
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productsList = products.GetAllProduct();
            List<ProductModelDTO> productModelDTOs = new List<ProductModelDTO>();
            foreach (var item in productsList)
            {
                productModelDTOs.Add(new ProductModelDTO(item));
            }
            return productModelDTOs;
        }
        [HttpGet("searchproducts/{searchTerm}")]
        public ActionResult <IEnumerable<ProductModel>> SearchResults(string searchTerm)
        {
            ProductsDAO products = new ProductsDAO();
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return  productList;
        }
        //dto model
        [HttpGet("ShowOneProduct/{Id}")]
        public ActionResult <ProductModelDTO> ShowOneProduct(int id)
        {
           
            ProductsDAO products = new ProductsDAO();
            ProductModelDTO pdto = new ProductModelDTO(products.GetProductById(id));
            return pdto ;
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
