using System.Threading.Tasks;
using Prism.Navigation;

namespace FormsPrismAbsoluteUriNavigation.ViewModels
{
    public class SecondPageViewModel : ViewModelBase
    {
        public SecondPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Second Page";
        }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            await Task.Delay(500); // simulate data loading
        }
    }
}
