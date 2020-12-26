using DAL.Context;

namespace DAL.Repositories
{
    public  abstract class BaseGenericRepository
    {
        protected readonly DatabaseContext _context;
        protected BaseGenericRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }
    }
}

