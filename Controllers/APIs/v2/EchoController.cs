using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Controllers.APIs.v2;

[ApiController]
[ApiVersion(2.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class EchoController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "v2";
    }
}