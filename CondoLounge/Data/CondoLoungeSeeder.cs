using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace CondoLounge.Data
{
    public class CondoLoungeSeeder
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public CondoLoungeSeeder(ApplicationDbContext context,
                IWebHostEnvironment hosting,
                UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole<int>> roleManager)
        {
            _db = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            //Verify that the database exists. Hover over the method and read the documentation. 
            _db.Database.EnsureCreated();

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Normal"));
            }
            if(!_db.Buildings.Any())
            {
                var building = new Building() { CondoNumber = "0000" };
                _db.Buildings.Add(building);
                await _db.SaveChangesAsync();
                if (!_userManager.Users.Any())
                {
                    var user = new ApplicationUser() { UserName = "admin@email.com", Email = "admin@email.com" , BuildingId = building.Id};
                    await _userManager.CreateAsync(user, "VerySecureAdmin45%");
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                if (!_db.Condos.Any())
                {
                    var adminUser = _userManager.Users.First();


                    var condo = new Condo()
                    {
                        Location = "Montreal",
                        BuildingId = building.Id,
                        UserId = adminUser.Id,
                    };

                    _db.Condos.Add(condo);
                    await _db.SaveChangesAsync();
                }
            }
        }
    }
}
