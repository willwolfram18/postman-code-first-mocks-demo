namespace DownstreamApi.Models
{
    /// <summary>
    /// Details about a particular movie.
    /// </summary>
    public class Movie
    {
        public int Id { get; set; }

        /// <summary>
        /// The title of the movie.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The rating of the movie. Ratings use a scale of 0 to 5, where the
        /// rating indicates how many stars for the movie.
        /// </summary>
        public float Rating { get; set; }

        /// <summary>
        /// An brief explanation of what the movie is about.
        /// </summary>
        public string Description { get; set; }
    }
}
