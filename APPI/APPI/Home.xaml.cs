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
        private NavigationPage loginpage;

        public Home()
        {
            InitializeComponent();

            get_geolocation();
        }

        private async void get_geolocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Best);
            var location = await Geolocation.GetLocationAsync(request);

            w.Text = location.Latitude.ToString();
            f.Text = location.Longitude.ToString();
        }

        private void login(object sender, EventArgs e)
        {
            loginpage = new NavigationPage(new Login());
            App.Current.MainPage = loginpage;
        }
    }
}