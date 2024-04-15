namespace Echo_HemAPI.TestGeneric_Repository
{
    public interface IGRepository<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();

        //Guid is the default Id Key in the database layer
        Task<TEntity?> GetByIdAsync(Guid id);

        //To allow for the programm to do Lambda Queries
        IQueryable<TEntity> GetQueryable();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task SaveChangesAsync();
    }
}
