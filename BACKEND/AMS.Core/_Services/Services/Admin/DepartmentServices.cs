using AutoMapper;
using AutoMapper.QueryableExtensions;
using AMS.Core._Repositories.Interfaces;
using AMS.Core._Services.Interfaces.Admin;
using AMS.Data.Dtos;
using AMS.Data.Models;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using TechnicalUtilities;
using AMS.Core.Constants;

namespace AMS.Core._Services.Services.Admin
{
    public class DepartmentServices : BaseServices, IDepartmentServices
    {
        public DepartmentServices(IRepositoryAccessor accessorServices, MapperConfiguration mapperConfiguration, IMapper mapper) : base(accessorServices, mapperConfiguration, mapper)
        {
        }

        public async Task<BaseResult<bool>> Create(DepartmentDto request)
        {
            var check = await _accessorServices.Department.FirstOrDefaultAsync(x => x.Name == request.Name.Trim(), true);
            if (check != null)
                return new ErrorResult<bool>(false, MesageConstants.DATA_IS_ALREADY);

            var last = await _accessorServices.Department.FindAll(true).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            try
            {
                var account = _mapper.Map<Department>(request);
                _accessorServices.Department.Add(account);
                await _accessorServices.Save();

                return new SuccessResult<bool>(true, MesageConstants.CREATE_SUCCESS);
            }
            catch (System.Exception)
            {
                return new ErrorResult<bool>(false, MesageConstants.ERROR);
            }
        }

        public async Task<BaseResult<bool>> Delete(int id)
        {
            var isExist = await _accessorServices.Department.FirstOrDefaultAsync(x => x.Id == id);
            if (isExist == null) return new ErrorResult<bool>(false, MesageConstants.DATA_NO_EXISTS);

            try
            {
                isExist.IsDeleted = true;
                _accessorServices.Department.Update(isExist);
                await _accessorServices.Save();

                return new SuccessResult<bool>(true, MesageConstants.DELETE_SUCCESS);
            }
            catch (System.Exception)
            {
                return new ErrorResult<bool>(false, MesageConstants.ERROR);
            }
        }

        public async Task<BaseResult<DepartmentDto>> Detail(int id)
        {
            var data = await _accessorServices.Department.FindAll(x => x.Id == id, true).ProjectTo<DepartmentDto>(_mapperConfiguration).FirstOrDefaultAsync();
            return new SuccessResult<DepartmentDto>(data);
        }

        public async Task<List<KeyValuePair<int, string>>> GetAll()
        {
            return await _accessorServices.Department.FindAll(x => !x.IsDeleted, true).Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToListAsync();
        }

        public async Task<PaginationUtility<DepartmentDto>> GetDataPagination(PaginationParam param, DepartmentParam filter)
        {
            var predicate = PredicateBuilder.New<Department>(x => !x.IsDeleted);
            if (!string.IsNullOrWhiteSpace(filter.Keyword))
                predicate.And(x => x.Name.Contains(filter.Keyword));

            var query = await _accessorServices.Department.FindAll(predicate, true).OrderByDescending(x => x.Status).ProjectTo<DepartmentDto>(_mapperConfiguration).ToListAsync();

            return PaginationUtility<DepartmentDto>.Create(query, param.PageNumber, param.PageSize);
        }

        public async Task<List<DepartmentDto>> GetData()
        {
            var predicate = PredicateBuilder.New<Department>(x => !x.IsDeleted);
            var query = await _accessorServices.Department.FindAll(predicate, true).OrderByDescending(x => x.Status).ProjectTo<DepartmentDto>(_mapperConfiguration).ToListAsync();
            return query;
        }

        public async Task<BaseResult<bool>> Update(DepartmentDto request)
        {
            var data = await _accessorServices.Department.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return new ErrorResult<bool>(false, MesageConstants.DATA_NO_EXISTS);

            data = _mapper.Map(request, data);
            _accessorServices.Department.Update(data);
            await _accessorServices.Save();
            return new SuccessResult<bool>(true, MesageConstants.UPDATE_SUCCESS);
        }
    }
}