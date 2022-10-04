using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raider.Domain.Entities;
using Raider.Wpf.Persistence;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;
using System.Windows;

namespace Raider.Wpf
{
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<RaiderDbContext>(options => options.UseSqlite("DataSource=Data\\Raider.db"));

                    services.AddScoped<NavigationStore>();
                    services.AddScoped<MainWindow>();
                    services.AddScoped<MainViewModel>();

                    // Data Services Registration
                    services.AddTransient(typeof(IDataService<>), typeof(DataService<>));
                    services.AddTransient<IRaidDataService, RaidDataService>();
                    services.AddTransient<IRaidSetupMapDataService, RaidSetupMapDataService>();

                    // Navigation Services Registration
                    services.AddTransient(serviceProvider => new NavigationService<AddClassViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<AddClassViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<AddRaidViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<AddRaidViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<AddRoleViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<AddRoleViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<AddSpecialisationViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<AddSpecialisationViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<AddSetupViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<AddSetupViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<ClassesViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<ClassesViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<RaidsViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<RaidsViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<RolesViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<RolesViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<SpecialisationsViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<SpecialisationsViewModel>()));

                    services.AddTransient(serviceProvider => new NavigationService<SetupsViewModel>(
                        serviceProvider.GetRequiredService<NavigationStore>(),
                        () => serviceProvider.GetRequiredService<SetupsViewModel>()));

                    // ViewModels Services Registration
                    services.AddTransient<DashboardViewModel>();
                    services.AddTransient<MembersViewModel>();
                    services.AddTransient<EventsViewModel>();
                    services.AddTransient<SetupsViewModel>();

                    services.AddTransient(serviceProvider => new ClassesViewModel(
                        serviceProvider.GetRequiredService<NavigationService<AddClassViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Class>>()));

                    services.AddTransient(serviceProvider => new SpecialisationsViewModel(
                        serviceProvider.GetRequiredService<NavigationService<AddSpecialisationViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Specialisation>>()));

                    services.AddTransient(serviceProvider => new RolesViewModel(
                        serviceProvider.GetRequiredService<NavigationService<AddRoleViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Role>>()));

                    services.AddTransient(serviceProvider => new RaidsViewModel(
                        serviceProvider.GetRequiredService<NavigationService<AddRaidViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Raid>>()));

                    // ViewModels Childs Services Registration
                    services.AddTransient(serviceProvider => new AddClassViewModel(
                        serviceProvider.GetRequiredService<NavigationService<ClassesViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Class>>()));

                    services.AddTransient(serviceProvider => new AddSpecialisationViewModel(
                        serviceProvider.GetRequiredService<NavigationService<SpecialisationsViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Specialisation>>(),
                        serviceProvider.GetRequiredService<IDataService<Class>>(),
                        serviceProvider.GetRequiredService<IDataService<Role>>()));

                    services.AddTransient(serviceProvider => new AddRoleViewModel(
                        serviceProvider.GetRequiredService<NavigationService<RolesViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Role>>()));

                    services.AddTransient(serviceProvider => new AddRaidViewModel(
                        serviceProvider.GetRequiredService<NavigationService<RaidsViewModel>>(),
                        serviceProvider.GetRequiredService<IDataService<Raid>>()));

                    services.AddTransient<AddSetupViewModel>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            MainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            MainWindow.Resources.MergedDictionaries.Add(this.Resources);

            var dataContext = AppHost.Services.GetRequiredService<MainViewModel>();
            dataContext.RequestClose += CloseApplication;

            MainWindow.DataContext = dataContext;

            MainWindow.Show();

            base.OnStartup(e);
        }

        private void CloseApplication()
        {
            MainWindow.Close();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            
            base.OnExit(e);
        }
    }
}