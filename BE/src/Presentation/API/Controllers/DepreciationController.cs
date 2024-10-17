using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/depreciation")]
    [ApiController]
    public class DepreciationController : BaseApi
    {
        private IBaseService<Depreciation> _baseService;

        public DepreciationController(IBaseService<Depreciation> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var depreciations = await _baseService.GetAllAsync();
            return Success<IList<Depreciation>>(data: depreciations);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var depreciation = _baseService.Find(id);
            return Success<IQueryable>(data: depreciation);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Depreciation depreciation)
        {
            var result = await _baseService.Crete(depreciation);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Depreciation depreciation)
        {
            var message = await _baseService.Update(id, depreciation);
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
