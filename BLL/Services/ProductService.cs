using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    // Way 1:
    //public interface IProductService
    //{
    //    public IQueryable<ProductModel> Query();
    //    public Service Create(Product record);
    //    public Service Update(Product record);
    //    public Service Delete(int id);
    //}

    // Way 1:
    //public class ProductService : Service, IProductService
    // Way 2:
    public class ProductService : Service, IService<Product, ProductModel>
    {
        public ProductService(Db db) : base(db)
        {
        }

        public IQueryable<ProductModel> Query()
        {
            return _db.Products.Include(p => p.Category).Include(p => p.ProductStores).ThenInclude(ps => ps.Store)
                .OrderBy(p => p.StockAmount).ThenByDescending(p => p.ExpirationDate).ThenBy(p => p.Name).Select(p => new ProductModel() { Record = p });
        }

        public Service Create(Product record)
        {
            if (_db.Products.Any(p => p.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Product with the same name exists!");
            // Way 1:
            //if ((record.StockAmount ?? 0) < 0 || (record.StockAmount ?? 0) > 1000000)
            //    return Error("Stock amount must be between 0 and 1000000!");
            // Way 1:
            //if (record.UnitPrice <= 0)
            //    return Error("Unit price must be a positive number!");
            // Way 2: Validation can also be made using entity data annotations

            record.Name = record.Name?.Trim();
            _db.Products.Add(record);
            _db.SaveChanges();
            return Success("Product created successfully.");
        }

        public Service Update(Product record)
        {
            if (_db.Products.Any(p => p.Id != record.Id && p.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Product with the same name exists!");
            // Way 1:
            //if ((record.StockAmount ?? 0) < 0 || (record.StockAmount ?? 0) > 1000000)
            //    return Error("Stock amount must be between 0 and 1000000!");
            // Way 1:
            //if (record.UnitPrice <= 0)
            //    return Error("Unit price must be a positive number!");
            // Way 2: Validation can also be made using entity data annotations

            var entity = _db.Products.SingleOrDefault(p => p.Id == record.Id);
            if (entity is null)
                return Error("Product not found!");

            entity.Name = record.Name?.Trim();
            entity.UnitPrice = record.UnitPrice;
            entity.StockAmount = record.StockAmount;
            entity.ExpirationDate = record.ExpirationDate;
            entity.CategoryId = record.CategoryId;

            _db.Products.Update(entity);
            _db.SaveChanges();
            return Success("Product updated successfully.");
        }

        public Service Delete(int id)
        {
            var entity = _db.Products.SingleOrDefault(p => p.Id == id);
            if (entity is null)
                return Error("Product not found!");

            _db.Products.Remove(entity);
            _db.SaveChanges();
            return Success("Product deleted successfully.");
        }
    }
}
