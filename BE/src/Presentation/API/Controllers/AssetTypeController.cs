using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.DTOs.Asset;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public async Task<IResponse> GetAll([FromQuery] AssetTypeFilterBindingModel filterModel)
        {
            var assets = _baseService.InitQuery();

            if (filterModel.Name != null)
            {
                assets = assets.Where(x => x.Name.ToLower().Contains(filterModel.Name.ToLower()));
            }
            if (filterModel.CategoryId != null)
            {
                assets = assets.Where(x => x.CategoryId == filterModel.CategoryId);
            }
            return Success(data: await assets.ProjectTo<AssetTypeResponseDTO>(_mapper.ConfigurationProvider).ToListAsync());
        }

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
