using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace APPI
{
    public partial class MainPage : ContentPage
    {
        private NavigationPage navigator;
        public MainPage()
        {
            InitializeComponent();
        }

        private void logout(object sender, EventArgs e)
        {
            navigator = new NavigationPage(new Home());
            App.Current.MainPage = navigator;
        }
    }
}
