using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
#if DEBUG
using System.Diagnostics;
#endif
using System.Net;

namespace leftmenubar
{
    public class MenuListClass
    {
        public string image { get; set; }

        public string text { get; set; }

        public bool enabled { get; set; } = true;
    }

    public class MenuView : ContentView
    {
        List<MenuListClass> menuList;

        public MenuView()
        {
            menuList = new List<MenuListClass>
            {
                new MenuListClass { text = "Menu_NewMeeting", image = "Add48" },
                new MenuListClass { text = "Menu_Upcoming", image = "CalendarDate0248" },
                new MenuListClass { text = "Menu_Cancel", image = "Close48" },
                new MenuListClass { text = "Menu_Pending", image = "get_info" },
                new MenuListClass { text = "Menu_CheckForMeetings", image = "newmeeting" },
                new MenuListClass { text = "Menu_Logout", image="logout" },
                new MenuListClass { text = "Menu_Help", image="help" },
            };

            var innerStack = new StackLayout
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Vertical,
            };

            var stackScroll = new ScrollView
            {
                HeightRequest = App.ScreenSize.Height,
                WidthRequest = App.ScreenSize.Width * .3,
                Content = innerStack
            };

            var masterStack = new StackLayout
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Vertical,
                MinimumWidthRequest = App.ScreenSize.Width * .85,
                WidthRequest = App.ScreenSize.Width * .85,
                HeightRequest = App.ScreenSize.Height /*- 52 - 36*/,
                TranslationY = 8,
                StyleId = "menu",
                Children = { stackScroll }
            };

            Content = masterStack;
        }

        StackLayout MenuListView(int i)
        {
            var imgIcon = new Image
            {
                WidthRequest = 42,
                HeightRequest = 42,
                Source = menuList[i].image
            };

            var lblText = new Label
            {
                FontSize = 18,
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = Constants.NELFTBlue,
                Text = menuList[i].text
            };

            var tap = new TapGestureRecognizer
            {
                NumberOfTapsRequired = 1,
            };

            var stack = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(0, 4, 0, 0),
                Children =
                {
                    new StackLayout
                    {
                        Padding = new Thickness(8),
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        { imgIcon,
                            new StackLayout
                            {
                                Padding = new Thickness(8, 0, 0, 0),
                                VerticalOptions = LayoutOptions.Center,
                                Children = { lblText }
                            }
                        }
                    }, new BoxView
                    {
                        WidthRequest = App.ScreenSize.Width,
                        HeightRequest = 1,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Color = Constants.LightGrey
                    }
                },
            };
            stack.GestureRecognizers.Add(tap);

            return stack;
        }


    }
}


