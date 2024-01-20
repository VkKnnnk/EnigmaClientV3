using EnigmaClientV3.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnigmaClientV3.View.MainPages
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationPage.xaml
    /// </summary>
    public partial class AuthenticationPage : UserControl
    {
        public AuthenticationPage()
        {
            InitializeComponent();
            DataContext = new AuthenticationPageVM();
        }
    }
}
