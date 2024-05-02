using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    public interface ITokenService
    {
        string CreateToken(Realtor realtor, int realtorFirmId, string? role);
    }
}
