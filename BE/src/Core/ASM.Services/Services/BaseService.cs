using ASM.Core.Entities.Common;
using ASM.Repositories.Interfaces;
using ASM.Services.Interfaces;

namespace ASM.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IQueryRepository<TEntity> _queryRepository;
        protected readonly ICommandRepository<TEntity> _commandRepository;
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IQueryRepository<TEntity> queryRepository, ICommandRepository<TEntity> commandRepository, IUnitOfWork unitOfWork)
        {
            _queryRepository = queryRepository;
            _commandRepository = commandRepository;
            _unitOfWork = unitOfWork;
        }

        public IList<TEntity> GetAll()
        {
            return _queryRepository.GetAll();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _queryRepository.GetAllAsync();
        }

        public IQueryable<TEntity> Find(int id)
        {
            return _queryRepository.Find(x => x.Id == id);
        }

        public async Task<TEntity> Crete(TEntity entity)
        {
            _commandRepository.Add(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task<string> Update(int id, TEntity entity)
        {
            var entityObj = _queryRepository.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return nameof(entity) + "Is Not Exist";
            }
            _commandRepository.Update(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return "Update successful.";
        }
        public async Task<string> Delete(int id)
        {
            var entity = _queryRepository.Find(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                throw new Exception("");
            }

            _commandRepository.Delete(entities: entity);
            await _unitOfWork.SaveChangesAsync();
            return "";
        }

    }
}
