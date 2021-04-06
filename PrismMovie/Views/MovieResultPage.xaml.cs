using System;
using System.Collections.Generic;
using PrismMovie.ViewModels;
using Xamarin.Forms;

namespace PrismMovie.Views
{
    public partial class MovieResultPage : ContentPage
    {
        public MovieResultPage(string _query)
        {
            InitializeComponent();
            this.BindingContext = new MovieResultViewModel(_query);
        }
    }
}
