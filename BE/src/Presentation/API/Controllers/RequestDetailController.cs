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

        [HttpGet("/getLoanDetailByRequestId")]
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

        [HttpGet("/getLoanDetailByStatus")]
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

        [HttpGet("/getStockInDetailByRequestId")]
        public IActionResult GetStockInDetailByRequestId(int requestId)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => x.RequestId == requestId).Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table for new location
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new
                    {
                        temp.rd,
                        temp.a,
                        NewLocation = loc
                    })
                    // Join with Departments table
                    .Join(_context.Departments, temp => temp.a.DepartmentId, dept => dept.Id, (temp, dept) => new
                    {
                        temp.rd,
                        temp.a,
                        temp.NewLocation,
                        Department = dept
                    })
                    // Join with AssetTypes table
                    .Join(_context.AssetTypes, temp => temp.a.AssetTypeId, at => at.Id, (temp, at) => new StockInDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        AssetTypeId = temp.a.AssetTypeId,
                        AssetStatus = (int)temp.a.Status,
                        SerialNumber = temp.a.SerialNumber,
                        AssetDescription = temp.a.Description,

                        DepartmentName = temp.Department.Name,
                        LocationName = temp.NewLocation.Name,
                        AssetTypeName = at.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getStockInDetailByStatus")]
        public IActionResult GetStockInDetailByStatus(int status)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => (int)x.Status == status).Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table for new location
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new
                    {
                        temp.rd,
                        temp.a,
                        NewLocation = loc
                    })
                    // Join with Departments table
                    .Join(_context.Departments, temp => temp.a.DepartmentId, dept => dept.Id, (temp, dept) => new
                    {
                        temp.rd,
                        temp.a,
                        temp.NewLocation,
                        Department = dept
                    })
                    // Join with AssetTypes table
                    .Join(_context.AssetTypes, temp => temp.a.AssetTypeId, at => at.Id, (temp, at) => new StockInDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        AssetTypeId = temp.a.AssetTypeId,
                        AssetStatus = (int)temp.a.Status,
                        SerialNumber = temp.a.SerialNumber,
                        AssetDescription = temp.a.Description,

                        DepartmentName = temp.Department.Name,
                        LocationName = temp.NewLocation.Name,
                        AssetTypeName = at.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getRelocationDetailByRequestId")]
        public IActionResult GetRelocationDetailByRequestId(int requestId)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => x.RequestId == requestId)
                    .Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new RelocationDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        SerialNumber = temp.a.SerialNumber,

                        LocationName = loc.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getRelocationDetailByStatus")]
        public IActionResult GetRelocationDetailByStatus(int status)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => (int)x.Status == status)
                    .Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new RelocationDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        SerialNumber = temp.a.SerialNumber,

                        LocationName = loc.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getMiantenanceDetailByRequestId")]
        public IActionResult GetMaintenanceDetailByRequestId(int requestId)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => x.RequestId == requestId)
                    .Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new MaintenanceDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        SerialNumber = temp.a.SerialNumber,

                        LocationName = loc.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getMaintenanceDetailByStatus")]
        public IActionResult GetMaintenanceDetailByStatus(int status)
        {
            try
            {
                var data = _context.RequestDetails
                    .Where(x => (int)x.Status == status)
                    .Join(_context.Assets, rd => rd.AssetId, a => a.Id, (rd, a) => new
                    {
                        rd,
                        a
                    })
                    // Join with Locations table
                    .Join(_context.Locations, temp => temp.rd.AssetNewLocationId, loc => loc.Id, (temp, loc) => new MaintenanceDetailDTO()
                    {
                        RequestDetailId = temp.rd.Id,
                        ActualDate = temp.rd.ActualReturnDate,
                        Description = temp.rd.Description,
                        Status = (int)temp.rd.Status,
                        ReceivedDate = temp.rd.ReceivedDate,
                        AssetOldLocation = temp.rd.AssetOldLocation,
                        AssetNewLocationId = temp.rd.AssetNewLocationId,

                        AssetId = temp.a.Id,
                        AssetName = temp.a.Name,
                        SerialNumber = temp.a.SerialNumber,

                        LocationName = loc.Name
                    })
                    .FirstOrDefault();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
