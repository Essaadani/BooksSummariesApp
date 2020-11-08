using BooksSummariesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BooksSummariesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        List<HomeMenuItem> menuItems;

        public MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem{ Id = MenuItemType.Home, Title="الصفحة الرئيسية"},
                new HomeMenuItem{ Id = MenuItemType.AddNewBook, Title="إضافة ملخص جديد"},
                new HomeMenuItem{ Id = MenuItemType.About, Title="حول التطبيق"},
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.ItemSelected += ListViewMenu_ItemSelected;
        }

        private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }

            var id = ((HomeMenuItem)e.SelectedItem).Id;

            RootPage.NavigateTo(id);
        }
    }
}