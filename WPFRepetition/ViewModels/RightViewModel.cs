using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using WPFRepetition.Managers;
using WPFRepetition.Models;

namespace WPFRepetition.ViewModels
{
    //Här i varje ViewModel class ärver vi OBserableObject för att ha access till INotifyPropertyChange metoder eller allt som ska vara Observable.
    class RightViewModel : ObservableObject
    {
        #region Fields

        private readonly DataModel _dataModel;
        private NavigationManager _navigationManager;

        #endregion

        #region Commands

        //IRelayCommand är ett interface vi använder oss av för att binda CountDownCommand.
        public IRelayCommand CountDownCommand { get; }
        public IRelayCommand NavigateRightCommand { get; }
        public IRelayCommand NavigateLeftCommand { get; }

        #endregion

        #region Props
        //
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
            //Koden nedan är en instans av RelayCommand där vi skapar en funktion inuti, () => Counter--
            // () => Counter-- är samma som en metod som säger Public void CountDown() { Counter-- } och sedan bli anropad som new RelayCommand(CountDown)
            _navigationManager = navigationManager;
            NavigateLeftCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new CenterViewModel(_dataModel, navigationManager));
            NavigateRightCommand = new RelayCommand(() => _navigationManager.CurrentViewModel = new LeftViewModel(_dataModel, navigationManager));
            CountDownCommand = new RelayCommand(() => Counter--);
        }
    }
}
