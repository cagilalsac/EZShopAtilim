using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

namespace BLL.Services
{
    public class StoreService : Service, IService<Store, StoreModel>
    {
        public StoreService(Db db) : base(db)
        {
        }

        public Service Create(Store record)
        {
            throw new NotImplementedException();
        }

        public Service Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<StoreModel> Query()
        {
            return _db.Stores.OrderByDescending(s => s.IsVirtual).ThenBy(s => s.Name).Select(s => new StoreModel() { Record = s });
        }

        public Service Update(Store record)
        {
            throw new NotImplementedException();
        }
    }
}
