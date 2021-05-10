using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Models
{
    public class ProductModel
    {
        [DisplayName("Id number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public  string Name { get; set; }
        [DisplayName("Best price")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
