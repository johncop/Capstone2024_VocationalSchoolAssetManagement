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
            return Success(data: _mapper.Map<CategoryResponseDTO>(await _baseService.Crete(_mapper.Map<Category>(category))));
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateCategoryBindingModel updateCategoryBindingModel)
        {
            updateCategoryBindingModel.Id = id;

            //Find the category by id
            var category = await _baseService.Find(id).FirstOrDefaultAsync();
            if (category is null)
            {
                return Error(message: "Not found category. Please try again.", httpStatusCode: HttpStatusCode.BadRequest);
            }

            // Map the updated binding model to the existing category and update it
            _mapper.Map(updateCategoryBindingModel, category);
            var updatedCategory = await _baseService.Update(category);

            // Return the mapped response DTO with success
            return Success<CategoryResponseDTO>(data: _mapper.Map<CategoryResponseDTO>(updatedCategory));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            Category category = await _baseService.Find(id).FirstOrDefaultAsync();
            return category is null ? Error(message: "Category not found.", httpStatusCode: HttpStatusCode.NotFound) : Success(message: await _baseService.Delete(id));
        }
    }
}
