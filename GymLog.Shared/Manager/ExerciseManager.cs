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
        private static List<Exercise> _exercises;

        public static List<Exercise> Exercises
        {
            get
            {
                if (_exercises == null)
                {
                    _exercises = (from e in DataManager.DB.Table<Exercise>()
                                  select e).ToList();
                }

                return _exercises;

            }
        }

        public static Exercise GetRandomExercise()
        {
            return Exercises[_rand.Next(Exercises.Count)];
        }

        public static Exercise GetExerciseById(int id)
        {
            var result = (from e in DataManager.DB.Table<Exercise>()
                          where e.Id == id
                          select e).SingleOrDefault();

            return result;
        }

        public static Enums.ExerciseMetricsEnum GetMetricByName(string name)
        {
            var result = (Enums.ExerciseMetricsEnum)System.Enum.Parse(typeof(Enums.ExerciseMetricsEnum), name);
            return result;
            
        }


        
    }
}
