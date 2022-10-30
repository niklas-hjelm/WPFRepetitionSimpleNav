using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WPFRepetition.Factories;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels;

class RightViewModel : ObservableObject
{
    #region Fields

    private readonly DataModel _dataModel;
    private readonly INavigationManager _navigationManager;

    #endregion

    #region Commands

    public IRelayCommand CountDownCommand { get; }
    public IRelayCommand NavigateLeftCommand { get; }
    public IRelayCommand NavigateRightCommand { get; }

    #endregion

    #region Props

    public int Counter
    {
        get => _dataModel.Counter;
        set
        {
            SetProperty(_dataModel.Counter, value, _dataModel, (model, value) => model.Counter = value);
        }
    }

    #endregion

    public RightViewModel(IDataManager dataManager,
        INavigationManager navigationManager,
        IViewModelFactory<CenterViewModel> centerFactory,
        IViewModelFactory<LeftViewModel> leftFactory)
    {
        _dataModel = dataManager.DataModel;
        _navigationManager = navigationManager;

        CountDownCommand = new RelayCommand(() => Counter--);
        NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = centerFactory.Create());
        NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = leftFactory.Create());
    }
}