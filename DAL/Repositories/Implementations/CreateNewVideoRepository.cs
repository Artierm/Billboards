using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class CreateNewVideoRepository : BaseGenericRepository, ICreateNewVideoRepository
    {
        public CreateNewVideoRepository() : base(new DatabaseContext())
        {

        }
        public void Create(Video model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Video model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public Video GetById(int modelId)
        {
            return _context.Videos.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
        public void Update(Video model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }

        public Video GetByName(string name)
        {
            return _context.Videos.AsQueryable().FirstOrDefault(c => c.NameOfVideo == name);
        }
    }
}
