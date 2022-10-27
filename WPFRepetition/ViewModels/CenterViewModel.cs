using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    class CenterViewModel : ObservableObject
    {
        #region Fields

        private DataModel _dataModel;
        private NavigationManager _navigationManager;

        #endregion

        #region Properties

        private int _counter;

        public int Counter
        {
            get => _dataModel.Counter;
            set => SetProperty(_dataModel.Counter, value, _dataModel, (model, value) => model.Counter = value);
        }

        #endregion

        #region Commands

        public IRelayCommand CountReset { get; }
        public IRelayCommand NavigateRightCommand { get; }
        public IRelayCommand NavigateLeftCommand { get; }

        #endregion

        public CenterViewModel(DataModel dataModel, NavigationManager navigationManager)
        {
            _dataModel = dataModel;
            _navigationManager = navigationManager;
            CountReset = new RelayCommand(() => Counter = 0);
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new RightViewModel(_dataModel, navigationManager));
        }
    }
}
