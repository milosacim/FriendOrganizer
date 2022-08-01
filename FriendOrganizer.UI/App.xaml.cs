using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            IServiceProvider serviceProvider = CreateServiceProvider();
            //Window window = new MainWindow(
            //    new MainViewModel(
            //        new FriendDataService()));
            Window window = serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<FriendOrganizerDbContextFactory>();

            services.AddSingleton<MainViewModel>();
            services.AddSingleton<INavigationViewModel, NavigationViewModel>();

            services.AddSingleton<IFriendDataService, FriendDataService> ();
            services.AddSingleton<IFriendLookupDataService, LookupDataService> ();
            services.AddSingleton<IFriendDetailViewModel, FriendDetailViewModel> ();

            services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            services.AddSingleton<IEventAggregator, EventAggregator>();

            return services.BuildServiceProvider();
        }
    }
}
