using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public Enums.ExerciseMetricsEnum Metric { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public string KeyStat { get { return "1 Rep Max: 70Kg"; } }

    }
}
