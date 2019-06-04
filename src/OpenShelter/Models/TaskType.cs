using System;
using SQLite;

namespace OpenShelter.Models
{
    public class TaskType
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
