using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/approval")]
    [ApiController]
    public class ApprovalController : BaseApi
    {
        private IBaseService<Approval> _baseService;

        public ApprovalController(IBaseService<Approval> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var approvals = await _baseService.GetAllAsync();
            return Success<IList<Approval>>(data: approvals);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var approval = _baseService.Find(id);
            return Success<IQueryable>(data: approval);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Approval approval)
        {
            var result = await _baseService.Crete(approval);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Approval approval)
        {
            var message = await _baseService.Update(id, approval);
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
