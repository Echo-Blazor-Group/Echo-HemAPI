using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Echo_HemAPI.Data.Repositories.Interfaces;
using Echo_HemAPI.Data.Repositories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Echo_HemAPI.Helper;
using System.Collections.Generic;


namespace Echo_HemAPI
{
    //Author All
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>
            (options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("EchoHomeDb")));


            builder.Services.AddIdentity<Realtor, IdentityRole>(options =>
            {
                // Configure identity options here
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromHours(1); // logs user out automatically in 1 hour
                options.SlidingExpiration = true; // post pones automatic log out when using the app

                //3 options below = fix routing
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            // Makes sure .NET doesn't trim the "Async"-suffix in async method names in routing and link generation
            builder.Services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IEstateRepository, EstateRepository>();
            builder.Services.AddScoped<IRealtorFirmRepository, RealtorFirmRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IPictureRepository, PictureRepository>();
            builder.Services.AddRazorPages();
            builder.Services.AddAutoMapper(typeof(Program));


            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<ApplicationDbContext>();
                var userManager = services.GetRequiredService<UserManager<Realtor>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                var dbSeeder = new DbSeeder();
                await dbSeeder.SeedAsync(userManager, roleManager, context);
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
            app.MapRazorPages();

            app.Run();
        }
    }
}
