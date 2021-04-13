using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismMovie.Helpers;

namespace PrismMovie.ViewModels
{
    public class SearchViewModel : BindableBase
    {
        #region Constructor
        public SearchViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
            SearchMovieCommand = new DelegateCommand<string>(SearchMovie);
        }
        #endregion Constructor

        #region Properties
        INavigationService _navigationService;
        #endregion Properties

        #region Methods
        private async void SearchMovie(string param)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(param))
                    throw new Exception("Favor de escribir el texto de busqueda");

                NavigationParameters keyValuePairs = new NavigationParameters();
                keyValuePairs.Add("query", param);
                await _navigationService.NavigateAsync(Pages.MovieResult, keyValuePairs);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Enterado");
            }
        }
        #endregion Methods

        #region Commands
        public DelegateCommand<string> SearchMovieCommand { get; }
        #endregion Commands
    }
}
