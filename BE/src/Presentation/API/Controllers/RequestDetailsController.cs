using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestDetailsController : BaseApi
    {
        private IBaseService<RequestDetails> _baseService;

        public RequestDetailsController(IBaseService<RequestDetails> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var details = await _baseService.GetAllAsync();
            return Success<IList<RequestDetails>>(data: details);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var asset = _baseService.Find(id);
            return Success<IQueryable>(data: asset);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] RequestDetails details)
        {
            var result = await _baseService.Crete(details);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] RequestDetails details)
        {
            var message = await _baseService.Update(id, details);
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
