using System.ComponentModel.DataAnnotations;

namespace casecalismam2.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
    }
}
