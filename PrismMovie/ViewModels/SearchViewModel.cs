using System;
using System.Collections.ObjectModel;
using PrismMovie.Models;
using PrismMovie.Services;

namespace PrismMovie.ViewModels
{
    public class SearchViewModel : BindableBase
    {
        #region Constructor
        public SearchViewModel()
        {
        }
        #endregion Constructor

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

        #region Commands
        private ActionCommand<string> _SearchMovieCommand;
        public ActionCommand<string> SearchMovieCommand
        {
            get => _SearchMovieCommand = _SearchMovieCommand ?? new ActionCommand<string>((param) => SearchMovieAsync(param));
        }
        #endregion Commands
    }
}
