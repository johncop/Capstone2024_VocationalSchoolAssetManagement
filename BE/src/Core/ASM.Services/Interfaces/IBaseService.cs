namespace ASM.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region Query
        IList<TEntity> GetAll();
        Task<IList<TResponse>> GetAllAsync<TResponse>();
        IQueryable<TEntity> Find(int id);
        #endregion

        #region Command
        Task<TEntity> Crete(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<string> Delete(int id);
        #endregion
    }

}
