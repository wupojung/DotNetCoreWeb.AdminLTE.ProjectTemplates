using DotNetCoreWeb.AdminLTE.ProjectTemplates.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Areas.Admin.ViewComponents
{
    public class SidebarMenuViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SidebarMenuViewModel> model = new List<SidebarMenuViewModel>();

            model.AddRange(GetExamplesMenu());
            model.AddRange(GetMiscellaneousMenu());
            model.AddRange(GetLabelMenu());


            return View(model);
        }
        private IList<SidebarMenuViewModel> GetExamplesMenu()
        {
            IList<SidebarMenuViewModel> result = new List<SidebarMenuViewModel>();
            result.Add(new SidebarMenuViewModel() { IsHeader = true, Title = "EXAMPLES" });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Calendar",
                Class = "nav-icon far fa-calendar-alt",
                Url = new DataUrl("Index", "Home", "Admin")
            });

            result.Add(new SidebarMenuViewModel()
            {
                Title = "Gallery",
                Class = "nav-icon far fa-image",
                Url = new DataUrl("Index", "Home", "Admin")
            });

            result.Add(new SidebarMenuViewModel()
            {
                Title = "Kanban Board",
                Class = "nav-icon fas fa-columns",
                Url = new DataUrl("Index", "Home", "Admin")
            });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Mailbox",
                Class = "nav-icon far fa-envelope",
                //Url = new DataUrl("Index", "Home", "Admin")
                Child = new List<SidebarMenuViewModel>()
                {
                    new SidebarMenuViewModel()
                    {
                        Title = "Inbox",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    },
                    new SidebarMenuViewModel()
                    {
                        Title = "Compose",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    },
                    new SidebarMenuViewModel()
                    {
                        Title = "Read",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    }
                }
            });

            result.Add(new SidebarMenuViewModel()
            {
                Title = "Pages",
                Class = "nav-icon fas fa-book",
                //Url = new DataUrl("Index", "Home", "Admin")
                Child = new List<SidebarMenuViewModel>()
                {
                    new SidebarMenuViewModel()
                    {
                        Title = "Invoice",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    },
                    new SidebarMenuViewModel()
                    {
                        Title = "Profile",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    },
                    new SidebarMenuViewModel()
                    {
                        Title = "E-commerce",
                        Class = "far fa-circle nav-icon",
                        Url = new DataUrl("Index", "Home", "Admin")
                    }
                }
            });

            return result;
        }
        private IList<SidebarMenuViewModel> GetMiscellaneousMenu()
        {
            IList<SidebarMenuViewModel> result = new List<SidebarMenuViewModel>();
            result.Add(new SidebarMenuViewModel() { IsHeader = true, Title = "MISCELLANEOUS" });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Tabbed IFrame Plugin",
                Class = "nav-icon fas fa-ellipsis-h",
                Url = new DataUrl("Index", "Home", "Admin")
            });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Documentation",
                Class = "nav-icon fas fa-file",
                //Url = new DataUrl("Index", "Home", "Admin")
                Url = new DataUrl("https://adminlte.io/docs/3.1/")
            });
            return result;
        }
        private IList<SidebarMenuViewModel> GetLabelMenu()
        {
            IList<SidebarMenuViewModel> result = new List<SidebarMenuViewModel>();
            result.Add(new SidebarMenuViewModel() { IsHeader = true, Title = "LABELS" });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Important",
                Class = "nav-icon far fa-circle text-danger",
                Url = new DataUrl("Index", "Home", "Admin")
            });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Warning",
                Class = "nav-icon far fa-circle text-warning",
                Url = new DataUrl("Index", "Home", "Admin")
            });
            result.Add(new SidebarMenuViewModel()
            {
                Title = "Informational",
                Class = "nav-icon far fa-circle text-info",
                Url = new DataUrl("Index", "Home", "Admin")
            });
            return result;
        }
    }
}