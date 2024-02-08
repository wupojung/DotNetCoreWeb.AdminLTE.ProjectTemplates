namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.Areas.Admin.ViewModels;

public class SidebarMenuViewModel
{
    public string Title { get; set; }
    public DataUrl Url { get; set; }
    public string Class { get; set; }
    public bool IsHeader { get; set; } = false;
    public IList<SidebarMenuViewModel> Child { get; set; }
}

public class DataUrl
{
    public DataUrl(string url)
    {
        Url = url;
    }

    public DataUrl(string actionName, string controllerName, string areaName)
    {
        ActionName = actionName;
        ControllerName = controllerName;
        AreaName = areaName;
    }

    /// <summary>
    /// Gets or sets the name of the action.
    /// </summary>
    public string AreaName { get; set; }

    /// <summary>
    /// Gets or sets the name of the action.
    /// </summary>
    public string ActionName { get; set; }

    /// <summary>
    /// Gets or sets the name of the controller.
    /// </summary>
    public string ControllerName { get; set; }

    /// <summary>
    /// Gets or sets the URL.
    /// </summary>
    public string Url { get; set; }

    public string DataId { get; set; }
}