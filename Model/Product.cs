using System.ComponentModel.DataAnnotations;

namespace DemoAPI.Model
{
    public class Product
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        public string? Name { get; set; }

        public ProductData? Data { get; set; }
    }
}
