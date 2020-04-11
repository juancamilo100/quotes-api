using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotesApi.Models;
using QuotesApi.Data;

namespace QuotesApi.Controllers
{
    [Route("[controller]")]
    public class QuotesController : Controller
    {
        private QuotesDbContext quotesDbContext;

        public QuotesController(QuotesDbContext dbContext)
        {
            quotesDbContext = dbContext;
        }

        static List<Quote> quotes = new List<Quote>()
        {
                new Quote() { Id = 0, Author = "Some Cool Author", Description = "Some DEscription", Title = "Some Title" },
                new Quote() { Id = 1, Author = "Another Author", Description = "Another DEscription", Title = "Another Title" }
        };

        // GET: api/values
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quotesDbContext.Quotes;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            return quotesDbContext.Quotes.Find(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Quote quote)
        {
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Quote quote)
        {
            var foundQuote = quotesDbContext.Quotes.Find(id);
            foundQuote.Author = quote.Author;
            foundQuote.Description = quote.Description;
            foundQuote.Title = quote.Title;
            quotesDbContext.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var foundQuote = quotesDbContext.Quotes.Find(id);
            quotesDbContext.Remove(foundQuote);
            quotesDbContext.SaveChanges();
        }
    }
}
