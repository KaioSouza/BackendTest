using System;
using System.Collections.Generic;
using System.Linq;
using BooksAPI.Models;
using BooksAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BooksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return new BookRepository().GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetById(int id)
        {
            try
            {
                return new BookRepository().GetAll().First(x => x.Id == id);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("getbyname/{name}/{order?}")]
        public ActionResult<IEnumerable<Book>> GetByName(string name, string order = null)
        {
            try
            {
                if (String.IsNullOrEmpty(order) || order.Equals("asc"))
                {
                    return new BookRepository().GetAll().Where(x => x.Name == name).OrderBy(x => x.Price).ToList();
                }
                else if (order.Equals("desc"))
                {
                    return new BookRepository().GetAll().Where(x => x.Name == name).OrderByDescending(x => x.Price).ToList();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("getbyauthor/{author}/{order?}")]
        public ActionResult<IEnumerable<Book>> GetByAuthor(string author, string order = null)
        {
            try
            {
                if (String.IsNullOrEmpty(order) || order.Equals("asc"))
                {
                    return new BookRepository().GetAll().Where(x => x.Specification.Author == author).OrderBy(x => x.Price).ToList();
                }
                else if(order.Equals("desc"))
                {
                    return new BookRepository().GetAll().Where(x => x.Specification.Author == author).OrderByDescending(x => x.Price).ToList();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("getfreightcost/{id}")]
        public ActionResult<string> GetFreightCost(int id)
        {
            try
            {
                return (new BookRepository().GetAll().Where(x => x.Id == id).First().Price / 100 * 20).ToString();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}