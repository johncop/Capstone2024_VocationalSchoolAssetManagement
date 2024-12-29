using AMS.Core._Services.Interfaces.Admin;
using AMS.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using TechnicalUtilities;
using AMS.Data.Models;
using AMS.Core.Helpers.AttributeCores;

namespace AMS.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryServices _service;

        public CategoryController(ICategoryServices service)
        {
            _service = service;
        }

        [SetPermissions("Category", "Create")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryDto dto)
        {
            dto.IsDeleted = false;
            dto.CreatedDate = now;
            return Ok(await _service.Create(dto));
        }

        [SetPermissions("Category", "Delete")]
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete([FromBody] CategoryDto dto)
        {
            dto.IsDeleted = true;
            dto.UpdatedDate = now;
            return Ok(await _service.Delete(dto.Id));
        }

        [SetPermissions("Category", "Update")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] CategoryDto dto)
        {
            dto.CreatedDate = now;
            return Ok(await _service.Update(dto));
        }

        [SetPermissions("Category", "GetDataPagination")]
        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string keyword)
        {
            return Ok(await _service.GetDataPagination(pagination, new CategoryParam { Keyword = keyword}));
        }

        [SetPermissions("Category", "GetDetail")]
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            return Ok(await _service.Detail(id));
        }

        [HttpGet("GetListCategory")]
        public async Task<IActionResult> GetListCategory()
        {
            return Ok(await _service.GetData());
        }


    }
}
