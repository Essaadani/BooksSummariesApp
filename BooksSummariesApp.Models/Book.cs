using System;

namespace BooksSummariesApp.Models
{
    public enum MenuItemType
    {
        Home,
        AddNewBook,
        Details,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
