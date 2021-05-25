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
    public class ProductController : Controller
    {
        //ProductsDAO products;
        //HardCodedSampleDataRepository products;
        public IProductDataService products { get; set; }
        public ProductController(IProductDataService data)
        {
            //products = new ProductsDAO();
            //products = new HardCodedSampleDataRepository();
            products = data;
        }
        public IActionResult ShowDetails(int id)
        {
           
            ProductModel foundProduct = products.GetProductById(id);
            return View(foundProduct);
        }
        public IActionResult ShowOneProductJSON(int id)
        {
            
            return Json(products.GetProductById(id));
        }
        public IActionResult Edit(int id)
        {
            
            ProductModel foundProduct = products.GetProductById(id);
            return View("Edit",foundProduct);
        }

        public IActionResult ProcessEdit(ProductModel product)
        {
           
            products.Update(product);
            return View("Index", products.GetAllProduct());
        }
        public IActionResult ProcessEditReturnPartial(ProductModel product)
        {
           
            products.Update(product);
            return PartialView("_productView", product);
        }
        [CustomAuthorization]
        public IActionResult Index()
        {
           

            return View(products.GetAllProduct());
        }
       
        public IActionResult SearchResults(string searchTerm)
        {
           
            List<ProductModel> productList = products.SearchProducts(searchTerm);
            return View("index", productList);
        }
        [CustomAuthorization]
        public IActionResult SearchForm()
        {
            return View();
        }
        public IActionResult Delete(int Id)
        {
           
            ProductModel product = products.GetProductById(Id);
            products.Delete(product);
            return View("Index", products.GetAllProduct());
        }
        public IActionResult Create()
        {
            return View("Insert");
        }
        public IActionResult ProcessInsert(ProductModel product)
        {
           
            products.Insert(product);
            return View("Index", products.GetAllProduct());
        }
    }
}
