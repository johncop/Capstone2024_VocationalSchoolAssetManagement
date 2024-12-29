using AMS.Core.CustomAttribute;
using AMS.Data.Dtos;
using Microsoft.Extensions.DependencyInjection;
using TechnicalUtilities;

namespace AMS.Core._Services.Interfaces.Admin
{
    [DependencyInjection(ServiceLifetime.Scoped)]
    public interface ILocationServices
    {
        Task<List<LocationDto>> GetData();
        Task<PaginationUtility<LocationDto>> GetDataPagination(PaginationParam param, LocationParam filter);
        Task<BaseResult<bool>> Create(LocationDto request);
        Task<BaseResult<bool>> Update(LocationDto request);
        Task<BaseResult<bool>> Delete(int id);
        Task<BaseResult<LocationDto>> Detail(int id);
        Task<List<KeyValuePair<int, string>>> GetAll();
    }
}