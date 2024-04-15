
using Echo_HemAPI.Data.Models;

namespace Echo_HemAPI.Helper
{
    public static class SeedCounties
    {
        public static County[] GetCounties()
        {
            return new[]
            {
            new County { CountyId = 1, CountyName ="" },
            new County { CountyId = 2, CountyName = "" },
            new County { CountyId = 3, CountyName = "" }
            // Add more counties here
        };


        }
}
