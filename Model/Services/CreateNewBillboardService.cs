using System;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject.Service
{
    public class CreateNewBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        private readonly ICreateNewLogRepository _createNewLogRepository;
        public CreateNewBillboardService(ICreateNewBillboardRepository createNewBillboardRepository, ICreateNewLogRepository createNewLogRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
            _createNewLogRepository = createNewLogRepository;
        }

        public void AddBillboard(string address)
        {
            Billboard billboard = new Billboard(string.Empty, address);
            _createNewBillboardRepository.Create(billboard);
            string message = $"Admin added new billboard {address}";
            Log log = new Log(DateTime.Now, message);
            _createNewLogRepository.Create(log);
        }
    }
}
