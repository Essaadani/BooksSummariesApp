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
    public partial class BookDetailsPage : ContentPage
    {
        public BookDetailsPage(Book book)
        {
            InitializeComponent();
            Book = book;
            BindingContext = this;
        }

        public Book Book { get; }
    }
}