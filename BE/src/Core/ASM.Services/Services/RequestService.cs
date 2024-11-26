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
    public class RequestService : IRequestService
    {
        private readonly ICommandRepository<RequestDetail> _commandDetailRepository;
        private readonly ICommandRepository<Request> _commandRepository;
        private readonly IMapper _mapper;
        private readonly IQueryRepository<Asset> _queryAssetRepository;
        private readonly IQueryRepository<Request> _queryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public RequestService(ICommandRepository<Request> commandRepository,
            IQueryRepository<Request> queryRepository, IMapper mapper, IUnitOfWork unitOfWork, IUserService userService, IQueryRepository<Asset> queryAssetRepository,
            ICommandRepository<RequestDetail> commandDetailRepository)
        {
            _commandRepository = commandRepository;
            _queryRepository = queryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userService = userService;
            _queryAssetRepository = queryAssetRepository;
            _commandDetailRepository = commandDetailRepository;
        }

        public async Task<IList<RequestResponseDTO>> GetAllAsync(Expression<Func<Request, bool>>? filter = null,
            Expression<Func<Request, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            return await _queryRepository.GetAllAsync<RequestResponseDTO>(filter, includeEntities, disableChangeTracker);
        }

        public async Task<RequestResponseDTO> GetAsync(Expression<Func<Request, bool>>? filter = null,
            Expression<Func<Request, object>>? includeEntities = null, bool disableChangeTracker = true)
        {
            var response = await _queryRepository.Find(filter)
                                                 .Include(x => x.RequestDetails)
                                                 .ProjectTo<RequestResponseDTO>(_mapper.ConfigurationProvider)
                                                 .FirstOrDefaultAsync();
            return response;
        }

        public async Task<(RequestResponseDTO response, string errMsg, HttpStatusCode sttCode)> Create(CreateRequestBindingModel model)
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

                var loanRequest = _mapper.Map<Request>(model);
                loanRequest.RequesterId = currentUser.Id;

                loanRequest.RequestDetails = new List<RequestDetail>();
                foreach (var detail in model.Details)
                {
                    var asset = _queryAssetRepository.Find(x => x.Id == detail.AssetId).FirstOrDefault();
                    if (asset is null)
                    {
                        return (null, "Cannot find asset", HttpStatusCode.NotFound);
                    }

                    loanRequest.RequestDetails.Add(new RequestDetail
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
                return (_mapper.Map<RequestResponseDTO>(loanRequest), "", HttpStatusCode.Created);
            }
            catch (DbException ex)
            {
                return (null, $"An unexpected error occurred: {ex.Message}", HttpStatusCode.InternalServerError);
            }
        }

        public async Task<(RequestResponseDTO response, string errMsg)> Update(int requestId, UpdateRequestBindingModel model)
        {
            var loanRequest = await _queryRepository.InitQuery(x => x.Id == requestId)
                                                    .Include(x => x.RequestDetails)
                                                    .FirstOrDefaultAsync();
            if (loanRequest is null)
            {
                return (null, "Cannot find request");
            }

            _mapper.Map(model, loanRequest);
            if (model.Details.Count > 0)
            {
                _commandDetailRepository.DeleteAll(loanRequest.RequestDetails.AsEnumerable());

                var assetIds = model.Details.Select(detail => detail.AssetId).Distinct().ToList();
                var assets = _queryAssetRepository.Find(x => assetIds.Contains(x.Id)).ToList();

                if (assets.Count != assetIds.Count)
                {
                    return (null, "One or more assets not found");
                }

                loanRequest.RequestDetails = model.Details.Select(x => new RequestDetail
                {
                    AssetId = assets.First(y => y.Id == x.AssetId).Id,
                    Description = x.Description,
                    Quantity = x.Quantity,
                    ReturnDate = x.ReturnDate
                }).ToList();
            }

            _commandRepository.Update(loanRequest);
            await _unitOfWork.SaveChangesAsync();
            return (_mapper.Map<RequestResponseDTO>(loanRequest), "");
        }


        public async Task<(RequestResponseDTO response, string errMsg)> Approve(int requestId, int approverId)
        {
            var request = await _queryRepository.Find(x => x.Id == requestId).Include(x => x.Approvals).FirstOrDefaultAsync();
            if (request is null)
            {
                return (null, "Cannot find request");
            }

            var approval = request.Approvals.FirstOrDefault(x => x.RequestId == requestId && x.ApproverId == approverId);
            if (approval is null)
            {
                return (null, "Cannot approve request");
            }

            approval.ApprovalDate = DateTime.UtcNow;
            request.IsApproved = true;

            _commandRepository.Update(request);
            await _unitOfWork.SaveChangesAsync();
            return (_mapper.Map<RequestResponseDTO>(request), "");
        }

        public async Task<(bool isDeleted, string errMsg)> DeleteAsync(int id)
        {
            var request = await _queryRepository.Find(x => x.Id == id).FirstOrDefaultAsync();
            if (request is null)
            {
                return (false, "Request not found");
            }

            request.IsDeleted = true;
            _commandRepository.Update(request);
            await _unitOfWork.SaveChangesAsync();
            return (true, string.Empty);
        }
    }
}
