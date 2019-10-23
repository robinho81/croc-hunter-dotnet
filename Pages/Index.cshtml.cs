using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;
using System.Runtime.Versioning;

namespace croc_hunter_dotnet.Pages
{
  public class IndexModel : PageModel
  {
    public string Hostname {get; set;}
    public string PoweredBy {get; set;}
    public void OnGet()
    {
      Hostname = System.Environment.MachineName;
      PoweredBy = Assembly.GetEntryAssembly()?.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName;
    }
  }
}
