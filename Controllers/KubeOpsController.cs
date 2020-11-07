using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//     WebHost.CreateDefaultBuilder(args)
//         .ConfigureAppConfiguration(c =>
//         {
//            c.AddJsonFile("config/appsettings.json", optional: true, reloadOnChange: true);
//         })
//         .UseStartup<Startup>();

namespace dotnet_core_web_api.Controllers
{
    [ApiController]
    [Route("/")]
    public class KubeOpsController : ControllerBase
    {
        private readonly ILogger<KubeOpsController> _logger;

        public KubeOpsController(ILogger<KubeOpsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public String Get()
        {
            return "Hello KubeOps Skills Dotnet Core !!";
        }
    }
}
