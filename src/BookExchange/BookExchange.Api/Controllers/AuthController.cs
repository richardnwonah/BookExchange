using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Core.Models;
using BookExchange.Api.Services;
using BookExchange.Api.Repositories;
using BookExchange.Api.DTOs;


#pragma warning restore format


namespace BookExchange.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;
        public AuthController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
   // GET api/values
    [HttpPost, Route("Login")]
    public IActionResult Login([FromBody] LoginDTO user)
    {

        if (user == null)
        {
            return BadRequest("Invalid client request");
        }

        var _user =  _userRepository.Verify(user);
         
        if (_user == null)
        {
            return Unauthorized();
        }
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, "Manager")
        };
        var accessToken = _tokenService.GenerateAccessToken(claims);
        var refreshToken = _tokenService.GenerateRefreshToken();
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        _userRepository.SaveChanges();
        return Ok(new
        {
            Token = accessToken,
            RefreshToken = refreshToken
        });
    }

    [HttpPost]
    [HttpPost, Route("Register")]
     public async Task<ActionResult<RegistrationDTO>> AddUser(RegistrationDTO user)
            {
               var result =  _userRepository.PostUser(user);
                if(!(await result))
                {

                }
                 return Ok();
                //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
                
            }   
}
