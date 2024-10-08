#nullable disable

namespace BLL.DAL
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public int? StockAmount { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
