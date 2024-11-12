using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/assetType")]
    [ApiController]
    public class AssetTypeController : BaseApi
    {
        private IBaseService<AssetType> _baseService;

        public AssetTypeController(IBaseService<AssetType> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var type = await _baseService.GetAllAsync();
            return Success<IList<AssetType>>(data: type);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var type = _baseService.Find(id);
            return Success<IQueryable>(data: type);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] AssetType type)
        {
            var result = await _baseService.Crete(type);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] AssetType type)
        {
            var message = await _baseService.Update(id, type);
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
