using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace FormsPrismAbsoluteUriNavigation.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand NavigateToFirstPageCommand { get; }

        public ICommand NavigateToSecondPageThroughFirstPageCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            NavigateToFirstPageCommand = new Command(
                async () => await NavigateToPageAsync("FirstPage"));
            NavigateToSecondPageThroughFirstPageCommand = new Command(
                async () => await NavigateToPageAsync("FirstPage/SecondPage"));
        }
    }
}
