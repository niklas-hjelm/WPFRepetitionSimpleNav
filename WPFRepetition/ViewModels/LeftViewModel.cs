using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class LeftViewModel : ObservableObject
    {

        #region Fields

        private readonly DataModel _dataModel;
        private NavigationManager _navigationManager;

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

        public LeftViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;

            CountUpCommand = new RelayCommand(() => Counter++);
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, _navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, _navigationManager));
        }
    }
}
