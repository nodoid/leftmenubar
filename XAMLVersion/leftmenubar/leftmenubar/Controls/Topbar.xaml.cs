using Xamarin.Forms;
using System;

namespace LeftMenuBar.Controls
{
    public partial class Topbar : ContentView
    {
        public static readonly BindableProperty LeftImageSourceProperty = BindableProperty.Create(nameof(LeftImageSource), typeof(ImageSource), typeof(Topbar));
        public static readonly BindableProperty CentreImageSourceProperty = BindableProperty.Create(nameof(CentreImageSource), typeof(ImageSource), typeof(Topbar));
        public static readonly BindableProperty RightImageSourceProperty = BindableProperty.Create(nameof(RightImageSource), typeof(ImageSource), typeof(Topbar));
        public static readonly BindableProperty CentreTextSourceProperty = BindableProperty.Create(nameof(CentreTextSource), typeof(string), typeof(Topbar));
        public static readonly BindableProperty LeftCommandProperty = BindableProperty.Create(nameof(LeftCommand), typeof(Command), typeof(Topbar));
        public static readonly BindableProperty RightCommandProperty = BindableProperty.Create(nameof(RightCommand), typeof(Command), typeof(Topbar));
        public static readonly BindableProperty BarColourProperty = BindableProperty.Create(nameof(BarColour), typeof(Color), typeof(Topbar), Color.White);
        public static readonly BindableProperty LeftHeightProperty = BindableProperty.Create(nameof(LeftHeight), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty LeftWidthProperty = BindableProperty.Create(nameof(LeftWidth), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty CentreHeightProperty = BindableProperty.Create(nameof(CentreHeight), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty CentreWidthProperty = BindableProperty.Create(nameof(CentreWidth), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty RightHeightProperty = BindableProperty.Create(nameof(RightHeight), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty RightWidthProperty = BindableProperty.Create(nameof(RightWidth), typeof(double), typeof(Topbar), 32D);
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(Topbar), 18D);
        public static readonly BindableProperty TextColourProperty = BindableProperty.Create(nameof(TextColour), typeof(Color), typeof(Topbar), Color.Black);

        public Topbar()
        {
            InitializeComponent();
            this.Content.BindingContext = this;


            if (Device.RuntimePlatform == Device.iOS)
                Padding = new Thickness(0, 22, 0, 0);
        }

        public ImageSource LeftImageSource
        {
            get => (ImageSource)GetValue(LeftImageSourceProperty);
            set => SetValue(LeftImageSourceProperty, value);
        }

        public ImageSource CentreImageSource
        {
            get => (ImageSource)GetValue(CentreImageSourceProperty);
            set
            {
                SetValue(CentreImageSourceProperty, value);
                HasImage = true;
                HasText = !HasImage;
            }
        }

        public ImageSource RightImageSource
        {
            get => (ImageSource)GetValue(RightImageSourceProperty);
            set => SetValue(RightImageSourceProperty, value);
        }

        public string CentreTextSource
        {
            get => (string)GetValue(CentreTextSourceProperty);
            set
            {
                SetValue(CentreTextSourceProperty, value);
                HasImage = false;
                HasText = !HasImage;
            }
        }

        public Command LeftCommand
        {
            get => (Command)GetValue(LeftCommandProperty);
            set => SetValue(LeftCommandProperty, value);
        }

        public Command RightCommand
        {
            get => (Command)GetValue(RightCommandProperty);
            set => SetValue(RightCommandProperty, value);
        }

        bool HasImage { get; set; }

        public bool HasText { get; set; }

        public Color BarColour
        {
            get => (Color)GetValue(BarColourProperty);
            set => SetValue(BarColourProperty, value);
        }

        public double LeftHeight
        {
            get => (double)GetValue(LeftHeightProperty);
            set => SetValue(LeftHeightProperty, value);
        }

        public double LeftWidth
        {
            get => (double)GetValue(LeftWidthProperty);
            set => SetValue(LeftWidthProperty, value);
        }

        public double CentreHeight
        {
            get => (double)GetValue(CentreHeightProperty);
            set => SetValue(CentreHeightProperty, value);
        }

        public double CentreWidth
        {
            get => (double)GetValue(CentreWidthProperty);
            set => SetValue(CentreWidthProperty, value);
        }

        public double RightHeight
        {
            get => (double)GetValue(RightHeightProperty);
            set => SetValue(RightHeightProperty, value);
        }

        public double RightWidth
        {
            get => (double)GetValue(RightWidthProperty);
            set => SetValue(RightWidthProperty, value);
        }

        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public Color TextColour
        {
            get => (Color)GetValue(TextColourProperty);
            set => SetValue(TextColourProperty, value);
        }
    }
}
