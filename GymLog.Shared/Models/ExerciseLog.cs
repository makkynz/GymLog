using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog.Shared.Models
{
    public class ExerciseLog
    {
        public Exercise Exercise { get; set; }
        public DateTime DateCreated { get; set; }
        public int SetCount { get; set; }

    }
}
