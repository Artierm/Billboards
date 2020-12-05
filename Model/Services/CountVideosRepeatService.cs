using DAL.Context;

namespace BillboardProject.Model.Services
{
    public class CountVideosRepeatService
    {
        private readonly DatabaseContext _database;
       public CountVideosRepeatService()
        {
            _database = new DatabaseContext();
        }
    }
}
