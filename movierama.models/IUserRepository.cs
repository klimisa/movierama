namespace movierama.models
{
    public interface IUserRepository
    {
        User GetById(int id);
    }
}