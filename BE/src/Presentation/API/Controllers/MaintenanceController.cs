using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Maintaince;
using ASM.Core.DTOs.Maintaince;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : BaseApi
    {
        private readonly IBaseService<Maintenance> _baseService;

        public MaintenanceController(IBaseService<Maintenance> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
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

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Maintenance maintaince)
        {
            var result = await _baseService.Crete(maintaince);
            return Success(data: result.Id);
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
