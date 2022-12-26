using OderApp.Helper;
using OderApp.Models;
using OderApp.Repositories;


namespace OderApp.Services
{
    public interface UserService
    {
        public Task<User> UpdateUser(User user);
    }
    public class UserServiceImpl : UserService
    {
        private readonly IUserRepository _userRepository;

        public UserServiceImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> UpdateUser(User user)
        {
            return (await _userRepository.UpdateUser(user.ConvertToUserEntity()) ??
                    throw new InvalidOperationException())
                .ConvertToUserModel();
        }
    }
}

