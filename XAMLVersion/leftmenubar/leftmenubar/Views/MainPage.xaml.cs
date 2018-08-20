using System;
using Xamarin.Forms;

namespace LeftMenuBar.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationViewPage());
        }
    }
}
