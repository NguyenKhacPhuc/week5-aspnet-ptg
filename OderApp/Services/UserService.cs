using System;
using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;
using OderApp.Services;

namespace OderApp.Services
{
    public interface UserService
    {
        public Task<User> UpdateUser(User user);
    }
    public class UserServiceImpl : UserService
    {
        private readonly IUserRepository _userRespository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRespository = userRepository;
        }

        public async Task<User> UpdateUser(User user)
        {
            return (await _userRespository.UpdateUser(user.ConvertToUserEntity())).ConvertToUser();
        }
    }
}

