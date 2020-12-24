using System.Linq;
using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;

namespace BillboardsProject.Model.Services
{
    public class LogService
    {
        private readonly ICreateNewLogRepository _createNewLogRepository;

        public LogService(ICreateNewLogRepository  createNewLogRepository)
        {
            _createNewLogRepository = createNewLogRepository;
        }

        public void CreateFileLogs()
        {
            var logs = _createNewLogRepository.GetAll();

            System.IO.File.WriteAllLines($@".\Log__.txt",
               logs.Select(l => l.ToString()).ToArray());
        }
    }
}