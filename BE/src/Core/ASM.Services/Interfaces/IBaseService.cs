namespace ASM.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        #region Query
        IList<TEntity> GetAll();
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> Find(int id);
        #endregion

        #region Command
        Task<TEntity> Crete(TEntity entity);
        Task<string> Update(int id, TEntity entity);
        Task<string> Delete(int id);
        #endregion
    }

}
