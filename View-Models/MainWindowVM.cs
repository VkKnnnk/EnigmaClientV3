using EnigmaClientV3.Models;
using EnigmaClientV3.Views.MainViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EnigmaClientV3.View_Models
{
    public class MainWindowVM : BaseVM
    {
        public MainWindowVM()
        {
            if (AppSession.Context.Database.CanConnect())
            {
                DisplayedViewModel = new AuthenticationViewVM();
                //подрубаем винапи функции
            }
            else
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }
        #region Commands
        private ICommand _displayAuthenticationViewCommand;
        public ICommand DisplayAuthenticationViewCommand
            => _displayAuthenticationViewCommand ??= new RelayCommand(DisplayAuthenticationView);
        private ICommand _displayWorkspaceViewCommand;
        public ICommand DisplayWorkspaceViewCommand
            => _displayWorkspaceViewCommand ??= new RelayCommand(DisplayWorkspaceView);
        #endregion
        #region Methods
        private void DisplayAuthenticationView(object param)
        {
            NavigateTo(new AuthenticationViewVM());
        }
        private void DisplayWorkspaceView(object param)
        {
            NavigateTo(new WorkspaceViewVM());
        }
        #endregion
    }
}
