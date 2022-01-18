using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;
using Plugin.Geolocator;

namespace APPI
{
    public partial class Activity : ContentPage
    {
        private NavigationPage navigator;

        public Activity()
        {
            InitializeComponent();
            geolocation_listen();            
        }

        private async Task geolocation_listen()
        {
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 10);

            CrossGeolocator.Current.PositionChanged += current_position;
        }

        private async void current_position(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;
            
            var placemarks = await Geocoding.GetPlacemarksAsync(position.Latitude, position.Longitude);

            var Placemark = placemarks?.FirstOrDefault();

            placemark.Text = Placemark.Thoroughfare + ", " + Placemark.SubThoroughfare + ", " + Placemark.Locality;
        }

        async void call_responsible(object sender, EventArgs e)
        {
            try
            {
                PhoneDialer.Open("42374268");
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Unable to dial", "Phone dialing failed", "OK");
            }
        }

        private void logout(object sender, EventArgs e)
        {
            navigator = new NavigationPage(new Home());
            App.Current.MainPage = navigator;
        }
    }
}
