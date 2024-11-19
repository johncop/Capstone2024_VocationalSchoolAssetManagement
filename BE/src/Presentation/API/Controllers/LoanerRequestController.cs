using System.Net;
using ASM.Application.Base.Interfaces;
using ASM.Application.Shared;
using ASM.Core.BindingModels.Request;
using ASM.Core.DTOs.Request;
using ASM.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanerRequest = ASM.Core.Entities.LoanerRequest;

namespace ASM.WebApi.Controllers
{
    [Route("api/loan-request")]
    [ApiController]
    public class LoanRequestController : BaseApi
    {
        private readonly IBaseService<LoanerRequest> _baseService;

        public LoanRequestController(IBaseService<LoanerRequest> baseService, IMapper mapper) : base(mapper)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IResponse> GetAll() =>
            Success<IList<LoanerRequestReponseDTO>>(data: await _baseService.GetAllAsync<LoanerRequestReponseDTO>());

        [HttpGet("{id:int}")]
        public IResponse Get(int id)
        {
            var request = _baseService.Find(id);
            return Success<IQueryable>(data: request);
        }

        [HttpPost]
        public async Task<IResponse> Create([FromBody] LoanerRequest request)
        {
            var result = await _baseService.Crete(request);
            return Success(data: result.Id);
        }

        [HttpPut("{id:int}")]
        public async Task<IResponse> Update(int id, [FromBody] UpdateLoanerRequestBindingModel updateLoanerRequestBindingModel)
        {
            var loanerRequest = await _baseService.Find(id).FirstOrDefaultAsync();
            if (loanerRequest is null)
            {
                return Error("Loaner Request Not Found", HttpStatusCode.NotFound);
            }

            _mapper.Map(updateLoanerRequestBindingModel, loanerRequest);
            return Success(data: _mapper.Map<LoanerRequestReponseDTO>(await _baseService.Update(loanerRequest)));
        }

        [HttpDelete("{id:int}")]
        public async Task<IResponse> Delete(int id)
        {
            var message = await _baseService.Delete(id);
            return Success(message: message);
        }
    }
}
