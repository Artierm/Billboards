using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DAL.Context;
using DAL.Models;

namespace DAL.Repositories.Implementations
{
    public class CreateNewLogRepository : BaseGenericRepository, ICreateNewLogRepository
    {
        public CreateNewLogRepository() : base(new DatabaseContext())
        {

        }

        public void Create(Log model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Log model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public Log GetById(int modelId)
        {
            return _context.Logs.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }

        public IEnumerable<Log> GetAll()
        {
            return _context.Logs.ToList();
        }

        public void Update(Log model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
