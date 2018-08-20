using System.Collections.Generic;
using LeftMenuBar.Models;
using Xamarin.Forms;

namespace LeftMenuBar.Controls
{
    public partial class MenuView : ContentView
    {
        public static readonly BindableProperty MasterBackgroundColourProperty = BindableProperty.Create(nameof(MasterBackgroundColour), typeof(Color), typeof(MenuView), Color.White, BindingMode.OneWayToSource);
        public static readonly BindableProperty MasterMinWidthProperty = BindableProperty.Create(nameof(MasterMinWidth), typeof(double), typeof(MenuView), App.Current.MainPage.Width * .35, BindingMode.OneWayToSource);
        public static readonly BindableProperty MasterWidthProperty = BindableProperty.Create(nameof(MasterMinWidth), typeof(double), typeof(MenuView), App.Current.MainPage.Width * .35, BindingMode.OneWayToSource);
        public static readonly BindableProperty MasterHeightProperty = BindableProperty.Create(nameof(MasterHeightProperty), typeof(double), typeof(MenuView), App.Current.MainPage.Height, BindingMode.OneWayToSource);
        public static readonly BindableProperty ScrollHeightProperty = BindableProperty.Create(nameof(ScrollHeightProperty), typeof(double), typeof(MenuView), App.Current.MainPage.Height, BindingMode.OneWayToSource);
        public static readonly BindableProperty ScrollWidthProperty = BindableProperty.Create(nameof(ScrollWidthProperty), typeof(double), typeof(MenuView), App.Current.MainPage.Width * .3, BindingMode.OneWayToSource);
        public static readonly BindableProperty MenuStackColorProperty = BindableProperty.Create(nameof(MenuStackColorProperty), typeof(Color), typeof(MenuView), Color.White, BindingMode.OneWayToSource);
        public static readonly BindableProperty MenuListProperty = BindableProperty.Create(nameof(MenuList), typeof(List<MenuListClass>), typeof(MenuView), new List<MenuListClass>(), BindingMode.OneWayToSource);
        public static readonly BindableProperty PageProperty = BindableProperty.Create(nameof(Page), typeof(Page), typeof(MenuView), null);


        public MenuView()
        {
            InitializeComponent();
            this.Content.BindingContext = this;
        }

        public Color MasterBackgroundColour
        {
            get => (Color)GetValue(MasterBackgroundColourProperty);
            set => SetValue(MasterBackgroundColourProperty, value);
        }

        public double MasterMinWidth
        {
            get => (double)GetValue(MasterMinWidthProperty);
            set => SetValue(MasterMinWidthProperty, value);
        }

        public double MasterWidth
        {
            get => (double)GetValue(MasterWidthProperty);
            set => SetValue(MasterWidthProperty, value);
        }

        public double MasterHeight
        {
            get => (double)GetValue(MasterHeightProperty);
            set => SetValue(MasterHeightProperty, value);
        }

        public double ScrollWidth
        {
            get => (double)GetValue(ScrollWidthProperty);
            set => SetValue(ScrollWidthProperty, value);
        }

        public double ScrollHeight
        {
            get => (double)GetValue(ScrollHeightProperty);
            set => SetValue(ScrollHeightProperty, value);
        }

        public Color MenuStackColor
        {
            get => (Color)GetValue(MenuStackColorProperty);
            set => SetValue(MenuStackColorProperty, value);
        }

        public List<MenuListClass> MenuList
        {
            get => (List<MenuListClass>)GetValue(MenuListProperty);
            set => SetValue(MenuListProperty, value);
        }

        public Page Page
        {
            get => (Page)GetValue(PageProperty);
            set => SetValue(PageProperty, value);
        }

        Command TapCommand
        {
            get
            {
                return new Command(() =>
                {
                    MessagingCenter.Send(this, "Menu", "Close");
                    Page = null;
                });
            }
        }
    }
}
