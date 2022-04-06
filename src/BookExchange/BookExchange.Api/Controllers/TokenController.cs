using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookExchange.Api.Services;
using BookExchange.Api.Repositories;
using BookExchange.Core.Models;
using BookExchange.Api.Data;


namespace BookExchange.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
     private readonly IUserRepository _userRepository;
     private readonly ApplicationDbContext _context;
    readonly ITokenService tokenService;

    public TokenController(IUserRepository userRepository, ITokenService tokenService, ApplicationDbContext context)
    {
        _userRepository = userRepository;
        _context = context;
        this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
    }

    [HttpPost]
    [Route("refresh")]
    public IActionResult Refresh(TokenApiModel tokenApiModel)
    {
        if (tokenApiModel is null)
        {
            return BadRequest("Invalid client request");
        }

        string accessToken = tokenApiModel.AccessToken;
        string refreshToken = tokenApiModel.RefreshToken;

        var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
        var username = principal.Identity.Name; //this is mapped to the Name claim by default

        var user = _context.Users.SingleOrDefault(u => u.Username == username);

        if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            return BadRequest("Invalid client request");
        }

        var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
        var newRefreshToken = tokenService.GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        _userRepository.SaveChanges();

        return new ObjectResult(new
        {
            accessToken = newAccessToken,
            refreshToken = newRefreshToken
        });
    }

    [HttpPost, Authorize]
    [Route("revoke")]
    public IActionResult Revoke()
    {
        var username = User.Identity.Name;

        var user = _context.Users.SingleOrDefault(u => u.Username == username);
        if (user == null) return BadRequest();

        user.RefreshToken = null;

        _userRepository.SaveChanges();

        return NoContent();
    }
}

