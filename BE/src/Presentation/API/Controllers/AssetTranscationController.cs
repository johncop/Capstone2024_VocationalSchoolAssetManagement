using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetTranscation;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Maintaince;
using ASM.Core.BindingModels.Maintenance;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.AssetTranscation;
using ASM.Core.DTOs.Maintaince;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTranscationController : BaseApi
    {
        private readonly IBaseService<TransactionRecord> _baseService;
        private readonly IMapper _mapper;

        public AssetTranscationController(IBaseService<TransactionRecord> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<AssetTranscationResponseDTO>>(data: await _baseService.GetAllAsync<AssetTranscationResponseDTO>());


        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var assetTranscations = _baseService.Find(id);
            return Success<IQueryable>(data: assetTranscations);
        }
        [HttpGet("by-asset-id")]
        public IResponse GetByAssetId([FromQuery] MaintenanceFilterBindingModel filter)
        {
            var assets = _baseService.InitQuery();

            if (filter.assetId != null)
            {
                assets = assets.Where(x => x.AssetId == filter.assetId);
            }
            return Success<IQueryable>(data: assets);
        }


        [HttpPost]
        public async Task<IResponse> Create([FromForm] CreateTranscationBindingModel assetTranscations)
        {
            var dataResp = await _baseService.Crete(_mapper.Map<TransactionRecord>(assetTranscations));
            return Success(data: _mapper.Map<AssetTranscationResponseDTO>(dataResp));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] MaintenanceBindingModel updateMaintenanceBindingModel)
        {
            var maintenance = await _baseService.Find(id).FirstOrDefaultAsync();
            if (maintenance is null)
            {
                return Error("Maintenance not found", HttpStatusCode.NotFound);
            }
            _mapper.Map(updateMaintenanceBindingModel, maintenance);
            return Success(data: _mapper.Map<AssetTranscationResponseDTO>(await _baseService.Update(maintenance)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
