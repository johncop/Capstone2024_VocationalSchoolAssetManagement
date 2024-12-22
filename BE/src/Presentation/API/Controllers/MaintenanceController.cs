using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Maintaince;
using ASM.Core.BindingModels.Maintenance;
using ASM.Core.DTOs.Asset;
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
    public class MaintenanceController : BaseApi
    {
        private readonly IBaseService<Maintenance> _baseService;
        private readonly IMapper _mapper;

        public MaintenanceController(IBaseService<Maintenance> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<MaintenanceResponseDTO>>(data: await _baseService.GetAllAsync<MaintenanceResponseDTO>());


        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var maintaince = _baseService.Find(id);
            return Success<IQueryable>(data: maintaince);
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
        public async Task<IResponse> Create([FromForm] CreateMaintenanceBindingModel maintaince)
        {
            var dataResp = await _baseService.Crete(_mapper.Map<Maintenance>(maintaince));
            return Success(data: _mapper.Map<MaintenanceResponseDTO>(dataResp));
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
            return Success(data: _mapper.Map<MaintenanceResponseDTO>(await _baseService.Update(maintenance)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
