using DAL.Context;

namespace Billbort.Model.Services
{
    public class CountVideosRepeatService
    {
        private DatabaseContext _database;
        CountVideosRepeatService()
        {
            _database = new DatabaseContext();
        }
    }
}
