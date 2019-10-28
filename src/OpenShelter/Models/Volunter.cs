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

        public bool Visible { get; set; } = true;

        public string Banner
        {

            get
            {
                return string.Format("{0} | {1}", Username, Visible == true ? "Activo" : "INactivo");
            }
        }
    }
}