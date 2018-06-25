using System.Collections.Generic;
using System.Linq;
using movierama.models;
using movierama.models.Account;

namespace movierama.repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User {Id = 1, FirstName = "Jaime", LastName = "Lannister", EmailAddress = "l@wa.com"},
            new User {Id = 2, FirstName = "Theon", LastName = "Greyjoy", EmailAddress = "g@wa.com"},
            new User {Id = 3, FirstName = "Eddard", LastName = "Stark", EmailAddress = "s@wa.com"},
            new User {Id = 4, FirstName = "Jon", LastName = "Snow", EmailAddress = "sn@wa.com"}
        };

        public User GetById(int id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }

        public User GetByEmailAddress(string emailAddress)
        {
            return Users.FirstOrDefault(user => user.EmailAddress == emailAddress);
        }

        public int Count => Users.Count;

        public void Add(User newUser)
        {
            Users.Add(newUser);
        }
    }
}