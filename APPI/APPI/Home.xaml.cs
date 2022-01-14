using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace APPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private NavigationPage loginpage;

        public Home()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            loginpage = new NavigationPage(new Login());
            App.Current.MainPage = loginpage;
        }
    }
}