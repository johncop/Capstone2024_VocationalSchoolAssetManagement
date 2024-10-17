using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{

    [Route("api/asset")]
    public class AssetController : BaseApi
    {
        private IBaseService<Asset> _baseService;

        public AssetController(IBaseService<Asset> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var assets = await _baseService.GetAllAsync();
            return Success<IList<Asset>>(data: assets);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var asset = _baseService.Find(id);
            return Success<IQueryable>(data: asset);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Asset asset)
        {
            var result = await _baseService.Crete(asset);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Asset asset)
        {
            var message = await _baseService.Update(id, asset);
            return Success(message: message);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message : message);
        }

    }
}
