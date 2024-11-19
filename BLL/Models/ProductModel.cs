#nullable disable

using BLL.DAL;
using System.ComponentModel;

namespace BLL.Models
{
    public class ProductModel
    {
        public Product Record { get; set; }

        public string Name => Record.Name;

        [DisplayName("Unit Price")]
        public string UnitPrice => Record.UnitPrice.ToString("C2");

        [DisplayName("Stock Amount")]
        // Way 1:
        //public int StockAmount => Record.StockAmount.HasValue ? Record.StockAmount.Value : 0;
        // Way 2:
        public int StockAmount => Record.StockAmount ?? 0;

        // Way 1:
        //public string ExpirationDate 
        //{ 
        //    get
        //    {
        //        string expirationDate = null;
        //        // Way 1:
        //        //if (Record.ExpirationDate is not null)
        //        // Way 2:
        //        if (Record.ExpirationDate.HasValue)
        //            expirationDate = Record.ExpirationDate.Value.ToString("MM/dd/yyyy");
        //        return expirationDate;
        //    }
        //}
        // Way 2:
        [DisplayName("Expiration Date")]
        public string ExpirationDate => Record.ExpirationDate.HasValue ? Record.ExpirationDate.Value.ToString("MM/dd/yyyy") : string.Empty;

        public string Category => Record.Category?.Name;
    }
}
