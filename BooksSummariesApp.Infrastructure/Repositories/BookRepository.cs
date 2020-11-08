using BooksSummariesApp.Models;
using Couchbase.Lite;
using Couchbase.Lite.Query;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BooksSummariesApp.Infrastructure.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        IEnumerable<Book> GetBooks();
    }
    public class BookRepository : IBookRepository
    {
        private readonly Database _database;
        public DatabaseManager DatabaseManager { get; set; } = new DatabaseManager();

        public BookRepository()
        {
            _database = DatabaseManager.GetDatabase();
        }
        public void Add(Book book)
        {
            try
            {
                if (book != null)
                {

                    string bookId = Guid.NewGuid().ToString();
                    book.CreatedAt = DateTime.Now;

                    MutableDocument mutableDocument = new MutableDocument(bookId);

                    mutableDocument.SetString("Id", book.Id);
                    mutableDocument.SetString("Title", book.Title);
                    mutableDocument.SetString("ShortDescription", book.ShortDescription);
                    mutableDocument.SetString("LongDescription", book.LongDescription);
                    mutableDocument.SetString("CreatedAt", book.CreatedAt.ToString("g"));
                    mutableDocument.SetString("type", "book");

                    _database.Save(mutableDocument);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

        public IEnumerable<Book> GetBooks()
        {
            using (var query = QueryBuilder
                .Select(SelectResult.Expression(Expression.Property("Id")),
                SelectResult.Expression(Expression.Property("Title")),
                SelectResult.Expression(Expression.Property("ShortDescription")),
                SelectResult.Expression(Expression.Property("CreatedAt")),
                SelectResult.Expression(Expression.Property("LongDescription")))
                .From(DataSource.Database(_database))
                .Where(Expression.Property("type").EqualTo(Expression.Value("book"))))
            {
                IResultSet results = query.Execute();
                string json = JsonConvert.SerializeObject(results);

                return JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            }


        }
    }
}
