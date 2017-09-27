using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace csharp_test_webapi_withdbsetup
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        public MediaContext _db {get; set;}
        public BooksController(MediaContext db)
        {
            _db = db;
        }
        
        // List<Book> Books = new List<Book>() {
        //     new Book("Moby Dick", "Penguin", 400, "Sdlkskjd333-f"),
        //     new Book("Fake Book", "Fakers", 700, "Sdlkdddskjd333-j"),
        //     new Book("Harry Potter", "ZachBooks", 150, "Sdlkskjdsfeee3-z")
        // };

        // GET api/values
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            // return new string[] { "book1", "book2" };
            return _db.Books;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Book value)
        // public IEnumerable<Book> Post([FromBody]Book value)
        {
            _db.Books.Add(value);
            _db.SaveChanges();
            return "Book was successfully added";
            // return _db.Books;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Book value)
        {
            var book = _db.Books.Find(id);
            if(book != null)
            {
                if(value.Title != null)
                {
                    book.Title = value.Title;
                }
                if(value.Publisher != null)
                {
                    book.Publisher = value.Publisher;
                }
                if(value.Pages != null)
                {
                    book.Pages = value.Pages;
                }
                _db.SaveChanges();
                return "Success";
            }
            return "It is broke";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var book = _db.Books.Find(id);
            if(book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                return "The magazine was deleted";
            }
            return "The delete failed";
        }
    }
}
