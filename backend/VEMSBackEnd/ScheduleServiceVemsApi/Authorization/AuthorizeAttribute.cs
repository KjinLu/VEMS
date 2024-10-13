namespace SchoolMate.Authorizotion;

using BusinessObject;
using CloudinaryDotNet;
using DataAccess.DTO;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using WebApi.Authorization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly IList<string> _accessRole;
    private readonly IRoleRepository roleRepository;

    public AuthorizeAttribute(params string[] accessRole)
    {
        roleRepository = new RoleRepository();
        _accessRole = accessRole ?? new string[] { };
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // Skip authorization if action is decorated with [AllowAnonymous] attribute
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous)
            return;

        // Authorization
        var user = (CommonAccountType)context.HttpContext.Items["User"];

        if (user != null)
        {

            if (_accessRole.Any() && !_accessRole.Contains(user.RoleName))
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
        else
        {
            context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        }
    }

}
