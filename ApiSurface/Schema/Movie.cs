namespace ApiSurface.Schema
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public float Rating { get; set; }

        public string Summary { get; set; }

        [GraphQLName("actors")]
        public Task<IEnumerable<Actor>> GetActorsAsync()
        {
            return Task.FromResult(Enumerable.Empty<Actor>());
        }
    }
}
