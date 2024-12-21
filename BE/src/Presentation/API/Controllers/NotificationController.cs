using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Notification;
using ASM.Core.DTOs.Notification;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using ASM.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : BaseApi
    {
        private readonly IBaseService<Notification> _baseService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;
        private readonly IUserService _userService;

        public NotificationController(IBaseService<Notification> baseService, IMapper mapper, INotificationService notificationService, IUserService userService) : base(mapper)
        {
            _baseService = baseService;
            _mapper = mapper;
            _notificationService = notificationService;
            _userService = userService;
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
        public async Task<IResponse> Update(int id, [FromBody] UpdateNotificationBindingModel updateNotificationBindingModel)
        {
            var notification = await _baseService.Find(id).FirstOrDefaultAsync();
            if (notification is null)
            {
                return Error("Notification not found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateNotificationBindingModel, notification);
            return Success(data: _mapper.Map<NotificationResponseDTO>(await _baseService.Update(notification)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }

        [HttpGet]
        public async Task<IResponse> GetNotificationByCurrentUser()
        {
            var currentUser = await _userService.GetCurrentUserAsync();

            var request = await _notificationService.GetAllAsync(x => x.UserId == currentUser.Id);
            return Success(data: request);
        }
    }
}
