namespace movierama.models.Movies
{
    public class Author
    {
        public int Id { get; }
        public string Name { get; }

        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}