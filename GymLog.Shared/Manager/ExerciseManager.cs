using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymLog.Shared.Models;

namespace GymLog.Shared.Manager
{
    public class ExerciseManager
    {

        private static Random _rand = new Random();
        public static List<Exercise> Exercises
        {
            get
            {
                return new List<Exercise>
                {
                    new Exercise { Name="Machine Chest Press", Metric = Enums.ExerciseMetricsEnum.WeightAndReps  },
                    new Exercise { Name="Rowwing Machine",  Metric = Enums.ExerciseMetricsEnum.TimeAndDistance   },
                    new Exercise { Name="Barbell Squat",  Metric = Enums.ExerciseMetricsEnum.WeightAndReps   }
                };
            }
        }

        public static Exercise GetRandomExercise()
        {
            return Exercises[_rand.Next(Exercises.Count)];
        }
    }
}
