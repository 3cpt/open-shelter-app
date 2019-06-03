using System;
using SQLite;

namespace OpenShelter.Models
{
    public class Attendance
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public string TaskType { get; set; }

        public DateTime EnterTime { get; set; }

        public DateTime ExitTime { get; set; }
    }
}
