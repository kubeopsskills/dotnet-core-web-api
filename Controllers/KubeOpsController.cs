using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWebAPI.Controllers
{
    public class KubeOpsController
    {
       public static async Task Get(HttpContext http){
          var apiService = http.RequestServices.GetRequiredService<APIService>();
          await http.Response.WriteAsync(apiService.ConnectionToDatabase());
       }
    }

}
