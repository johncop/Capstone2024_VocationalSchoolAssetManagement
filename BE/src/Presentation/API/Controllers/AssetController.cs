using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.DTOs.Asset;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{

    [Route("api/asset")]
    public class AssetController : BaseApi
    {
        private IBaseService<Asset> _baseService;

        public AssetController(IBaseService<Asset> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() => Success<IList<AssetResponseDTO>>(data: await _baseService.GetAllAsync<AssetResponseDTO>());

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id) =>
            Success<AssetResponseDTO>(
                data: _mapper.Map<AssetResponseDTO>(await _baseService.Find(id).FirstOrDefaultAsync()));

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
