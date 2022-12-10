using System.Net;
using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;

namespace OderApp.Services;

public interface ConfigurationService
{
    public Task<Result<Configuration>> GetConfiguration();
}

public class ConfigurationServiceImpl : ConfigurationService
{
    private readonly IConfigurationRepository _configurationRepository;

    public ConfigurationServiceImpl(IConfigurationRepository configurationRepository)
    {
        _configurationRepository = configurationRepository;
    }

    public async Task<Result<Configuration>> GetConfiguration()
    {
        var configurationEntity = await _configurationRepository.GetConfiguration();
        var configuration = configurationEntity.ConvertToConfiguration();
        return new Result<Configuration>(HttpStatusCode.Accepted, configuration, "success");
    }
}