using EnigmaClientV3.View_Model;
using System.Windows.Controls;

namespace EnigmaClientV3.View.MainPages.AuthenticationPages
{
    public partial class AuthorizationPage : UserControl
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            DataContext = new AuthorizationPageVM();
        }
    }
}
