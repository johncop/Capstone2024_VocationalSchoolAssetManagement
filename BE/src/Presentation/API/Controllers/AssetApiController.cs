using API;
using API.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetApiController : ControllerBase
    {

        private readonly ILogger<AssetApiController> _logger;

        public WeatherForecastController(ILogger<AssetApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Asset> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Asset
            {
                ID = 1,
                Name = "Asset1",
                Status = 1,
                Description = "Description1",
                userID = "phupx1"
            })
            .ToArray();
        }

        [HttpGet(Name = "GetID")]
        public Asset Get(int ID)
        {

            ArrayList<Asset> assets = Enumerable.Range(1, 5).Select(index => new Asset
            {
                ID = index,
                Name = "Asset1",
                Status = 1,
                Description = "Description" + index.toString(),
                userID = "phupx1"
            }) 
            .ToArray();

            return assets[ID];
        }

        [HttpGet(Name = "GetByUser")]
        public IEnumerable<Asset> Get(string userID)
        {

            ArrayList<Asset> assets = Enumerable.Range(1, 5).Select(index => new Asset
            {
                ID = index,
                Name = "Asset1",
                Status = 1,
                Description = "Description" + index.toString(),
                userID = "phupx" + index.toString()
            })
            .ToArray();

            return assets;
        }
    }
    
}
