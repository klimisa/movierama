namespace movierama.models
{
    public interface IUserRepository
    {
        User GetById(int id);
        User GetByEmailAddress(string emailAddress);
        int Count { get; }
        void Add(User newUser);
    }
}