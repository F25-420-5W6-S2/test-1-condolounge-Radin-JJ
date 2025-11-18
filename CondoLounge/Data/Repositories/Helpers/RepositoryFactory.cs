
using CondoLounge.Data.Entities;
using CondoLounge.Data.Interfaces;

namespace CondoLounge.Data.Repositories.Helpers
{
    public class RepositoryFactories
    {
        private ILoggerFactory _loggerFactory;
        private readonly IDictionary<Type, Func<ApplicationDbContext, object>> _repositoryFactories;

        private IDictionary<Type, Func<ApplicationDbContext, object>> GetDucthFactories()
        {
            return new Dictionary<Type, Func<ApplicationDbContext, object>>
            {
                {typeof(ICondoLounge<Building>), dbContext => new BuildingRepository(dbContext, new Logger<BuildingRepository>(_loggerFactory)) },
            };
        }
        public RepositoryFactories(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _repositoryFactories = GetDucthFactories();
        }

        public Func<ApplicationDbContext, object> GetRepositoryFactory<T>()
        {
            Func<ApplicationDbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<ApplicationDbContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<ApplicationDbContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbContext => new CondoLoungeGenericGenericRepository<T>(dbContext, 
                                        new Logger<CondoLoungeGenericGenericRepository<T>>(_loggerFactory));
        }
    }
}
