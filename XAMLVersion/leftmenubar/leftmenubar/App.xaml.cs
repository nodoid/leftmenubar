using LeftMenuBar.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace LeftMenuBar
{
    public partial class App : Application
    {
        public static App Self { get; set; }
        public bool PanelShowing { get; set; }

        public App()
        {
            InitializeComponent();
            App.Self = this;
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
