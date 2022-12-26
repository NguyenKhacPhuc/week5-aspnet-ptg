using OderApp.DataSource.Dao;
using OderApp.DataSource.Entities;

namespace OderApp.Repositories
{
    public interface IUserRepository
    {
        public Task<UserEntity?> UpdateUser(UserEntity user);
    }

    public class UserRepositoryImpl : IUserRepository
    {
        private readonly UserDao _userDao;

        public UserRepositoryImpl(UserDao userDao)
        {
            _userDao = userDao;
        }

        public async Task<UserEntity?> UpdateUser(UserEntity user)
        {
            return await _userDao.UpdateUser(user);
        }
    }
}

