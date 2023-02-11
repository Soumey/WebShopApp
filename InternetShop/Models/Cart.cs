using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShop.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int Count { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
      

    }
}
