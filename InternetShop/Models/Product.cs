using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace InternetShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }

    }
}
