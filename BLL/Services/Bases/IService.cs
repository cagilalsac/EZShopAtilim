namespace BLL.Services.Bases
{
    // Way 2:
    public interface IService<TEntity, TModel> 
        where TEntity : class, new() where TModel : class, new()
    {
        public IQueryable<TModel> Query();
        public Service Create(TEntity record);
        public Service Update(TEntity record);
        public Service Delete(int id);
    }
}
