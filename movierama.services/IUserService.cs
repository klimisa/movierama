using movierama.models;

namespace movierama.services
{
    public interface IUserService
    {
        User GetUser(int userId);
        void RegisterUser(string firstName, string lastName, string emailAddress, string password);
        User LoginUser(string emailAddress, string password);
    }
}