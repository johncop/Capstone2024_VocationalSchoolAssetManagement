using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Request;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/loan-request")]
    [ApiController]
    [Authorize]
    public class LoanRequestController : BaseApi
    {
        private readonly ILoanRequestService _loanRequestService;
        private readonly IUserService _userService;

        public LoanRequestController(ILoanRequestService loanRequestService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _loanRequestService = loanRequestService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            return Success(
                data: await _loanRequestService.GetAllAsync(x => x.RequesterId == currentUser.Id, x => x.LoanerRequestDetails));
        }

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _loanRequestService.GetAsync(x => x.RequesterId == currentUser.Id && x.Id == id, x => x.LoanerRequestDetails);
            return Success(data: request);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreateLoanRequestBindingModel createLoanRequestBindingModel)
        {
            if (createLoanRequestBindingModel.Details is null || createLoanRequestBindingModel.Details.Count == 0)
                return Error("Details are required", HttpStatusCode.BadRequest);


            var result = await _loanRequestService.Create(createLoanRequestBindingModel);
            if (result.errMsg != "")
            {
                return Error(result.errMsg, HttpStatusCode.BadRequest);
            }

            return Success(data: result.response);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id,
            [FromBody] UpdateLoanerRequestBindingModel updateLoanerRequestBindingModel)
        {
            var result = await _loanRequestService.Update(id, updateLoanerRequestBindingModel);
            return result.errMsg != "" ? Error(result.errMsg, HttpStatusCode.BadRequest) : Success(data: result.response);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _loanRequestService.DeleteAsync(id);
            return Success(message);
        }
    }
}
