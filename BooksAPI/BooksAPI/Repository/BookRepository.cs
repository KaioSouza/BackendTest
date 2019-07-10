using BooksAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BooksAPI.Repository
{
    public class BookRepository
    {
        private IEnumerable<Book> _books;

        public BookRepository()
        {       
            using (StreamReader reader = new StreamReader("books.json"))
            {
                this._books = JsonConvert.DeserializeObject<List<Book>>(reader.ReadToEnd());
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }
    }
}
