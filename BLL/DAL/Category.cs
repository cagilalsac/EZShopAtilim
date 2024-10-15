#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}