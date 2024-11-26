using System.Linq.Expressions;
using System.Net;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Core.Entities;

namespace ASM.Services.Interfaces
{
    public interface IRequestService
    {
        #region QUERY
        public Task<IList<RequestResponseDTO>> GetAllAsync(Expression<Func<Request, bool>>? filter = null,
            Expression<Func<Request, object>>? includeEntities = null, bool disableChangeTracker = true);

        public Task<RequestResponseDTO> GetAsync(Expression<Func<Request, bool>>? filter = null,
            Expression<Func<Request, object>>? includeEntities = null, bool disableChangeTracker = true);
        #endregion

        #region COMMAND
        Task<(RequestResponseDTO response, string errMsg, HttpStatusCode sttCode)> Create(CreateRequestBindingModel model);
        public Task<(RequestResponseDTO response, string errMsg)> Update(int requestId, UpdateRequestBindingModel model);
        Task<(RequestResponseDTO response, string errMsg)> Approve(int requestId, int approverId);
        public Task<(bool isDeleted, string errMsg)> DeleteAsync(int id);
        #endregion
    }
}
