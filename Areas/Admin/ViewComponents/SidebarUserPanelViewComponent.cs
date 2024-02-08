using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Areas.ViewComponents
{
    public class SidebarUserPanelViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}