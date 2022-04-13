using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Repositories;
using BookExchange.Core.Models;

namespace BookExchange.Api.Controllers;

[ApiController]
[Route("[controller]")]

    public class BorrowedBookController : ControllerBase
    { 
    private readonly IBorrowedBookRepository _bookDetails;
        public BorrowedBookController(IBorrowedBookRepository bookDetails)
        {
            _bookDetails = bookDetails;
        }
        [HttpGet]
   
            public async Task<IActionResult> GetBorrowedBook()
            {
                var borrowedBook = await _bookDetails.GetAllBorrowedBooks();
                return Ok(borrowedBook); 
            }     
           
     }


