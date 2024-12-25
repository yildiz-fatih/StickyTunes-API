using Microsoft.AspNetCore.Identity;
using StickyTunes.Business.DTOs.Account;
using StickyTunes.Business.Services.Interfaces;
using StickyTunes.Data.Models;

namespace StickyTunes.Business.Services.Implementations;

public class AccountService : IAccountService
{
    private readonly UserManager<ApiUser> _userManager;
    private readonly ITokenService _tokenService;

    public AccountService(UserManager<ApiUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = new ApiUser()
        {
            FullName = registerRequest.FullName,
            UserName = registerRequest.UserName,
            Email = registerRequest.Email
        };

        var result = await _userManager.CreateAsync(user, registerRequest.Password);
        
        if (!result.Succeeded)
        {
            return new RegisterResponse
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => $"{e.Code}: {e.Description}").ToList()
            };
        }
        
        return new RegisterResponse
        {
            Succeeded = true,
            Errors = []
        };
    }
    
    public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        var user = await _userManager.FindByNameAsync(loginRequest.UserName);

        if (user == null)
            return new LoginResponse
            {
                Succeeded = false,
                Errors = new List<string> { "User not found." }
            };

        if (!await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            return new LoginResponse
            {
                Succeeded = false,
                Errors = new List<string> { "Invalid username or password." }
            };
        
        var token = _tokenService.GenerateToken(user);

        return new LoginResponse
        {
            Succeeded = true,
            Token = token,
            Errors = []
        };
    }
}