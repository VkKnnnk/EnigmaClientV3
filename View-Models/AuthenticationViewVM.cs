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
        #region Commands
        private ICommand _displayAuthorizationViewCommand;
        public ICommand DisplayAuthorizationViewCommand
            => _displayAuthorizationViewCommand ??= new RelayCommand(DisplayAuthorizationView);
        private ICommand _displayRegistrationViewCommand;
        public ICommand DisplayRegistrationViewCommand
            => _displayRegistrationViewCommand ??= new RelayCommand(DisplayRegistrationView);
        private ICommand _changeKeyboardLayoutCommand;
        public ICommand ChangeKeyboardLayoutCommand
            => _changeKeyboardLayoutCommand ??= new RelayCommand(ChangeKeyboardLayout);
        #endregion
        public AuthenticationViewVM()
        {
            DisplayAuthorizationView(null);
            AppTimer().Tick += AuthenticationViewVM_Tick;
            InputLanguageManager.Current.InputLanguageChanged += Current_InputLanguageChanged;
        }
        #region Methods
        private DispatcherTimer AppTimer()
        {
            DispatcherTimer appTimer = new();
            appTimer.Interval = TimeSpan.FromSeconds(1);
            appTimer.Start();
            return appTimer;
        }
        private void AuthenticationViewVM_Tick(object sender, EventArgs e)
        {
            CurrentAppTime = DateTime.Now;
        }
        private void DisplayRegistrationView(object param)
        {
            NavigateTo(registrationVM);
        }
        private void DisplayAuthorizationView(object param)
        {
            NavigateTo(authorizationVM);
        }
        private void Current_InputLanguageChanged(object sender, InputLanguageEventArgs e)
        {
            KeyboardLayout = InputLanguageManager.Current.CurrentInputLanguage;
        }
        private void ChangeKeyboardLayout(object param)
        {
            if (KeyboardLayout.Name == "ru-RU")
                InputLanguageManager.Current.CurrentInputLanguage = new("en-US");
            else
                InputLanguageManager.Current.CurrentInputLanguage = new("ru-RU");
        }
        #endregion
    }
}
