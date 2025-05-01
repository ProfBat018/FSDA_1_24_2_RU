using GalaSoft.MvvmLight.Messaging;
using MovieApp.Services.Abstractions;
using MovieApp.Services.Implementations;
using MovieApp.ViewModels;
using MovieApp.Views;
using SimpleInjector;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MovieApp;

public partial class App : Application
{
    public static Container Container { get; set; }

    void Register()
    {
        Container = new();


        Container.RegisterSingleton<IMessenger, Messenger>();
        Container.RegisterSingleton<INavigationService, NavigationService>(); 

        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<InfoViewModel>();
        Container.RegisterSingleton<HomeViewModel>();

        Container.Verify();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        Register();

        var window = new MainView();
        window.DataContext = Container.GetInstance<MainViewModel>();

        window.ShowDialog();
    }
}

