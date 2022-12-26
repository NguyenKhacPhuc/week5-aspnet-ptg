using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database
{
    public class DBUserDaoImpl : UserDao
    {
        private readonly OrderDbContext _dbContext;
        public DBUserDaoImpl(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<UserEntity?> UpdateUser(UserEntity data)
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(UserEntity data)
        {
            _dbContext.User.Add(data);
            await _dbContext.SaveChangesAsync();
        }
    }
}