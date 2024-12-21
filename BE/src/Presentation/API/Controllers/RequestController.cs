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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestController : BaseApi
    {
        private readonly IRequestService _requestService;
        private readonly IUserService _userService;

        public RequestController(IRequestService requestService, IUserService userService, IMapper mapper) : base(mapper)
        {
            _requestService = requestService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var currentUser = await _userService.GetCurrentUserAsync();
            return Success(
                data: await _requestService.GetAllAsync(x => x.RequesterId == currentUser.Id, x => x.RequestDetails));
        }

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _requestService.GetAsync(x => x.RequesterId == currentUser.Id && x.Id == id);
            return Success(data: request);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreateRequestBindingModel createRequestBindingModel)
        {
            if (createRequestBindingModel.Details is null || createRequestBindingModel.Details.Count == 0)
                return Error("Details are required", HttpStatusCode.BadRequest);


            var result = await _requestService.Create(createRequestBindingModel);
            if (result.errMsg != "")
            {
                return Error(result.errMsg, HttpStatusCode.BadRequest);
            }

            return Success(data: result.response);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id,
            [FromBody] UpdateRequestBindingModel updateRequestBindingModel)
        {
            var result = await _requestService.Update(id, updateRequestBindingModel);
            return result.errMsg != "" ? Error(result.errMsg, HttpStatusCode.BadRequest) : Success(data: result.response);
        }

        [Route("approve/{id:int}")]
        [HttpPut]
        public async Task<IResponse> Approve([FromRoute] int id)
        {
            return Success();
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var deletedResult = await _requestService.DeleteAsync(id);
            if (deletedResult.errMsg != "")
            {
                return Error(deletedResult.errMsg, HttpStatusCode.BadRequest);
            }
            return Success("Request deleted successfully");
        }

        [HttpGet("/getByStatus")]
        public async Task<IResponse> GetRequestByStatus(int status)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _requestService.GetAsync(x => x.RequesterId == currentUser.Id && x.Status == status);
            return Success(data: request);
        }

        [HttpGet("/getByRequestType")]
        public async Task<IResponse> GetRequestByRequestType(int requestType)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _requestService.GetAsync(x => x.RequesterId == currentUser.Id && (int)x.RequestType == requestType);
            return Success(data: request);
        }

        [HttpGet("/getByRequestCode")]
        public async Task<IResponse> GetRequestByRequestCode(string requestCode)
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _requestService.GetAsync(x => x.RequesterId == currentUser.Id && x.RequestCode.Contains(requestCode));
            return Success(data: request);
        }
    }
}
