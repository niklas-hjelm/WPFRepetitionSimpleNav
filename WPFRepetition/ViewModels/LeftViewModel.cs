using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Factories;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

class LeftViewModel : ObservableObject
{

    #region Fields

    private readonly DataModel _dataModel;
    private readonly INavigationManager _navigationManager;

    #endregion

    #region Commands

    public IRelayCommand CountUpCommand { get; }
    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    #endregion

    #region Props

    public int Counter
    {
        get => _dataModel.Counter;
        set
        {
            _dataModel.Counter = value;
            OnPropertyChanged(nameof(Counter));
        }
    }

    #endregion

    public LeftViewModel(IDataManager dataManager,
        INavigationManager navigationManager,
        IViewModelFactory<RightViewModel> rightFactory,
        IViewModelFactory<CenterViewModel> centerFactory)
    {
        _dataModel = dataManager.DataModel;
        _navigationManager = navigationManager;

        CountUpCommand = new RelayCommand(() => Counter++);
        NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = rightFactory.Create());
        NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = centerFactory.Create());
    }
}