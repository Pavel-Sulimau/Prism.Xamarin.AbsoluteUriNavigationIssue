using FormsPrismAbsoluteUriNavigation.ViewModels;
using Xamarin.Forms;
using FormsPrismAbsoluteUriNavigation.Views;
using Prism.Ioc;

namespace FormsPrismAbsoluteUriNavigation
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<FirstPage, FirstPageViewModel>();
            containerRegistry.RegisterForNavigation<SecondPage, SecondPageViewModel>();
        }
    }
}
