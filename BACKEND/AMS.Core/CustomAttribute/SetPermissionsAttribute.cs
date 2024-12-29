using System.Security.Claims;
using AMS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace AMS.Core.Helpers.AttributeCores
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SetPermissionsAttribute : Attribute
    {
        public readonly string controller;
        public readonly string action;

        public SetPermissionsAttribute(string _controller, string _action)
        {
            controller = _controller;
            action = _action;
        }

        //public void OnAuthorization(AuthorizationFilterContext context)
        //{
        //    // skip authorization if action is decorated with [AllowAnonymous] attribute
        //    var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        //    if (allowAnonymous)
        //        return;

        //    DBContext _db = context.HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;
        //    int accountId = int.Parse(context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        //    var accountRoles = _db.Account_Roles.Where(x => x.AccountId == accountId).Select(x => x.RoleId).Distinct().ToList();
        //    var roles = _db.Roles.Where(x => accountRoles.Contains(x.Id)).Select(x => x.Id).ToList();

        //    var roleFunctions = _db.Role_Functions
        //        .Where(x => roles.Contains(x.RoleId))
        //        .Include(x => x.Function)
        //        .Select(x => x.Function)
        //        .Where(x => x.IsDelete == false && x.Status == true && x.Controller == controller && x.Action == action).ToList();

        //    var accountFunctions = _db.Account_Functions
        //        .Where(x => x.AccountId == accountId)
        //        .Include(x => x.Function)
        //        .Select(x => x.Function)
        //        .Where(x => x.IsDelete == false && x.Status == true && x.Controller == controller && x.Action == action).ToList();

        //    if (!roleFunctions.Any() && !accountFunctions.Any())
        //    {
        //        // not logged in or role not authorized
        //        context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //    }
        //}
    }
}