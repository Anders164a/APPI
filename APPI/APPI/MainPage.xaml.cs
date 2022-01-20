using System;
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

        private void activity(object sender, EventArgs e)
        {
            navigator = new NavigationPage(new Activity());
            App.Current.MainPage = navigator;
        }

        private void logout(object sender, EventArgs e)
        {
            navigator = new NavigationPage(new Home());
            App.Current.MainPage = navigator;
        }
    }
}
