using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class CreateNewBillboardRepository : BaseGenericRepository, ICreateNewBillboardRepository
    {
        public CreateNewBillboardRepository() : base(new DatabaseContext())
        {

        }
        public void Create(Billboard model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Billboard model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public Billboard GetById(int modelId)
        {
            return _context.Billboards.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }

        public IEnumerable<Billboard> GetAll()
        {
            return _context.Billboards.ToList();
        }
        public void Update(Billboard model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
