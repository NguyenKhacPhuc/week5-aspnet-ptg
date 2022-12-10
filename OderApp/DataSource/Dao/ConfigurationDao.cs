using OderApp.DataSource.Entities;
using OderApp.Models;

namespace OderApp.DataSource.Dao;

public interface ConfigurationDao
{
    public Task<ConfigurationEntity> GetConfiguration();
}

public class ConfigurationDaoImpl : ConfigurationDao
{
    private readonly FileJsonHandler _fileJsonHandler;
    private const string STORE_PATH_FILE = @"D:\InputPackageManagerTestData1.json";
    public ConfigurationDaoImpl(FileJsonHandler fileJsonHandler)
    {
        _fileJsonHandler = fileJsonHandler;
    }
    
    public async Task<ConfigurationEntity> GetConfiguration()
    {
        return await _fileJsonHandler.readFile<ConfigurationEntity>(STORE_PATH_FILE);
    }
}