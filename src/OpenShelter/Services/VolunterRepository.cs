using System.Linq;
using OpenShelter.Models;
using OpenShelter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(VolunterRepository))]
namespace OpenShelter.Services
{
    public class VolunterRepository : GenericRepository<Volunter>
    {
        public void InsertDummyData()
        {
            var list = this.GetAll(v => true);

            if (list != null && list.ToList().Count > 0)
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
}
