using SQLite;

namespace OpenShelter.Models
{
    public class Volunter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public int AccessCode { get; set; }
    }
}