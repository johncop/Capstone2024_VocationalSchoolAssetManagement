using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.AssetType;
using ASM.Core.BindingModels.Department;
using ASM.Core.BindingModels.Location;
using ASM.Core.DTOs.Asset;
using ASM.Core.DTOs.Department;
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
    public class DeparmentController : BaseApi
    {
        private readonly IBaseService<Department> _baseService;
        private readonly IBlobService _blobService;
        private readonly IMapper _mapper;

        public DeparmentController(IBaseService<Department> baseService, IMapper mapper, IBlobService blobService) : base(mapper)
        {
            _baseService = baseService;
            _blobService = blobService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IResponse> GetAll([FromQuery] DepartmentFilterBindingModel filterModel)
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
            return Success(data: await assets.ProjectTo<DepartmentResponseDTO>(_mapper.ConfigurationProvider).ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            return Success(
                data: _mapper.Map<DepartmentResponseDTO>(await _baseService.Find(id).FirstOrDefaultAsync()));
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] AddDepartmentBindingModel addDepartmentBindingModel)
        {
            var dataResp = await _baseService.Crete(_mapper.Map<Department>(addDepartmentBindingModel));
            return Success(data: _mapper.Map<DepartmentResponseDTO>(dataResp));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateDepartmentBindingModel updateDepartmentBindingModel)
        {
            var department = await _baseService.Find(id).FirstOrDefaultAsync();
            if (department is null)
            {
                return Error("Department not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateDepartmentBindingModel, department);
            return Success<DepartmentResponseDTO>(data: _mapper.Map<DepartmentResponseDTO>(await _baseService.Update(department)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
