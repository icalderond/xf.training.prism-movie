using System;
using System.Collections.ObjectModel;
using PrismMovie.Models;
using PrismMovie.Services;

namespace PrismMovie.ViewModels
{
    public class MovieResultViewModel : BindableBase
    {
        public MovieResultViewModel(string _query)
        {
            SearchMovieAsync(_query);
        }

        #region Properties
        private TheMovieDBService _TheMovieDBService;
        public TheMovieDBService TheMovieDBService
        {
            get => _TheMovieDBService = _TheMovieDBService ?? new TheMovieDBService();
        }

        private ObservableCollection<Movie> _MovieList;
        public ObservableCollection<Movie> MovieList
        {
            get => _MovieList;
            set => SetProperty(ref _MovieList, value);
        }

        #endregion Properties

        #region Methods
        public async void SearchMovieAsync(string _param)
        {
            try
            {
                var movies = await TheMovieDBService.SearchMovie(_param);
                MovieList = new ObservableCollection<Movie>(movies);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion Methods
    }
}
