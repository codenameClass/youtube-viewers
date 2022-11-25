using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YouTubeViewers.DataLayerProvider;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;
using YouTubeViewers.WPF.HostBuilders;
using Microsoft.EntityFrameworkCore;
using YouTubeViewers.Domain.Interfaces;
using AdresbeheerMDBlayer.Repositories;
using YouTubeViewers.EFLayer;
using System.Xml.Linq;

namespace YouTubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private RepositoryType type;
        public App()
        {
            _host = Host.CreateDefaultBuilder()
                .AddDbContext()
                .ConfigureServices((context, services) =>
                {


                    /*
                        AddSingleton is called twice with IMyDependency as the service type.
                        The second call to AddSingleton overrides the previous one when resolved as IMyDependency 
                        and adds to the previous one when multiple services are resolved via IEnumerable<IMyDependency>.
                        source: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0
                     */
                    string datalayer = System.Configuration.ConfigurationManager.AppSettings["DataLayer"];

                    type = datalayer == "EFC" ? RepositoryType.EFCore : RepositoryType.MDB;

                    if (type == RepositoryType.EFCore)
                    {
                        services.AddSingleton<IYouTubeViewerRepository, YoutubeViewerRepositoryEF>();

                    }
                    else
                    {
                        //...
                    }

                    //Dependency injection

                    //Singleton lifetime services are created the first time they are requested (or when ConfigureServices is run if you specify an instance there) and then every subsequent request will use the same instance
                    services.AddSingleton<ModalNavigationStore>();
                    services.AddSingleton<YouTubeViewersStore>();
                    services.AddSingleton<SelectedYouTubeViewerStore>();

                    //Transient lifetime services are created each time they are requested. This lifetime works best for lightweight, stateless services
                    services.AddTransient<YouTubeViewersViewModel>(CreateYouTubeViewersViewModel);
                    services.AddSingleton<MainViewModel>();

                    services.AddSingleton<MainWindow>((services) => new MainWindow()
                    {
                        DataContext = services.GetRequiredService<MainViewModel>()
                    });
                })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            if (type == RepositoryType.EFCore)
            {
                YouTubeViewersDbContextEFFactory youTubeViewersDbContextFactory =
                    _host.Services.GetRequiredService<YouTubeViewersDbContextEFFactory>();
                using (YouTubeViewersDbContextEF context = youTubeViewersDbContextFactory.Create())
                {
                    context.Database.Migrate();
                }
            }
            else
            {
                //...
            }
     

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }

        private YouTubeViewersViewModel CreateYouTubeViewersViewModel(IServiceProvider services)
        {
            return YouTubeViewersViewModel.LoadViewModel(
                services.GetRequiredService<YouTubeViewersStore>(),
                services.GetRequiredService<SelectedYouTubeViewerStore>(),
                services.GetRequiredService<ModalNavigationStore>());
        }
    }
}
