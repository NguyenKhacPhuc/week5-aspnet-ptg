using OderApp.DataSource.Entities;

namespace OderApp.DataSource.Dao
{
    public interface UserDao
    {
        public Task<UserEntity?> UpdateUser(UserEntity data);

        public Task AddUser(UserEntity data);
    }

    public class UserDaoImpl : UserDao
    {
        private const string STORE_PATH_FILE = @"D:\InputPackageManagerTestData1.json";

        private readonly FileJsonHandler _fileJsonHandler;

        public UserDaoImpl(FileJsonHandler fileJsonHandler)
        {
            _fileJsonHandler = fileJsonHandler;
        }

        public async Task<UserEntity?> UpdateUser(UserEntity data)
        {
            var users = (await _fileJsonHandler.readFile<IEnumerable<UserEntity>>(STORE_PATH_FILE)).ToList();
            if (users.Any(p => p.Id.Equals(data.Id)))
            {
                users.RemoveAt(users.FindIndex(p => p.Id.Equals(data.Id)));
                users.Add(data);
                await _fileJsonHandler.writeFile(STORE_PATH_FILE, users);
                return data;
            }

            return null;
        }

        public Task AddUser(UserEntity data)
        {
            throw new NotImplementedException();
        }
    }
}

