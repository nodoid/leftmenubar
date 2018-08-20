using System.Collections.Generic;
using LeftMenuBar.Models;
using Xamarin.Forms;

namespace LeftMenuBar.Controls
{
    public partial class MenuListView : ListView
    {
        public static readonly BindableProperty MenuListProperty = BindableProperty.Create(nameof(MenuList), typeof(List<MenuListClass>), typeof(MenuListView), new List<MenuListClass>(), BindingMode.OneWayToSource);
        public static readonly BindableProperty PageProperty = BindableProperty.Create(nameof(Page), typeof(Page), typeof(MenuListView), null);

        public MenuListView()
        {
            InitializeComponent();
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
