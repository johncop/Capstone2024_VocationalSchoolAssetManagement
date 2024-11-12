using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using LoanerRequest = ASM.Core.Entities.LoanerRequest;

namespace ASM.WebApi.Controllers
{
    [Route("api/request")]
    [ApiController]
    public class RequestController : BaseApi
    {
        private IBaseService<LoanerRequest> _baseService;

        public RequestController(IBaseService<LoanerRequest> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var requests = await _baseService.GetAllAsync();
            return Success<IList<LoanerRequest>>(data: requests);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var request = _baseService.Find(id);
            return Success<IQueryable>(data: request);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] LoanerRequest request)
        {
            var result = await _baseService.Crete(request);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] LoanerRequest request)
        {
            var message = await _baseService.Update(id, request);
            return Success(message: message);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
