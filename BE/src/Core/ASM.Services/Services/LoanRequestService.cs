using System.Linq.Expressions;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Core.Entities;
using ASM.Repositories.Interfaces;
using ASM.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ASM.Services.Services;

public class LoanRequestService : ILoanRequestService
{
    private readonly ICommandRepository<LoanRequest> _commandRepository;
    private readonly IMapper _mapper;
    private readonly IQueryRepository<LoanRequest> _queryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public LoanRequestService(ICommandRepository<LoanRequest> commandRepository,
        IQueryRepository<LoanRequest> queryRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IList<LoanerRequestReponseDTO>> GetAllAsync(Expression<Func<LoanRequest, bool>>? filter = null,
        Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true)
    {
        return await _queryRepository.InitQuery(filter, includeEntities, disableChangeTracker)
            .ProjectTo<LoanerRequestReponseDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<LoanerRequestReponseDTO?> GetAsync(int id)
    {
        return await _queryRepository.Find(x => x.Id == id)
            .ProjectTo<LoanerRequestReponseDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
    }

    public async Task<LoanerRequestReponseDTO> Create(CreateLoanRequestBindingModel model)
    {
        var loanerRequest = _mapper.Map<LoanRequest>(model);

        throw new NotImplementedException();
    }

    public async Task<LoanerRequestReponseDTO> Update(UpdateLoanerRequestBindingModel model)
    {
        throw new NotImplementedException();
    }

    public async Task<string> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
