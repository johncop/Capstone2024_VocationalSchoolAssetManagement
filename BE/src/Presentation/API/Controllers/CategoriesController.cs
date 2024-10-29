using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Category;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ASM.Core.DTOs.Category;
using AutoMapper;

namespace ASM.WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : BaseApi
    {
        private readonly IBaseService<Category> _baseService;

        public CategoriesController(IBaseService<Category> baseService, IMapper mapper) : base (mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<CategoryResponseDTO>>(data: await _baseService.GetAllAsync<CategoryResponseDTO>());

        [HttpGet("{id:int}")]
        public async Task<IResponse> Get(int id)
        {
            var category = _baseService.Find(id);
            return Success<CategoryResponseDTO>(data: _mapper.Map<CategoryResponseDTO>(await _baseService.Find(id).FirstOrDefaultAsync()));
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] AddCategoryBindingModel category)
        {
            var result = await _baseService.Crete(_mapper.Map<Category>(category));
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateCategoryBindingModel updateCategoryBindingModel)
        {
            updateCategoryBindingModel.Id = id;
            var category = await _baseService.Find(id).FirstOrDefaultAsync();
            if (category is null)
            {
                return Error(message: "Not found category. Please try again.", httpStatusCode: HttpStatusCode.BadRequest);
            }
            category = _mapper.Map<Category>(updateCategoryBindingModel);
            return Success(message: await _baseService.Update(id, category));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            Category category = await _baseService.Find(id).FirstOrDefaultAsync();
            return category is null ? Error(message: "Category not found.", httpStatusCode: HttpStatusCode.NotFound) : Success(message: await _baseService.Delete(id));
        }
    }
}
