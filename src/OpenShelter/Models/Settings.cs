using SQLite;

namespace OpenShelter.Models
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public bool FirstRun { get; set; }
    }
}
