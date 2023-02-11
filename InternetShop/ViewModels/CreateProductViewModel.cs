namespace InternetShop.ViewModels
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public IFormFile ProductImage { get; set; }
        public int ProductCount { get; set; }
        public int ProductPrice { get; set; }
    }
}
