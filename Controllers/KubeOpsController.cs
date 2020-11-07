using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Microsoft.Extensions.Options;

namespace dotnet_core_web_api.Controllers
{
    [ApiController]
    [Route("/")]
    public class KubeOpsController : ControllerBase
    {
        private Message _options;
        private DB _dbOption;

        public KubeOpsController(IOptions<Message> options, IOptions<DB> dbOptions)
        {
            _options = options.Value;
            _dbOption = dbOptions.Value;
        }

        [HttpGet]
        public String Get()
        {
            return _options.Text + " : "+ _dbOption.DB_URL;
        }
    }

}
