using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MovieApp.Messages;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.ViewModels;

class MainViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    private readonly IMessenger _messenger;
    private ViewModelBase currentView;

    public MainViewModel(INavigationService navigationService, IMessenger messenger)
    {
        CurrentView = App.Container.GetInstance<HomeViewModel>();

        _navigationService = navigationService;
        _messenger = messenger;

        _messenger.Register<NavigationMessage>(this, message =>
        {
            CurrentView = message.ViewModelType;
        });
    }

    public ViewModelBase CurrentView
    {
        get => currentView;
        set => Set(ref currentView, value); 
    }
}
