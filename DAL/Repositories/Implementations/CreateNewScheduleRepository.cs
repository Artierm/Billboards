using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class CreateNewScheduleRepository : BaseGenericRepository, ICreateNewScheduleRepository
    {
        public CreateNewScheduleRepository() : base(new DatabaseContext())
        {

        }
        public void Create(Schedule model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Schedule model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public Schedule GetById(int modelId)
        {
            return _context.Schedules.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }

        public Schedule GetByBillboardAddress(string model)
        {
            return _context.Schedules.AsQueryable().FirstOrDefault(c => c.BillboardAddress == model);
        }
        public IEnumerable<Schedule> GetAll()
        {
            return _context.Schedules.ToList();
        }
        public void Update(Schedule model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
