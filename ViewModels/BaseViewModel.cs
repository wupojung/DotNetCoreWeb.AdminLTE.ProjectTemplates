using System.ComponentModel;
using Newtonsoft.Json;

namespace DotNetCoreWeb.AdminLTE.ProjectTemplates.ViewModels;

public class BaseViewModel
{
    [DisplayName("Id")]
    [JsonProperty(Order = -99999)]
    public int Id { get; set; }

    [DisplayName("Created Date")]
    [JsonProperty(Order = 1)]
    public DateTime CreatedAt { get; set; }

    [DisplayName("Created")]
    [JsonProperty(Order = 2)]
    public int CreatedBy { get; set; }

    [DisplayName("Modified Date")]
    [JsonProperty(Order = 3)]
    public DateTime ModifiedAt { get; set; }

    [DisplayName("Modifier")]
    [JsonProperty(Order = 4)]
    public int ModifiedBy { get; set; }
}