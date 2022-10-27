using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class RightViewModel : ObservableObject
    {
        #region Fields

        private readonly DataModel _dataModel;
        private NavigationManager _navigationManager;

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

        public RightViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;

            CountDownCommand = new RelayCommand(() => Counter--);
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, _navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, _navigationManager));
        }
    }
}
