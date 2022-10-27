using System.Windows;
using WPFRepetition.Managers;
using WPFRepetition.ViewModels;
using WPFRepetition.Views;

namespace WPFRepetition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationManager _navigationManager;
        private readonly DataManager _dataManager;

        public App()
        {
            _navigationManager = new NavigationManager();
            _dataManager = new DataManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationManager.CurrentViewModel = new LeftViewModel(_dataManager.DataModel, _navigationManager);
            var rootWindow = new RootWindow { DataContext = new RootViewModel(_navigationManager, _dataManager) };
            rootWindow.Show();
            base.OnStartup(e);
        }
    }
}
