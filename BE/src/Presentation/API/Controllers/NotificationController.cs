using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.DTOs.Notification;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/notification")]
    [ApiController]
    public class NotificationController : BaseApi
    {
        private IBaseService<Notification> _baseService;

        public NotificationController(IBaseService<Notification> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<NotificationResponseDTO>>(data: await _baseService.GetAllAsync<NotificationResponseDTO>());


        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var notification = _baseService.Find(id);
            return Success<IQueryable>(data: notification);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] Notification notification)
        {
            var result = await _baseService.Crete(notification);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Notification notification)
        {
            var message = await _baseService.Update(id, notification);
            return Success(message: message);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message : message);
        }
    }
}
