using Asp.Versioning;
using DotNetCoreWeb.AdminLTE.ProjectTemplates.Services.User;
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
    public async Task<List<UserViewModel>> Index()
    {
        var data = await _userService.ListAsync();
        return data;
    }
}