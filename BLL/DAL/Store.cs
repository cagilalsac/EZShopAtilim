#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Store
    {
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Name { get; set; }

        public bool IsVirtual { get; set; }

        public List<ProductStore> ProductStores { get; set; } = new List<ProductStore>();
    }
}
