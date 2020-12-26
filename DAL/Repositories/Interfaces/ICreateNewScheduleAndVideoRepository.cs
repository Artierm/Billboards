using System.Collections.Generic;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface ICreateNewScheduleAndVideoRepository: IGenericRepository<ScheduleAndVideo>
    {
        public List<ScheduleAndVideo> GetByScheduleAll(Schedule modelId);

    }
}