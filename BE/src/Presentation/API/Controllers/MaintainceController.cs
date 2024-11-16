using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.DTOs.Maintaince;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/maintaince")]
    [ApiController]
    public class MaintenanceController : BaseApi
    {
        private IBaseService<Maintenance> _baseService;

        public MaintenanceController(IBaseService<Maintenance> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<MaintainceResponseDTO>>(data: await _baseService.GetAllAsync<MaintainceResponseDTO>());


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
        public async Task<IResponse> Update(int id, [FromBody] Maintenance maintaince)
        {
            var message = await _baseService.Update(id, maintaince);
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
