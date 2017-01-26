using Xamarin.Forms;

namespace leftmenubar
{
    public class Constants
    {
        public static Color NELFTGreen { get; private set; } = Color.FromRgb(99, 179, 46);

        public static Color NELFTYellow { get; private set; } = Color.FromRgb(254, 204, 0);

        public static Color NELFTOrange { get; private set; } = Color.FromRgb(244, 152, 0);

        public static Color NELFTMagenta { get; private set; } = Color.FromRgb(193, 0, 112);

        public static Color NELFTBlue { get; private set; } = Color.FromRgb(0, 113, 187);

        public static Color LightGrey { get; private set; } = Color.FromRgb(245, 245, 245);

        public static double SmallEntryFontSize = Device.OS == TargetPlatform.Android ? 14 : 12;

        public static double HeadlineFontSize = Device.OS == TargetPlatform.Android ? 28 : 24;

        public static double GeneralFontSize = Device.OS == TargetPlatform.Android ? 16 : 14;

        public static double ButtonFontSize = Device.OS == TargetPlatform.Android ? 16 : 14;

        public static double SubHeadingFontSize = Device.OS == TargetPlatform.Android ? 20 : 18;

        public static string BackgroundFilename = "background_75pc.png";

        public static string Version = "0.05, 06/10/2016";
    }
}

