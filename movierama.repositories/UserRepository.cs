using System.Collections.Generic;
using System.Linq;
using movierama.models;

namespace movierama.repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> Users = new List<User>
        {
            new User {Id = 1, Name = "Jaime Lannister"},
            new User {Id = 2, Name = "Theon Greyjoy"},
            new User {Id = 3, Name = "Eddard Stark"},
            new User {Id = 4, Name = "Jon Snow"}
        };

        public User GetById(int id)
        {
            return Users.FirstOrDefault(user => user.Id == id);
        }
    }
}