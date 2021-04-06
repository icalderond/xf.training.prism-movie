using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PrismMovie.Helpers;
using PrismMovie.Models;

namespace PrismMovie.Services
{
    public class TheMovieDBService
    {
        private HttpClientBase _HttpClientBase;
        public HttpClientBase HttpClientBase
        {
            get => _HttpClientBase = _HttpClientBase ?? new HttpClientBase();
        }

        public async Task<List<Movie>> SearchMovie(string _query)
        {
            try
            {
                var results = new List<Movie>();

                var queryString = APIMethods.ServerTheMovieDB
                    + APIMethods.SearchMovie
                    + APIMethods.SearchMovieParams
                    .Replace("{API_KEY}", AppSettings.API_KEY_TMDB)
                    .Replace("{QUERY}", _query);

                var response = await HttpClientBase.GetAsync(queryString);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    JObject jsonParsed = JObject.Parse(responseString);
                    var jsonResult = jsonParsed["results"].ToString();

                    results = JsonConvert.DeserializeObject<List<Movie>>(jsonResult);

                    results.ForEach(x =>
                    {
                        x.BackdropPath = APIMethods.ServerImageBase + x.BackdropPath;
                        x.PosterPath = APIMethods.ServerImageBase + x.PosterPath;
                    });
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
