using KoleServis.Core;
using KoleServis.MVVM.View;
using KoleServis.MVVM.ViewModel;
using KoleServis.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace KoleServis
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            
            services.AddSingleton<ManagerMainViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<BillsViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<ServicesViewModel>();
            services.AddSingleton<WorkersViewModel>();
            services.AddSingleton<ItemsViewModel>();
            services.AddSingleton<ItemComponentViewModel>();
            services.AddSingleton<WorkerMainViewModel>();
            services.AddSingleton<CreateBillViewModel>();


            services.AddSingleton<INavigationService, NavigationService>();

            services.AddSingleton<Func<Type, ViewModel>>(serviceProvider =>
            {
                return viewModelType =>
                {
                    return (ViewModel)serviceProvider.GetRequiredService(viewModelType);
                };
            });


            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            var navigationService = _serviceProvider.GetRequiredService<INavigationService>();
            //navigationService.NavigateTo<LoginViewModel>(false);
            navigationService.NavigateTo<WorkerMainViewModel>(false);

            mainWindow.Show();
        }
    }

}
