using EnigmaClientV3.Model;
using EnigmaClientV3.View.MainPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EnigmaClientV3.View_Model
{
    public class MainWindowVM : BaseVM
    {
        private readonly UserControl authenticationPage = new AuthenticationPage();
        private readonly UserControl workspacePage = new WorkspacePage();
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
