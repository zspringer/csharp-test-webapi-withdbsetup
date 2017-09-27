using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace csharp_test_webapi_withdbsetup
{
    [Route("api/[controller]")]
    public class MagazinesController : Controller
    {
        public MediaContext _db {get; set;}
        public MagazinesController(MediaContext db)
        {
            _db = db;
        }
        // List<Magazine> Magazines = new List<Magazine>() {
        //     new Magazine("Time", "Time", 4100, "ItsTime!", 232),
        //     new Magazine("Time", "Time", 4100, "ItsTime!", 232),
        //     new Magazine("Boys Life", "BoyScouts", 100, "ItsTime!", 232)
            
        // };

        // GET api/values
        [HttpGet]
        //IEnumerable is saying that it will iterate over a list
        public IEnumerable<Magazine> Get()
        {
            // return new string[] { "magazine1", "magazine2" };
            return _db.Magazines;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Magazine Get(int id)
        {
            return _db.Magazines.Find(id);
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Magazine value)
        {
            _db.Magazines.Add(value);
            _db.SaveChanges();
            return "Magazine was successfully added";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]Magazine value)
        {
            var magazine = _db.Magazines.Find(id);
            if(magazine != null)
            {
                if(value.Title != null)
                {
                    magazine.Title = value.Title;
                }
                if(value.Publisher != null)
                {
                    magazine.Publisher = value.Publisher;
                }
                if(value.Pages != null)
                {
                    magazine.Pages = value.Pages;
                }
                // if(value.Headline != null)
                // {
                //     magazine.Headline = value.Headline;
                // }
                // if(value.Issue != null)
                // {
                //     magazine.Issue = value.Issue;
                // }
                _db.SaveChanges();
                return "Success";
            }
            return "It is broke";
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            var magazine = _db.Magazines.Find(id);
            if(magazine != null)
            {
                _db.Magazines.Remove(magazine);
                _db.SaveChanges();
                return "The magazine was deleted";
            }
            return "The delete failed";
        }
    }
}
