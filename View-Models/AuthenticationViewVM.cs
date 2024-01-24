using EnigmaClientV3.Models;
using EnigmaClientV3.Views.MainViews.AuthenticationViews;
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

namespace EnigmaClientV3.View_Models
{
    public class AuthenticationViewVM : BaseVM
    {
        private readonly BaseVM registrationVM = new RegistrationViewVM();
        private readonly BaseVM authorizationVM = new AuthorizationViewVM();
        #region Properties
        private Visibility _registrationButtonVisibility = Visibility.Visible;
        public Visibility RegistrationButtonVisibility
        {
            get { return _registrationButtonVisibility; }
            set
            {
                _registrationButtonVisibility = value;
                OnPropertyChanged("RegistrationButtonVisibility");
            }
        }
        private Visibility _gobackButtonVisibility = Visibility.Hidden;
        public Visibility GobackButtonVisibility
        {
            get { return _gobackButtonVisibility; }
            set
            {
                _gobackButtonVisibility = value;
                OnPropertyChanged("GobackButtonVisibility");
            }
        }
        private DateTime _currentAppTime;
        public DateTime CurrentAppTime
        {
            get { return _currentAppTime; }
            set
            {
                _currentAppTime = value;
                OnPropertyChanged("CurrentAppTime");
            }
        }
        private CultureInfo _keyboardLayout = InputLanguageManager.Current.CurrentInputLanguage;
        public CultureInfo KeyboardLayout
        {
            get { return _keyboardLayout; }
            set
            {
                _keyboardLayout = value;
                OnPropertyChanged("KeyboardLayout");
            }
        }
        #endregion
        public AuthenticationViewVM()
        {
            NavigateTo(authorizationVM);
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
        private void ChangeKeyboardLayout()
        {
            if (KeyboardLayout.Name == "ru-RU")
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
