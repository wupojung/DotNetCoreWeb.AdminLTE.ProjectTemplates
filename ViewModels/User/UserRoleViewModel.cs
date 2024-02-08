using System.ComponentModel;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.User;

public class UserRoleViewModel : BaseViewModel
{
    [DisplayName("Role Name")] public string Name { get; set; }

    [DisplayName("Active")] public bool Active { get; set; }
}