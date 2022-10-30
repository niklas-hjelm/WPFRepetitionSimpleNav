using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFRepetition.Managers;

class NavigationManager : INavigationManager
{
    private ObservableObject _currentViewModel;

    public ObservableObject CurrentViewModel
    {
        get { return _currentViewModel; }
        set
        {
            _currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    public void OnCurrentViewModelChanged()
    {
        CurrentViewModelChanged?.Invoke();
    }

    public event Action CurrentViewModelChanged;
}