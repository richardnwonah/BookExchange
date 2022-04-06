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
//[Authorize]
    public class UserController : ControllerBase
    { 
    private readonly IUserRepository _users;
        public UserController(IUserRepository users)
        {
            _users = users;
        }
        [HttpGet]
       // [Authorize]
            public async Task<IActionResult> Get(){

                var users = await _users.GetAllUsersAsync();
                return Ok(users);
        
        }
                
        }


