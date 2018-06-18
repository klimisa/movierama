using System;
using movierama.infrastructure.security;
using movierama.models;
using movierama.repositories;

namespace movierama.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService() : this(new UserRepository())
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

        public void RegisterUser(string firstName, string lastName, string emailAddress, string password)
        {
            var user = _userRepository.GetByEmailAddress(emailAddress);
            if (user != null)
            {
                throw new InvalidOperationException("User already registered.");
            }

            var salt = SecurityHelper.GetSalt();
            var saltedPassword = salt + password;
            var hash = PasswordStorage.CreateHash(saltedPassword);
            var newUser = new User
            {
                Id = _userRepository.Count + 1,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress,
                Password = hash,
                Salt = salt
            };

            _userRepository.Add(newUser);
        }

        public User LoginUser(string emailAddress, string password)
        {
            
            var user = _userRepository.GetByEmailAddress(emailAddress);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var saltedPassword = user.Salt + password;
            if (PasswordStorage.VerifyPassword(saltedPassword, user.Password))
            {
                return user;
            }

            throw new InvalidOperationException("User not found.");
        }
    }
}