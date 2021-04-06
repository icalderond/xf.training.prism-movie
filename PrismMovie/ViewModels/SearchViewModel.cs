using System;
using System.Collections.ObjectModel;
using PrismMovie.Models;
using PrismMovie.Services;
using PrismMovie.Views;

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
        #endregion Properties

        #region Methods
        #endregion Methods

        #region Commands
        private ActionCommand<string> _SearchMovieCommand;
        public ActionCommand<string> SearchMovieCommand
        {
            get => _SearchMovieCommand = _SearchMovieCommand ?? new ActionCommand<string>(async (param) =>
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(param))
                        throw new Exception("Favor de escribir el texto de busqueda");

                    await App.Current.MainPage.Navigation.PushAsync(new MovieResultPage(param));
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Alerta", ex.Message, "Enterado");
                }
            });
        }
        #endregion Commands
    }
}
