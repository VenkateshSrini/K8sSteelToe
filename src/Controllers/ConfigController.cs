using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace k8sConfigs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly IConfiguration _configuration;
        private IKubernetes _kubernetesClient;
        public ConfigController(ILogger<ConfigController> logger, IConfiguration configuration,
            IKubernetes kubernetesClient)
        {
            _logger = logger;
            _configuration = configuration;
            _kubernetesClient = kubernetesClient;


        }
        [HttpGet]
        [Route("secrets")]
        public ActionResult<List<string>>GetSecrets()
        {
             string _connectionString;
            var dbconfig = _configuration["Database:config"];
            _connectionString = _configuration[dbconfig];
           
            var retrunList = new List<string> { _connectionString };
            return retrunList;
        }
        [HttpGet]
        [Route("configmap")]
        public ActionResult<string> GetConfigMap()
        {
            return _configuration["Logging:LogLevel:Default"];         
        }
    }
}
