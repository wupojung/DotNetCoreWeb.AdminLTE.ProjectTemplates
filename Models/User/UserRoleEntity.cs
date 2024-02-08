namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Models.User;

public class UserRoleEntity : BaseEntity
{
    public string Name { get; set; }
    public bool Active { get; set; }
}