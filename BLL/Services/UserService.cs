using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class UserService : Service, IService<User, UserModel>
    {
        public UserService(Db db) : base(db)
        {
        }

        public Service Create(User record)
        {
            throw new NotImplementedException();
        }

        public Service Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> Query()
        {
            return _db.Users.Include(u => u.Role).Select(u => new UserModel() { Record = u });
        }

        public Service Update(User record)
        {
            throw new NotImplementedException();
        }
    }
}
