using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface ICreateNewVideoRepository: IGenericRepository<Video>
    {
        Video GetByName(string name);
    }
}
