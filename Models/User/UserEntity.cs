namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Models.User;

public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Nickname { get; set; }
    public string Email { get; set; }
}