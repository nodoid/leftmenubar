using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace leftmenubar
{
    public class MainPage : BasePage
    {
        public StackLayout stack;
        StackLayout innerStack;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (innerStack != null)
                if (innerStack.Children.Count != 0)
                    innerStack.Children.Clear();

            CreateUI();
        }

        public MainPage(bool toUpdates = false)
        {
            BackgroundColor = Color.White;
        }

        void CreateUI()
        {
            stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = App.ScreenSize.Width,
                HeightRequest = App.ScreenSize.Height - 52,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            innerStack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start,
                Orientation = StackOrientation.Horizontal,
                MinimumWidthRequest = App.ScreenSize.Width,
                WidthRequest = App.ScreenSize.Width,
                HeightRequest = App.ScreenSize.Height - 52,
            };

            var topbar = new TopBar("Swipe test", this, "", "icomenu", innerStack).CreateTopBar();
            stack.HeightRequest = App.ScreenSize.Height - topbar.HeightRequest;

            var btnNew = new CustomButton
            {
                WidthRequest = App.ScreenSize.Width * .45,
                HeightRequest = App.ScreenSize.Height * .3,
                BorderRadius = 5,
                BackgroundColor = Constants.NELFTOrange,
                Text = Langs.Menu_NewMeeting,
                TextColor = Color.Black,
                Image = "Add48",
                Command = new Command(async (t) => await Navigation.PushAsync(new NewMeeting()))
            };

            var btnCancel = new CustomButton
            {
                WidthRequest = App.ScreenSize.Width * .45,
                HeightRequest = App.ScreenSize.Height * .3,
                BorderRadius = 5,
                BackgroundColor = Constants.NELFTBlue,
                Text = Langs.Menu_Cancel,
                TextColor = Color.Black,
                Image = "Close48",
                Command = new Command(async (t) => await Navigation.PushAsync(new CancelMeeting()))
            };

            var btnPending = new CustomButton
            {
                WidthRequest = App.ScreenSize.Width * .45,
                HeightRequest = App.ScreenSize.Height * .3,
                BorderRadius = 5,
                BackgroundColor = Constants.NELFTGreen,
                Text = Langs.Menu_Pending,
                TextColor = Color.Black,
                Image = "get_info",
                Command = new Command(async (t) => await Navigation.PushAsync(new PendingMeeting()))
            };

            var btnUpcoming = new CustomButton
            {
                WidthRequest = App.ScreenSize.Width * .45,
                HeightRequest = App.ScreenSize.Height * .3,
                BorderRadius = 5,
                BackgroundColor = Constants.NELFTYellow,
                Text = Langs.Menu_Upcoming,
                TextColor = Color.Black,
                Image = "CalendarDate0248",
                Command = new Command(async (t) => await Navigation.PushAsync(new UpComingMeeting()))
            };

            stack.Children.Add(new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Padding = new Thickness(12, 12),
                TranslationY = -8,
                Children =
                        {
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                WidthRequest = App.ScreenSize.Width * .9,
                                Children = {btnNew, btnUpcoming}
                            },
                            new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                WidthRequest = App.ScreenSize.Width * .9,
                                Children = {btnCancel, btnPending}
                            }
                        }
            });

            innerStack.Children.Add(stack);

            Content = CreateContent(new StackLayout
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalOptions = LayoutOptions.Start,
                        WidthRequest = App.ScreenSize.Width,
                        Children = { topbar }
                    },
                    innerStack
                }
            });
        }
    }
}
