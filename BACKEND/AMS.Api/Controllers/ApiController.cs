using System.Net;
using System.Security.Claims;
using AMS.Api.Helpers.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechnicalUtilities;

namespace AMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ClientApiError), (int)HttpStatusCode.BadRequest)]
    public class ApiController : ControllerBase
    {
        protected int userId => User.FindFirst(ClaimTypes.NameIdentifier).Value.ToInt();
        protected string userName => User.FindFirst(ClaimTypes.Name).Value;
        protected DateTime now => DateTime.Now;
    }
}
