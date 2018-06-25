namespace movierama.models.Movies
{
    public class Publisher
    {
        public int Id { get; }
        public string Name { get; }

        public Publisher(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}