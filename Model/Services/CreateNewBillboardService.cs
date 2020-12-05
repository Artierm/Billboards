using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject.Service
{
    public class CreateNewBillboardService
    {
        private readonly ICreateNewBillboardRepository _createNewBillboardRepository;
        public CreateNewBillboardService(ICreateNewBillboardRepository createNewBillboardRepository)
        {
            _createNewBillboardRepository = createNewBillboardRepository;
        }

        public void AddBillboard(string address)
        {
            Billboard billboard = new Billboard(string.Empty, address);
            _createNewBillboardRepository.Create(billboard);
        }
    }
}
