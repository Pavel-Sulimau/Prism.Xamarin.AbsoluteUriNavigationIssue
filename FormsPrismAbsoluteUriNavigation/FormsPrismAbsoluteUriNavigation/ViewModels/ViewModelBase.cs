using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace FormsPrismAbsoluteUriNavigation.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, IInitializeAsync, INavigationAware, IDestructible
    {
        private string _title;
        private bool _isBusy;
        private string _navigationResult;

        public string NavigationResult
        {
            get => _navigationResult;
            set => SetProperty(ref _navigationResult, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        protected INavigationService NavigationService { get; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {
        }

        public virtual Task InitializeAsync(INavigationParameters parameters)
        {
            return Task.CompletedTask;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public virtual void Destroy()
        {
        }

        protected async Task NavigateToPageAsync(string pageName)
        {
            NavigationResult = "Navigation started...";

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            INavigationResult navigationResult;
            try
            {
                IsBusy = true;
                navigationResult = await NavigationService.NavigateAsync(pageName);
            }
            finally
            {
                stopwatch.Start();
                IsBusy = false;
            }

            if (navigationResult?.Success ?? false)
            {
                NavigationResult = $"Navigation succeded in {stopwatch.ElapsedMilliseconds / 1000} seconds.";
            }
            else if (navigationResult?.Exception != null)
            {
                NavigationResult = $"Navigation failed with {navigationResult.Exception.Message}.";
            }
        }
    }
}
