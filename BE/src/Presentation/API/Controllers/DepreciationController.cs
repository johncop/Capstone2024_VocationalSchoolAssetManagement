using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.DTOs.Depreciation;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepreciationController : BaseApi
    {
        private readonly IBaseService<Depreciation> _baseService;
        private readonly IMapper _mapper;

        public DepreciationController(IBaseService<Depreciation> baseService, IMapper mapper): base(mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<DepreciationResponseDTO>>(data: await _baseService.GetAllAsync<DepreciationResponseDTO>());

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var depreciation = _baseService.Find(id);
            return Success<IQueryable>(data: depreciation);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Depreciation depreciation)
        {
            var result = await _baseService.Crete(depreciation);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Depreciation updateDepreciationBindingModel)
        {
            var depreciation = await _baseService.Find(id).FirstOrDefaultAsync();
            if (depreciation is null)
            {
                return Error("Depreciation Not Found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateDepreciationBindingModel, depreciation);

            var updatedDepreciation = await _baseService.Update(depreciation);
            return Success<DepreciationResponseDTO>(data: _mapper.Map<DepreciationResponseDTO>(updatedDepreciation));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
