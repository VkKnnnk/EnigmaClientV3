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
    public class MainWindowVM : INotifyPropertyChanged
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
        public void ChangePage()
        {
            if (CurrentPage == authenticationPage)
                CurrentPage = workspacePage;
            else
                CurrentPage = authenticationPage;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
