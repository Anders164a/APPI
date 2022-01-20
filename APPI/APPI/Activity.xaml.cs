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
using System.Net.Http;
using Newtonsoft.Json;
using APPI_CL;

namespace APPI
{
    public partial class Activity : ContentPage
    {
        private NavigationPage navigator;

        public Activity()
        {
            InitializeComponent();
            responsible_geolocation_listen();
            geolocation_listen();
        }

        private void responsible_geolocation_listen()
        {
            // A minimum time of 5 seconds have to had passed.
            Device.StartTimer(TimeSpan.FromSeconds(5), () => {
                responsible_position();
                return true;
            });
        }

        private async Task geolocation_listen()
        {
            // A minimum time of 5 seconds have to had passed and a distance of 5 meters.
            await CrossGeolocator.Current.StartListeningAsync(TimeSpan.FromSeconds(5), 5);

            CrossGeolocator.Current.PositionChanged += current_position;
        }

        private async void responsible_position()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://pan01.skp-dp.sde.dk/HJV/API/get_activity.php");
            var responseString = await response.Content.ReadAsStringAsync();
            var activity_object = JsonConvert.DeserializeObject<activity>(responseString);

            var placemarks = await Geocoding.GetPlacemarksAsync(activity_object.responsible_latitude, activity_object.responsible_longitude);

            var Placemark = placemarks?.FirstOrDefault();

            responsible_placemark.Text = Placemark.Thoroughfare + ", " + Placemark.SubThoroughfare + ", " + Placemark.Locality;

            responsible_placemark_exactly.Text = activity_object.responsible_latitude + ", " + activity_object.responsible_longitude;
        }

        private async void current_position(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            var position = e.Position;

            placemark_exactly.Text = position.Latitude + ", " + position.Longitude;
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
