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
using System.IO;
using SQLite;

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
                Vibration.Vibrate();
                await DisplayAlert("Login Failed", "MA nr. el. Password blev ikke udfyldt korrekt!", "OK");
                return;
            }
            
            if (!allow_login(ma.Text, password.Text))
            {
                Vibration.Vibrate();
                await DisplayAlert("Login Failed", "MA nr. & Password matchede ikke", "OK");
                return;
            }

            navigator = new NavigationPage(new MainPage());
            App.Current.MainPage = navigator;
        }

        private bool allow_login(string ma, string password)
        {
            if (ma != "487647" || password != "123")
            {
                return false;
            }

            return true;
        }

        // This is an example of how I would've used DB, if I could've got it to work, within the given time.
        private bool allow_login_db(string ma, string password)
        {
            connection.mysql_open_connection();

            string check_user = "SELECT id FROM users WHERE ma = '" + ma + "' AND PASSWORD = '" + password + "'";

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(check_user, connection.mysql_conn);
                DataTable dt = new DataTable();

                adapter.Fill(dt);

                if (dt.Rows.Count != 1)
                {
                    return false;
                }

                return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}