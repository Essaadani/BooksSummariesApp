using BooksSummariesApp.Models;
using BooksSummariesApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BooksSummariesApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<MenuItemType, NavigationPage> MenuPages = new Dictionary<MenuItemType, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MenuPages.Add(MenuItemType.Home, (NavigationPage)Detail);
        }

        public void NavigateTo(MenuItemType menuItemType)
        {
            MenuPages.Clear();
            if (!MenuPages.ContainsKey(menuItemType))
            {
                switch (menuItemType)
                {
                    case MenuItemType.Home:
                        MenuPages.Add(menuItemType, new NavigationPage(new BooksListPage()));
                        break;
                    case MenuItemType.AddNewBook:
                        MenuPages.Add(menuItemType, new NavigationPage(new AddNewBookPage()));
                        break;
                    case MenuItemType.About:
                        MenuPages.Add(menuItemType, new NavigationPage(new AboutPage()));
                        break;
                    default:
                        break;
                }

                NavigationPage newPage = MenuPages[menuItemType];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;
                    IsPresented = false;
                }
            }
        }
    }
}
