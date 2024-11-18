using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Inventory;
using ASM.Core.DTOs.Inventory;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : BaseApi
    {
        private IBaseService<Inventory> _baseService;

        public InventoryController(IBaseService<Inventory> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<InventoryResponseDTO>>(data: await _baseService.GetAllAsync<InventoryResponseDTO>());

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var inventory = _baseService.Find(id);
            return Success<IQueryable>(data: inventory);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Inventory inventory)
        {
            await _baseService.Crete(inventory);
            return Success();
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateInventoryBindingModel updatedInventoryBindingModel)
        {
            var inventory = await _baseService.Find(id).FirstOrDefaultAsync();
            if (inventory == null)
            {
                return Error("Inventory not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updatedInventoryBindingModel, inventory);
            return Success(data: _mapper.Map<InventoryResponseDTO>(await _baseService.Update(inventory)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            await _baseService.Delete(id);
            return Success();
        }
    }


}
