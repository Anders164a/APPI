using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using MySql.Data.MySqlClient;
using APPI_DB;

namespace APPI
{
    public partial class Login : ContentPage
    {
        private NavigationPage navigator;

        public Login()
        {
            InitializeComponent();
        }

        private async void login(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ma.Text) || String.IsNullOrEmpty(password.Text))
            {
                await DisplayAlert("Login Failed", "MA nr. el. Password blev ikke udfyldt korrekt!", "OK");
                return;
            }
            
            if (!allow_login(ma.Text, password.Text))
            {
                await DisplayAlert("Login Failed", "MA nr. & Password matchede ikke", "OK");
                return;
            }


            navigator = new NavigationPage(new MainPage());
            App.Current.MainPage = navigator;
        }

        private bool allow_login(string ma, string password)
        {
            connection.open_connection();

            if (ma != "487647" || password != "123")
            {
                return false;
            }

            return true;
            //open_connection();

            //string find_user = "SELECT id FROM users WHERE ma = '" + ma + "' AND password = '" + password + "'";


            //MySqlDataAdapter da = new MySqlDataAdapter(find_user, connection.conn);

            //DataTable DT = new DataTable();

            //da.Fill(DT);

            //test(DT);

            //return true;
        }

        private async void test(DataTable DT)
        {
            await this.DisplayAlert("Test", DT.Rows.Count.ToString(), "OK");
        }

        /*async void call(object sender, EventArgs e)
        {
            if(await this.DisplayAlert("Ring til;", NUMBER, "Yes", "no"))
            {
                try
                {
                    PhoneDialer.Open(NUMBER);
                } catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                } catch (FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
                } catch (Exception)
                {
                    await DisplayAlert("Unable to dial", "Phone dialing failed", "OK");
                }
            }
        }*/
    }
}