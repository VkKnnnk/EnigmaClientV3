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

namespace EnigmaClientV3.View_Models
{
    public class MainWindowVM : BaseVM
    {
        private readonly UserControl authenticationPage = new AuthenticationView();
        private readonly UserControl workspacePage = new WorkspaceView();
        private UserControl currentPage;

        public UserControl CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }
        public MainWindowVM()
        {
            if (AppSession.Context.Database.CanConnect())
            {
                CurrentPage = authenticationPage;
                //подрубаем винапи функции
            }
            else
            {
                MessageBox.Show("Отсутствует подключение к базе данных", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                Application.Current.Shutdown();
            }
        }
        protected void ChangeMainPage()
        {
            if (CurrentPage == authenticationPage)
                CurrentPage = workspacePage;
            else
                CurrentPage = authenticationPage;
        }
    }
}
