using Prism;
using Prism.Ioc;
using Prism.Unity;
using PrismMovie.Helpers;
using PrismMovie.ViewModels;
using PrismMovie.Views;
using Xamarin.Forms;

namespace PrismMovie
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            NavigationService.NavigateAsync($"{Pages.NavigationPage}/{Pages.Search}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>(Pages.Search);
            containerRegistry.RegisterForNavigation<MovieResultPage, MovieResultViewModel>(Pages.MovieResult);
        }
    }
}
