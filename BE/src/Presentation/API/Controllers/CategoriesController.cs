using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Category;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ASM.WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoriesController : BaseApi
    {
        private IBaseService<Category> _baseService;

        public CategoriesController(IBaseService<Category> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll()
        {
            var categories = await _baseService.GetAllAsync();
            return Success<IList<Category>>(data: categories);
        }

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var category = _baseService.Find(id);
            return Success<IQueryable>(data: category);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] AddCategoryBindingModel category)
        {
            var newCate = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };
            var result = await _baseService.Crete(newCate);
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

            category.Name = string.IsNullOrEmpty(updateCategoryBindingModel.Name) ? category.Name : updateCategoryBindingModel.Name;
            category.Description = string.IsNullOrEmpty(updateCategoryBindingModel.Description) ? category.Description : updateCategoryBindingModel.Description;
            var message = await _baseService.Update(id, category);
            return Success(message: message);
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
