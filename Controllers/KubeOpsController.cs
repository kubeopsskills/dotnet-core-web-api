using DotNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetCoreWebAPI.Controllers
{
    public class KubeOpsController
    {
       async public static void Get(HttpContext http){
          var apiService = http.RequestServices.GetRequiredService<APIService>();
          await http.Response.WriteAsync(apiService.ConnectionToDatabase());
       }
    }

}
