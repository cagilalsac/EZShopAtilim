#nullable disable

using System.ComponentModel.DataAnnotations;

namespace BLL.DAL
{
    public class Role
    {
        public int Id { get; set; }

        [Required, StringLength(5)]
        public string Name { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
