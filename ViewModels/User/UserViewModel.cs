using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels.User;

public class UserViewModel : BaseViewModel
{
    [DisplayName("Username")] public string Username { get; set; }

    [ValidateNever]
    [DisplayName("Password")]
    public string Password { get; set; }

    [DisplayName("Name")] public string Name { get; set; }

    [DisplayName("Nickname")] public string Nickname { get; set; }

    [DisplayName("E-mail")] public string Email { get; set; }

    [ValidateNever]
    [DisplayName("Role List")]
    public IList<UserRoleViewModel>? RoleList { get; set; }

    public UserViewModel()
    {
        this.RoleList = new List<UserRoleViewModel>();
    }
}