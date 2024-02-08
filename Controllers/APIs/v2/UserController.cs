using Asp.Versioning;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.Services.User;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.APIs.v2;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Controllers.APIs.v2;

[ApiController]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        IActionResult result;
        try
        {
            var data = await _userService.ListAsync();
            result = ApiResultFactory.Create(data);
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp);
            result = ApiResultFactory.Create(exp);
        }
        return result;
    }
}