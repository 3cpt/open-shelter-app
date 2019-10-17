using OpenShelter.Models;
using OpenShelter.Services;

[assembly: Xamarin.Forms.Dependency(typeof(TaskTypeRepository))]
namespace OpenShelter.Services
{
    public class TaskTypeRepository : GenericRepository<TaskType>
    {
    }
}
