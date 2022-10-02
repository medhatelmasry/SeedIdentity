using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SeedIdentity.Data
{
    public class IdentitySeedData
    {
        public static async Task Initialize(ApplicationDbContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {

            context.Database.EnsureCreated();

            string asdminRole = "Admin";
            string memberRole = "Member";
            string password4all = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(asdminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(asdminRole));
            }

            if (await roleManager.FindByNameAsync(memberRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(memberRole));
            }

            if (await userManager.FindByNameAsync("aa@aa.aa") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    PhoneNumber = "6902341234"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, asdminRole);
                }
            }

            if (await userManager.FindByNameAsync("mm@mm.mm") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    PhoneNumber = "1112223333"
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, memberRole);
                }
            }
        }
    }
}