using Xamarin.Forms;
namespace LeftMenuBar.Models
{
    public class MenuListClass
    {
        public string ImageSource { get; set; }

        public double ImageWidth { get; set; }

        public double ImageHeight { get; set; }

        public string Text { get; set; }

        public Color TextColor { get; set; } = Color.Black;

        public Color BoxColor { get; set; } = Color.Gray;

        public double BoxWidth { get; set; } = Application.Current.MainPage.Width;

        public double FontSize { get; set; } = 14;

        public bool IsEnabled { get; set; } = true;
    }
}
