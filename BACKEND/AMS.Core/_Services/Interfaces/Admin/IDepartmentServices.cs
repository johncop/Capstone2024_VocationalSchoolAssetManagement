using AMS.Core.CustomAttribute;
using AMS.Data.Dtos;
using Microsoft.Extensions.DependencyInjection;
using TechnicalUtilities;

namespace AMS.Core._Services.Interfaces.Admin
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface IDepartmentServices
    {
        Task<List<DepartmentDto>> GetData();
        Task<PaginationUtility<DepartmentDto>> GetDataPagination(PaginationParam param, DepartmentParam filter);
        Task<BaseResult<bool>> Create(DepartmentDto request);
        Task<BaseResult<bool>> Update(DepartmentDto request);
        Task<BaseResult<bool>> Delete(int id);
        Task<BaseResult<DepartmentDto>> Detail(int id);
        Task<List<KeyValuePair<int, string>>> GetAll();
    }
}