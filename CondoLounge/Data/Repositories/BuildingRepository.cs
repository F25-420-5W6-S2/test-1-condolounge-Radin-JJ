using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data.Repositories
{
    public class BuildingRepository : CondoLoungeGenericGenericRepository<Building>, IBuildingRepository
    {
        private readonly ApplicationDbContext _db;
        public BuildingRepository(ApplicationDbContext db, ILogger<BuildingRepository> logger) : base(db, logger)
        {
            _db = db;
        }
        public IEnumerable<Building> GetAll()
        {
            return _db.Buildings
                .Include(b => b.Users)
                .Include(b => b.Condos)
                .ToList();
        }
        public IEnumerable<ApplicationUser> GetApplicationUsersforBuilding(int buildingId)
        {
            return _db.Users
                .Where(u=> u.BuildingId == buildingId)
                .ToList();
        }        
        public IEnumerable<Condo> GetCondosForBuilding(int buildingId)
        {
            return _db.Condos
                .Where(c=> c.BuildingId == buildingId)
                .ToList();
        }

    }
}
