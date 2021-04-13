namespace PrismMovie.Helpers
{
    public class APIMethods
    {
        public const string ServerTheMovieDB = "https://api.themoviedb.org/3/";
        public const string ServerImageBase = "https://image.tmdb.org/t/p/w500/";
        public const string SearchMovie = "search/movie";
        public const string SearchMovieParams = "?api_key={API_KEY}&language=en-US&query={QUERY}&page=1&include_adult=false";
    }
}
