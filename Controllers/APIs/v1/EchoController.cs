using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Controllers.APIs.v1;

[ApiController]
[ApiVersion(1.0)]
[Route("api/v{version:apiVersion}/[controller]")]
public class EchoController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "v1";
    }
}