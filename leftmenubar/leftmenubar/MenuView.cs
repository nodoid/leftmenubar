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
                new MenuListClass { text = Langs.Menu_NewMeeting, image = "Add48" },
                new MenuListClass { text = Langs.Menu_Upcoming, image = "CalendarDate0248" },
                new MenuListClass { text = Langs.Menu_Cancel, image = "Close48" },
                new MenuListClass { text = Langs.Menu_Pending, image = "get_info" },
                new MenuListClass { text = Langs.Menu_CheckForMeetings, image = "newmeeting" },
                new MenuListClass { text = Langs.Menu_Logout, image="logout" },
                new MenuListClass { text = Langs.Menu_Help, image="help" },
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
                Children = {stackScroll}
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
                Command = new Command(async (t) =>
                    {
                        MessagingCenter.Send(this, "Menu", "Close");
                        Page page = null;
                        switch (i)
                        {
                            case 0:
                                page = new NewMeeting();
                                break;
                            case 1:
                                page = new UpComingMeeting();
                                break;
                            case 2:
                                page = new CancelMeeting();
                                break;
                            case 3:
                                page = new PendingMeeting();
                                break;
                            case 4:
                                await DataGatherer.GetDataGatherForDates();
                                break;
                            case 5:
                                if (await Application.Current.MainPage.DisplayAlert(Langs.Logout_Title, Langs.Logout_Message, Langs.General_OK, Langs.General_Cancel))
                                {
                                    await Logout(App.Self.UserSettings.LoadSetting<string>("Username", SettingType.String), App.Self.UserSettings.LoadSetting<string>("Password", SettingType.String)).ContinueWith((y) =>
                                    {
                                        if (y.IsCompleted)
                                        {
                                            Device.BeginInvokeOnMainThread(() =>
                                            {
                                                App.Self.UserSettings.SaveSetting("Username", string.Empty, SettingType.String);
                                                App.Self.UserSettings.SaveSetting("Password", string.Empty, SettingType.String);
                                                Application.Current.MainPage = new Login();
                                            });
                                        }
                                    });

                                    //await Navigation.PushAsync(Application.Current.MainPage);
                                }
                                break;
                            case 6:
                                await Application.Current.MainPage.DisplayAlert(Langs.Help_Title, string.Format("{0} {1}\n\n{2}", Langs.Help_Version, Constants.Version, Langs.Help_Message), Langs.General_OK);
                                break;
                        }
                        if (i < 4)
                            await Navigation.PushAsync(page);
                    }
                )
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

        async Task Logout(string username, string password)
        {
            var passwordEn = WebUtility.UrlEncode(password);
            var uri = string.Format(@"https://apps.nelft.nhs.uk/ADAuthentication/api/UserSecurity/AuthenticateEncryptedUser?logout={0}&password={1}", username, passwordEn);

            var client = new HttpClient();
            var response = await client.GetAsync(uri);
            var userEncryptionString = response.Content.ReadAsStringAsync().Result;
#if DEBUG
            Debug.WriteLine("hello");
#endif
        }
    }
}


