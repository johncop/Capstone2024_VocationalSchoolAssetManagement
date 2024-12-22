using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Asset;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Location;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.Location;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : BaseApi
    {
        private readonly IBaseService<Location> _baseService;
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;

        public LocationController(IBaseService<Location> baseService, IMapper mapper, IBlobService blobService) : base(mapper)
        {
            _baseService = baseService;
            _blobService = blobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll([FromQuery] LocationFilterBindingModel filterModel)
        {
            var assets = _baseService.InitQuery();

            if (filterModel.Name != null)
            {
                assets = assets.Where(x => x.Name.ToLower().Contains(filterModel.Name.ToLower()));
            }
            if (filterModel.Status != null)
            {
                assets = assets.Where(x => x.Status == filterModel.Status);
            }
            return Success(data: await assets.ProjectTo<LocationResponseDTO>(_mapper.ConfigurationProvider).ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            return Success(
                data: _mapper.Map<LocationResponseDTO>(await _baseService.Find(id).FirstOrDefaultAsync()));
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] AddLocationBindingModel addLocationBindingModel)
        {
            var dataResp = await _baseService.Crete(_mapper.Map<Location>(addLocationBindingModel));
            return Success(data: _mapper.Map<LocationResponseDTO>(dataResp));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateLocationBindingModel updateLocationBindingModel)
        {
            var location = await _baseService.Find(id).FirstOrDefaultAsync();
            if (location is null)
            {
                return Error("Asset Type not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateLocationBindingModel, location);
            return Success<LocationResponseDTO>(data: _mapper.Map<LocationResponseDTO>(await _baseService.Update(location)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
