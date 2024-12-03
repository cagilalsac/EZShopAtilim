#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        // Way 2:
        [Range(0.01, double.MaxValue, ErrorMessage = "Unit price must be a positive number!")]
        public decimal UnitPrice { get; set; }

        // Way 2:
        [Range(0, 1000000, ErrorMessage = "Stock amount must be between {1} and {2}!")]
        public int? StockAmount { get; set; } // {0} : property name or display name

        public DateTime? ExpirationDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();
    }
}
