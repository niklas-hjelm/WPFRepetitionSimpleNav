using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFRepetition.Managers;

internal interface INavigationManager
{
    ObservableObject CurrentViewModel { get; set; }
    void OnCurrentViewModelChanged();
    event Action CurrentViewModelChanged;
}