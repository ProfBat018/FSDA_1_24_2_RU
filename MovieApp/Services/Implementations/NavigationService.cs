using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MovieApp.Messages;
using MovieApp.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Implementations;

class NavigationService : INavigationService
{
    private readonly IMessenger _messenger;

    public NavigationService(IMessenger messenger)
    {
        _messenger = messenger;
    }

    public void NavigateTo<T>() where T : ViewModelBase
    {
        _messenger.Send(new NavigationMessage()
        {
            ViewModelType = App.Container.GetInstance<T>()
        });
    }
}
