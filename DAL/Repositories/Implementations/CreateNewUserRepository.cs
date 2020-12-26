using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
    public class CreateNewUserRepository : BaseGenericRepository, ICreateNewUserRepository
    {
       public CreateNewUserRepository():base(new DatabaseContext())
        {

        }
        public void Create(User model)
        {
            _context.Add(model);
            _context.SaveChanges();
        }                                                                                               

        public void Delete(User model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public User GetById(int modelId)
        {
            return _context.Users.AsQueryable().FirstOrDefault(c => c.Id == modelId);
        }

        public IEnumerable<User> GetAll ()
        {
            return _context.Users.ToList();
        }
        public void Update(User model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
