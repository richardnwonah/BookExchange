using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Repositories;
using BookExchange.Core.Models;
using BookExchange.Api.DTOs;

namespace BookExchange.Api.Controllers;

[ApiController]
[Route("[controller]")]
    [Authorize]
    public class BookController : ControllerBase
    { 
    private readonly IBookRepository _books;
        public BookController(IBookRepository books)
        {
            _books = books;
        }  
        [Authorize]
         [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookByIdAsync(Guid Id)
        {
            var result = _books.GetBookByIdAsync(Id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBook(){
                var books = await _books.GetAllBooksAsync();
                return Ok(books);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO book)
        {
            
            var result =  _books.PostBook(book);
            if(!(await result))
            {

            }
            return CreatedAtAction(nameof(GetBook), new { bookid = book.Id }, book);
                
            }    
        [Authorize] 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid Id)
        {
            var result = _books.DeleteBook(Id);
                if(result == null)
                {
                    return NotFound();
                }
            
            return NoContent();
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(Guid Id, BookDTO book)
        {
            if (Id != book.Id)
            {
            return BadRequest();
            }

            var result = _books.PutBook(book);

            if(result == null)
            {
                return NotFound();
            }
             return NoContent();
        }
                
     }


