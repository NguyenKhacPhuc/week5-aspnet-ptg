using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database
{
    public class DbConfigurationDao : ConfigurationDao
    {
        private readonly OrderDbContext _dbContext;
        
        public DbConfigurationDao(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ConfigurationEntity> GetConfiguration()
        {
            List<ConfigurationEntity> models = await _dbContext.Configuration.ToListAsync();
            return models.First();

        }
    }
}