using ASM.Core.Entities.Common;
using ASM.Repositories.Interfaces;
using ASM.Services.Interfaces;
using AutoMapper;

namespace ASM.Services.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IQueryRepository<TEntity> _queryRepository;
        private readonly ICommandRepository<TEntity> _commandRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

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

        public async Task<IList<TResponse>> GetAllAsync<TResponse>()
        {
            return await _queryRepository.GetAllAsync<TResponse>();
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
        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                _commandRepository.Update(entities: entity);
                await _unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }

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
