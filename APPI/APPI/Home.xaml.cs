using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace APPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        private NavigationPage navigtor;

        public Home()
        {
            InitializeComponent();
        }

        private void login(object sender, EventArgs e)
        {
            navigtor = new NavigationPage(new Login());
            App.Current.MainPage = navigtor;
        }
    }
}