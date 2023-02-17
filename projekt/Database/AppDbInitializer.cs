using Microsoft.AspNetCore.Identity;
using projekt.Models.Data.Static;

namespace projekt.Models;

public class AppDbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

            context.Database.EnsureCreated();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(new List<Category>()
                {
                    new Category()
                    {
                        Name = "Krzesło",
                    },
                    new Category()
                    {
                        Name = "Łóżko",
                    },
                    new Category()
                    {
                        Name = "Biurko",
                    },
                    new Category()
                    {
                        Name = "Szafa",
                    },
                    
                });
                context.SaveChanges();
            }

            if (!context.Companies.Any())
            {
                context.Companies.AddRange(new List<Company>()
                {
                    new Company()
                    {
                        Name = "Good furniture",
                        Address = "Kraków, Wrocławska 12/4",
                        PhoneNumber = "514 413 514"
                    },
                    new Company()
                    {
                        Name = "Bedding company",
                        Address = "Kraków, Krakowska 15/4",
                        PhoneNumber = "413 613 114"
                    },
                    new Company()
                    {
                        Name = "Meble na wymiar",
                        Address = "Kraków, Filipa 3/4",
                        PhoneNumber = "114 413 442"
                    },
                });
                context.SaveChanges();

                if (!context.Creators.Any())
                {
                    context.Creators.AddRange(new List<Creator>()
                    {
                        new Creator()
                        {
                            FirstName = "Paweł",
                            SecondName = "Nowak",
                            Bio = "Paweł Nowak jest pasjonatą. Najczęściej projektuje biurka i krzesła."
                        },
                        new Creator()
                        {
                            FirstName = "Tomasz",
                            SecondName = "Kot",
                            Bio = "Tomasz Kot zajmuje się meblami od 20 lat. Jego specjalność to szafy na wymiar."
                        },
                    });
                    context.SaveChanges();
                }
                if (!context.Furnitures.Any())
                {
                    context.Furnitures.AddRange(new List<Furniture>()
                    {
                        new Furniture()
                        {
                            Name = "Krzesło",
                            ImageURL = "https://halomeble.pl/36070-large_default/brock-krzeslo-tapicerowane-do-jadalni.jpg",
                            ProductionDate = DateTime.Now.AddDays(-10),
                            CompanyId = 1,
                            CreatorId = 1,
                            CategoryId = 1
                        },
                        new Furniture()
                        {
                            Name = "Szafa",
                            ImageURL = "https://a.allegroimg.com/original/038722/00fbbdd249f5858a162865413c4a/Szafa-przesuwna-Garderoba-MULTI-23-233-z-lustrem", ProductionDate = DateTime.Now.AddDays(-15),
                            CompanyId = 3,
                            CreatorId = 2,
                            CategoryId = 4
                        },
                        new Furniture()
                        {
                            Name = "Łóżko",
                            ImageURL = "https://mybed.pl/environment/cache/images/1028_1028_productGfx_2315/gulia.jpg",
                            ProductionDate = DateTime.Now.AddDays(-30),
                            CompanyId = 2,
                            CreatorId = 1,
                            CategoryId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }

    public static async Task SeedUsers(IApplicationBuilder applicationBuilder)
    {
        using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            
            string adminUserEmail = "admin@admin.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    FullName = "AdminUser",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Admin@111");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }


            string appUserEmail = "user@user.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    FullName = "AppUser",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "User@222");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}