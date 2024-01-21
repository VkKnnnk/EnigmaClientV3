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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace EnigmaClientV3.View_Model
{
    public class AuthenticationPageVM : BaseVM
    {
        private DateTime currentAppTime;
        private CultureInfo keyboardLayout = InputLanguageManager.Current.CurrentInputLanguage;
        private readonly UserControl registrationPage = new RegistrationPage();
        private readonly UserControl authorizationPage = new AuthorizationPage();
        private UserControl currentPage;
        private Visibility registrationButtonVisibility = Visibility.Visible;
        private Visibility gobackButtonVisibility = Visibility.Hidden;

        public Visibility RegistrationButtonVisibility
        {
            get { return registrationButtonVisibility; }
            set
            {
                registrationButtonVisibility = value;
                OnPropertyChanged("RegistrationButtonVisibility");
            }
        }
        public Visibility GobackButtonVisibility
        {
            get { return gobackButtonVisibility; }
            set
            {
                gobackButtonVisibility = value;
                OnPropertyChanged("GobackButtonVisibility");
            }
        }
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
            CurrentPage = authorizationPage;
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
        private void ChangePage()
        {
            if (CurrentPage == authorizationPage)
            {
                RegistrationButtonVisibility = Visibility.Hidden;
                CurrentPage = registrationPage;
                GobackButtonVisibility = Visibility.Visible;
            }
            else
            {
                GobackButtonVisibility = Visibility.Hidden;
                CurrentPage = authorizationPage;
                RegistrationButtonVisibility = Visibility.Visible;
            }
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
        private void ChangeKeyboardLayout()
        {
            if (keyboardLayout.Name == "ru-RU")
                InputLanguageManager.Current.CurrentInputLanguage = new("en-US");
            else
                InputLanguageManager.Current.CurrentInputLanguage = new("ru-RU");
        }
        private RelayCommand changeKeyboardLayoutCommand;
        public RelayCommand ChangeKeyboardLayoutCommand
        {
            get
            {
                return changeKeyboardLayoutCommand ?? new RelayCommand(obj =>
                {
                    ChangeKeyboardLayout();
                });
            }
        }

    }
}
