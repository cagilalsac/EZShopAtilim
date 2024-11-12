using BLL.DAL;
using BLL.Models;
using BLL.Services.Bases;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public interface ICategoryService
    {
        public IQueryable<CategoryModel> Query();
        public Service Create(Category record);
        public Service Update(Category record);
        public Service Delete(int id);
    }

    public class CategoryService : Service, ICategoryService
    {
        public CategoryService(Db db) : base(db)
        {
        }

        public Service Create(Category record)
        {
            // Way 1:
            //Category existingCategory = _db.Categories.SingleOrDefault(c => c.Name == record.Name);
            //if (existingCategory is not null)
            //    return Error("Category with the same name exists!");
            // Way 2:
            if (_db.Categories.Any(c => c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");

            record.Name = record.Name?.Trim();
            record.Description = record.Description?.Trim();
            _db.Categories.Add(record);
            _db.SaveChanges();
            return Success("Category is created successfully.");
        }

        public Service Update(Category record)
        {
            if (_db.Categories.Any(c => c.Id != record.Id && c.Name.ToUpper() == record.Name.ToUpper().Trim()))
                return Error("Category with the same name exists!");
            record.Name = record.Name?.Trim();
            record.Description = record.Description?.Trim();
            _db.Categories.Update(record);
            _db.SaveChanges();
            return Success("Category is updated successfully.");
        }

        public Service Delete(int id)
        {
            //Category category = _db.Categories.Find(id); 
            Category category = _db.Categories.Include(c => c.Products).SingleOrDefault(c => c.Id == id);
            if (category is null)
                return Error("Category is not found.");

            // Way 1:
            //if (category.Products.Count > 0)
            //    return Error("Category has relational products!");
            // Way 2:
            if (category.Products.Any())
                return Error("Category has relational products!");

            _db.Categories.Remove(category);
            _db.SaveChanges();
            return Success("Category is deleted successfully.");
        }

        public IQueryable<CategoryModel> Query()
        {
            return _db.Categories.OrderBy(c => c.Name).Select(c => new CategoryModel()
            {
                Record = c
            });
        }
    }
}
