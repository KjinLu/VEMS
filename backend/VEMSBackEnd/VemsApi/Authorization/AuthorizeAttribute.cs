namespace SchoolMate.Authorizotion;

using CloudinaryDotNet;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

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
        // authorization
        var user = context.HttpContext.Items["User"];
        if (user != null)
        {
            string roleName;

            if (user is Student student)
            {
                var userRoles = roleRepository.GetRoleNameById(student.StudentId);
            }
            else if (user is Teacher teacher)
            {
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            if ((_accessRole.Any() && !_accessRole.Contains(roleName)))
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
