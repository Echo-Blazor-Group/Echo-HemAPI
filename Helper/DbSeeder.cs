using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Echo_HemAPI.Helper
{

    //Author Seb
    public class DbSeeder
    {
        public async Task SeedAsync(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager,
                                    ApplicationDbContext context)
        {
            //SeedPicturesAsync calls the other methods in order to pass the needed paramaters and seed all models.
            await SeedPicturesAsync(userManager,roleManager, context);
            await context.SaveChangesAsync();
        }

        private async Task SeedPicturesAsync(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager,
                                             ApplicationDbContext context)

        {   //Check to see if data in pictures table, if so, do not seed.
            if (await context.Pictures.AnyAsync())
            {
                await Task.CompletedTask;
            }
            var pictures = new List<Picture>
        {
            //Logotyp Sverige Mäklarna [0]
            new Picture { PictureUrl = "https://shorturl.at/wKPQR"},
            //Logotyp Skandinaviens Mäklare [1]
            new Picture { PictureUrl = "https://shorturl.at/ltDNT"},
            //Logotyp Länets Mäklare [2]
            new Picture { PictureUrl = "https://shorturl.at/bgvwF"},
            //Logotyp Hemma Mäklarna [3]
            new Picture { PictureUrl = "https://shorturl.at/iFMVX"},
            //Logotyp Fastighetsbyrån [4]
            new Picture { PictureUrl = "https://shorturl.at/iHKUZ"},


            //A realtor profile picture [5]
            new Picture {PictureUrl = "https://shorturl.at/cIY05"},
            //A realtor profile picture [6]
            new Picture {PictureUrl = "https://shorturl.at/eDGY6"},
            //A realtor profile picture [7]
            new Picture {PictureUrl = "https://shorturl.at/bjwAP"},
            //A realtor profile picture [8]
            new Picture {PictureUrl = "https://shorturl.at/yMQ57"},
            //A realtor profile picture [9]
            new Picture {PictureUrl = "https://shorturl.at/airKP"},


            //Estate 1; Villa, pic 1/2 [10]
            new Picture {PictureUrl = "https://shorturl.at/fjAP6"},
            //Estate 1; Villa, pic 2/2 [11]
            new Picture {PictureUrl = "https://shorturl.at/bhjQ6"},

            //Estate 2; Bostadsrättsradhus, pic 1/2 [12]
            new Picture {PictureUrl = "https://shorturl.at/knoqS"},
            //Estate 2; Bostadsrättsradhus, pic 2/2 [13]
            new Picture {PictureUrl = "https://shorturl.at/bpsD3"},

            //Estate 3; Fritidshus, pic 1/2 [14]
            new Picture {PictureUrl = "https://t.ly/P6gGo"},
            //Estate 3; Fritidshus, pic 2/2 [15]
            new Picture {PictureUrl = "https://t.ly/pL39g"},

            //Estate 4; Bostadsrättslägenhet, pic 1/2 [16]
            new Picture {PictureUrl = "https://t.ly/eUdxU"},
            //Estate 4; Bostadsrättslägenhet, pic 2/2 [17]
            new Picture {PictureUrl = "https://t.ly/z2sKC"}

        };

            await context.Pictures.AddRangeAsync(pictures);
            await context.SaveChangesAsync();
            pictures = await context.Pictures.ToListAsync();
            await SeedRealtorFirmsAsync(userManager, roleManager,context,pictures);
        }

        private async Task SeedRealtorFirmsAsync(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager,
                                                 ApplicationDbContext context, List<Picture> pictures)
        {
            var firms = new List<RealtorFirm>
        {
            new RealtorFirm { Name = "Sverige Mäklarna", RealtorFirmPresentation = "Vi har de bästa mäklarna i Sverige.", Logotype = pictures[0]},
            new RealtorFirm { Name = "Skandinaviens Mäklarna", RealtorFirmPresentation = "Efter 79 år i branschen så hjälper vi dig att hitta ditt nya hem.", Logotype = pictures[1]},
            new RealtorFirm { Name = "Länets Mäklare", RealtorFirmPresentation = "Vi tror på att jobba lokalt.", Logotype = pictures[2]},
            new RealtorFirm { Name = "Hemma Mäklarna", RealtorFirmPresentation = "Borta bra, hemma bäst.", Logotype = pictures[3]},
            new RealtorFirm { Name = "Fastighetsbyrån", RealtorFirmPresentation = "Vi kan fastigheter.", Logotype = pictures[4]}

        };

            await context.RealtorFirms.AddRangeAsync(firms);
            await context.SaveChangesAsync();
            firms = await context.RealtorFirms.ToListAsync();
            await SeedRealtorsAsync(userManager,roleManager,context, pictures, firms);
        }

        private async Task SeedRealtorsAsync(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager,
                                             ApplicationDbContext context, List<Picture> pictures, List<RealtorFirm> firms)
        {
            var realtors = new List<Realtor>
        {
            new Realtor { FirstName = "John", LastName = "Doe", RealtorFirm = firms[0], ProfilePicture = pictures[5]
            ,Email ="Johndoe@hotmail.com", UserName ="Johndoe@hotmail.com", PhoneNumber ="0762255184"},

            new Realtor { FirstName = "Jane", LastName = "Smith", RealtorFirm = firms[1], ProfilePicture = pictures[6]
            ,Email ="Janesmith@hotmail.com", UserName ="Janesmith@hotmail.com", PhoneNumber ="0762255185"},

            new Realtor { FirstName = "Kalle", LastName = "Kula",RealtorFirm = firms[2], ProfilePicture = pictures[7]
            ,Email ="Kallekula@hotmail.com", UserName ="Kallekula@hotmail.com", PhoneNumber ="0762255186"},

            new Realtor { FirstName = "Samed", LastName = "Salman",RealtorFirm = firms[3], ProfilePicture = pictures[8]
            ,Email ="Samedsalman@hotmail.com", UserName ="Samedsalman@hotmail.com", PhoneNumber ="0762255187"},

            new Realtor { FirstName = "Gustaf", LastName = "VSF", RealtorFirm = firms[4], ProfilePicture = pictures[9]
            ,Email ="Gustafvsf@hotmail.com", UserName ="Gustafvsf@hotmail.com", PhoneNumber ="0762255188"}

        };
            for (int i = 0; i < 5; i++)
            {
                string password = $"{realtors[i].FirstName}@1234";
                await userManager.CreateAsync(realtors[i], password);
            }
            await SeedEstatesAsync(userManager,roleManager,context,pictures, realtors);
        }


        private async Task SeedEstatesAsync(UserManager<Realtor> userManager, RoleManager<IdentityRole> roleManager,
                                            ApplicationDbContext context, List<Picture> pictures, List<Realtor> realtors)
        {
            var counties = await context.Counties.ToListAsync();
            var categories = await context.Categories.ToListAsync();
            var estates = new List<Estate>
        {
            new Estate
                {
                    Address = "123 Main St",
                    StartingPrice = 200000,
                    LivingAreaKvm = "150",
                    NumberOfRooms = "3",
                    BiAreaKvm = "50",
                    EstateAreaKvm = "200",
                    MonthlyFee = "3000",
                    RunningCosts = "1000",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "A beautiful house near the park.",
                    PublishDate = new DateOnly(2024, 4, 18),
                    County = counties[0],
                    Realtor = realtors[0],
                    Category = categories[0],
                    Pictures = pictures.GetRange(10,2)


                },
                new Estate
                {
                    Address = "789 Oak Avenue",
                    StartingPrice = 250000,
                    LivingAreaKvm = "180",
                    NumberOfRooms = "5",
                    BiAreaKvm = "60",
                    EstateAreaKvm = "240",
                    MonthlyFee = "3200",
                    RunningCosts = "1100",
                    ConstructionDate = "2015-09-20",
                    EstateDescription = "Spacious modern house with a backyard pool",
                    PublishDate = new DateOnly(2024, 4, 18),
                    County = counties[1],
                    Realtor = realtors[1],
                    Category = categories[1],
                    Pictures = pictures.GetRange(12,2)
                },
                new Estate
                {
                    Address = "458 Elm Street",
                    StartingPrice = 180000,
                    LivingAreaKvm = "110",
                    NumberOfRooms = "4",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "160",
                    MonthlyFee = "1800",
                    RunningCosts = "900",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "Cozy family home near the lake",
                    PublishDate = new DateOnly(2024, 4, 18),
                    County = counties[2],
                    Realtor = realtors[2],
                    Category = categories[2],
                    Pictures = pictures.GetRange(14,2)

                },
                new Estate
                {
                    Address = "456 Allsm Street",
                    StartingPrice = 180000,
                    LivingAreaKvm = "120",
                    NumberOfRooms = "5",
                    BiAreaKvm = "40",
                    EstateAreaKvm = "160",
                    MonthlyFee = "2800",
                    RunningCosts = "900",
                    ConstructionDate = "2020-01-01",
                    EstateDescription = "Cozy family home near the lake",
                    PublishDate = new DateOnly(2024, 4, 18),
                    County = counties[3],
                    Realtor = realtors[3],
                    Category = categories[3],
                    Pictures = pictures.GetRange(16,2)

                }

        };

            await context.Estates.AddRangeAsync(estates);
            await context.SaveChangesAsync();
        }
    }

}
