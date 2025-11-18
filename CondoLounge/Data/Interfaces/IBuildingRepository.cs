using CondoLounge.Data.Entities;

namespace CondoLounge.Data.Interfaces
{
    public interface IBuildingRepository : ICondoLounge<Building>
    {
        IEnumerable<ApplicationUser> GetApplicationUsersforBuilding(int buildingId);
        IEnumerable<Condo> GetCondosForBuilding(int buildingId);
    }
}
