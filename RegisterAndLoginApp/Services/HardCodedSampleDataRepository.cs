using Bogus;
using RegisterAndLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Services
{
    public class HardCodedSampleDataRepository : IProductDataService
    {
        static List<ProductModel> productList = new List<ProductModel>();

        public int Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> GetAllProduct()
        {
            if (productList.Count == 0)
            {
                productList.Add(new ProductModel { Id = 1, Name = "Mouse Pad", Price = 5.99m, Description = "A square plastic" });
                productList.Add(new ProductModel { Id = 2, Name = "Mouse Keybord", Price = 5.99m, Description = "A square plastic" });
                productList.Add(new ProductModel { Id = 3, Name = "Mouse Pading", Price = 5.99m, Description = "A square plastic" });
                productList.Add(new ProductModel { Id = 4, Name = "Mouse", Price = 5.99m, Description = "A square plastic" });

                for (int i = 0; i < 100; i++)
                {
                    productList.Add(new Faker<ProductModel>().RuleFor(p => p.Id, i + 5)
                        .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                        .RuleFor(p => p.Price, f => f.Random.Decimal(100))
                        .RuleFor(p => p.Description, f => f.Rant.Review())

                        );
                }
            }
            

            return productList;
        }

        public ProductModel GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public int Insert(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public List<ProductModel> SearchProducts(string x)
        {
            throw new NotImplementedException();
        }

        public int Update(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
