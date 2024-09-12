namespace SchoolMate.Authorizotion;

using BusinessObject;
using CloudinaryDotNet;
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
        var user = context.HttpContext.Items["User"];
        if (user != null)
        {
            Guid roleId;
            Role userRole;

            if (user is Admin)
            {
                userRole = roleRepository.GetRoleById(((Admin)user).RoleId);
            }
            else if (user is Teacher)
            {
                userRole = roleRepository.GetRoleById(((Teacher)user).RoleId);
            }
            else if (user is Student)
            {
                userRole = roleRepository.GetRoleById(((Student)user).RoleId);
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }


            if (_accessRole.Any() && !_accessRole.Contains(userRole.Code))
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
