namespace Sales.Infraestructure.Core
{
    public interface IDaoBase<TEntity> where TEntity : class
    {
        DataResult Save(TEntity entity);
        void Update(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(int Id);
        bool Exists(string Id);
    }
}