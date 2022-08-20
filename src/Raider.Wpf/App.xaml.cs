﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Raider.Wpf.Persistence;
using Raider.Wpf.Services;
using Raider.Wpf.Store;
using Raider.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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

                    services.AddSingleton<INavigator, Navigator>();
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainViewModel>();

                    services.AddTransient<IClassDataService, ClassDataService>();
                    services.AddTransient<ISpecialisationDataService, SpecialisationDataService>();
                    services.AddTransient<IRoleDataService, RoleDataService>();
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