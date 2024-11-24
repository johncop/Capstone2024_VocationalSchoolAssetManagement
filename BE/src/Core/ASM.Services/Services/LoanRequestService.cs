using System.Data.Common;
using System.Linq.Expressions;
using System.Net;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Core.Entities;
using ASM.Repositories.Interfaces;
using ASM.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace ASM.Services.Services
{
    public class LoanRequestService : ILoanRequestService
    {
        private readonly ICommandRepository<LoanRequestDetail> _commandDetailRepository;
        private readonly ICommandRepository<LoanRequest> _commandRepository;
        private readonly IMapper _mapper;
        private readonly IQueryRepository<Asset> _queryAssetRepository;
        private readonly IQueryRepository<LoanRequest> _queryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public LoanRequestService(ICommandRepository<LoanRequest> commandRepository,
            IQueryRepository<LoanRequest> queryRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserService userService, IQueryRepository<Asset> queryAssetRepository,
            ICommandRepository<LoanRequestDetail> commandDetailRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _queryAssetRepository = queryAssetRepository;
            _commandDetailRepository = commandDetailRepository;
        }

        public async Task<IList<LoanerRequestReponseDTO>> GetAllAsync(Expression<Func<LoanRequest, bool>>? filter = null,
            Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return await _queryRepository.GetAllAsync<LoanerRequestReponseDTO>(filter, includeEntities, disableChangeTracker);
        }

        public async Task<LoanerRequestReponseDTO> GetAsync(Expression<Func<LoanRequest, bool>>? filter = null,
            Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            var response = await _queryRepository.Find(filter)
                                                 .Include(x => x.LoanerRequestDetails)
                                                 .ProjectTo<LoanerRequestReponseDTO>(_mapper.ConfigurationProvider)
                                                 .FirstOrDefaultAsync();
            return response;
        }

        public async Task<(LoanerRequestReponseDTO response, string errMsg, HttpStatusCode sttCode)> Create(CreateLoanRequestBindingModel model)
        {
            try
            {
                var currentUser = await _userService.GetCurrentUserAsync();
                if (currentUser is null)
                {
                    return (null, "Cannot get current user", HttpStatusCode.Forbidden);
                }

                var manager = await _userService.GetByRole("Manager");
                if (manager is null)
                {
                    return (null, "Cannot find manager", HttpStatusCode.Forbidden);
                }

                var loanRequest = _mapper.Map<LoanRequest>(model);
                loanRequest.RequesterId = currentUser.Id;

                loanRequest.LoanerRequestDetails = new List<LoanRequestDetail>();
                foreach (var detail in model.Details)
                {
                    var asset = _queryAssetRepository.Find(x => x.Id == detail.AssetId).FirstOrDefault();
                    if (asset is null)
                    {
                        return (null, "Cannot find asset", HttpStatusCode.NotFound);
                    }

                    loanRequest.LoanerRequestDetails.Add(new LoanRequestDetail
                    {
                        AssetId = asset.Id,
                        Description = detail.Description,
                        Quantity = detail.Quantity,
                        ReturnDate = detail.ReturnDate
                    });
                }

                loanRequest.Approvals = new List<Approval>
                {
                    new()
                    {
                        ApprovalDate = DateTime.Now,
                        ApproverId = manager.Id
                    }
                };

                _commandRepository.Add(loanRequest);
                await _unitOfWork.SaveChangesAsync();
                return (_mapper.Map<LoanerRequestReponseDTO>(loanRequest), "", HttpStatusCode.Created);
            }
            catch (DbException ex)
            {
                return (null, $"An unexpected error occurred: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(LoanerRequestReponseDTO response, string errMsg)> Update(int requestId, UpdateLoanerRequestBindingModel model)
        {
            var loanRequest = await _queryRepository.InitQuery(x => x.Id == requestId)
                                                    .Include(x => x.LoanerRequestDetails)
                                                    .FirstOrDefaultAsync();
            if (loanRequest is null)
            {
                return (null, "Cannot find request");
            }

            _mapper.Map(model, loanRequest);
            if (model.Details.Count > 0)
            {
                _commandDetailRepository.DeleteAll(loanRequest.LoanerRequestDetails.AsEnumerable());

                var assetIds = model.Details.Select(detail => detail.AssetId).Distinct().ToList();
                var assets = _queryAssetRepository.Find(x => assetIds.Contains(x.Id)).ToList();

                if (assets.Count != assetIds.Count)
                {
                    return (null, "One or more assets not found");
                }

                loanRequest.LoanerRequestDetails = model.Details.Select(x => new LoanRequestDetail
                {
                    AssetId = assets.First(y => y.Id == x.AssetId).Id,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    ReturnDate = x.ReturnDate
                }).ToList();
            }

            _commandRepository.Update(loanRequest);
            await _unitOfWork.SaveChangesAsync();
            return (_mapper.Map<LoanerRequestReponseDTO>(loanRequest), "");
        }
    }
}
