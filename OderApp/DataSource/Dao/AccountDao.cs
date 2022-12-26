using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Dao
{

  public interface AccountDao
    {
        public Task Insert(AccountEntity data);
        public Task<List<AccountEntity>> GetAll();
        public Task Update(AccountEntity data);
        public Task Delete(string id);
        public Task<AccountEntity?> GetAccount(string email, string password);
    }

    public class AccountDaoImpl:AccountDao
    {
        private const string STORE_PATH_FILE = @"D:\InputPackageManagerTestData1.json";

        private readonly FileJsonHandler _fileJsonHandler;
        public AccountDaoImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }
        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<AccountEntity> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountEntity?> GetAccount(string email, string password)
        {
            var accounts = await _fileJsonHandler.readFile<IEnumerable<AccountEntity>>(STORE_PATH_FILE);

          return (from item in accounts where item.Password == password && item.Email == email select item ).SingleOrDefault();

        }

        public async Task<List<AccountEntity>> GetAll()
        {
            return await _fileJsonHandler.readFile<List<AccountEntity>>(STORE_PATH_FILE);
        }

        public async Task Insert(AccountEntity data)
        {
            List<AccountEntity> accounts = await _fileJsonHandler.readFile<List<AccountEntity>>(STORE_PATH_FILE);
            accounts.Add(data);
            await _fileJsonHandler.writeFile(STORE_PATH_FILE, accounts);
        }

        public async Task Update(AccountEntity data)
        {
            List<AccountEntity> accounts = await _fileJsonHandler.readFile<List<AccountEntity>>(STORE_PATH_FILE);
            await _fileJsonHandler.writeFile(STORE_PATH_FILE, accounts);
        }
        
    }
}
