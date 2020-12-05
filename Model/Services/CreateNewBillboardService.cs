using DAL.Models;
using DAL.Repositories.Interfaces;

namespace BillboardProject.Presents
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
            DAL.Models.Billboard billboard = new DAL.Models.Billboard(string.Empty, address);
            _createNewBillboardRepository.Create(billboard);
        }
    }
}
