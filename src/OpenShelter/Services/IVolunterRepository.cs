using OpenShelter.Models;

namespace OpenShelter.Services
{
    public interface IVolunterRepository : IGenericRepository<Volunter>
    {
        void InsertDummyData();
    }
}