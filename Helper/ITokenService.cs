using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    //Author: Seb
    public interface ITokenService
    {
        string CreateToken(Realtor realtor, int realtorFirmId, string? role, string? realtorId);
    }
}
