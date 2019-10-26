using System;
using SQLite;

namespace OpenShelter.Models
{
    public class Attendance
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime EnterTime { get; set; }

        public DateTime ExitTime { get; set; }

        [Indexed]
        public int VolunterId { get; set; }

        public string Name { get; set; }

        public string TaskType { get; set; }

        public string Banner
        {

            get
            {
                return string.Format("{0} / {1}", Name, TaskType);
            }
        }

        public string Description
        {

            get
            {
                return string.Format("{0} - {1}", EnterTime.ToString("HH:mm dd-MM-yyyy"), ExitTime != default ? ExitTime.ToString("HH:mm dd-MM-yyyy") : String.Empty);
            }
        }
    }
}
