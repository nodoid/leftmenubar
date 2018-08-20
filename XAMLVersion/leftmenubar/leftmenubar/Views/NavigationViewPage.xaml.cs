using LeftMenuBar.Controls;
using Xamarin.Forms;
using LeftMenuBar.Models;
using System.Collections.Generic;

namespace LeftMenuBar.Views
{
    public partial class NavigationViewPage : ContentPage
    {
        MenuView Menu;
        Rectangle origBounds = new Rectangle();

        public NavigationViewPage()
        {
            InitializeComponent();
            BindingContext = this;

            mainStack.HeightRequest = Application.Current.MainPage.Height - topBar.HeightRequest;

            topBar.LeftCommand = BackCommand;
            topBar.RightCommand = MenuCommand;

            mainStack.WidthRequest = innerStack.MinimumWidthRequest = innerStack.WidthRequest = contentStack.WidthRequest = Application.Current.MainPage.Width;
            innerStack.HeightRequest = contentStack.HeightRequest = Application.Current.MainPage.Height - 52;
            Menu = new MenuView
            {
                BackgroundColor = Color.WhiteSmoke,
                Page = this,
                MinimumWidthRequest = Application.Current.MainPage.Width * .85,
                WidthRequest = Application.Current.MainPage.WidthRequest * .85,
                HeightRequest = Application.Current.MainPage.Height,
                MenuList = new List<MenuListClass>
                {
                    new MenuListClass {ImageSource = "arrowback_blue", ImageWidth = 32, ImageHeight = 32, Text = "Option 1", TextColor = Color.Blue, FontSize = 14},
                    new MenuListClass {ImageSource = "logo", ImageWidth = 32, ImageHeight = 32, Text = "Option 2", TextColor = Color.Blue, FontSize = 14},
                    new MenuListClass {ImageSource = "menu", ImageWidth = 32, ImageHeight = 32, Text = "Option 3", TextColor = Color.Blue, FontSize = 14},
                }
            };
        }

        Command BackCommand
        {
            get
            {
                return new Command(async () => await Navigation.PopAsync());
            }
        }

        Command MenuCommand
        {
            get
            {
                return new Command(() =>
                {
                    var bounds = innerStack.Children[0].Bounds;
                    bounds.X = Application.Current.MainPage.Width * .18;
                    if (!App.Self.PanelShowing)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                            {
                                innerStack.WidthRequest = innerStack.Width + Menu.Content.WidthRequest;

                                if (innerStack.Children.Count == 1)
                                {
                                    innerStack.Children.Add(new StackLayout
                                    {
                                        Children = { Menu }
                                    });
                                }

                                origBounds = innerStack.Children[1].Bounds;
                                if (origBounds.X < Application.Current.MainPage.Width)
                                    origBounds.X = Application.Current.MainPage.Width + 6;

                                await innerStack.Children[1].LayoutTo(bounds, 250, Easing.CubicIn);
                                innerStack.Children[0].Opacity = .5;
                                App.Self.PanelShowing = true;
                            });
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                    {
                        if (innerStack.Children.Count > 1)
                        {
                            innerStack.Children[1].LayoutTo(origBounds, 250, Easing.CubicOut).ContinueWith((t) =>
                    {
                        if (t.IsCompleted)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                                    {
                                        innerStack.Children[0].Opacity = 1;
                                        App.Self.PanelShowing = false;
                                    });
                        }
                    });
                        }
                    });
                    }

                });
            }
        }
    }
}
