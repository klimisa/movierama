using movierama.models;

namespace movierama.services
{
    public interface IUserService
    {
        User GetUser(int userId);
    }
}