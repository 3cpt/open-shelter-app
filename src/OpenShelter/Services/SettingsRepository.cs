using OpenShelter.Models;
using OpenShelter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(SettingsRepository))]
namespace OpenShelter.Services
{
    public class SettingsRepository : GenericRepository<Settings>
    {
        void InsertDefault()
        {

        }
    }
}
