using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPFRepetition.Helpers;
using WPFRepetition.Managers;
using WPFRepetition.ViewModels;
using WPFRepetition.Views;

namespace WPFRepetition;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost AppHost { get; private set; }
    
    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<INavigationManager, NavigationManager>();
                services.AddScoped<IDataManager, DataManager>();

                services.AddViewModelFactory<RootViewModel>();
                services.AddViewModelFactory<LeftViewModel>();
                services.AddViewModelFactory<RightViewModel>();
                services.AddViewModelFactory<CenterViewModel>();

                services.AddSingleton<RootWindow>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();
        
        var rootWindow = AppHost.Services.GetRequiredService<RootWindow>();
        rootWindow.DataContext = AppHost.Services.GetRequiredService<RootViewModel>();
        rootWindow.Show();

        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        base.OnExit(e);
    }
}