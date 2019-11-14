using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace FormsPrismAbsoluteUriNavigation.ViewModels
{
    public class FirstPageViewModel : ViewModelBase
    {
        public ICommand NavigateToSecondPageCommand { get; }

        public FirstPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "First Page";

            NavigateToSecondPageCommand = new Command(async () => await NavigateToPageAsync("SecondPage"));
        }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            await Task.Delay(3000); // simulate long data loading
        }
    }
}