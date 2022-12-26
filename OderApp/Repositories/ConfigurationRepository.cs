using OderApp.DataSource.Entities;
using OderApp.DataSource.Dao;

namespace OderApp.Repositories
{
    public interface IConfigurationRepository
    {
        public Task<ConfigurationEntity?> GetConfiguration();
    }
    public class ConfigurationRepositoryImpl : IConfigurationRepository
    {
   
        private readonly ConfigurationDao _configurationDao;
        public ConfigurationRepositoryImpl(ConfigurationDao configurationDao)
        {
            _configurationDao = configurationDao;
        }


        public async Task<ConfigurationEntity?> GetConfiguration()
        {
            return await _configurationDao.GetConfiguration();
        }
    }
}