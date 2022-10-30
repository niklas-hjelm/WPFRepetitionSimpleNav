using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Factories;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

class CenterViewModel : ObservableObject
{
    #region Fields

    private DataModel _dataModel;
    private INavigationManager _navigationManager;

    #endregion

    #region Properties

    public int Counter
    {
        get => _dataModel.Counter;
        set => SetProperty(_dataModel.Counter, value, _dataModel, (model, value) => model.Counter = value);
    }

    #endregion

    #region Commands

    public IRelayCommand ResetCounterCommand { get; }
    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    #endregion

    public CenterViewModel(IDataManager dataManager,
        INavigationManager navigationManager,
        IViewModelFactory<LeftViewModel> leftFactory,
        IViewModelFactory<RightViewModel> rightFactory)
    {
        _dataModel = dataManager.DataModel;
        _navigationManager = navigationManager;

        ResetCounterCommand = new RelayCommand(() => Counter = 0);
        NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = leftFactory.Create());
        NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = rightFactory.Create());
    }
}