using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;
namespace CondoLounge.Data.Repositories
{
    public class CondoRepository : CondoLoungeGenericGenericRepository<Condo>, ICondoRepository
    {
        public CondoRepository(ApplicationDbContext db, ILogger<CondoRepository> logger) : base(db, logger)
        {

        }
    }
}
