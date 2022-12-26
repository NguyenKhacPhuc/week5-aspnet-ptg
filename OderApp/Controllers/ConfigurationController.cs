using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        
        private readonly ILogger<ConfigurationController> _logger;
        private readonly ConfigurationService _configurationService;

        public ConfigurationController(ILogger<ConfigurationController> logger, ConfigurationService configurationService)
        {
            _logger = logger;
            _configurationService = configurationService;
        }

        [HttpGet(Name = "GetConfiguration")]
        public async Task<Configuration> GetConfiguration()
        {
            var result = await _configurationService.GetConfiguration();

            return result.Data ?? throw new InvalidOperationException();
        }
    }
}