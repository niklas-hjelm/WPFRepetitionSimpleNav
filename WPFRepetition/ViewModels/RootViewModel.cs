using CommunityToolkit.Mvvm.ComponentModel;
using WPFRepetition.Factories;
using WPFRepetition.Managers;

namespace WPFRepetition.ViewModels;

class RootViewModel : ObservableObject
{
    private readonly INavigationManager _navigationManager;

    #region Commands
        
    #endregion

    public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;
        
    public RootViewModel(INavigationManager navigationManager, IViewModelFactory<LeftViewModel> leftFactory)
    {
        _navigationManager = navigationManager;
        _navigationManager.CurrentViewModel = leftFactory.Create();

        _navigationManager.CurrentViewModelChanged += CurrentViewModelChanged;
    }


    private void CurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
        
}