using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.Entities;
using ASM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : BaseApi
    {
        private IBaseService<Category> _baseService;

        public CategoryController(IBaseService<Category> baseService)
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
        public async Task<IResponse> Create([FromBody] Category category)
        {
            var result = await _baseService.Crete(category);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] Category category)
        {
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
