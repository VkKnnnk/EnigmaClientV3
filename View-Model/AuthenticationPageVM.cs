using EnigmaClientV3.Model;
using EnigmaClientV3.View.MainPages.AuthenticationPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace EnigmaClientV3.View_Model
{
    public class AuthenticationPageVM : INotifyPropertyChanged
    {
        private DateTime currentAppTime;
        private CultureInfo keyboardLayout;
        private readonly UserControl regPage = new RegistrationPage();
        private readonly UserControl authPage = new AuthorizationPage();
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
        public DateTime CurrentAppTime
        {
            get { return currentAppTime; }
            set
            {
                currentAppTime = value;
                OnPropertyChanged("CurrentAppTime");
            }
        }
        public CultureInfo KeyboardLayout
        {
            get { return keyboardLayout; }
            set
            {
                keyboardLayout = value;
                OnPropertyChanged("KeyboardLayout");
            }
        }
        public AuthenticationPageVM()
        {
            CurrentPage = authPage;
            KeyboardLayout = InputLanguageManager.Current.CurrentInputLanguage;
            InputLanguageManager.Current.InputLanguageChanged += Current_InputLanguageChanged;
            StartAppTimer().Tick += AuthenticationPageVM_Tick;
        }

        private void Current_InputLanguageChanged(object sender, InputLanguageEventArgs e)
        {
            KeyboardLayout = InputLanguageManager.Current.CurrentInputLanguage;
        }

        private void AuthenticationPageVM_Tick(object sender, EventArgs e)
        {
            CurrentAppTime = DateTime.Now;
        }
        public static DispatcherTimer StartAppTimer()
        {
            DispatcherTimer appTimer = new();
            appTimer.Interval = TimeSpan.FromSeconds(1);
            appTimer.Start();
            return appTimer;
        }
        public void ChangePage()
        {
            if (CurrentPage == authPage)
                CurrentPage = regPage;
            else
                CurrentPage = authPage;
        }

        private RelayCommand changePageCommand;
        public RelayCommand ChangePageCommand
        {
            get
            {
                return changePageCommand ?? new RelayCommand(obj =>
                {
                    ChangePage();
                });
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
