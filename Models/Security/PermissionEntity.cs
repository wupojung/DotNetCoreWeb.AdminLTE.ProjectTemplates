namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Models.Security;

public class PermissionEntity : BaseEntity
{
    public string Name { get; set; }
    public string SystemName { get; set; }
    public string Category { get; set; }
}