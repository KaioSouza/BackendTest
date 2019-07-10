using BooksAPI.Controllers;
using BooksAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace BooksApiTest
{
    public class BooksTest
    {
        private BooksController _booksController;
        public BooksTest()
        {
           _booksController = new BooksController();
        }

        [Fact]
        public void GetByIdReturnsBook()
        {
            Assert.IsType<ActionResult<Book>>(_booksController.GetById(1));
        }

        [Fact]
        public void GetByNameReturnsBookCollection()
        {
           Assert.IsType<ActionResult<IEnumerable<Book>>>(_booksController.GetByName(""));
        }

        [Fact]
        public void GetByAuthorReturnsNull()
        {     
            Assert.Null(_booksController.GetByAuthor("").Value);
        }
    }
}
