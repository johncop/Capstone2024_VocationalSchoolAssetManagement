using System.Linq.Expressions;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Core.Entities;

namespace ASM.Services.Interfaces;

public interface ILoanRequestService
{
    #region QUERY

    public Task<IList<LoanerRequestReponseDTO>> GetAllAsync(Expression<Func<LoanRequest, bool>>? filter = null,
        Expression<Func<LoanRequest, object>>? includeEntities = null, bool disableChangeTracker = true);

    public Task<LoanerRequestReponseDTO?> GetAsync(int id);

    #endregion

    #region COMMAND

    public Task<LoanerRequestReponseDTO> Create(CreateLoanRequestBindingModel model);
    public Task<LoanerRequestReponseDTO> Update(UpdateLoanerRequestBindingModel model);
    public Task<string> DeleteAsync(int id);

    #endregion
}
