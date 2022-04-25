namespace BookExchange.Api.Controllers;

using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Helpers;
using BookExchange.Api.Models;
using BookExchange.Api.Services;

[ApiController]
[Route("[controller]")]
public class authController : ControllerBase
{
    private IUserService _userService;

    public authController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
