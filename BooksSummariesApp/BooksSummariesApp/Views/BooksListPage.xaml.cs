using BooksSummariesApp.Infrastructure.Repositories;
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
    public partial class BooksListPage : ContentPage
    {
        private readonly IBookRepository bookRepository = new BookRepository();
        public BooksListPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BooksListView.ItemsSource = bookRepository.GetBooks();
        }

        private async void BooksListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Book;
            if (item == null)
            {
                return;
            }

            await Navigation.PushAsync(new BookDetailsPage(item));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddNewBookPage()));
        }
    }
}