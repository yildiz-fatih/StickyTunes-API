using Microsoft.AspNetCore.Mvc;
using StickyTunes.Business.DTOs.Account;
using StickyTunes.Business.Services.Interfaces;

namespace StickyTunes.API.Controllers;

[Route("api/accounts")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(new RegisterResponse
            {
                Succeeded = false,
                Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
            });

        var result = await _accountService.RegisterAsync(registerRequest);

        if (result.Succeeded)
            return Ok(new RegisterResponse
            {
                Succeeded = true,
                Errors = []
            });

        return BadRequest(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        if (!ModelState.IsValid)
            return BadRequest(new LoginResponse
            {
                Succeeded = false,
                Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
            });

        var result = await _accountService.LoginAsync(loginRequest);

        if (result.Succeeded)
        {
            return Ok(result);
        }

        return Unauthorized(result);
    }
}