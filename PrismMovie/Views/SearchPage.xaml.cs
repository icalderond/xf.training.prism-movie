using PrismMovie.ViewModels;
using Xamarin.Forms;

namespace PrismMovie.Views
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            this.BindingContext = new SearchViewModel();
        }
    }
}
