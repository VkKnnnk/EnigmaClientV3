using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaClientV3.View_Models
{
    public abstract class BaseVM : INotifyPropertyChanged
    {
        private BaseVM _displayedViewModel;
        public BaseVM DisplayedViewModel
        {
            get { return _displayedViewModel; }
            set
            {
                _displayedViewModel = value;
                OnPropertyChanged("DisplayedViewModel");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected void NavigateTo(BaseVM newDisplayedViewModel)
        {
            if (DisplayedViewModel != newDisplayedViewModel)
                DisplayedViewModel = newDisplayedViewModel;
        }

    }
}
