using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class StoreService : Service, IService<Store, StoreModel>
    {
        public StoreService(Db db) : base(db)
        {
        }

        public Service Create(Store record)
        {
            if (_db.Stores.Any(s => s.Name.ToUpper() == record.Name.ToUpper().Trim() && s.IsVirtual == record.IsVirtual))
                return Error($"{(record.IsVirtual ? "Virtual " : "")}Store with the same name exists!");
            record.Name = record.Name?.Trim();
            _db.Stores.Add(record);
            _db.SaveChanges();
            return Success("Store is created successfully.");
        }

        public Service Delete(int id)
        {
            var entity = _db.Stores.Include(s => s.ProductStores).SingleOrDefault(s => s.Id == id);
            if (entity is null)
                return Error("Store not found!");
            _db.ProductStores.RemoveRange(entity.ProductStores);
            _db.Stores.Remove(entity);
            _db.SaveChanges();
            return Success("Store is deleted successfully.");
        }

        public IQueryable<StoreModel> Query()
        {
            return _db.Stores.OrderByDescending(s => s.IsVirtual).ThenBy(s => s.Name).Select(s => new StoreModel() { Record = s });
        }

        public Service Update(Store record)
        {
            if (_db.Stores.Any(s => s.Id != record.Id && s.Name.ToUpper() == record.Name.ToUpper().Trim() && s.IsVirtual == record.IsVirtual))
                return Error($"{(record.IsVirtual ? "Virtual " : "")}Store with the same name exists!");
            var entity = _db.Stores.Find(record.Id);
            if (entity is null)
                return Error("Store not found!");
            entity.Name = record.Name?.Trim();
            entity.IsVirtual = record.IsVirtual;
            _db.Stores.Update(entity);
            _db.SaveChanges();
            return Success("Store is updated successfully.");
        }
    }
}
