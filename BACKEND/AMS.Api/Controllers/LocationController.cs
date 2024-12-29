using AMS.Core._Services.Interfaces.Admin;
using AMS.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using TechnicalUtilities;
using AMS.Data.Models;
using AMS.Core.Helpers.AttributeCores;

namespace AMS.Api.Controllers
{
    public class LocationController : ApiController
    {
        private readonly ILocationServices _service;

        public LocationController(ILocationServices service)
        {
            _service = service;
        }

        [SetPermissions("Location", "Create")]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] LocationDto dto)
        {
            dto.IsDeleted = false;
            dto.CreatedDate = now;
            return Ok(await _service.Create(dto));
        }

        [SetPermissions("Location", "Delete")]
        [HttpPut("Delete")]
        public async Task<IActionResult> Delete([FromBody] LocationDto dto)
        {
            dto.IsDeleted = true;
            dto.UpdatedDate = now;
            return Ok(await _service.Delete(dto.Id));
        }

        [SetPermissions("Location", "Update")]
        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] LocationDto dto)
        {
            dto.CreatedDate = now;
            return Ok(await _service.Update(dto));
        }

        [SetPermissions("Location", "GetDataPagination")]
        [HttpGet("GetDataPagination")]
        public async Task<IActionResult> GetDataPagination([FromQuery] PaginationParam pagination, string keyword)
        {
            return Ok(await _service.GetDataPagination(pagination, new LocationParam { Keyword = keyword}));
        }

        [SetPermissions("Location", "GetDetail")]
        [HttpGet("GetDetail")]
        public async Task<IActionResult> GetDetail([FromQuery] int id)
        {
            return Ok(await _service.Detail(id));
        }

        [HttpGet("GetListLocation")]
        public async Task<IActionResult> GetListLocation()
        {
            return Ok(await _service.GetData());
        }


    }
}
