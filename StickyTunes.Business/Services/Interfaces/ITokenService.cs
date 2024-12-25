using StickyTunes.Data.Models;

namespace StickyTunes.Business.Services.Interfaces;

public interface ITokenService
{
    public string GenerateToken(ApiUser user);
}