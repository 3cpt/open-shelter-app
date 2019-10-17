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

        [Indexed]
        public int TaskTypeId { get; set; }

        public string TaskType { get; set; }
    }
}
