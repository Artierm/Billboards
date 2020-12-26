using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface ICreateNewScheduleRepository : IGenericRepository<Schedule>
    {
        public Schedule GetByBillboardAddress(string model);
    }
}
