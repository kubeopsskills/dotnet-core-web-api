using System;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebAPI.Services;

namespace DotNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class KubeOpsController : ControllerBase
    {
        private readonly APIService _apiService;

        public KubeOpsController(APIService apiService)
        {
           _apiService = apiService;
        }

        [HttpGet]
        public String Get()
        {
            return _apiService.ConnectionToDatabase();
        }
    }

}
