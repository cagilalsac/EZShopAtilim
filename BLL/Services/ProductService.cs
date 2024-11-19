using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;

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

        public Service Create(Product record)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductModel> Query()
        {
            throw new NotImplementedException();
        }

        public Service Update(Product record)
        {
            throw new NotImplementedException();
        }
    }
}
