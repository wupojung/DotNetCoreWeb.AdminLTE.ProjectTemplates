using DotNetCoreWeb.AdminLTE.ProjectTemplates.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Controllers;

public class AccountController : BaseAdminController
{

    [HttpGet]
    public IActionResult Logout()
    {
        return RedirectToAction("Index", "Home");
    }
}