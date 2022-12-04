using OderApp.Models;
using OderApp.DataSource;
using OderApp.DataSource.Entities;
using OderApp.DataSource.Dao;
namespace OderApp.Repositories
{
    public interface IAccountRepository
    {
        public Task<AccountEntity?> getAccount(string email, string password);
    }
    public class AccountRepositoryImpl : IAccountRepository
    {
   
        private readonly AccountDao _accountDao;
        public AccountRepositoryImpl(AccountDao accountDao)
        {
            _accountDao = accountDao;
        }
        public async Task<AccountEntity?> getAccount(string email, string password)
        {
            return await _accountDao.GetAccount(email, password);
        }
    }
}
