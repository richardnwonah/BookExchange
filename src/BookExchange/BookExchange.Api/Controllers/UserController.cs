namespace BookExchange.Api.Controllers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Helpers;
using BookExchange.Api.Models;
using BookExchange.Api.Repositories;
using BookExchange.Api.Services;
using BookExchange.Core.Models;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private readonly IUserRepository _users;
    private IUserService _userService;

    public UserController(IUserService userService, IUserRepository users)
    {
        _userService = userService;
          _users = users;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

      [HttpGet("{UserId}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(Guid UserId)
        {
            var result = _users.GetUserByIdAsync(UserId);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteUser(Guid Id)
        {
            var result = _users.DeleteUser(Id);
                if(result == null)
                {
                    return NotFound();
                }
            
            return NoContent();
        }


    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
