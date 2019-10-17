using OpenShelter.Models;
using OpenShelter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(VolunterRepository))]
namespace OpenShelter.Services
{
    public class AttendanceRepository : GenericRepository<Attendance>
    {
    }
}
