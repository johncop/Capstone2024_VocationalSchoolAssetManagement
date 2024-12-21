using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.DTOs.Asset;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/asset-types")]
    [ApiController]
    public class AssetTypeController : BaseApi
    {
        private readonly IBaseService<AssetType> _baseService;
        private readonly IMapper _mapper;

        public AssetTypeController(IBaseService<AssetType> baseService, IMapper mapper) : base (mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<AssetTypeResponseDTO>>(data: await _baseService.GetAllAsync<AssetTypeResponseDTO>());

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var type = _baseService.Find(id);
            return Success<IQueryable>(data: type);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] CreateAssetTypeBindingModel createAssetTypeBindingModel)
        {
            var dataResp = await _baseService.Crete(_mapper.Map<AssetType>(createAssetTypeBindingModel));
            return Success(data: _mapper.Map<AssetTypeResponseDTO>(dataResp));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateAssetTypeBindingModel updateAssetTypeBindingModel)
        {
            var assetType = await _baseService.Find(id).FirstOrDefaultAsync();
            if (assetType is null)
            {
                return Error("Asset Type not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateAssetTypeBindingModel, assetType);
            return Success<AssetTypeResponseDTO>(data: _mapper.Map<AssetTypeResponseDTO>(await _baseService.Update(assetType)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
