using Xamarin.Forms;

namespace leftmenubar
{
    public class BasePage : ContentPage
    {
        Image bgImage { get; set; } = new Image { Source = Constants.BackgroundFilename, Aspect = Aspect.Fill };

        public BasePage()
        {
            BackgroundColor = Color.White;
            NavigationPage.SetHasNavigationBar(this, false);
            if (Device.OS == TargetPlatform.iOS)
            {
                Padding = new Thickness(0, 20);
            }
        }

        public RelativeLayout CreateContent(StackLayout masterStack)
        {
            var relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(bgImage,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => App.ScreenSize.Width),
                Constraint.RelativeToParent((parent) => App.ScreenSize.Height));

            relativeLayout.Children.Add(masterStack,
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent((parent) => App.ScreenSize.Width),
                Constraint.RelativeToParent((parent) => App.ScreenSize.Height));

            return relativeLayout;
        }
    }
}

