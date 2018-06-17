using movierama.models;
using movierama.repositories;

namespace movierama.services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(): this(new UserRepository())
        {
            
        }
        
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public User GetUser(int userId)
        {
            return _userRepository.GetById(userId);
        }
    }
}