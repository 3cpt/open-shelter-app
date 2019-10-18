using System.Linq;
using OpenShelter.Models;
using OpenShelter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(VolunterRepository))]
namespace OpenShelter.Services
{
    public class VolunterRepository : GenericRepository<Volunter>, IVolunterRepository
    {
        public void InsertDummyData()
        {
            for (int i = 0; i < 5; i++)
            {
                var volunter = new Volunter
                {
                    AccessCode = 100 + i,
                    Name = $"name_{i}",
                    Username = $"us{i}",
                };

                this.Add(volunter);
            }
        }
    }
}
