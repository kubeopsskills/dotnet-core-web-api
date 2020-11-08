using System;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace dotnet_core_web_api.Controllers
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
