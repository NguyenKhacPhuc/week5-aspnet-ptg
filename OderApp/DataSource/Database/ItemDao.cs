using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database
{
    public class DbItemDao : ItemDao
    {
        private readonly OrderDbContext _dbContext;

        public DbItemDao(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Delete(string id)
        {
            var item = await _dbContext.Item.FindAsync(Convert.ToInt32(id));
            _dbContext.Item.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ItemEntity>> GetAll()
        {
            return await _dbContext.Item.ToListAsync();
        }

        public async Task Insert(ItemEntity data)
        {
            _dbContext.Item.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ItemEntity data)
        {
            _dbContext.Item.Add(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}
