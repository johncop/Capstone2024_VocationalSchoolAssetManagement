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
    public class CategoryServices : BaseServices, ICategoryServices
    {
        public CategoryServices(IRepositoryAccessor accessorServices, MapperConfiguration mapperConfiguration, IMapper mapper) : base(accessorServices, mapperConfiguration, mapper)
        {
        }

        public async Task<BaseResult<bool>> Create(CategoryDto request)
        {
            var check = await _accessorServices.Category.FirstOrDefaultAsync(x => x.Name == request.Name.Trim(), true);
            if (check != null)
                return new ErrorResult<bool>(false, MesageConstants.DATA_IS_ALREADY);

            var last = await _accessorServices.Category.FindAll(true).OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            try
            {
                var account = _mapper.Map<Category>(request);
                _accessorServices.Category.Add(account);
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
            var isExist = await _accessorServices.Category.FirstOrDefaultAsync(x => x.Id == id);
            if (isExist == null) return new ErrorResult<bool>(false, MesageConstants.DATA_NO_EXISTS);

            try
            {
                isExist.IsDeleted = true;
                _accessorServices.Category.Update(isExist);
                await _accessorServices.Save();

                return new SuccessResult<bool>(true, MesageConstants.DELETE_SUCCESS);
            }
            catch (System.Exception)
            {
                return new ErrorResult<bool>(false, MesageConstants.ERROR);
            }
        }

        public async Task<BaseResult<CategoryDto>> Detail(int id)
        {
            var data = await _accessorServices.Category.FindAll(x => x.Id == id, true).ProjectTo<CategoryDto>(_mapperConfiguration).FirstOrDefaultAsync();
            return new SuccessResult<CategoryDto>(data);
        }

        public async Task<List<KeyValuePair<int, string>>> GetAll()
        {
            return await _accessorServices.Category.FindAll(x => !x.IsDeleted, true).Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToListAsync();
        }

        public async Task<PaginationUtility<CategoryDto>> GetDataPagination(PaginationParam param, CategoryParam filter)
        {
            var predicate = PredicateBuilder.New<Category>(x => !x.IsDeleted);
            if (!string.IsNullOrWhiteSpace(filter.Keyword))
                predicate.And(x => x.Name.Contains(filter.Keyword));

            var query = await _accessorServices.Category.FindAll(predicate, true).OrderByDescending(x => x.Name).ProjectTo<CategoryDto>(_mapperConfiguration).ToListAsync();

            return PaginationUtility<CategoryDto>.Create(query, param.PageNumber, param.PageSize);
        }

        public async Task<List<CategoryDto>> GetData()
        {
            var predicate = PredicateBuilder.New<Category>(x => !x.IsDeleted);
            var query = await _accessorServices.Category.FindAll(predicate, true).OrderByDescending(x => x.Name).ProjectTo<CategoryDto>(_mapperConfiguration).ToListAsync();
            return query;
        }

        public async Task<BaseResult<bool>> Update(CategoryDto request)
        {
            var data = await _accessorServices.Category.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (data == null) return new ErrorResult<bool>(false, MesageConstants.DATA_NO_EXISTS);

            data = _mapper.Map(request, data);
            _accessorServices.Category.Update(data);
            await _accessorServices.Save();
            return new SuccessResult<bool>(true, MesageConstants.UPDATE_SUCCESS);
        }
    }
}