using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prism.Events;
using System;
using System.Configuration;
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

            services.AddDbContext<FriendOrganizerDbContext>(options =>
                 options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FriendOrganizer;Integrated Security=True"),
                 ServiceLifetime.Transient);

            services.AddScoped<MainViewModel>();
            services.AddSingleton<INavigationViewModel, NavigationViewModel>();
            services.AddSingleton<IEventAggregator, EventAggregator>();

            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IFriendLookupDataService, LookupDataService>();
            services.AddTransient<IFriendDetailViewModel, FriendDetailViewModel>();
            services.AddTransient<Func<IFriendDetailViewModel>>(s => () => s.GetService<IFriendDetailViewModel>());

            services.AddScoped(s => new MainWindow(s.GetRequiredService<MainViewModel>()));

            return services.BuildServiceProvider();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured. Please inform the admin." + Environment.NewLine + e.Exception.Message, "Unexpected error");
            e.Handled = true;
        }


    }
}
