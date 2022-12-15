using System;
using Microsoft.EntityFrameworkCore;
using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Database
{
	public class DBAccountDaoImpl: AccountDao
    {
        private readonly OrderDbContext _dbContext;
		public DBAccountDaoImpl(OrderDbContext dbContext)
		{
            _dbContext = dbContext;
		}

        public async Task Delete(string id)
        {
            var account = await _dbContext.Account.FindAsync(Convert.ToInt32(id));

            _dbContext.Remove(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AccountEntity?> GetAccount(string email, string password)
        {

         return await _dbContext.Account.Where(account => account.Email == email && account.Password == password).SingleOrDefaultAsync();
        
        }

        public async Task<List<AccountEntity>> GetAll()
        {
            return await _dbContext.Account.ToListAsync();
        }

        public async Task Insert(AccountEntity data)
        {
            _dbContext.Add(data);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(AccountEntity data)
        {
            _dbContext.Update(data);
           await _dbContext.SaveChangesAsync();
        }
    }
}

