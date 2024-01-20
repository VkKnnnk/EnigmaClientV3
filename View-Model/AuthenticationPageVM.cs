using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EnigmaClientV3.View_Model
{
    public class AuthenticationPageVM : INotifyPropertyChanged
    {

        private DateTime currentAppTime;
        public DateTime CurrentAppTime
        {
            get { return currentAppTime; }
            set
            {
                currentAppTime = value;
                OnPropertyChanged("CurrentAppTime");
            }
        }
        public AuthenticationPageVM()
        {
            StartAppTimer().Tick += AuthenticationPageVM_Tick;
        }

        private void AuthenticationPageVM_Tick(object sender, EventArgs e)
        {
            CurrentAppTime = DateTime.Now;
        }
        public static DispatcherTimer StartAppTimer()
        {
            DispatcherTimer appTimer = new DispatcherTimer();
            appTimer.Interval = TimeSpan.FromSeconds(1);
            appTimer.Start();
            return appTimer;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
