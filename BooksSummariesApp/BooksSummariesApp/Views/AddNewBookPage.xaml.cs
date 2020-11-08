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
    public partial class AddNewBookPage : ContentPage
    {
        private readonly IBookRepository bookRepository = new BookRepository();
        public Book Book { get; set; } = new Book();
        public AddNewBookPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            bookRepository.Add(Book);
            await Navigation.PopModalAsync();
        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}