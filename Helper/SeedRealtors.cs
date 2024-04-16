using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace Echo_HemAPI.Helper
{
    //Author Seb
    public class SeedRealtors
    {
        public static async Task<bool> CreateRealtors(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager, int numberOfSeeds)
        {
            if (await userManager.Users.AnyAsync())
            {
                return false;
            }

            for (int i = 0; i < numberOfSeeds; i++)
            {
                var realtor = new Realtor
                {
                    FirstName = "John",
                    LastName = "Doe",
                    //Email = $"JohnDoe@{}"
                    //RealtorFirm = RealtorFirm 
                                                     
                };

                // Create the user
                var result = await userManager.CreateAsync(realtor, $"{realtor.FirstName}@1234");

                if (!result.Succeeded)
                {
                    // Handle user creation failure
                    return false;
                }

                // Assign roles if needed
                // Example: await userManager.AddToRoleAsync(realtor, "Realtor");
            }
            return true;
            
        }
    }
}
