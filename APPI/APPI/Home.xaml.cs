using System;
using Xamarin.Forms;
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