using Microsoft.AspNetCore.Mvc;
using OderApp.Models;
using OderApp.Services;
using System.Net;

namespace OderApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigurationController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

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

            return result.Data;
        }
    }
}