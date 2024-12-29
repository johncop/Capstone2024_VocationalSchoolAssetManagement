using AMS.Core._Services.Interfaces.Admin;
using AMS.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using TechnicalUtilities;
using AMS.Data.Models;
using AMS.Core.Helpers.AttributeCores;

namespace AMS.Api.Controllers
{
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentServices _service;

        public DepartmentController(IDepartmentServices service)
        {
            _service = service;
        }

        [SetPermissions("Department", "Create")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] DepartmentDto dto)
        {
            dto.IsDeleted = false;
            dto.CreatedDate = now;
            return Ok(await _service.Create(dto));
        }

        [SetPermissions("Department", "Delete")]
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete([FromBody] DepartmentDto dto)
        {
            dto.IsDeleted = true;
            dto.UpdatedDate = now;
            return Ok(await _service.Delete(dto.Id));
        }

        [SetPermissions("Department", "Update")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] DepartmentDto dto)
        {
            dto.CreatedDate = now;
            return Ok(await _service.Update(dto));
        }

        [SetPermissions("Department", "GetDataPagination")]
        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string keyword)
        {
            return Ok(await _service.GetDataPagination(pagination, new DepartmentParam { Keyword = keyword}));
        }

        [SetPermissions("Department", "GetDetail")]
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            return Ok(await _service.Detail(id));
        }

        [HttpGet("GetListDepartment")]
        public async Task<IActionResult> GetListDepartment()
        {
            return Ok(await _service.GetData());
        }


    }
}
