namespace ApiSurface.Schema
{
    public class Query
    {
        [GraphQLName("movies")]
        public Task<IEnumerable<Movie>> GetMovies()
        {
            return Task.FromResult(Enumerable.Empty<Movie>());
        }

        [GraphQLName("movie")]
        public Task<Movie?> GetMovie(int id)
        {
            return Task.FromResult<Movie?>(null);
        }

        [GraphQLName("actors")]
        public Task<IEnumerable<Actor>> GetActors()
        {
            return Task.FromResult(Enumerable.Empty<Actor>());
        }

        [GraphQLName("actor")]
        public Task<Actor?> GetActor(int id)
        {
            return Task.FromResult<Actor?>(null);
        }
    }
}
