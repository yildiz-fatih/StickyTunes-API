using StickyTunes.Business.DTOs.Account;

namespace StickyTunes.Business.Services.Interfaces;

public interface IAccountService
{
    public Task<RegisterResponse> RegisterAsync(RegisterRequest registerRequest);
    public Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
}