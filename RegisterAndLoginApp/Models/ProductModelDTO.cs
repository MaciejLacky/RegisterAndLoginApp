using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Models
{
    public class ProductModelDTO
    {
        [DisplayName("Id number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Best price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string PriceString { get; set; }
        public string Description { get; set; }

        public string ShortDescription { get; set; }
        public decimal Tax { get; set; }

        public ProductModelDTO(int id, string name, decimal price, string description )
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;

            PriceString = string.Format("{0:C}", price);
            ShortDescription = description.Length <= 10 ? description : description.Substring(0, 10);
            Tax = price * 0.08M;
        }
        //alternative format with model in ctor
        public ProductModelDTO(ProductModel p)
        {
            Id = p.Id;
            Name = p.Name;
            Price = p.Price;
            Description = p.Description;

            PriceString = string.Format("{0:C}", p.Price);
            ShortDescription = p.Description.Length <= 10 ? p.Description : p.Description.Substring(0, 10);
            Tax = p.Price * 0.08M;
        }
    }
}
