using System.Linq.Expressions;
using System.Net;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Core.Entities;

namespace ASM.Services.Interfaces
{
    public interface ILoanRequestService
    {
        #region QUERY
        public Task<IList<LoanerRequestReponseDTO>> GetAllAsync(Expression<Func<LoanRequest, bool>>? filter = null,
            Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true);

        public Task<LoanerRequestReponseDTO> GetAsync(Expression<Func<LoanRequest, bool>>? filter = null,
            Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true);
        #endregion

        #region COMMAND
        Task<(LoanerRequestReponseDTO response, string errMsg, HttpStatusCode sttCode)> Create(CreateLoanRequestBindingModel model);
        public Task<(LoanerRequestReponseDTO response, string errMsg)> Update(int requestId, UpdateLoanerRequestBindingModel model);
        public Task<string> DeleteAsync(int id);
        #endregion
    }
}
