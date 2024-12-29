using AMS.Core.CustomAttribute;
using AMS.Data.Dtos;
using Microsoft.Extensions.DependencyInjection;
using TechnicalUtilities;

namespace AMS.Core._Services.Interfaces.Admin
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface ICategoryServices
    {
        Task<List<CategoryDto>> GetData();
        Task<PaginationUtility<CategoryDto>> GetDataPagination(PaginationParam param, CategoryParam filter);
        Task<BaseResult<bool>> Create(CategoryDto request);
        Task<BaseResult<bool>> Update(CategoryDto request);
        Task<BaseResult<bool>> Delete(int id);
        Task<BaseResult<CategoryDto>> Detail(int id);
        Task<List<KeyValuePair<int, string>>> GetAll();
    }
}