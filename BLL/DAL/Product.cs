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

        public decimal UnitPrice { get; set; }

        public int? StockAmount { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
