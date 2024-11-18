using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.DTOs.Asset;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class AssetController : BaseApi
    {
        private readonly IBaseService<Asset> _baseService;

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
        public async Task<IResponse> Create([FromBody] CreateAssetBindingModel asset)
        {
            var result = await _baseService.Crete(_mapper.Map<Asset>(asset));
            return Success(data: _mapper.Map<AssetResponseDTO>(result));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateAssetBindingModel updateAssetBindingModel)
        {
            var asset = await _baseService.Find(id).FirstOrDefaultAsync();
            if (asset is null)
            {
                return Error("Asset not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateAssetBindingModel, asset);
            return Success<AssetResponseDTO>(data: _mapper.Map<AssetResponseDTO>(await _baseService.Update(asset)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message : message);
        }

    }
}
