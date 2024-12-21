using ASM.Core.DTOs.RequestDetail;
using ASM.Database.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RequestDetailController : ControllerBase
    {
        private readonly AssetManagementDbContext _context;
        public RequestDetailController(AssetManagementDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLoanDetailByRequestId(int requestId)
        {
            try
            {
                var data = _context.RequestDetails.Where(x => x.RequestId == requestId).Join(_context.Assets, a => a.AssetId, b => b.Id, (a, b) => new RequestAssetDTOs()
                {
                    RequestId = a.RequestId,
                    RequestDetailId = a.Id,
                    ReturnDate = a.ReturnDate,
                    ActualDate = a.ActualReturnDate,
                    Description = a.Description,
                    Status = (int)a.Status,
                    ReceivedDate = a.ReceivedDate,
                    AssetId = b.Id,
                    AssetName = b.Name,
                    AssetType = b.AssetTypeId,
                    SerialNumber = b.SerialNumber
                }).Join(_context.Approvals, a => a.RequestId, b => b.RequestId, (a, b) => new RequestDetailDTOs()
                {
                    RequestId = a.RequestId,
                    RequestDetailId = a.RequestDetailId,
                    ReturnDate = a.ReturnDate,
                    ActualDate = a.ActualDate,
                    Description = a.Description,
                    Status = a.Status,
                    ReceivedDate = a.ReceivedDate,
                    AssetId = b.Id,
                    AssetName = a.AssetName,
                    AssetType = a.AssetType,
                    SerialNumber = a.SerialNumber,
                    ApprovedDate = b.ApprovalDate,
                }).FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetLoanDetailByStatus(int status)
        {
            try
            {
                var data = _context.RequestDetails.Where(x => (int)x.Status == status).Join(_context.Assets, a => a.AssetId, b => b.Id, (a, b) => new RequestAssetDTOs()
                {
                    RequestId = a.RequestId,
                    RequestDetailId = a.Id,
                    ReturnDate = a.ReturnDate,
                    ActualDate = a.ActualReturnDate,
                    Description = a.Description,
                    Status = (int)a.Status,
                    ReceivedDate = a.ReceivedDate,
                    AssetId = b.Id,
                    AssetName = b.Name,
                    AssetType = b.AssetTypeId,
                    SerialNumber = b.SerialNumber
                }).Join(_context.Approvals, a => a.RequestId, b => b.RequestId, (a, b) => new RequestDetailDTOs()
                {
                    RequestId = a.RequestId,
                    RequestDetailId = a.RequestDetailId,
                    ReturnDate = a.ReturnDate,
                    ActualDate = a.ActualDate,
                    Description = a.Description,
                    Status = a.Status,
                    ReceivedDate = a.ReceivedDate,
                    AssetId = b.Id,
                    AssetName = a.AssetName,
                    AssetType = a.AssetType,
                    SerialNumber = a.SerialNumber,
                    ApprovedDate = b.ApprovalDate,
                }).FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
