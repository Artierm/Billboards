using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    public class CreateNewScheduleAndVideoRepository : BaseGenericRepository, ICreateNewScheduleAndVideoRepository
    {
        public CreateNewScheduleAndVideoRepository() : base(new DatabaseContext())
        {

        }
        public void Create(ScheduleAndVideo model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(ScheduleAndVideo model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public ScheduleAndVideo GetById(int modelId)
        {
            return _context.ScheduleAndVideo.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }
        public List<ScheduleAndVideo> GetByScheduleAll(Schedule modelId)
        {
            return _context.ScheduleAndVideo.AsQueryable().Where(c => c.Schedule == modelId).ToList();
        }

        public IEnumerable<ScheduleAndVideo> GetAll()
        {
            return _context.ScheduleAndVideo.ToList();
        }
        public void Update(ScheduleAndVideo model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
