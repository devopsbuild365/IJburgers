using System.Security.Claims;
using Duende.IdentityModel;
using IdentityService.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace IdentityService;

public class SeedData
{
    public static void EnsureSeedData(WebApplication app)
    {
        using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (userMgr.Users.Any()) return;

            var kenneth = userMgr.FindByNameAsync("kenneth").Result;
            if (kenneth == null)
            {
                kenneth = new ApplicationUser
                {
                    UserName = "kenneth",
                    Email = "KennethCheung@example.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(kenneth, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(kenneth, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Kenneth Cheung")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("kenneth created");
            }
            else
            {
                Log.Debug("kenneth already exists");
            }

            var amay = userMgr.FindByNameAsync("amay").Result;
            if (amay == null)
            {
                amay = new ApplicationUser
                {
                    UserName = "amay",
                    Email = "Amay@example.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(amay, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(amay, new Claim[] {
                            new Claim(JwtClaimTypes.Name, "Amay Leung")
                        }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Log.Debug("amay created");
            }
            else
            {
                Log.Debug("amay already exists");
            }
        }
    }
}
