using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace Echo_HemAPI.Helper
{
    //Static details
    //Author: Seb
    public static class SD
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Realtor = "Realtor";
        public const string SuperAdminOrRealtor = SD.SuperAdmin + "," + SD.Realtor;
    }
}
